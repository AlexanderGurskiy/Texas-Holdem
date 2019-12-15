using System.Collections.Generic;
using System.Linq;
using Poker.Core.Domain;

namespace Poker.Core.Analyzers
{
    public class StraightFlushAnalyzer : IComboAnalyzer
    {
        private readonly IComboAnalyzer _flushAnalyzer;
        public StraightFlushAnalyzer()
        {
            _flushAnalyzer = new FlushAnalyzer();
        }
        public ComboWeight Weight => ComboWeight.StraightFlush;

        public AnalyzedComboResult Analyze(IReadOnlyList<Card> cards)
        {
            var result = _flushAnalyzer.Analyze(cards);

            if (result.IsCombo)
            {
                var ranks = result.Combo.Select(card => card.Rank).ToList();
                if (ranks.IndexOf(CardRank.Ace) != -1
                    && ranks.IndexOf(CardRank.King) != -1
                    && ranks.IndexOf(CardRank.Queen) != -1
                    && ranks.IndexOf(CardRank.Jack) != -1
                    && ranks.IndexOf(CardRank.Ten) != -1
                    )
                {
                    return AnalyzedComboResult.FromCombo(result.Combo, Weight);
                }
            }
            return AnalyzedComboResult.DefaultResult;
        }
    }
}
