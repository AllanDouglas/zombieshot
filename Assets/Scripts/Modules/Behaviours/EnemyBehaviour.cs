using Zombieshot.Engine;
using UnityEngine;
using Zenject;

namespace Zombieshot.Game
{
    public class EnemyBehaviour : MonoBehaviour
    {

        public class Factory : Factory<IItem, EnemyBehaviour>
        {

        }

    }
}