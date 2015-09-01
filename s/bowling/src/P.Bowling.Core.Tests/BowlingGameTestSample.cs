using NUnit.Framework;

namespace P.Bowling.Core.Tests {
    [TestFixture]
    [Category("Random Cases")]
    public class BowlingGameTestSample : BowlingGameTest {
        #region Tests Begin Here

        [Test]
        public void Test01() {
            Assert.AreEqual(0, Game.Score());
        }

        [Test]
        public void Test02() {
            Test(new[] {
                new[] {1, 4},
                new[] {4, 5},
                new[] {6, 4},
                new[] {5, 5},
                new[] {10},
                new[] {0, 1},
                new[] {7, 3},
                new[] {6, 4},
                new[] {10},
                new[] {2, 8, 6}
            }, 133);
        }

        [Test]
        public void Test03() {
            Test(new[] {
                new[] {2, 8},
                new[] {6, 4},
                new[] {10},
                new[] {10},
                new[] {9, 1},
                new[] {0, 1},
                new[] {7, 3},
                new[] {6, 4},
                new[] {10},
                new[] {10, 9, 1}
            }, 181);
        }

        [Test]
        public void Test04() {
            Test(new[] {
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5}
            }, 145);
        }

        [Test]
        public void Test05() {
            Test(new[] {
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5},
                new[] {5, 5, 5}
            }, 150);
        }

        [Test]
        public void Test06() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(0);
                Game.Roll(0);
            }
            Game.Roll(10);
            Game.Roll(10);
            Game.Roll(10);
            Assert.AreEqual(30, Game.Score());
        }

        [Test]
        public void Test07() {
            for (var i = 1; i <= 9; ++i) {
                Game.Roll(9);
                Game.Roll(1);
            }
            Game.Roll(10);
            Game.Roll(10);
            Game.Roll(10);
            Assert.AreEqual(202, Game.Score());
        }

        [Test]
        public void Test08() {
            for (var i = 1; i <= 10; ++i) {
                Game.Roll(0);
                Game.Roll(1);
            }
            Assert.AreEqual(10, Game.Score());
        }

        [Test]
        public void Test09() {
            Test(new[] { 9, 1, 0, 10, 10, 10, 6, 2, 7, 3, 8, 2, 10, 9, 0, 10, 10, 8 }, 176);
            Assert.True(Game.IsCompleted);
        }

        [Test]
        public void Test10() {
            Test(new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, 68);
            Assert.True(Game.IsCompleted);
        }

        #endregion
    }
}
