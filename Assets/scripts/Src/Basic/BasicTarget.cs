using Src.Interfaces;

namespace Src.Basic
{
    internal class BasicTarget : IBoardItem<int>
    {
        private readonly IBoardPoint<int> _point;
        private readonly int _range;

        public IBoardPoint<int> Position
        {
            get
            {
                return _point;
            }
        }

        public int Range
        {
            get
            {
                return _range;
            }
        }

        public BasicTarget(IBoardPoint<int> point, int range)
        {
            _point = point;
            _range = range;
        }
    }
}