namespace Src.Interfaces
{
    public interface IBoardItem<T>
    {
        IBoardPoint<T> Position { get; }
        int Range { get; }
    }
}
