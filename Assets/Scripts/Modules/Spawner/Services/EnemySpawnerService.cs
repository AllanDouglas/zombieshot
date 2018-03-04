using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class EnemySpawnerService : ISpawner
    {
        private SpawnerEnemyResponseSignal responseSignal;

        [Inject]
        public EnemySpawnerService(SpawnerEnemyResponseSignal responseSignal)
        {
            this.responseSignal = responseSignal;
        }
        
        public void Spawn()
        {
            // TODO: create the enemies acording by the settings
            this.responseSignal.Fire(new BasicEnemy[] { new BasicEnemy(range:5) });
        }
    }
}