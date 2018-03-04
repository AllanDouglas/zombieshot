namespace Zombieshot.Engine
{
    public class BasicWeapon : IWeapon
    {
        public BasicWeapon(float speed = 1, float power = 1, int range = 1)
        {
            Speed = speed;
            Power = power;
            Range = range;
        }

        public int Range
        {
            get;
            private set;
        }

        public float Speed
        {
            get;
            private set;
        }

        public float Power
        {
            get;
            private set;
        }
    }
}