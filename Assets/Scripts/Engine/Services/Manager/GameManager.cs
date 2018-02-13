using System;

namespace Zombieshot.Engine

{
    public class GameManager : IGameManager
    {
        public static event Action OnGameOver;
        public static event Action OnPause;
        public static event Action OnResume;
        public static event Action OnInit;

        protected IInputManager inputManager;

        public GameManager(
            IInputManager inputManager
            )
        {
            this.inputManager = inputManager;
        }

        public void Gameover()
        {
            if (OnGameOver != null) OnGameOver();
        }

        public void Start()
        {
            if (OnInit != null) OnInit();
        }

        public void Pause()
        {
            if (OnPause != null) OnPause();
        }

        public void Resume()
        {
            if (OnResume != null) OnResume();
        }


    }
}