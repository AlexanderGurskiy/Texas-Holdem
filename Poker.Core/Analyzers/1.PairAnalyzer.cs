using System.Collections.Generic;
using System.Linq;
using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class PairAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.Pair;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 2);
            if (groups.Count() == 1)
            {
                var combo = groups.First().ToList();
                return AnalyzedComboResult.FromCombo(combo, Weight);
            }
            return AnalyzedComboResult.DefaultResult;
        }
    }
}