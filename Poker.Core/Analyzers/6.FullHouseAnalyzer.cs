using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class FullHouseAnalyzer : IComboAnalyzer
    {
        private readonly IComboAnalyzer _threeOfKindAnalyzer;
        public FullHouseAnalyzer()
        {
            _threeOfKindAnalyzer = new ThreeOfKindAnalyzer();
        }
        public ComboWeight Weight => ComboWeight.FullHouse;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var threeOfKindResult = _threeOfKindAnalyzer.Analyze(cards);
            if (threeOfKindResult.IsCombo)
            {
                var pairsGroups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 2);
                if (pairsGroups.Count() >= 1)
                {
                    var combo = pairsGroups
                        .OrderByDescending(group => group.Key)
                        .First()
                        .ToList();
                    var resultCombo = threeOfKindResult.Combo.Concat(combo).ToList();
                    return AnalyzedComboResult.FromCombo(resultCombo, Weight);
                }
            }
            return AnalyzedComboResult.DefaultResult;

        }
    }
}
