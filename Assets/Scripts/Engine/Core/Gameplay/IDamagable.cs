namespace Zombieshot.Engine
{
    public interface IDamageable
    {
        int Health { get; }
        void Damage(int amount);
    }
}