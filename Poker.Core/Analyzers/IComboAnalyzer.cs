using Poker.Core.Combinations;
using Poker.Core.Domain;
using System.Collections.Generic;

namespace Poker.Core.Analyzers
{
    public interface IComboAnalyzer
    {       
        ICombo Analyze(IReadOnlyList<Card> cards);
    }
}
