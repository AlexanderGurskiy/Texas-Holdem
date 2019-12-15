using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Store
{
    public class CardRankStore : ICardRankStore
    {
        private readonly IDictionary<char, CardRank> _ranks;
        public CardRankStore()
        {
            _ranks = new Dictionary<char, CardRank>
            {
                { 'A', CardRank.Ace },
                { 'K', CardRank.King },
                { 'Q', CardRank.Queen },
                { 'J', CardRank.Jack },
                { 'T', CardRank.Ten },
                { '9', CardRank.Nine },
                { '8', CardRank.Eight },
                { '7', CardRank.Seven },
                { '6', CardRank.Six },
                { '5', CardRank.Five },
                { '4', CardRank.Four },
                { '3', CardRank.Three },
                { '2', CardRank.Two },
            };
        }  

        public CardRank GetCardRank(char ch)
        {
            if (_ranks.ContainsKey(ch))
            {
                return _ranks[ch];
            }
            throw new ApplicationException("message");
        }
    }
}
