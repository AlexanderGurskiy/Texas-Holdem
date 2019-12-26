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
    public class FullHouseAnalyzerTests
    {
        [TestMethod]
        public void Is_FullHouseCombo_Test()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Compare_FullHouseCombo_Test()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };
            var result = pairComboAnalyzer.Analyze(cards);

            var expected = new List<Card>()
            {
                 new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                  new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)

            };
            Assert.IsTrue(expected.SequenceEqual((result as FullHouseCombo).ComboCards.ToList(), new CardEqualityComparer()));
        }

        [TestMethod]
        public void Is_Not_FullHouseCombo_Test()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
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
