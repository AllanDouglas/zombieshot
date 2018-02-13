using System;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    public abstract class InputHandler : IInputManager, ITickable
    {

        protected internal event Action OnTap;


        public void AddListener(Action listener)
        {
            this.OnTap += listener;
        }

        public void RemoveListener(Action listener)
        {
            this.OnTap -= listener;
        }

        public void Tick()
        {
            this.Update();
        }

        public abstract void Update();

        protected void InvokeOnTap()
        {
            if (OnTap != null)
            {
                this.OnTap();
            }
        }
    }
}