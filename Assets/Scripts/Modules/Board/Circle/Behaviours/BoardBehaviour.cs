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
        private float size = 2f;
        #endregion

        [Inject]
        private IBoard<IItem, int> board;
        

        // Use this for initialization
        void Start()
        {
        
        }

        private void Put(EnemyBehaviour enemy)
        {
            IPoint<int> point = board.FreePoints.Shuffle().First();

            var pos = new Vector2(
                Mathf.Cos(point.Point * Mathf.Deg2Rad),
                Mathf.Sin(point.Point * Mathf.Deg2Rad)
           );

            Debug.Log(point.Point);
            Debug.Log(pos);
            enemy.transform.position = (pos * this.size);
        }

    }
}