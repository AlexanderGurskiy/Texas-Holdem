using Poker.Core.Domain;
using Poker.Core.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.CardFactory
{
    public abstract class PokerFactory
    {
        private readonly ICardRankStore _cardRankStore;
        private readonly ICardSuitStore _cardSuitStore;
        public PokerFactory(ICardRankStore cardRankStore, ICardSuitStore cardSuitStore)
        {
            _cardRankStore = cardRankStore;
            _cardSuitStore = cardSuitStore;
        }
      
        public abstract IReadOnlyList<Card> CreateBoard(string input);
        public abstract IReadOnlyList<Player> CreatePlayers(string input);

        protected virtual IReadOnlyList<Card> DecodeCards(string encodedInput)
        {           
            var cards = new List<Card>();
            for (int i = 0; i < encodedInput.Length; i = i + 2)
            {
                var rank = encodedInput[i];
                var suit = encodedInput[i + 1];
                var decodedRank = _cardRankStore.GetCardRank(rank);
                var decodedSuit = _cardSuitStore.GetCardSuit(suit);
                var encodedCard = new string(new char[] { rank, suit });
                cards.Add(new Card(decodedRank, decodedSuit, encodedCard));
            }
            return cards;
        }
    }
}
