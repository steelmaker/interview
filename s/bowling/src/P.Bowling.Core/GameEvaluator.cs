using System.Collections.Generic;

namespace P.Bowling.Core {
    public class GameEvaluator {
        public int Evaluate(Game game) {
            return EvaluateImpl(game, game.Frames);
        }

        protected virtual int EvaluateImpl(Game game, IList<GameFrame> frames) {
            var result = 0;
            for (var i = 0; i < frames.Count; ++i) {
                var frame = frames[i];
                var next1 = Get(game, frames, i + 1);
                var next2 = Get(game, frames, i + 2);
                result += frames[i].Score;
                result += Bonus(frame, next1, next2);
            }
            return result;
        }

        private static int Bonus(GameFrame frame, GameFrame next1, GameFrame next2) {
            if (!frame.IsLast) {
                if (frame.IsSpare)  return Bonus(next1);
                if (frame.IsStrike) return Bonus(next1, next2);
            }
            return 0;
        }

        private static int Bonus(GameFrame next1, GameFrame next2) {
            if (next1.IsStrike && !next1.IsLast) {
                return next1[1] + next2[1];
            }
            return next1[1] + next1[2];

        }

        private static int Bonus(GameFrame next) {
            return next[1];
        }

        private static GameFrame Get(Game game, IList<GameFrame> frames, int i) {
            if (i < frames.Count)
                return frames[i];
            return new GameFrame(game);
        }
    }
}
