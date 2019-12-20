using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Analyzers;
using Poker.Core.Comparators;
using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTests
{
    [TestClass]
    public class StraightFlushAnalyzerTests
    {
        [TestMethod]
        public void IsCombo_Test()
        {
            var pairComboAnalyzer = new StraightFlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Jack, CardSuit.Diamond),
                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Diamond),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Diamond)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result.IsCombo);
        }

        [TestMethod]
        public void Compare_Combo_Test()
        {
            var pairComboAnalyzer = new StraightFlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Jack, CardSuit.Diamond),
                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Diamond),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Diamond)
            };
            var result = pairComboAnalyzer.Analyze(cards);

            var expected = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Diamond),
                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Jack, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Diamond)
            };
            Assert.IsTrue(expected.SequenceEqual(result.Combo.ToList(), new CardEqualityComparer()));
        }

        [TestMethod]
        public void Is_Not_Combo_Test()
        {
            var pairComboAnalyzer = new StraightFlushAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Queen, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Diamond),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.King, CardSuit.Diamond)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsFalse(result.IsCombo);
        }
    }
}
