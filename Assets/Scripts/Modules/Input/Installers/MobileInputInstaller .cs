using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class MobileInputInstaller : Installer<PCInputInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputManager>().To<MobileInput>().AsSingle().NonLazy();
        }
    }
}