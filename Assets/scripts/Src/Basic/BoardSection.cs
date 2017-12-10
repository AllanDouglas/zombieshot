using Src.Interfaces;

namespace Src.Basic
{
    public class BoardSection : IBoardSection<int>
    {

        private int _amount;
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
                return _amount == _positions.Length;
            }
        }

        public void Add(int position)
        {
            if(!Full)
            {
                this._positions [_amount] = position;
                _amount++;
            }
        }

        public BoardSection(int size)
        {
            this._positions = new int[size];
        }

    }
}
