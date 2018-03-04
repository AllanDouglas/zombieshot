using UnityEngine;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICircleBoardService : IBoard<IEnemy, Vector2>
    {
        int Radius { get; }
    }
}
