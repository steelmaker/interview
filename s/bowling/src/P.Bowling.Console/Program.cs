using P.Bowling.Core;

namespace P.Bowling.Console {
    internal class Program {
        internal static void Main(string[] args) {
            var game = new Game();
            var history = new[] {
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
            };
            foreach (var frame in history) {
                foreach (var pins in frame) {
                    game.Roll(pins);
                }
            }
            System.Console.WriteLine(game.Score());
            System.Console.WriteLine("Presss any key to continue..");
            System.Console.ReadKey();
        }
    }
}
