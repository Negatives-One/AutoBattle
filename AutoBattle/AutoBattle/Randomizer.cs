using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public static class Randomizer
    {
        public static int GetRandomInt(int min, int max)
        {
            var rand = new Random();
            int index = rand.Next(min, max);
            return index;
        }
        public static float GetPercentage()
        {
            var rand = new Random();
            float value = (float)rand.NextDouble();
            return value;
        }
    }
}
