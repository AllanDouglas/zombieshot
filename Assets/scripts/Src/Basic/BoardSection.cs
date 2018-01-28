using Src.Interfaces;

namespace Src.Basic
{
    public class BoardSection : ISlot<int>
    {

        private int _size;
        private readonly int[] _positions;

        public int[] Positions
        {
            get
            {
                return _positions;
            }
        }

        public bool Full
        {
            get
            {
                return _size == _positions.Length;
            }
        }

        public void Add(int position)
        {
            if(!Full)
            {
                this._positions [_size] = position;
                _size++;
            }
        }

        public BoardSection(int size)
        {
            this._positions = new int[size];
        }

    }
}
