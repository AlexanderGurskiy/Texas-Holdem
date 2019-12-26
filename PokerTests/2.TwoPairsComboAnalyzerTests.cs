using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Analyzers;
using Poker.Core.Combinations;
using Poker.Core.Comparators;
using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTests
{
    [TestClass]
    public class TwoPairsComboAnalyzerTests
    {
        [TestMethod]
        public void Is_TwoPairsCombo_Test()
        {

            var pairComboAnalyzer = new TwoPairsAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Is_Hight_Pairs_Presented_TwoPairsCombo_Test()
        {

            var pairComboAnalyzer = new TwoPairsAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Ten, CardSuit.Spade),
                new Card(CardRank.Ten, CardSuit.Diamond),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.King, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            var actual = (result as TwoPairsCombo).ComboCards
                .ToList();
            var expected = new List<Card>()
            {
                new Card(CardRank.King, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart),
                new Card(CardRank.Ten, CardSuit.Spade),
                new Card(CardRank.Ten, CardSuit.Diamond),
            };
            Assert.IsTrue(expected.SequenceEqual(actual, new CardEqualityComparer()));
        }


        [TestMethod]
        public void Is_Not_TwoPairsCombo_Test()
        {
            var pairComboAnalyzer = new TwoPairsAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Heart),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Two, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsFalse(result != null);
        }
    }
}
