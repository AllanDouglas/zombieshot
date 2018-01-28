namespace Src.Interfaces
{
    public interface IDamageable
    {
        int Health { get; }
        void Damage(int amount);
    }
}