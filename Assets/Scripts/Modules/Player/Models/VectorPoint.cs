using UnityEngine;
using Zombieshot.Engine;

namespace Zombieshot.Game
{

    /// <summary>
    /// Vector2 based point
    /// </summary>
    public class VectorPoint : IPoint<Vector2>
    {


        public VectorPoint(Vector2 position)
        {
            this.Point = position;
        }


        public Vector2 Point
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("VectorPoint: x: {0}, y: {1}", this.Point.x, this.Point.y);
        }

    }

}
