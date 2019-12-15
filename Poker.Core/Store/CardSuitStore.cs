using Poker.Core.Domain;
using Poker.Core.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Store
{
    public class CardSuitStore : ICardSuitStore
    {
        private readonly IDictionary<char, CardSuit> _suits;
        public CardSuitStore()
        {
            _suits = new Dictionary<char, CardSuit>
            {
                { 'h', CardSuit.Heart },
                { 'd', CardSuit.Diamond },
                { 'c', CardSuit.Club },
                { 's', CardSuit.Spade }
            };
        }

        public CardSuitStore(IDictionary<char, CardSuit> suits)
        {
            _suits = suits;
        }

        public CardSuit GetCardSuit(char ch)
        {
            if (_suits.ContainsKey(ch))
            {
                return _suits[ch];
            }
            throw new ApplicationException("message");
        }
    }
}
