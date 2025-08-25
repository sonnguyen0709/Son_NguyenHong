using System.Text.Json.Serialization;
namespace YugiohCard.Models
{
    public enum SpellType
    {
        Normal,
        QuickPlay,
        Continuous,
        Ritual,
        Field,
        Equip
    }

    public enum TrapType
    {
        Normal,
        Continuous,
        Counter
    }
    public enum MonsterRace
    {
        Dragon,
        Warrior,
        Spellcaster,
        Beast,
        Fiend,
        Fairy,
        Zombie,
        Machine,
        Aqua,
        Pyro,
        Thunder,
        Rock,
        Plant,
        Insect,
        Dinosaur,
        Reptile,
        Fish,
        SeaSerpent,
        Wyrm,
        Psychic,
        Cyberse,
        DivineBeast
    }
    public enum MonsterType
    {
        Normal,
        Effect,
        Ritual,
        Fusion,
        Synchro,
        XYZ,
        Link,
        Pendulum,
        Gemini,
        Tuner
    }
}

