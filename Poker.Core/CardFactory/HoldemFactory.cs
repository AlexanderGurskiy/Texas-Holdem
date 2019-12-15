using System.Collections.Generic;
using Poker.Core.Domain;
using Poker.Core.Reader;
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
            string encodedBoard = input.Substring(0, 10);
            return DecodeCards(encodedBoard);
        }

        public override IReadOnlyList<Player> CreatePlayers(string input)
        {
            var players = new List<Player>();
            using (var reader = new StringReader(input, 10))
            {
                while (reader.Read())
                {
                    var hand = base.DecodeCards(reader.GetEncodedCards());                  
                    players.Add(new Player(hand));
                }
            }
            return players;
        }
    }
}
