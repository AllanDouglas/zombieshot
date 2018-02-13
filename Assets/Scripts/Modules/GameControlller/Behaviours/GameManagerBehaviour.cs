using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class GameManagerBehaviour : MonoBehaviour
    {
        [Inject]
        private IGameManager gameManager;

    }
}