using Zenject;
using Zombieshot.Game;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class CircleBoardInstaller : Installer<CircleBoardInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IBoard<IItem, int>>().To<CircleBoard>().AsTransient();
            Container.Bind<IPoint<int>>().To<BasicPoint>().AsTransient();
            Container.BindInterfacesAndSelfTo<BasicEnemy>().AsTransient();
            Container.Bind<BoardBehaviour>().FromComponentInHierarchy().AsSingle();

        }
    }
}