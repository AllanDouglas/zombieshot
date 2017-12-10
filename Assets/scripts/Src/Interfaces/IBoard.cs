namespace Src.Interfaces
{
    public interface IBoard<T>
    {
        void Put(IBoardItem<T> target);
        void Put(IBoardItem<T>[] targets);

        IBoardItem<T> Get(IBoardItem<T> point);
    }
}
