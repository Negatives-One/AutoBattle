using System;
using static AutoBattle.Character;
using static AutoBattle.Grid;
using System.Collections.Generic;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace AutoBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            CharacterCreationManager characterCreation = new CharacterCreationManager();
            EnviromentCreationManager enviromentCreation = new EnviromentCreationManager();
            Setup();

            //Prepare the game
            void Setup()
            {
                GameManager.Grid = new Grid(enviromentCreation.GetGridSizeChoice());
                characterCreation.TeamsSizeChoice();
                for (int i = 0; i < GameManager.PlayerTeamSize; i++)
                {
                    CharacterClass playerClass = characterCreation.GetPlayerClassChoice();
                    characterCreation.CreatePlayerCharacter(playerClass);
                }
                for (int j = 0; j < GameManager.EnemyTeamSize; j++)
                {
                    characterCreation.CreateEnemyCharacter();
                }
                StartGame();
            }

            void StartGame()
            {
                characterCreation.AlocateCharacters();
                StartTurn();
            }

            void StartTurn()
            {

                if (GameManager.CurrentTurn == 0)
                {
                    //AllPlayers.Sort();  
                }

                foreach (Character character in GameManager.AllPlayers)
                {
                    character.StartTurn(GameManager.Grid);
                }

                GameManager.CurrentTurn++;
                HandleTurn();
            }

            void HandleTurn()
            {
                //if (GameManager.PlayerCharacter.Health == 0)
                //{
                //    return;
                //}
                //else if (GameManager.EnemyCharacter.Health == 0)
                //{
                //    Console.Write(Environment.NewLine + Environment.NewLine);

                //    // endgame?

                //    Console.Write(Environment.NewLine + Environment.NewLine);

                //    return;
                //}
                //else
                //{
                //    Console.Write(Environment.NewLine + Environment.NewLine);
                //    Console.WriteLine("Click on any key to start the next turn...\n");
                //    Console.Write(Environment.NewLine + Environment.NewLine);

                //    ConsoleKeyInfo key = Console.ReadKey();
                //    StartTurn();
                //}
            }
        }
    }
}
