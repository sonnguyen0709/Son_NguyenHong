using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YugiohCard.Models;
using YugiohCard.Data;
using YugiohCard.Service;
using EFCore.BulkExtensions;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using YugiohCard.Interface;

namespace YugiohCard.Controllers
{
    [Authorize]
    [ApiController]
    [Route("yugioh/[controller]")]
    public class MonsterCardsController : ControllerBase
    {
        private readonly IMonsterCardService _monsterCard;
        public MonsterCardsController(IMonsterCardService monsterCard)
        {
            _monsterCard = monsterCard;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<MonsterCard>> GetMonsterCard()
        {
            var monsterCard = _monsterCard.GetMonsterCards();

            return Ok(monsterCard);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<MonsterCard> GetMonsterCardById(string id)
        {
            if (!_monsterCard.MonsterCardExists(id))
                return NotFound();

            var monsterCard = _monsterCard.GetMonsterCardById(id);

            return Ok(monsterCard);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<MonsterCard> Create(MonsterCard monsterCard)
        {
            if (monsterCard == null)
                return BadRequest(ModelState);

            if (_monsterCard.MonsterCardExists(monsterCard.Id))
            {
                ModelState.AddModelError("", "Monster card already exists");
                return StatusCode(422, ModelState);
            }

            bool created = _monsterCard.CreatedMonsterCard(monsterCard);

            if (!created)
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction(nameof(GetMonsterCardById), new { id = monsterCard.Id }, monsterCard);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(string id,[FromBody] MonsterCard updatedCard)
        {
            if (updatedCard == null)
                return BadRequest(ModelState);
            if (updatedCard.Id !=  id)
                return BadRequest("ID in route and body do not match.");
            if (!_monsterCard.MonsterCardExists(id))
                return NotFound();

            bool updated = _monsterCard.UpdateMonsterCard(id, updatedCard);

            if (!updated)
            {
                ModelState.AddModelError("", "Something went wrong while updating the Monster card");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Update");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (!_monsterCard.MonsterCardExists(id))
                return NotFound();

            bool deleted = _monsterCard.DeleteMonsterCard(id);

            if (!deleted)
            {
                ModelState.AddModelError("", "Something went wrong while deleting the Monster card");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Delete");
        }

        [HttpPost("BulkInsertMonsterCards")]
        [Authorize(Roles = "Admin")]
        public ActionResult BulkInsert([FromBody] List<MonsterCard> monsterCards)
        {
            if (monsterCards == null || !monsterCards.Any())
            {
                return BadRequest("No cards provided.");
            }

            var validCards = new List<MonsterCard>();
            var validationErrors = new List<object>();

            foreach (var card in monsterCards)
            {
                var context = new ValidationContext(card);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(card, context, results, true))
                {
                    validCards.Add(card);
                }
                else
                {
                    validationErrors.Add(new
                    {
                        card.Id,
                        Errors = results.Select(r => r.ErrorMessage)
                    });
                }
            }

            if (validCards.Any())
            {
                var bulkInsert = _monsterCard.BulkInsertMonsterCard(validCards);
                if (!bulkInsert)
                {
                    ModelState.AddModelError("", "Something went wrong while inserting the Monster card");
                    return StatusCode(500, ModelState);
                }
            }
            else
            {
                return BadRequest(new
                {
                    message = "No valid cards to insert.",
                    validationErrors
                });
            }

            return Ok(new
            {
                message = "Bulk insert completed",
                inserted = validCards.Count,
                validationErrors
            });
        }
        
        [HttpPut("BulkUpdateMonsterCards")]
        [Authorize(Roles = "Admin")]
        public ActionResult BulkUpdate([FromBody] List<MonsterCard> updateCards)
        {
            if (updateCards == null || !updateCards.Any())
            {
                return BadRequest("No cards provided.");
            }

            int successCount = 0;
            var validationErrors = new List<object>();
            var notFoundIds = new List<string>();
            var validCards = new List<MonsterCard>();

            foreach (var card in updateCards)
            {
                var context = new ValidationContext(card);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(card, context, results, true))
                {
                    validationErrors.Add(new { card.Id, Errors = results });
                    continue;
                }

                var existingCard = _monsterCard.MonsterCardExists(card.Id);
                if (!existingCard)
                {
                    notFoundIds.Add(card.Id);
                    continue;
                }

                validCards.Add(card);
                successCount++;
            }

            if (validCards.Any())
            {
                var bulkUpdate = _monsterCard.BulkUpdateMonsterCard(validCards);
                if (!bulkUpdate)
                {
                    ModelState.AddModelError("", "Something went wrong while updating the Monster card");
                    return StatusCode(500, ModelState);
                }
            }
            else
            {
                return BadRequest(new
                {
                    message = "No valid cards to update.",
                    validationErrors
                });
            }

            return Ok(new
            {
                message = "Bulk update completed",
                updated = successCount,
                notFound = notFoundIds,
                validationErrors
            });
        }
    }
}

