using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Src.Interfaces;
using Src.Basic;

namespace Src.Tests
{

    public class BasicTests
    {

        [Test]
        public void GetItemAtSamePosition()
        {

            IBoard<IItem, int> board = new CircleBoard();

            IItem item = new BoardItem(5);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);

            Assert.AreSame(item, board.Get(point));


        }

        [Test]
        public void GetItemInsideRange()
        {

            IBoard<IItem, int> board = new CircleBoard();

            IItem item = new BoardItem(5);
            IPoint<int> point = new BasicPoint(360);
            board.Put(item, point);

            Assert.AreSame(item, board.Get(new BasicPoint(2)));


        }

        [Test]
        public void GetAllFreeArea()
        {

            IBoard<IItem, int> board = new CircleBoard();

            Assert.AreEqual(360, board.FreePoints.Length);

        }

        [Test]
        public void GetFreeAreaLessOneItemFiveRanged()
        {
            IBoard<IItem, int> board = new CircleBoard();

            IItem item = new BoardItem(5);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);

            Assert.AreEqual(355, board.FreePoints.Length);

        }

        [Test]
        public void GetItemOutsideRange()
        {

            Assert.Catch(
                    typeof(Exceptions.BoardException),
                    new TestDelegate(GetingOutSideItem)
            );

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

            IBoard<IItem, int> board = new CircleBoard();

            IItem item = new BoardItem(5);
            IPoint<int> point = new BasicPoint(1);
            board.Put(item, point);
            board.Get(new BasicPoint(360));
        }
    }
}