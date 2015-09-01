using System;
using System.Collections.Generic;
using System.Linq;

namespace P.Bowling.Core {
    /// <summary>
    /// Bowling game class. This type is not thread-safe.
    /// </summary>
    public class Game {
        #region Fields

        private readonly List<GameFrame> _frames;
        private int _frameSeqno;

        #endregion

        #region Properties

        public bool IsCompleted { get; private set; }
        public int NumOfFrames { get; private set; }
        public int NumOfPins { get; private set; }

        public IList<GameFrame> Frames {
            get {
                return _frames;
            }
        }

        #endregion

        #region Ctors

        public Game(int numOfFrames = 10, int numOfPins = 10) {
            NumOfFrames = Math.Max(1, numOfFrames);
            NumOfPins = Math.Max(1, numOfPins);
            _frames = new List<GameFrame> {
                GetNextFrame()
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Player rolls a number of pins.
        /// </summary>
        /// <param name="pins">The number of pins knocked down during a roll.</param>
        public void Roll(int pins) {
            if (IsCompleted) {
                throw new InvalidOperationException("Game is in completed state");
            }
            RollImpl(pins);
        }

        /// <summary>
        /// Gets end score of the game.
        /// </summary>
        /// <returns>The score of the total game.</returns>
        public int Score() {
            return ScoreImpl();
        }

        #endregion

        #region Protected/Private Methods

        protected virtual void RollImpl(int pins) {
            var currentFrame = _frames.Last();
            currentFrame.Roll(pins);
            if (currentFrame.IsCompleted) {
                if (currentFrame.IsLast) {
                    IsCompleted = true;
                    return;
                }
                _frames.Add(GetNextFrame());
            }
        }

        protected virtual int ScoreImpl() {
            return new GameEvaluator().Evaluate(this);
        }

        private GameFrame GetNextFrame() {
            if (++_frameSeqno < NumOfFrames)
                return new GameFrame(this);
            return new GameFrameLast(this);
        }

        #endregion
    }
}
