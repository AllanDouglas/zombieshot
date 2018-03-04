using System;
using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public class GameControllerService : GameManager, IDisposable
    {

        private ISpawner spawner;
        private TargetBehaviour weapon;
        private IBoard<IEnemy, Vector2> board;


        [Inject]
        public GameControllerService(
            IInputManager inputManager,
            TargetBehaviour weapon,
            IBoard<IEnemy, Vector2> board,
            ISpawner spawner
            ) : base(inputManager)
        {
            this.spawner = spawner;
            this.board = board;
            this.inputManager.AddListener(this.OnTouch);
            this.weapon = weapon;

            
        }

        public void Dispose()
        {
            this.inputManager.RemoveListener(this.OnTouch);
        }

        private void OnTouch()
        {
            var pos = this.weapon.GetLookPosition();
            Debug.LogFormat("look position: {0}", pos);
            try
            {
                Debug.LogFormat("item founded: {0}", this.board.Get(pos));
            }
            catch (Exceptions.BoardException)
            { }

            
        }

    }
}