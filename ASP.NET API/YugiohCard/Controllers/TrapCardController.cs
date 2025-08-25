using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using YugiohCard.Models;
using Microsoft.AspNetCore.Authorization;
using YugiohCard.Data;

namespace YugiohCard.Controllers
{
    [Authorize]
    [ApiController]
    [Route("yugioh/[controller]")]
    public class TrapCardsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TrapCardsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<TrapCard>> GetAll()
        {
            return Ok(_context);
        }

        [HttpGet("{id}")]
        public ActionResult<TrapCard> GetById(string id)
        {
            var card = _context.TrapCards.SingleOrDefault(x => x.Id == id);
            return card == null ? NotFound() : card;
        }

        [HttpPost]
        public ActionResult<TrapCard> Create(TrapCard trapCard)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _context.TrapCards.Add(trapCard);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = trapCard.Id }, trapCard);
        }

        [HttpPut("{id}")]
        public ActionResult<TrapCard> Update(string id, TrapCard trapCard)
        {
            var existing = _context.TrapCards.SingleOrDefault(x => x.Id == id);
            if (existing == null) return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            existing.Name = trapCard.Name;
            existing.Type = trapCard.Type;
            existing.Effect = trapCard.Effect;
            existing.ImageUrl = trapCard.ImageUrl;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<TrapCard> Delete(string id)
        {
            var card = _context.TrapCards.SingleOrDefault(x => x.Id == id);
            if (card == null) return NotFound();
            _context.TrapCards.Remove(card);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
