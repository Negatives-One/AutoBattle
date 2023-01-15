using static AutoBattle.Types;

namespace AutoBattle
{
    public static class ClassData
    {
        /// <summary>
        /// A Struct that carries a class stats data
        /// </summary>
        public struct ClassStats
        {
            public string className;
            public int health;
            public int baseDamage;
            public int speed;
            public int range;
            public string sprite;
            public Skill skill;

            public ClassStats(string _className, int _health, int _baseDamage, int _speed, int _range, string _sprite, Skill _skill)
            {
                className = _className;
                health = _health;
                baseDamage = _baseDamage;
                speed = _speed;
                range = _range;
                sprite = _sprite;
                skill = _skill;
            }
        }

        private static ClassStats paladin = new ClassStats("Paladin", 190, 45, 80, 1, "P", new ShieldStrike("Shield Strike"));
        private static ClassStats warrior = new ClassStats("Warrior", 110, 60, 110, 1, "W", new DoubleDamage("Double Damage"));
        private static ClassStats cleric = new ClassStats("Cleric", 100, 70, 90, 2, "C", new Heal("Heal"));
        private static ClassStats archer = new ClassStats("Archer", 90, 80, 100, 3, "A", new Knockback("Knockback"));

        /// <summary>
        /// Returns a class "prefab"
        /// </summary>
        /// <param name="characterClass"></param>
        /// <returns></returns>
        public static ClassStats GetClassData(CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Paladin:
                    return paladin;
                case CharacterClass.Warrior:
                    return warrior;
                case CharacterClass.Cleric:
                    return cleric;
                case CharacterClass.Archer:
                    return archer;
                default:
                    return paladin;
            }
        }

    }
}
