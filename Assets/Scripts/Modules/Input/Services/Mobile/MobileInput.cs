namespace Zombieshot.Game
{
    public class MobileInput : InputHandler
    {
        public override void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                this.InvokeOnTap();
            }

        }
    }
}