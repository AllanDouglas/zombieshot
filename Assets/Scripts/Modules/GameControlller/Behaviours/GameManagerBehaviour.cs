using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class GameManagerBehaviour : MonoBehaviour
    {
        [Inject]
        private IGameManager gameManager;

        [Inject]
        private ISpawner spawner;

        private void Start()
        {
            this.spawner.Spawn();
        }

    }
}