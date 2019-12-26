using Poker.Core.Domain;
using System.Collections.Generic;

namespace Poker.Core.Comparators
{
    public class PlayerComboComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x.Combo.GreaterThen(y.Combo))
            {
                return 1;
            }
            else if (x.Combo.LessThen(y.Combo))
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
