using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Domain
{
    public class Card
    {
        public CardRank Rank { get; private set; }
        public CardSuit Suit { get; private set; }
        private readonly string _encodedFormat;

        public Card(CardRank rank, CardSuit suit, string encodedFormat)
        {
            Rank = rank;
            Suit = suit;
            _encodedFormat = encodedFormat;
        }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            _encodedFormat = string.Empty;
        }

        public override string ToString()
        {
            return _encodedFormat;
        }
    }
}