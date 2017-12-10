namespace Src.Interfaces
{
    internal interface IBoardSection<T>
    {
        T[] Positions { get; }
        bool Full { get; }
        void Add(T position);        
    }
}
