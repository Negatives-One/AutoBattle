using System;
namespace AutoBattle
{
    public static class Randomizer
    {
        /// <summary>
        /// Generate a random integer
        /// </summary>
        /// <param name="min">Minimum range</param>
        /// <param name="max">maximum range</param>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            var rand = new Random();
            int index = rand.Next(min, max);
            return index;
        }
        /// <summary>
        /// Generates a random between 0f and 1f
        /// </summary>
        /// <returns></returns>
        public static float GetPercentage()
        {
            var rand = new Random();
            float value = (float)rand.NextDouble();
            return value;
        }
    }
}
