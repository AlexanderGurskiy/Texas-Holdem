using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Analyzers;
using Poker.Core.Comparators;
using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerTests
{
    [TestClass]
    public class ComboCompareTests
    {
        [TestMethod]
        public void FullHouses_Are_Not_Equals()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Ace, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsFalse(result1.EqualsTo(result2));
        }

        [TestMethod]
        public void FullHouses_Are_Equals()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsTrue(result1.EqualsTo(result2));
        }

        [TestMethod]
        public void FullHouse_Greater()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Ace, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsTrue(result1.GreaterThen(result2));
        }

        [TestMethod]
        public void FullHouse_Less()
        {
            var pairComboAnalyzer = new FullHouseAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Ace, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Four, CardSuit.Club),
                new Card(CardRank.Four, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.King, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsTrue(result2.LessThen(result1));
        }


        [TestMethod]
        public void Straights_Are_Not_Equals()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {              
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsFalse(result1.EqualsTo(result2));
        }


        [TestMethod]
        public void Straights_Are_Equals()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Eight, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsFalse(result1.EqualsTo(result2));
        }


        [TestMethod]
        public void Straight_Greater()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsTrue(result1.GreaterThen(result2));
        }


        [TestMethod]
        public void Straight_Less()
        {
            var pairComboAnalyzer = new StraightAnalyzer();
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Six, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.Ace, CardSuit.Heart)
            };

            var cards2 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Heart),
                new Card(CardRank.Five, CardSuit.Spade),
                new Card(CardRank.Two, CardSuit.Spade),

                new Card(CardRank.Ace, CardSuit.Club),
                new Card(CardRank.King, CardSuit.Heart)
            };
            var result1 = pairComboAnalyzer.Analyze(cards1);
            var result2 = pairComboAnalyzer.Analyze(cards2);

            Assert.IsTrue(result2.LessThen(result1));
        }
    }
}
