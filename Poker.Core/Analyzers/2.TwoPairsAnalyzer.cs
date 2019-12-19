using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class TwoPairsAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.TwoPairs;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 2);
            if (groups.Count() >= 2)
            {
                var combo = groups.OrderByDescending(group => group.Key)
                    .Take(2)
                    .SelectMany(card => card)
                    .ToList();
                return AnalyzedComboResult.FromCombo(combo, Weight);
            }
            return AnalyzedComboResult.DefaultResult;
        }
    }
}
