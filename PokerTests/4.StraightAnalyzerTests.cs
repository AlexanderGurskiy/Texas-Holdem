using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Analyzers;
using Poker.Core.Domain;
using System.Collections.Generic;

namespace PokerTests
{
    [TestClass]
    public class StraightAnalyzerTests
    {
        [TestMethod]
        public void Is_StraightCombo_Test()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result.IsCombo);
        }

        [TestMethod]
        public void Is_Not_StraightCombo_Test()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Nine, CardSuit.Spade),
                new Card(CardRank.Jack, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsFalse(result.IsCombo);
        }

        [TestMethod]
        public void Is_LowestStraightCombo_Test()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Jack, CardSuit.Spade),

                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Ace, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result.IsCombo);
        }
    }
}
