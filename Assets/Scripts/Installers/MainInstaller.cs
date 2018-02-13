using Zombieshot.Game;
using Zombieshot.Engine;
using Zenject;

namespace Zombieshot.Game
{

    public class MainInstaller : MonoInstaller
    {

        [UnityEngine.SerializeField]
        private EnemyBehaviour enemyPrefab;
        [UnityEngine.SerializeField]
        private EnemySpawner spawnerPrefab;


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
           
            CircleBoardInstaller.Install(Container);
            GameControllerInstaller.Install(Container);
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