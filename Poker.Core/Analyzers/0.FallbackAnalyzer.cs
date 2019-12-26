using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FallbackAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var combo = cards.OrderByDescending(card => card.Rank).Take(1).ToList();
            var kickers = cards.OrderByDescending(card => card.Rank).Skip(1).Take(4).ToList();
            return new FallbackCombo(combo, kickers);
        }
    }
}