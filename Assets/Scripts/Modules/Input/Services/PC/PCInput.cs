namespace Zombieshot.Game { 
    public class PCInput : InputHandler
    {
        public override void Update()
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                UnityEngine.Debug.Log("Hehe is the pc input");
                this.InvokeOnTap();
            }

        }
    }
}