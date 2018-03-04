using Zombieshot.Game;
using Zombieshot.Engine;
using Zenject;

namespace Zombieshot.Game
{

    public class MainInstaller : MonoInstaller
    {

        [UnityEngine.SerializeField]
        private BoardEnemyBehaviour enemyPrefab;
        
        public override void InstallBindings()
        {

#if UNITY_EDITOR || UNTIY_PC
            this.PCBundle();
#elif UNITY_ANDROID || UNITY_IOS
        this.MobileBundle();
#endif
            this.General();
        }

        private void General()
        {
            PlayerInstaller.Install(Container);
            CircleBoardInstaller.Install(Container, enemyPrefab);
            GameControllerInstaller.Install(Container);
            SpawnerInstaller.Install(Container);
        }

        private void PCBundle()
        {
            PCInputInstaller.Install(Container);
        }

        private void MobileBundle()
        {
            MobileInputInstaller.Install(Container);
        }

    }
}