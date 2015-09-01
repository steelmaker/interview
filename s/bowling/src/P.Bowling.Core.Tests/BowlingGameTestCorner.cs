using System;
using NUnit.Framework;

namespace P.Bowling.Core.Tests {
    [TestFixture]
    [Category("Corner/Edge Cases")]
    public class BowlingGameTestCorner : BowlingGameTest {
        #region Tests Begin Here

        [Test]
        public void Test01() {
            for (var i = 1; i <= 12; ++i) {
                Game.Roll(10);
            }
            Assert.True(Game.IsCompleted);
            Assert.AreEqual(300, Game.Score());
        }

        [Test]
        public void Test02() {
            for (var i = 1; i <= 20; ++i) {
                Game.Roll(0);
            }
            Assert.True(Game.IsCompleted);
            Assert.AreEqual(0, Game.Score());
        }

        [Test]
        public void Test03() {
            for (var i = 1; i <= 10; ++i) {
                Game.Roll(9);
                Game.Roll(1);
            }
            Game.Roll(10);
            Assert.True(Game.IsCompleted);
            Assert.AreEqual(191, Game.Score());
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test04() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
            Game.Roll(2);
            Game.Roll(9);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test05() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
            Game.Roll(9);
            Game.Roll(2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test06() {
            Game.Roll(9);
            Game.Roll(9);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test07() {
            for (var i = 1; i <= 20; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test08() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
            Game.Roll(10);
            Game.Roll(10);
            Game.Roll(10);
            Game.Roll(10);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test09() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(10);
            }
            Game.Roll(0);
            Game.Roll(0);
            Game.Roll(10);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test10() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
            Game.Roll(1);
            Game.Roll(1);
            Game.Roll(10);
        }

        #endregion
    }
}
