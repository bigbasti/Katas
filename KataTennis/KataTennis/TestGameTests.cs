using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TennisGame;

namespace KataTennis {
    [TestClass]
    public class TestGameTests {

        [TestMethod]
        public void  New_Game_Creates_With_Player_Scores_0_0() {
            var sut = new TennisGame.TennisGame();

            Assert.IsNotNull(sut);
            Assert.AreEqual(TennisScore.Love, sut.Player1.Score);
            Assert.AreEqual(TennisScore.Love, sut.Player2.Score);
        }

        [TestMethod]
        public void When_Player_Scores_Score_Is_Increased() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2);

            Assert.AreEqual(TennisScore.Fifteen, sut.Player1.Score);
            Assert.AreEqual(TennisScore.Love, sut.Player2.Score);
        }

        [TestMethod]
        public void When_Player1_Score_Is_Fourty_And_Scores_And_Has_1_Point_Lead_He_Wins() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30

            sut.Player1.ScorePointAgainst(sut.Player2); // Game - 30 <- Should be

            Assert.AreEqual(TennisScore.Game, sut.Player1.Score);
        }

        [TestMethod]
        public void When_Player1_Has_Advantage_And_Scores_He_Wins() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40

            sut.Player1.ScorePointAgainst(sut.Player2); // Adv - 40 
            sut.Player1.ScorePointAgainst(sut.Player2); // Game - 40

            Assert.AreEqual(TennisScore.Game, sut.Player1.Score);
        }

        [TestMethod]
        public void When_Player1_Has_Advantage_And_Player2_Scores_Game_Is_Set_To_Duece() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40

            sut.Player1.ScorePointAgainst(sut.Player2); // Adv - 40 
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40

            Assert.AreEqual(TennisScore.Fourty, sut.Player1.Score);
            Assert.AreEqual(TennisScore.Fourty, sut.Player2.Score);
        }

        [TestMethod]
        public void When_A_Player_Wins_No_Scores_Are_Counted_Anymore() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40

            sut.Player1.ScorePointAgainst(sut.Player2); // Adv - 40 
            sut.Player1.ScorePointAgainst(sut.Player2); // Game - 40

            sut.Player1.ScorePointAgainst(sut.Player2); // Game - 40
            sut.Player2.ScorePointAgainst(sut.Player1); // Game - 40

            Assert.AreEqual(TennisScore.Game, sut.Player1.Score);
            Assert.AreEqual(TennisScore.Fourty, sut.Player2.Score);
        }

        [TestMethod]
        public void GameState_Returns_Duece_When_Botg_Players_Have_Score_Of_40() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40

            Assert.AreEqual("Duece", sut.GameState);
        }

        [TestMethod]
        public void GameState_Returns_Game_For_Player1_When_Player1_Wins() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // Game - 40

            Assert.AreEqual("Game for Player1", sut.GameState);
        }

        [TestMethod]
        public void GameState_Returns_Advantage_For_Player1_When_Player1_Has_Advantage() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15
            sut.Player2.ScorePointAgainst(sut.Player1); // 30 - 30
            sut.Player1.ScorePointAgainst(sut.Player2); // 40 - 30
            sut.Player2.ScorePointAgainst(sut.Player1); // 40 - 40
            sut.Player1.ScorePointAgainst(sut.Player2); // Adv - 40

            Assert.AreEqual("Advantage for Player1", sut.GameState);
        }

        [TestMethod]
        public void GameState_Returns_Game_Score_When_No_Spacial_State_Is_Set() {
            var sut = new TennisGame.TennisGame();

            sut.Player1.ScorePointAgainst(sut.Player2); // 15 - 0
            sut.Player2.ScorePointAgainst(sut.Player1); // 15 - 15
            sut.Player1.ScorePointAgainst(sut.Player2); // 30 - 15

            Assert.AreEqual("Thirty - Fifteen", sut.GameState);
        }

    }
}
