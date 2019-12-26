using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FlushAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Suit).Where(group => group.Count() >= 5);
            if (groups.Count() == 1)
            {
                var combo = groups.First().OrderByDescending(card => card.Rank).Take(5).ToList();
                return new FlushCombo(combo);
            }
            return null;
        }       
    }
}