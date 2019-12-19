using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Comparators
{
    public class CardEqualityComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (x is null || y is null) return false;

            return x.Rank == y.Rank && x.Suit == y.Suit;
        }

        public int GetHashCode(Card obj)
        {
            if (obj is null) return 0;

            int hashCodeName = obj.Rank.GetHashCode();
            int hasCodeAge = obj.Suit.GetHashCode();

            return hashCodeName ^ hasCodeAge;
        }
    }
}
