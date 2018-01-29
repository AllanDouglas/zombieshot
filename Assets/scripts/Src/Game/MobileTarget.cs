using Src.Interfaces;

namespace Src.Game
{
    public class MobileTarget : Target, IMobile
    {

        public MobileTarget(int range, int speed) : base(range)
        {
            this.Speed = speed;
        }

        public float Speed
        {
            get;
            private set;
        }
    }
}
