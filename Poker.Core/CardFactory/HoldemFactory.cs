using System.Collections.Generic;
using Poker.Core.Domain;
using Poker.Core.Store;

namespace Poker.Core.CardFactory
{
    public class HoldemFactory : PokerFactory
    {
        public HoldemFactory(ICardRankStore cardRankStore, ICardSuitStore cardSuitStore) 
            : base(cardRankStore, cardSuitStore)
        {
        }

        public override IReadOnlyList<Card> CreateBoard(string input)
        {            
            return DecodeCards(input);
        }

        public override Player CreatePlayer(string input)
        {
            var hand = DecodeCards(input);
            return new Player(hand);
        }
    }
}
