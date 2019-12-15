using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FallbackAnalyzer : IComboAnalyzer
    {
        public ComboWeight Weight => ComboWeight.FallBack;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var combo = cards.OrderByDescending(card => (int)card.Rank).First();
            return AnalyzedComboResult.FromCombo(new List<Card>() { combo }, Weight);
        }
    }
}