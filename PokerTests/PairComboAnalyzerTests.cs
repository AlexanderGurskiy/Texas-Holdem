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
    public class PairAnalyzerTests
    {
        [TestMethod]
        public void Is_PairCombo_Test()
        {            
            var pairComboAnalyzer = new PairAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);
            Assert.IsTrue(result.IsCombo);
        }

        [TestMethod]
        public void Compare_PairCombo_Test()
        {
            var pairComboAnalyzer = new PairAnalyzer();
            var cards = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Spade),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Eight, CardSuit.Spade),
                new Card(CardRank.Seven, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Ten, CardSuit.Spade)
            };
            var result = pairComboAnalyzer.Analyze(cards);

            var expected = new List<Card>()
            {
                 new Card(CardRank.Four, CardSuit.Club),
                 new Card(CardRank.Four, CardSuit.Heart),
            };
            Assert.IsTrue(expected.SequenceEqual(result.Combo.ToList(), new CardEqualityComparer()));
        }

        [TestMethod]
        public void Is_Not_PairCombo_Test()
        {
            var pairComboAnalyzer = new PairAnalyzer();
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
            Assert.IsFalse(result.IsCombo);
        }        
    }
}
