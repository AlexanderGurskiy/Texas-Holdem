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
    public class FlushComboAnalyzerTests
    {
        [TestMethod]
        public void Is_FlushCombo_Test()
        {
            var pairComboAnalyzer = new FlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ten, CardSuit.Club)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Compare_FlushCombo_Test()
        {
            var pairComboAnalyzer = new FlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Eight, CardSuit.Club),
                new Card(CardRank.Seven, CardSuit.Club),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ten, CardSuit.Club)
            };
            var result = pairComboAnalyzer.Analyze(cards);

            var expected = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.Ten, CardSuit.Club),
                new Card(CardRank.Eight, CardSuit.Club),
                new Card(CardRank.Seven, CardSuit.Club),

            };
            Assert.IsTrue(expected.SequenceEqual((result as FlushCombo).ComboCards.ToList(), new CardEqualityComparer()));
        }

        [TestMethod]
        public void Is_Not_FlushCombo_Test()
        {
            var pairComboAnalyzer = new FlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsFalse(result != null);
        }
    }
}
