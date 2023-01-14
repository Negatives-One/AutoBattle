﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AutoBattle
{
    public class Types
    {

        public struct CharacterClassSpecific
        {
            CharacterClass characterClass;
            float hpModifier;
            float classDamage;
            CharacterSkills[] skills;
        }

        public struct GridTile
        {
            public Vector2 position;
            public bool ocupied;
            public int index;

            public GridTile(Vector2 pos, bool ocupied, int index)
            {
                position = pos;
                this.ocupied = ocupied;
                this.index = index;
            }

        }

        public struct CharacterSkills
        {
            string name;
            float damage;
            float damageMultiplier;
        }

        public enum CharacterClass : uint
        {
            Paladin = 1,
            Warrior = 2,
            Cleric = 3,
            Archer = 4
        }

    }
}
