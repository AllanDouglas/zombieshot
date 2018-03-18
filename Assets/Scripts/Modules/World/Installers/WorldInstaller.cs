using Zenject;

namespace Zombieshot.Game
{

    /// <summary>
    /// 
    /// </summary>
    public class WorldInstaller : Installer< WorldInstaller>
    {
        
        public override void InstallBindings()
        {
            Container.Bind<WorldBehaviour>().FromComponentInHierarchy().AsSingle();

        }
    }

}
