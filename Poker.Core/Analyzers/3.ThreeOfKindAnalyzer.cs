using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Analyzers
{
    public class ThreeOfKindAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.ThreeOfKind;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 3);
            if (groups.Count() == 1)
            {
                var combo = groups.First().ToList();
                return AnalyzedComboResult.FromCombo(combo, Weight);
            }
            return AnalyzedComboResult.DefaultResult;
        }
    }
}
