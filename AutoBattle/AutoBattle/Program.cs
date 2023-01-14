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
            Grid grid = new Grid(new Vector2(5, 5));
            CharacterClass playerCharacterClass;
            GridTile playerCurrentLocation;
            GridTile enemyCurrentLocation;
            Character playerCharacter;
            Character enemyCharacter;
            List<Character> allPlayers = new List<Character>();
            List<Character> allEnemies = new List<Character>();
            List<Character> allCharacters = new List<Character>();
            int currentTurn = 0;
            int numberOfPossibleTiles = grid.GridTiles.Count;
            Setup();

            //Prepare the game
            void Setup()
            {
                CharacterClass playerClass = GetPlayerClassChoice();
                CreatePlayerCharacter(playerClass);
                CreateEnemyCharacter();
                StartGame();
            }


            CharacterClass GetPlayerClassChoice()
            {
                //asks for the player to choose between for possible classes via console.
                Console.WriteLine("Choose Between One of this Classes:\n");
                Console.WriteLine("[1] Paladin, [2] Warrior, [3] Cleric, [4] Archer");
                //store the player choice in a variable

                int choice;
                CharacterClass selectedCharacterClass = CharacterClass.Paladin;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    selectedCharacterClass = (CharacterClass)choice;
                }
                else
                {
                    GetPlayerClassChoice();
                }
                return selectedCharacterClass;
            }

            void CreatePlayerCharacter(CharacterClass characterClass)
            {
                Console.WriteLine($"Player Class Choice: {characterClass}");
                playerCharacter = new Character(characterClass, allPlayers.Count, allCharacters.Count, false);
                allPlayers.Add(playerCharacter);
                allCharacters.Add(playerCharacter);
            }

            void CreateEnemyCharacter()
            {
                //randomly choose the enemy class and set up vital variables
                var rand = new Random();
                CharacterClass enemyClass = (CharacterClass)rand.Next(1, 4);

                Console.WriteLine($"Enemy Class Choice: {enemyClass}");
                enemyCharacter = new Character(enemyClass, allEnemies.Count, allCharacters.Count, true);
                allEnemies.Add(enemyCharacter);
                allCharacters.Add(enemyCharacter);
            }

            void StartGame()
            {
                //populates the character variables and targets
                playerCharacter.Target = enemyCharacter;
                enemyCharacter.Target = playerCharacter;
                AlocateCharacters();
                StartTurn();
            }

            void StartTurn()
            {

                if (currentTurn == 0)
                {
                    //AllPlayers.Sort();  
                }

                foreach (Character character in allPlayers)
                {
                    character.StartTurn(grid);
                }

                currentTurn++;
                HandleTurn();
            }

            void HandleTurn()
            {
                if (playerCharacter.Health == 0)
                {
                    return;
                }
                else if (enemyCharacter.Health == 0)
                {
                    Console.Write(Environment.NewLine + Environment.NewLine);

                    // endgame?

                    Console.Write(Environment.NewLine + Environment.NewLine);

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

            int GetRandomInt(int min, int max)
            {
                var rand = new Random();
                int index = rand.Next(min, max);
                return index;
            }

            void AlocateCharacters()
            {
                foreach (Character character in allCharacters)
                {
                    AlocatePlayerCharacter(character);
                }
            }

            void AlocatePlayerCharacter(Character character)
            {
                List<GridTile> freeTiles = grid.GetFreeTiles();

                int randomIndex = GetRandomInt(0, freeTiles.Count - 1);
                GridTile randomLocation = freeTiles.ElementAt(randomIndex);
                Console.Write($"{randomLocation.index}\n");

                randomLocation.ocupied = true;
                character.CurrentTile = randomLocation;

                grid.UpdateTile(randomLocation);

                grid.DrawBattlefield(new Vector2(5, 5));
            }

            //void AlocateEnemyCharacter()
            //{
            //    List<GridTile> freeTiles = grid.GetFreeTiles();

            //    int random = GetRandomInt(0, freeTiles.Count - 1);
            //    GridTile randomLocation = (grid.GridTiles.ElementAt(random));
            //    Console.Write($"{random}\n");
            //    if (!randomLocation.ocupied)
            //    {
            //        enemyCurrentLocation = randomLocation;
            //        randomLocation.ocupied = true;
            //        grid.GridTiles[random] = randomLocation;
            //        enemyCharacter.CurrentTile = grid.GridTiles[random];
            //        grid.DrawBattlefield(new Vector2(5, 5));
            //    }
            //    else
            //    {
            //        AlocateEnemyCharacter();
            //    }
            //}
        }
    }
}
