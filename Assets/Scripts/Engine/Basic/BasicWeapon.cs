namespace Zombieshot.Engine
{
    public class BasicWeapon : IWeapon
    {
        public BasicWeapon(float speed, float power)
        {
            Speed = speed;
            Power = power;
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