using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static AutoBattle.Types;

namespace AutoBattle
{
    public static class ClassData
    {
        public struct ClassStats
        {
            public int health;
            public int baseDamage;

            public ClassStats(int _health, int _baseDamage)
            {
                health = _health;
                baseDamage = _baseDamage;
            }
        }

        private static ClassStats paladin = new ClassStats(120, 50);
        private static ClassStats warrior = new ClassStats(110, 60);
        private static ClassStats cleric = new ClassStats(100, 70);
        private static ClassStats archer = new ClassStats(90, 80);

        public static ClassStats GetClassStats(CharacterClass characterClass)
        {
            switch(characterClass)
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
