namespace Src.Interfaces
{
    internal interface ISlot<T>
    {
        T[] Positions { get; }
        bool Full { get; }
        void Add(T position);
    }
}
