namespace Zombieshot.Engine
{
    public class EnemySpawner : ISpawner<IItem>
    {

        private IEnemy[] pool;

        // Use this for initialization
        void Start()
        {
            this.Setup();
        }

        public IItem Spawn()
        {
            for (int i = 0; i < this.pool.Length; i++)
            {
                var enemy = this.pool[i];
                
            };

            throw new System.Exception("there is not item avalible");
        }

        private void Setup()
        {
            for (int i = 0; i < pool.Length; i++)
            {
                // create the pool
            }
        }
    }
}