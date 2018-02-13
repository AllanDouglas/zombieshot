namespace Zombieshot.Engine
{
    internal interface ISlot<T>
    {
        T[] Positions { get; }
        bool Full { get; }
        void Add(T position);
    }
}
