using System;
using System.Collections.Generic;
using System.Linq;
using static AutoBattle.Types;

namespace AutoBattle
{
    public class CharacterCreationManager
    {
        public CharacterCreationManager()
        {

        }
        /// <summary>
        /// Get player's character quantity choice
        /// </summary>
        public void TeamsSizeChoice()
        {
            //int choicePlayer = 0;
            //while (choicePlayer < 1 || choicePlayer > 3)
            //{
            //    //asks for the player to choose between for possible lengths via console.
            //    Console.WriteLine("Choose player quantity (1 - 3):\n");
            //    //store the player choice in a variable

            //    choicePlayer = int.Parse(Console.ReadLine());
            //    if (choicePlayer < 1 || choicePlayer > 3)
            //    {
            //        Console.WriteLine("Choose a valid quantity.\n");
            //    }
            //}
            //int choiceEnemy = 0;
            //while (choiceEnemy < 1 || choiceEnemy > 3)
            //{
            //    //asks for the player to choose between for possible lengths via console.
            //    Console.WriteLine("Choose enemy quantity (1 - 3):\n");
            //    //store the player choice in a variable

            //    choiceEnemy = int.Parse(Console.ReadLine());
            //    if (choiceEnemy < 1 || choiceEnemy > 3)
            //    {
            //        Console.WriteLine("Choose a valid quantity.\n");
            //    }
            //}
            GameManager.PlayerTeamSize = 1;//choicePlayer;
            GameManager.EnemyTeamSize = 1;//choiceEnemy;
        }

        /// <summary>
        /// Return a Player Choice about classes
        /// </summary>
        /// <returns></returns>
        public CharacterClass GetPlayerClassChoice()
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

        /// <summary>
        /// Creates a player character
        /// </summary>
        /// <param name="characterClass">class to be created</param>
        public void CreatePlayerCharacter(CharacterClass characterClass)
        {
            Character playerCharacter = new Character(characterClass, GameManager.AllPlayers.Count, GameManager.AllCharacters.Count, false);

            GameManager.AllPlayers.Add(playerCharacter);
            GameManager.AllCharacters.Add(playerCharacter);

            Console.WriteLine($"Player Class Choice: {characterClass}, {playerCharacter.Name} reporting for battle");
        }
        /// <summary>
        /// Creates a enemy with random class
        /// </summary>
        public void CreateEnemyCharacter()
        {
            //randomly choose the enemy class and set up vital variables
            var rand = new Random();
            CharacterClass enemyClass = (CharacterClass)rand.Next(1, 4);

            Character enemyCharacter = new Character(enemyClass, GameManager.AllEnemies.Count, GameManager.AllCharacters.Count, true);

            GameManager.AllEnemies.Add(enemyCharacter);
            GameManager.AllCharacters.Add(enemyCharacter);

            Console.WriteLine($"Enemy Class Choice: {enemyClass}, {enemyCharacter.Name} reporting for battle");
        }
        /// <summary>
        /// Place characters on grid
        /// </summary>
        public void AlocateCharacters()
        {
            foreach (Character character in GameManager.AllCharacters)
            {
                AlocateSingleCharacter(character);
            }
        }
        /// <summary>
        /// Place a character on the battlefield
        /// </summary>
        /// <param name="character"></param>
        public void AlocateSingleCharacter(Character character)
        {
            List<GridTile> freeTiles = GameManager.Grid.GetFreeTiles();

            int randomIndex = Randomizer.GetRandomInt(0, freeTiles.Count - 1);
            GridTile randomLocation = freeTiles.ElementAt(randomIndex);

            randomLocation.occupiedBy = character;
            character.CurrentTile = randomLocation;

            GameManager.Grid.UpdateTile(randomLocation);

            GameManager.Grid.DrawBattlefield();

            character.Deployed();
        }
    }
}
