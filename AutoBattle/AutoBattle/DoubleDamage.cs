using System;

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
