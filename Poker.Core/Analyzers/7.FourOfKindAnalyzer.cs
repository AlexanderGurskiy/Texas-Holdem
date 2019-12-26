using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FourOfKindAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 4);
            if (groups.Count() == 1)
            {
                var combo = groups.First().ToList();
                var kickers = cards
                 .Where(
                     card => !combo.Any(comboCard => card.Rank == comboCard.Rank && card.Suit == comboCard.Suit)
                 )
                 .OrderByDescending(card => card.Rank)
                 .Take(1)
                 .ToList();
                return new FourOfKindCombo(combo, kickers);
            }
            return null;
        }
    }
}
