using Zombieshot.Engine;
using UnityEngine;
using Zenject;

namespace Zombieshot.Game
{
    public class BoardEnemyBehaviour : MonoBehaviour
    {

        #region Inspector
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        #endregion

        [Inject]
        private readonly BoardEnemyBehaviour.Pool pool;

        [Inject]
        public IEnemy Enemy
        {
            get;
            private set;
        }
        
        private void Update()
        {
            if (this.Enemy.Health <= 0)
            {
                this.pool.Despawn(this);
            }
        }


        public class Pool : MonoMemoryPool<IEnemy, BoardEnemyBehaviour>
        {
            protected override void Reinitialize(IEnemy enemy, BoardEnemyBehaviour item)
            {
                item.Enemy = enemy;
            }
        }
    }
}