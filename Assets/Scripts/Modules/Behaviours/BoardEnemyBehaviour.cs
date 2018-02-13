using Zombieshot.Engine;
using UnityEngine;
using Zenject;

namespace Zombieshot.Game
{
    public class BoardEnemyBehaviour : MonoBehaviour
    {

        [Inject]
        public IItem Target
        {
            get;
            private set;
        }

        public class Factory : MonoMemoryPool<IItem, BoardEnemyBehaviour>
        {

        }
    }
}