namespace AutoBattle
{
    public abstract class Skill
    {
        public string Name { get; set; }
        public float ActivationChance { get; set; }
        public Character Owner { get; set; }

        /// <summary>
        /// Call the skill effect
        /// </summary>
        /// <param name="character">Sometimes needed to trigger the effect</param>
        public virtual void DoEffect(Character character)
        {

        }
    }
}
