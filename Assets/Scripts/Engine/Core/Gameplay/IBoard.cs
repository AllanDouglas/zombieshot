namespace Zombieshot.Engine
{
    public interface IBoard<T, H>
    {
        IPoint<H>[] FreePointsTo(T target);

        void Put(T target, IPoint<H> point);

        T Get(IPoint<H> point);
        
    }
}
