namespace Zombieshot.Engine
{
    public class BasicWave : IWave
    {
        public BasicWave(int amount, int enemyLevel)
        {
            Amount = amount;
            EnemyLevel = enemyLevel;
        }

        public int Amount
        {
            get;
            private set;
        }

        public int EnemyLevel
        {
            get;
            private set;
        }
    }

}