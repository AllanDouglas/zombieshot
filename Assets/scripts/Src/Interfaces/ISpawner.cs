
namespace Src.Basic
{
    interface ISpawner<T>
    {
        T Spawn();
        T[] Spawn(int amout);
    }
}
