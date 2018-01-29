using Src.Interfaces;

namespace Src.Game
{
    public class DamageableTarget : Target, IDamageable
    {

        public DamageableTarget(int range, int health) : base(range)
        {
            this.Health = health;
        }

        public int Health
        {
            get;
            private set;
        }

        public void Damage(int amount)
        {
            this.Health -= amount;
        }

    }
}
