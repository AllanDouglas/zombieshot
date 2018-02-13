using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class PCInputInstaller : Installer<PCInputInstaller>
    {
        public override void InstallBindings()
        {

            Container.Bind<ITickable>().To<PCInput>().AsSingle().NonLazy();
            Container.Bind<IInputManager>().To<PCInput>().AsSingle().NonLazy();
        }
    }
}