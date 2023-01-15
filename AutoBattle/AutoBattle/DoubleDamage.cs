using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public class DoubleDamage : Skill
    {
        public DoubleDamage(string _name)
        {
            Name = _name;
            ActivationChance = 0.5f;
        }
        public override void DoEffect(Character character)
        {
            Owner.DamageMultiplier = 2f;
            Console.WriteLine($"Warrior enrages, next attack will deal double damage!\n");
        }
    }
}
