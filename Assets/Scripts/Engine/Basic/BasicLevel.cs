namespace Zombieshot.Engine
{
    public class BasicLevel : ILevel
    {
        public BasicLevel(int id, IWave[] wave)
        {
            Id = id;
            Wave = wave;
        }

        public int Id
        {
            get;
            private set;
        }

        public IWave[] Wave
        {
            get;
            private set;
        }
    }

}