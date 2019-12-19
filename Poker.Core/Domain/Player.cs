using Poker.Core.Analyzers;
using Poker.Core.Analyzers.Result;
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

        private AnalyzedComboResult _analyzedComboResult;
        public IReadOnlyList<Card> Hand { get; private set; }
        
        public string EncodedHand
        {
            get
            {
                return string.Join("", Hand.Select(card => card.ToString()));
            }
        }

        public void PatchCombo(AnalyzedComboResult analyzedComboResult)
        {
            _analyzedComboResult = analyzedComboResult;
        }

        public AnalyzedComboResult AnalyzedComboResult
        {
            get
            {
                return _analyzedComboResult ?? AnalyzedComboResult.DefaultResult;
            }
        }
    }
}