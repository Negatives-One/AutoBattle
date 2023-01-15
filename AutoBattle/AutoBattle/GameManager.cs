using System.Collections.Generic;

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

        /// <summary>
        /// Checks if all players are dead
        /// </summary>
        /// <returns></returns>
        public static bool AllPlayerIsDead()
        {
            float sum = 0;
            foreach (Character item in AllPlayers)
            {
                sum += item.Health;
            }
            return sum <= 0;
        }
        /// <summary>
        /// Checks if all enemies are dead
        /// </summary>
        /// <returns></returns>
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
