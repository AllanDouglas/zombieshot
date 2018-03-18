using System;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class GameControllerService : GameManager, IDisposable
    {

        private ISpawner spawner;
        private TargetBehaviour player;
        private ICircleBoardService board;
        private EnemyBehaviour.Pool enemyPool;

        [Inject]
        public GameControllerService(
            EnemyBehaviour.Pool enemyPool,
            IInputManager inputManager,
            TargetBehaviour weapon,
            ICircleBoardService board,
            ISpawner spawner
            ) : base(inputManager)
        {
            this.enemyPool = enemyPool;
            this.spawner = spawner;
            this.board = board;
            this.inputManager.AddListener(this.OnTouch);
            this.player = weapon;
        }

        public void Dispose()
        {
            this.inputManager.RemoveListener(this.OnTouch);
        }

        private void OnTouch()
        {
            if (this.player.CanShot)
            {
                var pos = this.player.Shot(this.board.Radius);
                try
                {
                    this.EnemyFound(this.board.Get(pos, this.player.Weapon));
                }
                catch (Exceptions.BoardException)
                { }
            }
        }

        private void EnemyFound(IEnemy enemy)
        {
            enemy.Damage((int)this.player.Weapon.Power);

            UnityEngine.Debug.Log(enemy);

            if (enemy.Health <= 0)
            {
                this.enemyPool.Despawn(enemy);
            }

        }
    }
}