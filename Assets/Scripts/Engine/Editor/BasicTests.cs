using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Zombieshot.Engine;

namespace Src.Tests
{

    public class BasicTests
    {

        [Test]
        public void GetItemAtSamePosition()
        {

            IBoard<IItem, int> board = new BasicBoard();

            IItem item = new BasicEnemy(5);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);

            Assert.AreSame(item, board.Get(point));


        }

        [Test]
        public void MustBeAFullBoard()
        {

            IBoard<IItem, int> board = new BasicBoard(4);

            IItem item = new BasicEnemy(range: 4);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);

            Assert.AreEqual(0, board.FreePointsTo(item).Length);


        }


        [Test]
        public void GetItemInsideRange()
        {

            IBoard<IItem, int> board = new BasicBoard();

            IItem item = new BasicEnemy(range: 5);
            IPoint<int> point = new BasicPoint(360);
            board.Put(item, point);

            Assert.AreSame(item, board.Get(new BasicPoint(2)));


        }

        [Test]
        public void GetAllFreeArea()
        {

            IBoard<IItem, int> board = new BasicBoard(4);

            Assert.AreEqual(4, board.FreePointsTo(new BasicEnemy(range: 0)).Length);

        }

        [Test]
        public void GetFreeAreaLessOneItem()
        {
            IBoard<IItem, int> board = new BasicBoard(4);

            IItem item = new BasicEnemy(range: 2);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);

            Assert.AreEqual(1, board.FreePointsTo(item).Length);

        }

        [Test]
        public void GetItemOutsideRange()
        {

            Assert.Catch(
                    typeof(Zombieshot.Exceptions.BoardException),
                    new TestDelegate(GetingOutSideItem)
            );

        }
        [Test]
        public void CauseDamage()
        {

            IDamageable target = new BasicEnemy(health: 5);

            target.Damage(2);

            Assert.AreEqual(target.Health, 3);

        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator BasicTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }

        private void GetingOutSideItem()
        {

            IBoard<IItem, int> board = new BasicBoard(360);

            IItem item = new BasicEnemy(range: 5);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);
            board.Get(new BasicPoint(360));
        }
    }
}