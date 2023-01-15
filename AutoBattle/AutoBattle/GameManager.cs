using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public static class GameManager
    {
        public static Grid Grid;
        public static int PlayerTeamSize = 1;
        public static int EnemyTeamSize = 1;
        public static List<Character> AllPlayers = new List<Character>();
        public static List<Character> AllEnemies = new List<Character>();
        public static List<Character> AllCharacters = new List<Character>();
        public static int CurrentTurn = 0;

        public static Character GetRandomPlayer()
        {
            return AllPlayers[Randomizer.GetRandomInt(0, AllPlayers.Count)];
        }
        public static Character GetRandomEnemy()
        {
            return AllEnemies[Randomizer.GetRandomInt(0, AllEnemies.Count)];
        }

        public static bool AllPlayerIsDead()
        {
            float sum = 0;
            foreach (Character item in AllPlayers)
            {
                sum += item.Health;
            }
            return sum <= 0;
        }
        public static bool AllEnemyIsDead()
        {
            float sum = 0;
            foreach (Character item in AllEnemies)
            {
                sum += item.Health;
            }
            return sum <= 0;
        }
    }
}
