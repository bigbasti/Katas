using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisGame {
    public class TennisGame {

        public Player Player2 {
            get;
            private set;
        }
        public Player Player1 {
            get;
            private set;
        }

        public string GameState {
            get {
                if (Player1.Score == TennisScore.Fourty && Player2.Score == TennisScore.Fourty) {
                    return "Duece";
                }
                if (Player1.Score == TennisScore.Game) {
                    return "Game for Player1";
                }
                if (Player2.Score == TennisScore.Game) {
                    return "Game for Player2";
                }
                if (Player1.Score == TennisScore.Advantage) {
                    return "Advantage for Player1";
                }
                if (Player2.Score == TennisScore.Advantage) {
                    return "Advantage for Player2";
                }

                return Player1.Score.ToString() + " - " + Player2.Score.ToString();
            }
        }

        public TennisGame() {
            Player1 = new Player();
            Player2 = new Player();
        }
    }

    public enum TennisScore {
        Love,
        Fifteen,
        Thirty,
        Fourty,
        Advantage,
        Game
    }
}
