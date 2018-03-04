using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class 
        GameControllerInstaller : Installer<GameControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameManager>().To<GameControllerService>().AsSingle();
        }
    }
}