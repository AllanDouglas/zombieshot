namespace Zombieshot.Engine
{

    public interface ILevel
    {
        int Id { get; }
        IWave[] Wave { get; }
    }
}
