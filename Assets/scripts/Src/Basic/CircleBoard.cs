using Src.Interfaces;
using System.Collections.Generic;
using Src.Extensions;

namespace Src.Basic
{
    public class CircleBoard : IBoard<int>
    {
        private readonly IBoardItem<int>[] _itens;
        private readonly int _size = 360;


        public IBoardItem<int> Get(IBoardItem<int> point)
        {

            for (int i = 0; i < point.Range; i++)
            {
                int position = i + point.Position.Point;
                IBoardItem<int> item = _itens[position];

                if (item != null)
                {
                    return item;
                }

            }

            return null;
        }

        public void Put(IBoardItem<int> target)
        {
            List<int[]> empty = GetEmptySections(target.Range).Shuffle() as List<int[]>;

            System.Array.ForEach(empty[0], (int position) =>
            {
                _itens[position] = target;
            });

        }

        public void Put(IBoardItem<int>[] targets)
        {
            System.Array.ForEach(targets, (target) =>
            {
                Put(target);
            });
        }

        public CircleBoard()
        {
            _itens = new IBoardItem<int>[this._size];
        }

        private IList<IBoardSection<int>> GetEmptySections(int range)
        {
            List<IBoardSection<int>> areas = new List<IBoardSection<int>>();
            BoardSection section = new BoardSection(range);
            for (int i = 0; i < _size; i++)
            {

                for (int j = 0; j < range; j++)
                {
                    int position = i + j;
                    if (position > _size)
                    {
                        position = j;
                    }

                    if (_itens.Length < position && this._itens[position] != null)
                    {
                        break;
                    }

                    section.Add(position);

                }

                if (section.Full)
                {
                    areas.Add(section);
                    section = new BoardSection(range);
                }

            }

            return areas;
        }
    }
}
