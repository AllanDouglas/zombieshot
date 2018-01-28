using Src.Interfaces;

namespace Src.Basic
{
    public class BasicPoint : IPoint<int>
    {
        private int _point;

        public int Point
        {
            get
            {
                return _point;
            }
        }

        public BasicPoint(int point)
        {
            this._point = point;
        }


    }
}