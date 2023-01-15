using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AutoBattle
{
    public class Types
    {
        /// <summary>
        /// A struct that represents a game grid tile
        /// </summary>
        public struct GridTile
        {
            public Vector2 position;
            public Character occupiedBy;
            public int index;

            public GridTile(Vector2 pos, Character ocupied, int index)
            {
                position = pos;
                this.occupiedBy = ocupied;
                this.index = index;
            }
            /// <summary>
            /// Check if a GridTile is occupied
            /// </summary>
            /// <returns></returns>
            public bool IsOccupied()
            {
                return occupiedBy != null;
            }

        }
        /// <summary>
        /// Character classes enumerator
        /// </summary>
        public enum CharacterClass : uint
        {
            Paladin = 1,
            Warrior = 2,
            Cleric = 3,
            Archer = 4
        }

    }
}
