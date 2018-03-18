using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    /// <summary>
    /// 
    /// </summary>
    public class EnemyInstaller : Installer<EnemyBehaviour, EnemyInstaller>
    {
        private EnemyBehaviour enemyPrefab;

        public EnemyInstaller(EnemyBehaviour enemyPrefab)
        {
            this.enemyPrefab = enemyPrefab;
        }

        public override void InstallBindings()
        {
            
            Container.BindFactory<EnemyPayload, IEnemy, EnemyBehaviour.Factory>()
                .FromFactory<EnemyFactory>();

            Container.BindMemoryPool<EnemyBehaviour, EnemyBehaviour.Pool>()
                  .WithInitialSize(5)
                  .FromComponentInNewPrefab(enemyPrefab)
                  .UnderTransformGroup("Enemies")
                  .NonLazy();
        }
    }

}
