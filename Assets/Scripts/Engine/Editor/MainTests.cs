using NUnit.Framework;
using Zombieshot.Engine;
using Zombieshot.Game;
using UnityEngine;
using System.Collections.Generic;

namespace Src.Tests
{
    [TestFixture]
    public class MainTests : Zenject.ZenjectUnitTestFixture
    {
        [SetUp]
        public void CommonInstaller()
        {
            var go = new GameObject();

            CircleBoardInstaller.Install(Container, go.AddComponent<BoardEnemyBehaviour>());
        }

        [Test]
        public void GetItemAtSamePosition()
        {
            var board = new CircleBoardService();

            var enemy = new BasicEnemy(range: 5);
            var pos = new Vector2(2, 0);
            var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
            var collider = go.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            go.transform.position = pos;

            Assert.AreSame(enemy, board.Get(new VectorPoint(pos)));
        }

        [Test]
        public void MustBeAFullBoard()
        {
            var board = new CircleBoardService();
            var enemy = new BasicEnemy(range: 5);
            var gos = new List<BoardEnemyBehaviour>();

            for (int i = 0; i < 360; i++)
            {
                if (board.FreePointsTo(enemy).Length <= 0) break;

                Vector2 pos = new Vector2(
                   Mathf.Cos(i * Mathf.Deg2Rad),
                   Mathf.Sin(i * Mathf.Deg2Rad)
                );

                var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
                var collider = go.gameObject.AddComponent<CircleCollider2D>();
                collider.radius = 0.5f;
                go.transform.position = pos;
                enemy = new BasicEnemy(range: 5);
                gos.Add(go);
            }

            Assert.AreEqual(0, board.FreePointsTo(enemy).Length);

        }


        [Test]
        public void GetItemInsideRange()
        {
            var board = new CircleBoardService();

            var enemy = new BasicEnemy(range: 5);

            Vector2 pos = new Vector2(
                   Mathf.Cos(0 * Mathf.Deg2Rad),
                   Mathf.Sin(0 * Mathf.Deg2Rad)
            );

            Vector2 pos2 = new Vector2(
                   Mathf.Cos(359 * Mathf.Deg2Rad),
                   Mathf.Sin(359 * Mathf.Deg2Rad)
            );

            var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
            var collider = go.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            go.transform.position = pos;

            Assert.AreSame(enemy, board.Get(new VectorPoint(pos2)));
        }

        [Test]
        public void GetAllFreeArea()
        {
            var board = new CircleBoardService();

            var freePoints = board.FreePointsTo(new BasicEnemy(range: 5));

            Assert.AreEqual(360, freePoints.Length);
        }

        [Test]
        public void GetFreeAreaLessOneItem()
        {
            var board = new CircleBoardService();

            var enemy = new BasicEnemy(range: 5);
            var pos = new Vector2(2, 0);
            var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
            var collider = go.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            go.transform.position = pos;

            var freePoints = board.FreePointsTo(new BasicEnemy(range: 5));

            Assert.AreNotEqual(360, freePoints.Length);

        }

        [Test]
        public void GetItemOutsideRange()
        {

            var board = new CircleBoardService();

            var enemy = new BasicEnemy(range: 5);

            Vector2 pos = new Vector2(
                   Mathf.Cos(0 * Mathf.Deg2Rad),
                   Mathf.Sin(0 * Mathf.Deg2Rad)
            );

            int angle = 35;

            Vector2 pos2 = new Vector2(
                   Mathf.Cos(angle * Mathf.Deg2Rad),
                   Mathf.Sin(angle * Mathf.Deg2Rad)
            );

            var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
            var collider = go.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            go.transform.position = pos;

            Assert.Throws<Zombieshot.Exceptions.BoardException>(() => board.Get(new VectorPoint(pos2)));

        }
        [Test]
        public void CauseDamage()
        {
            var board = new CircleBoardService();

            var enemy = new BasicEnemy(range: 5, health: 1);
            var pos = new Vector2(2, 0);
            var go = Container.Resolve<BoardEnemyBehaviour.Pool>().Spawn(enemy);
            var collider = go.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            go.transform.position = pos;

            board.Get(new VectorPoint(pos)).Damage(1);

            Assert.AreEqual(enemy.Health, board.Get(new VectorPoint(pos)).Health);

        }

    }
}