using Zombieshot.Engine;
using Zombieshot.Extensions;
using UnityEngine;
using Zenject;

namespace Zombieshot.Game
{
    public class BoardBehaviour : MonoBehaviour
    {
        #region Inspector
        [SerializeField]
        private float radio = 2f;
        #endregion

        [Inject]
        private ICircleBoardService board;
        [Inject]
        private SpawnerEnemyResponseSignal spawner;
        [Inject]
        private readonly BoardEnemyBehaviour.Pool pool;

        // Use this for initialization
        void Start()
        {
            this.spawner.Listen(this.SpawnerHandler);
        }

        private void OnDestroy()
        {
            this.spawner.Unlisten(this.SpawnerHandler);
        }

        private void Put(BoardEnemyBehaviour enemy)
        {
            var freePoints = board.FreePointsTo(enemy.Enemy);

            if (freePoints.Length > 0)
            {
                IPoint<Vector2> point = freePoints.Shuffle().First();
                if (point != null)
                {
                    this.board.Put(enemy.Enemy, point);
                    enemy.transform.position = point.Point;
                }
            }


        }

        private void SpawnerHandler(IEnemy[] enemies)
        {
            foreach (IEnemy enemy in enemies)
            {
                this.Put(this.pool.Spawn(enemy));
            }
        }

    }
}