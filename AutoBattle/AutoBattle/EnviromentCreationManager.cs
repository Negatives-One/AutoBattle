﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public class EnviromentCreationManager
    {
        public EnviromentCreationManager()
        {

        }

        public Vector2 GetGridSizeChoice()
        {
            int choiceX = 0;
            while (choiceX < 5 || choiceX > 10)
            {
                //asks for the player to choose between for possible lengths via console.
                Console.WriteLine("Choose grid width (5 - 10):\n");
                //store the player choice in a variable

                choiceX = int.Parse(Console.ReadLine());
                if (choiceX < 5 || choiceX > 10)
                {
                    Console.WriteLine("Choose a valid size.\n");
                }
            }
            int choiceY = 0;
            while (choiceY < 5 || choiceY > 10)
            {
                //asks for the player to choose between for possible lengths via console.
                Console.WriteLine("Choose grid height (5 - 10):\n");
                //store the player choice in a variable

                choiceY = int.Parse(Console.ReadLine());
                if (choiceY < 5 || choiceY > 10)
                {
                    Console.WriteLine("Choose a valid size.\n");
                }
            }
            return new Vector2(choiceX, choiceY);
        }
    }
}
