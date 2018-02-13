namespace Zombieshot.Engine
{
    public interface IInputManager
    {

        void Update();

        void AddListener(System.Action listener);

        void RemoveListener(System.Action listener);

    }
}