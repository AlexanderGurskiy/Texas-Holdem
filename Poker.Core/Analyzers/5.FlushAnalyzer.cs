using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FlushAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.Flush;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var groups = cards.GroupBy(card => card.Suit).Where(group => group.Count() >= 5);
            if (groups.Count() == 1)
            {
                var combo = groups.First().OrderByDescending(card => (int)card.Rank).Take(5).ToList();
                return AnalyzedComboResult.FromCombo(combo, Weight);
            }
            return AnalyzedComboResult.DefaultResult;
        }       
    }
}