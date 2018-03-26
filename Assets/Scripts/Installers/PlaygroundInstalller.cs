using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class PlaygroundInstalller : MonoInstaller
    {
        public EnemyBehaviour enemyPrefab;
        public override void InstallBindings()
        {
            PCInputInstaller.Install(Container);
            EnemyInstall();
        }

        private void EnemyInstall()
        {
            
            Container.BindFactory<EnemyPayload, IEnemy, EnemyBehaviour.Factory>()
              .FromFactory<EnemyFactory>();
            Container.DeclareSignal<EnemyDestroyedSignal>();
            Container.BindMemoryPool<EnemyBehaviour, EnemyBehaviour.Pool>()
                  .WithInitialSize(5)
                  .FromComponentInNewPrefab(enemyPrefab)
                  .UnderTransformGroup("Enemies")
                  .NonLazy();
        }

    }

}