﻿using System;
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
        public string ClassName { get; set; }
        public float Health { get; set; }
        public int BaseDamage { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public string Sprite { get; set; }
        public float DamageMultiplier { get; set; }
        public GridTile CurrentTile { get; set; }
        public int ContextIndex { get; set; }
        public int CharacterIndex { get; set; }
        public bool IsEnemy { get; set; }
        public bool IsDead { get; set; }
        public List<Character> Target { get; set; }

        public Skill ClassSkill { get; set; }

        public Character(CharacterClass _characterClass, int _contextIndex, int _characterIndex, bool _isEnemy)
        {
            Name = NameGenerator.GetRandomName();
            //populates the character variables and targets
            ClassStats stats = ClassData.GetClassData(_characterClass);
            Health = stats.health;
            BaseDamage = stats.baseDamage;
            Speed = stats.speed;
            Range = stats.range;
            Sprite = stats.sprite;
            ContextIndex = _contextIndex;
            CharacterIndex = _characterIndex;
            IsEnemy = _isEnemy;
            ClassName = _characterClass.ToString();
            DamageMultiplier = 1f;
            ClassSkill = stats.skill;
            ClassSkill.Owner = this;
        }

        public void Deployed()
        {
            if (IsEnemy) Target = GameManager.AllPlayers;
            else Target = GameManager.AllEnemies;
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Die();
                Health = 0;
            }
        }

        public void Die()
        {
            IsDead = true;

            GridTile updatedTile = CurrentTile;
            updatedTile.ocupiedBy = null;
            GameManager.Grid.UpdateTile(updatedTile);

            if (IsEnemy) GameManager.AllEnemies.Remove(this);
            else GameManager.AllPlayers.Remove(this);
            GameManager.AllPlayers.Remove(this);

            GameManager.Grid.DrawBattlefield();
            Console.WriteLine($"\nCharacter {Name}({ClassName}) is Dead.\n\n");
        }

        public void WalkTo(Vector2 dir)
        {
            try
            {
                GridTile t = GameManager.Grid.GridTiles[(int)CurrentTile.position.X + (int)dir.X][(int)CurrentTile.position.Y + (int)dir.Y];
            }
            catch(Exception) {
                return;
            }
            if (dir == Vector2.Zero)
            {
                Console.WriteLine($"\nCharacter {Name}({ClassName}) waited.\n\n");
            }

            Vector2 currentPos = CurrentTile.position;

            GridTile oldTile = GameManager.Grid.GridTiles[(int)currentPos.X][(int)currentPos.Y];
            oldTile.ocupiedBy = null;
            GameManager.Grid.UpdateTile(oldTile);

            Vector2 newPos = CurrentTile.position + dir;

            GridTile newTile = GameManager.Grid.GridTiles[(int)newPos.X][(int)newPos.Y];
            newTile.ocupiedBy = this;
            GameManager.Grid.UpdateTile(newTile);

            CurrentTile = GameManager.Grid.GridTiles[(int)newPos.X][(int)newPos.Y];

            GameManager.Grid.DrawBattlefield();
        }
        
        public void StartTurn()
        {
            if (!IsDead)
            {
                List<Character> possibleTargets = CheckInRangeTargets(GameManager.Grid);
                if (possibleTargets.Count > 0)
                {
                    Attack(possibleTargets);
                    return;
                }
                else
                {   // if there is no target close enough, calculates in wich direction this character should move to be closer to a possible target
                    Character closestTarget = GameManager.Grid.ClosestCharacter(CurrentTile);
                    Vector2 walkDir = closestTarget.CurrentTile.position - CurrentTile.position;
                    Vector2 walkDirModified = IgnoreSmallerAxis(walkDir);

                    if (MoveOcupied(walkDirModified))
                    {
                        walkDirModified = Vector2.Zero;
                    }

                    WalkTo(walkDirModified);
                }
            }

        }

        // Check in x and y directions if there is any character close enough to be a target.
        private List<Character> CheckInRangeTargets(Grid battlefield)
        {
            List<Character> possibleTargets = new List<Character>();

            Vector2 checkingFrom = CurrentTile.position;

            for (int i = 1; i <= Range; i++)
            {
                // element left
                if ((int)checkingFrom.X - i >= 0)
                {
                    GridTile elementLeft = GameManager.Grid.GridTiles[(int)checkingFrom.X - i][(int)checkingFrom.Y];
                    if (elementLeft.ocupiedBy != null)
                    {
                        if (ShouldKill(elementLeft.ocupiedBy)) possibleTargets.Add(elementLeft.ocupiedBy);
                    }
                }

                // element right
                if ((int)checkingFrom.X + i < GameManager.Grid.GridSize.Y)
                {
                    GridTile elementRight = GameManager.Grid.GridTiles[(int)checkingFrom.X + i][(int)checkingFrom.Y];
                    if (elementRight.ocupiedBy != null)
                    {
                        if (ShouldKill(elementRight.ocupiedBy)) possibleTargets.Add(elementRight.ocupiedBy);
                    }
                }

                // element above
                if ((int)checkingFrom.Y - i >= 0)
                {
                    GridTile elementAbove = GameManager.Grid.GridTiles[(int)checkingFrom.X][(int)checkingFrom.Y - i];
                    if (elementAbove.ocupiedBy != null)
                    {
                        if (ShouldKill(elementAbove.ocupiedBy)) possibleTargets.Add(elementAbove.ocupiedBy);
                    }
                }

                // element below
                if ((int)checkingFrom.Y + i < GameManager.Grid.GridSize.X)
                {
                    GridTile elementBelow = GameManager.Grid.GridTiles[(int)checkingFrom.X][(int)checkingFrom.Y + i];
                    if (elementBelow.ocupiedBy != null)
                    {
                        if (ShouldKill(elementBelow.ocupiedBy)) possibleTargets.Add(elementBelow.ocupiedBy);
                    }
                }
            }

            return possibleTargets;
        }

        public void Attack(List<Character> targets)
        {
            Character selectedTarget = targets[Randomizer.GetRandomInt(0, targets.Count)];

            float roll = Randomizer.GetPercentage();
            if (roll > ClassSkill.ActivationChance)
            {
                ClassSkill.DoEffect(selectedTarget);
            }

            int damageDealt = Randomizer.GetRandomInt(10, BaseDamage);

            damageDealt = (int)Math.Round(DamageMultiplier * (float)damageDealt);

            selectedTarget.TakeDamage(damageDealt);

            DamageMultiplier = 1f;

            Console.WriteLine($"Player {Name}({ClassName}) is attacking the player {selectedTarget.Name}({selectedTarget.ClassName}) and did {damageDealt} damage\n");
            Console.WriteLine($"{selectedTarget.Name}({selectedTarget.ClassName}) has {selectedTarget.Health} health left\n\n");
        }

        private bool ShouldKill(Character character)
        {
            if (IsEnemy != character.IsEnemy) return true;
            else return false;
        }

        private bool MoveOcupied(Vector2 dir)
        {
            return GameManager.Grid.GridTiles[(int)CurrentTile.position.X + (int)dir.X][(int)CurrentTile.position.Y + (int)dir.Y].IsOcupied();
        }

        private Vector2 IgnoreSmallerAxis(Vector2 originalVector)
        {
            if (MathF.Abs(originalVector.X) > MathF.Abs(originalVector.Y))
            {
                return new Vector2(MathF.Sign(originalVector.X), 0);
            }
            else
            {
                return new Vector2(0, MathF.Sign(originalVector.Y));
            }
        }
    }
}
