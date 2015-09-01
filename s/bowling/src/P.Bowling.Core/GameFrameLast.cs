namespace P.Bowling.Core {
    public class GameFrameLast : GameFrame {
        internal GameFrameLast(Game game)
            : base(game)
        {
            IsLast = true;
        }

        protected override void VerifyRollImpl(int pins) {
            if (IsStrike || IsSpare || IsPerfect(2)) {
                return;
            }
            base.VerifyRollImpl(pins);
        }

        protected override bool GetIsCompletedImpl() {
            if (IsStrike || IsSpare)
                return Pins.Count == 3;
            return Pins.Count == 2;
        }
    }
}
