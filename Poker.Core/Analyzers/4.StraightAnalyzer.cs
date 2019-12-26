using System.Collections.Generic;
using System.Linq;
using Poker.Core.Combinations;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class StraightAnalyzer : IComboAnalyzer
    {
        public ICombo Analyze(IReadOnlyList<Card> cards)
        {
            var sortedCards = cards.OrderBy(card => card.Rank).ToList();
            int index = sortedCards.Count() - 1;
            var combo = new List<Card>();

            while (index >= 0 && combo.Count < 5)
            {
                if (!combo.Any() || sortedCards[index].Rank != combo.Last().Rank - 1)
                {
                    combo.Clear();
                }
                combo.Add(sortedCards[index]);
                index--;
            }

            if (combo.Count == 4 && IsLowestStraight(cards))
            {
                var anyAce = cards.First(card => card.Rank == CardRank.Ace);
                combo.Add(anyAce);
            }

            if (combo.Count == 5)
            {
                return new StraightCombo(combo);
            }

            return null;
        }

        private bool IsLowestStraight(IReadOnlyList<Card> cards)
        {
            var ranks = cards.Select(card => card.Rank).ToList();
            return ranks.IndexOf(CardRank.Ace) != -1
                && ranks.IndexOf(CardRank.Two) != -1
                && ranks.IndexOf(CardRank.Three) != -1
                && ranks.IndexOf(CardRank.Four) != -1
                && ranks.IndexOf(CardRank.Five) != -1;
        }
    }
}
