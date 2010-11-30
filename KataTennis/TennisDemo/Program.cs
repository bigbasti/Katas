using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TennisGame;

namespace TennisDemo {
    class Program {
        static void Main(string[] args) {
            TennisGame.TennisGame tg = new TennisGame.TennisGame();

            System.Console.WriteLine("The Game begins:");

            while (true) {
                
                System.Console.WriteLine("\n" + tg.GameState + "\n");
                System.Console.WriteLine("Who shall score? (1 = Player1 | 2 = Player2):");
                string ps = System.Console.ReadLine();

                if (ps.Equals("1")) {
                    tg.Player1.ScorePointAgainst(tg.Player2);
                } else if (ps.Equals("2")) {
                    tg.Player2.ScorePointAgainst(tg.Player1);
                } else {
                    return;
                }

                if (tg.Player1.Score == TennisScore.Game || tg.Player2.Score == TennisScore.Game) {
                    System.Console.WriteLine("\n" + tg.GameState + "\n\nPress Any Key to exit...");
                    string aas = System.Console.ReadLine();
                    return;
                }

            }
        }
    }
}
