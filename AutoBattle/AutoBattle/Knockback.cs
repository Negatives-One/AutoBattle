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
    public class Knockback : Skill
    {
        public Knockback(string _name)
        {
            Name = _name;
            ActivationChance = 0.4f;
        }
        public override void DoEffect(Character character)
        {
            Vector2 walkDir = character.CurrentTile.position - Owner.CurrentTile.position;
            Vector2 walkDirModified = IgnoreSmallerAxis(walkDir);
            character.WalkTo(walkDirModified);
            Console.WriteLine($"{Owner.Name}({Owner.ClassName}) used {Name} on {character.Name}({character.ClassName}), causing knockback!\n");
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
