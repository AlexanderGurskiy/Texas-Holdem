using Poker.Core.Domain;
using System.Collections.Generic;

namespace Poker.Core.Comparators
{
    public class PlayerComboComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x.AnalyzedComboResult.GreaterThen(y.AnalyzedComboResult))
            {
                return 1;
            }
            else if (x.AnalyzedComboResult.LessThen(y.AnalyzedComboResult))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
