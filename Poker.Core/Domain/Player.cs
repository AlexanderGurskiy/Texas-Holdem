using Poker.Core.Combinations;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Domain
{
    public class Player
    {
        public Player(IReadOnlyList<Card> hand)
        {
            Hand = hand;       
        }

        public IReadOnlyList<Card> Hand { get; private set; }
        
        public string EncodedHand
        {
            get
            {
                return string.Join("", Hand.Select(card => card.ToString()));
            }
        }

        public void PatchCombo(ICombo combo)
        {
            Combo = combo;
        }

        public ICombo Combo { get; private set; }
    }
}