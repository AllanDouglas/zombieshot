using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {

            Container.Bind<IWeapon>().To<BasicWeapon>().AsTransient();
            Container.Bind<IPoint<int>>().To<BasicPoint>().AsTransient();
            Container.Bind<TargetBehaviour>().FromComponentInHierarchy().AsSingle();

        }
    }
}