using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
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

        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var threeOfKindCombo = _threeOfKindAnalyzer.Analyze(cards);
            if (threeOfKindCombo != null)
            {
                var pairsGroups = cards.GroupBy(card => card.Rank).Where(group => group.Count() == 2);
                if (pairsGroups.Count() >= 1)
                {
                    var combo = pairsGroups
                        .OrderByDescending(group => group.Key)
                        .First()
                        .ToList();
                    var resultCombo = (threeOfKindCombo as ThreeOfKindCombo).ComboCards.Concat(combo).ToList();

                    return new FullHouseCombo(resultCombo);
                }
            }
            return null;

        }
    }
}
