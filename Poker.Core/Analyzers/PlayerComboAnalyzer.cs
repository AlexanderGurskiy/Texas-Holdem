using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Analyzers
{
    public class PlayerComboAnalyzer
    {
        private readonly IReadOnlyList<IComboAnalyzer> _comboAnalyzers;
        private readonly IReadOnlyList<Card> _board;
        public PlayerComboAnalyzer(IReadOnlyList<IComboAnalyzer> comboAnalyzers, IReadOnlyList<Card> board)
        {
            _comboAnalyzers = comboAnalyzers;
            _board = board;
        }

        public void PatchPlayerCombo(Player player)
        {
            foreach(var analyzer in _comboAnalyzers)
            {
                var cards = player.Hand.Concat(_board).ToList();
                var result = analyzer.Analyze(cards);
                if (result != null)
                {
                    player.PatchCombo(result);
                    break;
                }
            }
        }
    }
}
