using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class FullHouseCombo : Combo
    {
        public FullHouseCombo(IReadOnlyList<Card> combo) 
            : base(combo)
        {
        }

        public override ComboWeight Weight => ComboWeight.FullHouse;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

            var compareCombo = combo as FullHouseCombo;
            var threeSourcePower = ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 3)
                 .Key;            

            var pairSourcePower = ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 2)
                 .Key;

            var threeComparePower = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 3)
                 .Key;

            var pairComparePower = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 2)
                 .Key;

            return (threeSourcePower == threeComparePower) && (pairSourcePower == pairComparePower);
        }

        public override bool GreaterThen(ICombo combo)
        {
            if (base.GreaterThen(combo)) return true;
            if (base.LessThen(combo)) return false;

            var compareCombo = combo as FullHouseCombo;
            var threeSourcePower = ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 3)
                 .Key;

            var pairSourcePower = ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 2)
                 .Key;

            var threeComparePower = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 3)
                 .Key;

            var pairComparePower = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Single(group => group.Count() == 2)
                 .Key;

            if (threeSourcePower > threeComparePower) return true;


            return (threeSourcePower == threeComparePower) && (pairSourcePower > pairComparePower);
        }

        public override bool LessThen(ICombo combo)
        {
            return !(EqualsTo(combo) || GreaterThen(combo));
        }
    }
}
