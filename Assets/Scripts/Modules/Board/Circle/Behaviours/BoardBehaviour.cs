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

        // Use this for initialization
        void Start()
        {
            this.spawner.Listen(this.SpawnerHandler);
        }

        private void OnDestroy()
        {
            this.spawner.Unlisten(this.SpawnerHandler);
        }

        private void Put(EnemyBehaviour enemy)
        {
            var freePoints = board.FreePointsTo(enemy.Enemy);

            if (freePoints.Length > 0)
            {
                IPoint<Vector2> point = freePoints.Shuffle().First();
                if (point != null)
                {
                    board.Put(enemy.Enemy, point);
                    enemy.Target.position = point.Point;
                }
            }


        }

        private void SpawnerHandler(EnemyBehaviour[] enemies)
        {
            foreach (EnemyBehaviour enemy in enemies)
            {
                this.Put(enemy);
            }
        }

    }
}