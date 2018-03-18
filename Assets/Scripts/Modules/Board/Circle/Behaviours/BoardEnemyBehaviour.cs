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
        public IEnemy Enemy
        {
            get;
            private set;
        }

    }
}