namespace Zombieshot.Engine
{
    public interface IEnemy : IDamageable, IItem
    {
        int Level { get; }
        int Speed { get; }
        void Die();

    }
}
