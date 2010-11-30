using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisGame {
    
    public class Player {
        public TennisScore Score { get; private set; }

        public Player() {
            this.Score = TennisScore.Love;
        }

        public void ScorePointAgainst(Player player) {

            if (this.Score == TennisScore.Game || player.Score == TennisScore.Game) {
                return;
            }

            if (player.Score == TennisScore.Fourty && this.Score == TennisScore.Fourty) {
                Score = TennisScore.Advantage;
                return;
            }

            if (player.Score <= TennisScore.Thirty && this.Score == TennisScore.Fourty) {
                Score = TennisScore.Game;
                return;
            }

            if (player.Score == TennisScore.Fourty && this.Score == TennisScore.Advantage) {
                Score = TennisScore.Game;
                return;
            }

            if (player.Score == TennisScore.Advantage && this.Score == TennisScore.Fourty) {
                Score = TennisScore.Fourty;
                player.Score = TennisScore.Fourty;
                return;
            }

            Score++;
        }
    }
}
