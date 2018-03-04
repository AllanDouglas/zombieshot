using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    /// <summary>
    /// Spawner Installer
    /// </summary>
    public class SpawnerInstaller : Installer<SpawnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SpawnerEnemyResponseSignal>();
            Container.Bind<ISpawner>().To<EnemySpawnerService>().AsSingle();
        }
    }

}
