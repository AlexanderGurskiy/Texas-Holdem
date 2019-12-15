using Poker.Core.Domain;
using System.Collections.Generic;

namespace Poker.Core.Analyzers
{
    public interface IComboAnalyzer
    {
        ComboWeight Weight { get; }
        AnalyzedComboResult Analyze(IReadOnlyList<Card> cards);
    }
}
