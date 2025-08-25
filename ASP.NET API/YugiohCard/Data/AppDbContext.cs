using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using YugiohCard.Models;

namespace YugiohCard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<MonsterCard> MonsterCards { get; set; }
        public DbSet<SpellCard> SpellCards { get; set; }
        public DbSet<TrapCard> TrapCards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonsterCard>().HasData(
                new MonsterCard
                {
                    Id = "RA04-EN001",
                    Name = "Dark Magician",
                    Race = MonsterRace.Spellcaster,
                    Type = MonsterType.Normal,
                    Level = 7,
                    ATK = 2500,
                    DEF = 2100,
                    Effect = "The ultimate wizard in terms of attack and defense.",
                    ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4041"
                },

            new MonsterCard
            {
                Id = "BLC1-EN039",
                Name = "Number 39: Utopia",
                Race = MonsterRace.Warrior,
                Type = MonsterType.XYZ,
                Rank = 4,
                ATK = 2500,
                DEF = 2000,
                Effect = $"2 Level 4 monsters \n When a monster declares an attack: You can detach 1 material from this card; negate the attack. If this card is targeted for an attack, while it has no material: Destroy this card.",
                ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=9575"
            },

            new MonsterCard
            {
                Id = "DUDE-EN022",
                Name = "Gaia Saber, the Lightning Shadow",
                Race = MonsterRace.Machine,
                Type = MonsterType.Link,
                Link = 3,
                ATK = 2600,
                Effect = "2+ monsters",
                ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=13090"
            });

            modelBuilder.Entity<SpellCard>().HasData(
                new SpellCard
                {
                    Id = "LOB-EN119",
                    Name = "Pot of Greed",
                    Type = SpellType.Normal,
                    Effect = "Draw 2 cards.",
                    ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4844"
                },

            new SpellCard
            {
                Id = "MGED-EN047",
                Name = "Mystic Mine",
                Type = SpellType.Field,
                Effect = "If your opponent controls more monsters than you do, your opponent cannot activate monster effects or declare an attack. " +
                "If you control more monsters than your opponent does, you cannot activate monster effects or declare an attack. " +
                "Once per turn, during the End Phase, if both players control the same number of monsters: Destroy this card.",
                ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=14314"
            });

            modelBuilder.Entity<TrapCard>().HasData(
                new TrapCard
                {
                    Id = "RA03-EN093",
                    Name = "Mirror Force",
                    Type = TrapType.Normal,
                    Effect = "When an opponent's monster declares an attack: Destroy all your opponent's Attack Position monsters.",
                    ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4887"
                },

            new TrapCard
            {
                Id = "RA02-EN075",
                Name = "Solemn Judgment",
                Type = TrapType.Counter,
                Effect = "When a monster(s) would be Summoned, OR a Spell/Trap Card is activated: Pay half your LP; negate the Summon or activation, and if you do, destroy that card.",
                ImageUrl = "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4861"
            });
        }
    }
}
