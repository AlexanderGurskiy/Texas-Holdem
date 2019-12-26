using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class TwoPairsAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 2);
            if (groups.Count() >= 2)
            {
                var combo = groups.OrderByDescending(group => group.Key)
                    .Take(2)
                    .SelectMany(card => card)
                    .ToList();               
                var kickers = cards
                    .Where(
                        card => !combo.Any(comboCard => card.Rank == comboCard.Rank && card.Suit == comboCard.Suit)
                    )
                    .OrderByDescending(card => card.Rank)
                    .Take(1)
                    .ToList();
                return new TwoPairsCombo(combo, kickers);               
            }
            return null;
        }
    }
}
