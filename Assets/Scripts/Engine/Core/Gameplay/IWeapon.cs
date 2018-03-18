namespace Zombieshot.Engine
{

    public interface IWeapon : IItem
    {
        float Speed { get; }
        float Power { get; }
        float ReloadTime { get; }
    }
}