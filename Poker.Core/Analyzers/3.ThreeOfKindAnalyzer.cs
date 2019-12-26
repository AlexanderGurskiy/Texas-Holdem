using Poker.Core.Combinations;
using Poker.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Analyzers
{
    public class ThreeOfKindAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 3);
            if (groups.Count() == 1)
            {
                var combo = groups.First().ToList();
                var kickers = cards
                  .Where(
                      card => !combo.Any(comboCard => card.Rank == comboCard.Rank && card.Suit == comboCard.Suit)
                  )
                  .OrderByDescending(card => card.Rank)
                  .Take(2)
                  .ToList();
                return new ThreeOfKindCombo(combo, kickers);
            }
            return null;
        }
    }
}
