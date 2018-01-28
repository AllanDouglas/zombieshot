namespace Src.Interfaces
{
    public interface IBoard<T, H>
    {
        IPoint<H>[] FreePoints { get; }

        void Put(T target, IPoint<H> point);

        T Get(IPoint<H> point);
        
    }
}
