using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;
using static System.Net.Mime.MediaTypeNames;

namespace AutoBattle
{
    public class Heal : Skill
    {
        private int healAmmount = 40;
        public Heal(string _name)
        {
            Name = _name;
            ActivationChance = 0.2f;
        }
        public override void DoEffect(Character character)
        {
            Owner.Health += healAmmount;
            Console.WriteLine($"{Owner.Name}({Owner.ClassName}) used {Name} on yourself, healing {healAmmount}, {Owner.Name}({Owner.ClassName}) has {Owner.Health} Health now!\n");
        }
    }
}
