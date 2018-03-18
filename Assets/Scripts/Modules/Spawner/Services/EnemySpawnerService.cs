using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class EnemySpawnerService : ISpawner
    {
        private SpawnerEnemyResponseSignal responseSignal;
        private EnemyBehaviour.Pool enemyPool;

        [Inject]
        public EnemySpawnerService(
            EnemyBehaviour.Pool pool,
            SpawnerEnemyResponseSignal responseSignal)
        {
            this.enemyPool = pool;
            this.responseSignal = responseSignal;
        }

        public void Spawn()
        {
            // TODO: create the enemies acording by the settings
            this.responseSignal.Fire(new[] { enemyPool.Spawn() });
        }
    }
}