using Src.Interfaces;
using System.Collections.Generic;
using Src.Exceptions;

namespace Src.Basic
{
    public class CircleBoard : IBoard<IItem, int>
    {
        private readonly IDictionary<int, IItem> _itens;
        private readonly int _size = 360;

        public CircleBoard()
        {
            _itens = new Dictionary<int, IItem>();
        }

        public IPoint<int>[] FreePoints
        {
            get
            {
                List<IPoint<int>> points = new List<IPoint<int>>();

                for (int i = 0; i < this._size; i++)
                {
                    IPoint<int> point = new BasicPoint(i);
                    IItem item;
                    bool founded = this.Touch(point, out item);
                    if (!founded) points.Add(point);

                }

                return points.ToArray();
            }
        }

        public IItem Get(IPoint<int> point)
        {

            IItem item;
            bool founded = this.Touch(point, out item);

            if (founded) return item;

            throw new BoardException("Item not found");

        }

        public void Put(IItem target, IPoint<int> point)
        {
            if (point.Point > this._size)
            {
                throw new BoardException("point outside board");
            }

            if (this._itens.ContainsKey(point.Point))
            {
                this._itens.Remove(point.Point);
            }

            this._itens.Add(point.Point, target);
        }

        private bool Touch(IPoint<int> point, out IItem item)
        {

            foreach (int position in this._itens.Keys)
            {
                item = this._itens[position];


                var points = new List<int>();

                for (int i = 0; i < item.Range; i++)
                {

                    var pos = position + i;

                    if (pos > 360)
                    {
                        pos -= 360;
                    }

                    points.Add(pos);
                }

                if (points.Contains(point.Point)) return true;

            }

            item = null;
            return false;


        }

    }
}
