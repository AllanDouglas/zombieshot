using System.Collections.Generic;
using Zombieshot.Engine;
using Zombieshot.Exceptions;

namespace Zombieshot.Engine
{

    /// <summary>
    /// 
    /// </summary>
    public class BasicBoard : IBoard<IItem, int>
    {

        protected readonly IDictionary<int, IItem> _itens;
        protected readonly int _size;

        public BasicBoard(int size = 360)
        {
            _itens = new Dictionary<int, IItem>();
            _size = size;
        }

        public IPoint<int>[] FreePointsTo(IItem target)
        {
            List<IPoint<int>> points = new List<IPoint<int>>();

            for (int i = 1; i <= this._size; i++)
            {
                IPoint<int> point = new BasicPoint(i);
                IItem item;
                bool founded = this.TouchBy(point, target, out item);
                if (!founded) points.Add(point);

            }

            return points.ToArray();
        }

        public IItem Get(IPoint<int> point)
        {

            IItem item;
            bool founded = this.TouchBy(point, new BasicEnemy(range: 0), out item);

            if (founded) return item;

            throw new BoardException("Item not found");

        }

        public void Put(IItem target, IPoint<int> point)
        {
            if (point.Point > this._size || point.Point <= 0)
            {
                throw new BoardException("point outside board");
            }

            if (target.Range > this._size)
            {
                throw new BoardException("the item range is bigger than board size");
            }

            if (this._itens.ContainsKey(point.Point))
            {
                this._itens.Remove(point.Point);
            }

            this._itens.Add(point.Point, target);
        }

        private List<int> Points(IItem item, IPoint<int> point)
        {

            var targePoints = new List<int>();
            for (int i = 0; i < item.Range; i++)
            {

                var pos = point.Point + i;

                if (pos > _size)
                {
                    pos -= _size;
                }

                targePoints.Add(pos);
            }
            return targePoints;
        }

        private bool TouchBy(IPoint<int> point, IItem target, out IItem item)
        {

            var targePoints = this.Points(target, point);

            foreach (int position in _itens.Keys)
            {
                item = _itens[position];

                var itemPoints = this.Points(item, new BasicPoint(position));

                bool intersect = itemPoints.Exists((index) => {
                    return targePoints.Contains(index);
                });

                if (itemPoints.Contains(point.Point) || intersect) return true;

            }

            item = null;
            return false;


        }

    }
}
