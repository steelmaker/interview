using System;
using System.Collections.Generic;
using System.Linq;

namespace P.Bowling.Core {
    public class GameFrame {
        #region Fields

        protected readonly List<int> Pins = new List<int>();
        protected readonly Game Game;

        #endregion

        #region Properties

        internal bool IsCompleted {
            get {
                return GetIsCompletedImpl();
            }
        }

        internal int Score {
            get {
                return Pins.Sum();
            }
        }

        internal int this[int attempt] {
            get {
                if (1 <= attempt && attempt <= Pins.Count) {
                    return Pins[attempt - 1];
                }
                return 0;
            }
        }

        #endregion

        #region Properties : Public

        public bool IsStrike { get { return this[1] == Game.NumOfPins; } }
        public bool IsSpare  { get { return this[1] != Game.NumOfPins && this[1] + this[2] == Game.NumOfPins; } }

        public bool IsLast { get; protected set; }

        #endregion

        #region Ctors

        internal GameFrame(Game game) {
            Game = game;
        }

        #endregion

        #region Public Methods

        public void Roll(int pins) {
            if (IsCompleted) {
                throw new InvalidOperationException("Frame is in completed state");
            }
            RollImpl(pins);
        }

        #endregion

        #region Protected Methods

        protected virtual void RollImpl(int pins) {
            VerifyRollImpl(pins);
            Pins.Add(pins);
        }

        protected virtual void VerifyRollImpl(int pins) {
            if (pins < 0 || pins > Game.NumOfPins - this[1]) {
                throw new ArgumentOutOfRangeException("pins");
            }
        }

        protected virtual bool GetIsCompletedImpl() {
            if (IsStrike || IsSpare)
                return true;
            return Pins.Count == 2;
        }

        protected bool IsPerfect(int attempts) {
            return Score == Game.NumOfPins * attempts;
        }

        #endregion
    }
}
