using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class EnemyBehaviour : MonoBehaviour
    {

        #region Inspector
        [Header("Enemy Prperties")]
        [SerializeField]
        private int level;
        [SerializeField]
        private int speed;
        [SerializeField]
        private int range;
        [SerializeField]
        private int health;
        [Header("Enemy Graphics")]
        [SerializeField]
        private Transform board;
        [SerializeField]
        private Transform world;
        #endregion

        public IEnemy Enemy
        {
            get;
            private set;
        }

        [Inject]
        private EnemyBehaviour.Factory factory;

        public Transform Target
        {
            get
            {
                return board;
            }
        }

        public Transform World
        {
            get
            {
                return world;
            }
        }

        private void Awake()
        {
            Enemy = factory.Create(new EnemyPayload(level, speed, range, health));
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            this.world.Translate(Vector2.left * this.speed * Time.deltaTime);
        }

        public class Pool : MonoMemoryPool<EnemyBehaviour>
        {
            private HashSet<EnemyBehaviour> activeItens =
               new HashSet<EnemyBehaviour>();

            protected override void OnSpawned(EnemyBehaviour item)
            {
                base.OnSpawned(item);
                this.activeItens.Add(item);
            }

            protected override void OnDespawned(EnemyBehaviour item)
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
                        Despawn(item);
                        break;
                    }
                }
            }
        }


        public class Factory : Factory<EnemyPayload, IEnemy>
        {
        }

    }

}
