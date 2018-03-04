namespace Zombieshot.Game { 
    public class PCInput : InputHandler
    {
        public override void Update()
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                this.InvokeOnTap();
            }

        }
    }
}