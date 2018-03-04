using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zombieshot.Engine;

namespace Zombieshot.Game
{
    public class CircleBoardService : ICircleBoardService
    {
        private readonly int _size;
        private readonly float _tweak;
        private readonly int _radius;

        private List<IItem> _itens;

        [Inject]
        public CircleBoardService(int size = 360, int tweak = 10, int radius = 2)
        {
            this._size = size;
            this._tweak = tweak;
            this._radius = radius;
            this._itens = new List<IItem>();

        }

        public int Radius
        {
            get
            {
                return _radius;
            }
        }

        public IPoint<Vector2>[] FreePointsTo(IEnemy target)
        {

            List<VectorPoint> points = new List<VectorPoint>();

            for (int i = 0; i < this._size; i++)
            {
                Vector2 pos = new Vector2(
                    Mathf.Cos(i * Mathf.Deg2Rad),
                    Mathf.Sin(i * Mathf.Deg2Rad)
                );

                pos = (pos * this._radius);
                try
                {
                    var item = this.TouchTo(pos, target);
                }
                catch (Exceptions.BoardException)
                {
                    points.Add(new VectorPoint(pos));
                }

            }

            return points.ToArray();
        }

        public IEnemy Get(IPoint<Vector2> point, IWeapon weapon)
        {
            try
            {
                return this.TouchTo(point.Point, new BasicEnemy(
                    range: weapon.Range
                ));
            }
            catch (Exceptions.BoardException e)
            {
                throw new Exceptions.BoardException(
                    string.Format("{0}:, {1}", e.Message, point.Point)
                );
            }
        }

        public void Put(IEnemy target, IPoint<Vector2> point)
        {
            this._itens.Add(target);
        }

        public void Remove(IEnemy target)
        {
            this._itens.Remove(target);
        }

        private IEnemy TouchTo(Vector2 position, IItem target)
        {
            float radius = (float)target.Range / _tweak;
            var collider = Physics2D.OverlapCircle(position, radius);

            try
            {
                if (collider != null)
                {
                    return collider.gameObject.GetComponent<BoardEnemyBehaviour>().Enemy;
                }

                throw new Exceptions.BoardException("Item not found");
            }
            catch (System.NullReferenceException)
            {
                throw new Exceptions.BoardException("Item not found");
            }
        }

    }
}