using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static AutoBattle.Types;
using System.Numerics;
using static AutoBattle.ClassData;

namespace AutoBattle
{
    public abstract class Skill
    {
        public string Name { get; set; }
        public float ActivationChance { get; set; }

        public Character Owner { get; set; }

        public virtual void DoEffect(Character character)
        {

        }
    }
}
