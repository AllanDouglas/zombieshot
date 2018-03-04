using Zombieshot.Engine;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

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

        public class Pool : MonoMemoryPool<IEnemy, BoardEnemyBehaviour>
        {

            private HashSet<BoardEnemyBehaviour> activeItens =
                new HashSet<BoardEnemyBehaviour>();

            protected override void Reinitialize(IEnemy enemy, BoardEnemyBehaviour item)
            {
                item.Enemy = enemy;
            }

            protected override void OnSpawned(BoardEnemyBehaviour item)
            {
                base.OnSpawned(item);
                this.activeItens.Add(item);
            }

            protected override void OnDespawned(BoardEnemyBehaviour item)
            {
                base.OnDespawned(item);
                this.activeItens.Remove(item);
            }

            public void Despawn(IEnemy enemy)
            {
                foreach (var item in this.activeItens)
                {
                    if (item.Enemy.Equals(enemy))
                    {
                        this.Despawn(item);
                        break;
                    }
                }
            }
        }
    }
}