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
    public class ThreeOfKindComboAnalyzerTests
    {
        [TestMethod]
        public void Is_ThreeOfKindCombo_Test()
        {
            var threOfKindComboAnalyzer = new ThreeOfKindAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Four, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result = threOfKindComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Is_Not_ThreeOfKindCombo_Test()
        {
            var threOfKindComboAnalyzer = new ThreeOfKindAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Ace, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result = threOfKindComboAnalyzer.Analyze(cards);
            Assert.IsFalse(result != null);
        }

        [TestMethod]
        public void Compare_ThreeOfKindCombo_Test()
        {
            var pairComboAnalyzer = new ThreeOfKindAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Four, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result = pairComboAnalyzer.Analyze(cards);

            var expected = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Four, CardSuit.Spade),
            };
            Assert.IsTrue(expected.SequenceEqual((result as ThreeOfKindCombo).ComboCards.ToList(), new CardEqualityComparer()));
        }
    }
}

