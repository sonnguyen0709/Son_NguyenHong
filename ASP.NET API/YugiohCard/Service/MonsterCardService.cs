using YugiohCard.Models;
using YugiohCard.Interface;
using YugiohCard.Data;
using EFCore.BulkExtensions;

namespace YugiohCard.Service
{
    public class MonsterCardService : IMonsterCardService
    {
        private readonly AppDbContext _context;
        public MonsterCardService(AppDbContext context)
        {
            _context = context;
        }
        public ICollection<MonsterCard> GetMonsterCards()
        {
            return _context.MonsterCards.ToList();
        }
        public MonsterCard GetMonsterCardById(string id)
        {
            return _context.MonsterCards.SingleOrDefault(p => p.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool MonsterCardExists(string id)
        {
            var existing = _context.MonsterCards.SingleOrDefault(p => p.Id == id);
            return existing != null;
        }
        public bool CreatedMonsterCard(MonsterCard monsterCard)
        {
            _context.Add(monsterCard);
            return Save();
        }
        public bool BulkInsertMonsterCard(List<MonsterCard> monsterCards)
        {
            _context.BulkInsert(monsterCards);
            return Save();
        }
        public bool BulkUpdateMonsterCard(List<MonsterCard> updateCards)
        {
            _context.BulkUpdate(updateCards);
            return Save();
        }
        public bool UpdateMonsterCard(string id, MonsterCard updateCard)
        {
            var existingCard = _context.MonsterCards.SingleOrDefault(c => c.Id == id);

            existingCard.Name = updateCard.Name;
            existingCard.Type = updateCard.Type;
            existingCard.Race = updateCard.Race;
            existingCard.Level = updateCard.Level;
            existingCard.Rank = updateCard.Rank;
            existingCard.Link = updateCard.Link;
            existingCard.ATK = updateCard.ATK;
            existingCard.DEF = updateCard.DEF;
            existingCard.Effect = updateCard.Effect;
            existingCard.ImageUrl = updateCard.ImageUrl;

            return Save();
        }
        public bool DeleteMonsterCard(string id)
        {
            var existingCard = _context.MonsterCards.SingleOrDefault(c => c.Id == id);
            _context.Remove(existingCard);
            return Save();
        }
    }
}
