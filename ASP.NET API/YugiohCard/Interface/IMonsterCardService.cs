using YugiohCard.Models;
namespace YugiohCard.Interface
{
    public interface IMonsterCardService
    {
        ICollection<MonsterCard> GetMonsterCards();
        MonsterCard GetMonsterCardById(string id);
        bool MonsterCardExists(string id);
        bool CreatedMonsterCard(MonsterCard card);
        bool UpdateMonsterCard(string id, MonsterCard card);
        bool DeleteMonsterCard(string id);
        bool BulkInsertMonsterCard(List<MonsterCard> monsterCards);
        bool BulkUpdateMonsterCard(List<MonsterCard> updateCards);
        bool Save();
    }
}
