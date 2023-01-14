using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public class Character
    {
        public string Name { get; set; }
        public float Health;
        public float BaseDamage;
        public float DamageMultiplier { get; set; }
        public GridTile CurrentTile;
        public int ContextIndex;
        public int CharacterIndex;
        public bool IsEnemy;
        public Character Target { get; set; }

        public Character(CharacterClass _characterClass, int _contextIndex, int _characterIndex, bool _isEnemy)
        {
            //populates the character variables and targets
            ClassStats stats = ClassData.GetClassStats(_characterClass);
            Health = stats.health;
            BaseDamage = stats.baseDamage;
            ContextIndex = _contextIndex;
            CharacterIndex = _characterIndex;
            IsEnemy = _isEnemy;
        }

        public void Deployed()
        {
            if (IsEnemy) Target = GameManager.GetRandomPlayer();
            else Target = GameManager.GetRandomEnemy();
        }

        public bool TakeDamage(float amount)
        {
            if ((Health -= BaseDamage) <= 0)
            {
                Die();
                return true;
            }
            return false;
        }

        public void Die()
        {
            //TODO >> maybe kill him?
        }

        public void WalkTo(bool canWalk)
        {

        }

        public void StartTurn(Grid battlefield)
        {

            if (CheckCloseTargets(battlefield)) 
            {
                Attack(Target);
                

                return;
            }
            else
            {   // if there is no target close enough, calculates in wich direction this character should move to be closer to a possible target
                if(this.CurrentTile.position.X > Target.CurrentTile.position.X)
                {
                    if ((battlefield.GridTiles.Exists(x => x.index == CurrentTile.index - 1)))
                    {
                        CurrentTile.ocupied = false;
                        battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                        CurrentTile = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index - 1));
                        CurrentTile.ocupied = true;
                        battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                        Console.WriteLine($"Player {ContextIndex} walked left\n");
                        battlefield.DrawBattlefield(new Vector2(5, 5));

                        return;
                    }
                } else if(CurrentTile.position.X < Target.CurrentTile.position.X)
                {
                    CurrentTile.ocupied = false;
                    battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                    CurrentTile = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index + 1));
                    CurrentTile.ocupied = true;
                    battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                    Console.WriteLine($"Player {ContextIndex} walked right\n");
                    battlefield.DrawBattlefield(new Vector2(5, 5));
                    return;
                }

                if (this.CurrentTile.position.Y > Target.CurrentTile.position.Y)
                {
                    battlefield.DrawBattlefield(new Vector2(5, 5));
                    this.CurrentTile.ocupied = false;
                    battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                    this.CurrentTile = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index - battlefield.GridSize.X));
                    this.CurrentTile.ocupied = true;
                    battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                    Console.WriteLine($"Player {ContextIndex} walked up\n");
                    return;
                }
                else if(this.CurrentTile.position.Y < Target.CurrentTile.position.Y)
                {
                    this.CurrentTile.ocupied = true;
                    battlefield.GridTiles[CurrentTile.index] = this.CurrentTile;
                    this.CurrentTile = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index + battlefield.GridSize.X));
                    this.CurrentTile.ocupied = false;
                    battlefield.GridTiles[CurrentTile.index] = CurrentTile;
                    Console.WriteLine($"Player {ContextIndex} walked down\n");
                    battlefield.DrawBattlefield(new Vector2(5, 5));

                    return;
                }
            }
        }

        // Check in x and y directions if there is any character close enough to be a target.
        bool CheckCloseTargets(Grid battlefield)
        {
            bool left = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index - 1).ocupied);
            bool right = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index + 1).ocupied);
            bool up = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index + battlefield.GridSize.X).ocupied);
            bool down = (battlefield.GridTiles.Find(x => x.index == CurrentTile.index - battlefield.GridSize.X).ocupied);

            if (left & right & up & down) 
            {
                return true;
            }
            return false; 
        }

        public void Attack (Character target)
        {
            Random rand = new Random();
            target.TakeDamage(rand.Next(0, (int)BaseDamage));
            Console.WriteLine($"Player {ContextIndex} is attacking the player {Target.ContextIndex} and did {BaseDamage} damage\n");
        }
    }
}
