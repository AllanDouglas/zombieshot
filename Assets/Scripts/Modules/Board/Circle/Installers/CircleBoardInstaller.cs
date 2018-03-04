using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class CircleBoardInstaller : Installer<BoardEnemyBehaviour, CircleBoardInstaller>
    {
        private BoardEnemyBehaviour enemyPrefab;

        public CircleBoardInstaller(BoardEnemyBehaviour enemyBehaviour)
        {
            this.enemyPrefab = enemyBehaviour;
        }

        public override void InstallBindings()
        {
            Container.Bind<IBoard<IEnemy, Vector2>>().To<CircleBoardService>().AsTransient();
            Container.Bind<IPoint<int>>().To<BasicPoint>().AsTransient();
            Container.BindInterfacesAndSelfTo<BasicEnemy>().AsTransient();
            Container.Bind<BoardBehaviour>().FromComponentInHierarchy().AsSingle();

            Container.BindMemoryPool<BoardEnemyBehaviour, BoardEnemyBehaviour.Pool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(enemyPrefab)
                .UnderTransformGroup("Enemies")
                .NonLazy();

        }
    }
}