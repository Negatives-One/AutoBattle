using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public class ShieldStrike : Skill
    {
        private int Damage = 40;
        public ShieldStrike(string _name)
        {
            Name = _name;
            ActivationChance = 0.3f;
        }
        public override void DoEffect(Character character)
        {
            character.TakeDamage(Damage);
            Console.WriteLine($"{Owner.Name}({Owner.ClassName}) used {Name} on {character.Name}({character.ClassName}), dealing extra {Damage} damage!\n");
        }
    }
}
