using UnityEngine;
using UnityEditor;
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
        public void BasicTestsSimplePasses()
        {

            IBoard<int> board = new CircleBoard();

            IBoardItem<int> item = new BoardItem(new BasicPoint(0), 5);

            board.Put(item);
            
            Assert.AreSame(item, board.Get(item));


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
    }
}