using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FourOfKindAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.FourOfKind;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 4);
            if (groups.Count() == 1)
            {
                var combo = groups.First().ToList();
                return AnalyzedComboResult.FromCombo(combo, Weight);
            }
            return AnalyzedComboResult.DefaultResult;
        }
    }
}
