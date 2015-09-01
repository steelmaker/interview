using NUnit.Framework;

namespace P.Bowling.Core.Tests {
    public abstract class BowlingGameTest {
        #region Properties

        public Game Game { get; private set; }

        #endregion

        #region Setup Stuff

        [SetUp]
        public void Setup() {
            SetupImpl();
        }

        protected virtual void SetupImpl() {
            Game = new Game();
        }

        #endregion

        #region Protected Methods

        protected void Test(int[] history, int expected) {
            foreach (var pins in history) {
                Game.Roll(pins);
            }
            Assert.AreEqual(expected, Game.Score());
        }

        protected void Test(int[][] history, int expected) {
            foreach (var frame in history) {
                foreach (var pins in frame) {
                    Game.Roll(pins);
                }
            }
            Assert.AreEqual(expected, Game.Score());
        }

        #endregion
    }
}
