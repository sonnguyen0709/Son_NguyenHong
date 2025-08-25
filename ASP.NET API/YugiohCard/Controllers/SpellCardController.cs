using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YugiohCard.Models;
using YugiohCard.Data;
using Microsoft.AspNetCore.Authorization;

namespace YugiohCard.Controllers
{
    [Authorize]
    [ApiController]
    [Route("yugioh/[controller]")]
    public class SpellCardsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SpellCardsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<SpellCard>> GetAll()
        {
            return Ok(_context.SpellCards);
        }

        [HttpGet("{id}")]
        public ActionResult<SpellCard> GetById(string id)
        {
            var card = _context.SpellCards.SingleOrDefault(c => c.Id == id);
            return card == null ? NotFound() : Ok(card);
        }

        [HttpPost]
        public ActionResult<SpellCard> Create(SpellCard card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.SpellCards.Add(card);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, SpellCard updated)
        {
            var existing = _context.SpellCards.SingleOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            existing.Name = updated.Name;
            existing.Type = updated.Type;
            existing.Effect = updated.Effect;
            existing.ImageUrl = updated.ImageUrl;

            _context.SaveChanges(); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var card = _context.SpellCards.SingleOrDefault(c => c.Id == id);
            if (card == null) return NotFound();

            _context.SpellCards.Remove(card);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
