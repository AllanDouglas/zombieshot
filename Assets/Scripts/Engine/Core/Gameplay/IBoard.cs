namespace Zombieshot.Engine
{
    public interface IBoard<T, H>
    {
        IPoint<H>[] FreePointsTo(T target);

        void Put(T target, IPoint<H> point);

        void Remove(T target);

        T Get(IPoint<H> point, IWeapon weapon);
        
    }
}
