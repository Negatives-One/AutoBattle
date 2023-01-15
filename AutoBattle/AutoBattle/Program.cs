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
                    GameManager.AllCharacters = GameManager.AllCharacters.OrderByDescending(o => o.Speed).ToList();
                }

                foreach (Character character in GameManager.AllCharacters)
                {
                    character.StartTurn();
                }

                GameManager.CurrentTurn++;
                HandleTurn();
            }

            void HandleTurn()
            {
                if (GameManager.AllPlayerIsDead())
                {
                    EndGame("Enemies");
                    return;
                }
                else if (GameManager.AllEnemyIsDead())
                {
                    EndGame("Players");
                    return;
                }
                else
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);
                    Console.WriteLine("Click on any key to start the next turn...\n");
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    ConsoleKeyInfo key = Console.ReadKey();
                    StartTurn();
                }
            }

            void EndGame(string winner)
            {
                Console.Write(Environment.NewLine + Environment.NewLine);
                Console.WriteLine(winner + " won the game!\n");
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
