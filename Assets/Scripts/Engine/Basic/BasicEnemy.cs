namespace Zombieshot.Engine {

    public class BasicEnemy : IEnemy
    {
        public BasicEnemy(int level = 1, int speed = 1, int health = 1 , int range = 1)
        {
            Level = level;
            Speed = speed;
            Health = health;
            Range = range;
        }

        public int Level
        {
            get;
            private set;
        }

        public int Speed
        {
            get;
            private set;
        }

        public int Health
        {
            get;
            private set;
        }

        public int Range
        {
            get;
            private set;
        }

        public void Damage(int amount)
        {
            this.Health -= amount;
        }

        public void Die()
        {
            // TODO
        }
    }
}
