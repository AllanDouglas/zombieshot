using Src.Interfaces;

namespace Src.Basic
{
    public class BoardItem : IBoardItem<int>
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

        public BoardItem(IBoardPoint<int> point, int range)
        {
            this._point = point;
            this._range = range;
        }
    }
}
