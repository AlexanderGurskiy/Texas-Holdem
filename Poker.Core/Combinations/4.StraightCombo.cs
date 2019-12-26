using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class StraightCombo : Combo
    {
        public StraightCombo(IReadOnlyList<Card> combo) 
            : base(combo)
        {
        }

        public override ComboWeight Weight => ComboWeight.Straight;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;            

            return ComboCards.First().Rank == (combo as StraightCombo).ComboCards.First().Rank;
        }

        public override bool GreaterThen(ICombo combo)
        {
            if (base.GreaterThen(combo)) return true;
            if (base.LessThen(combo)) return false;

            return ComboCards.First().Rank > (combo as StraightCombo).ComboCards.First().Rank;
        }
        public override bool LessThen(ICombo combo)
        {
            return !(EqualsTo(combo) || GreaterThen(combo));
        }
    }
}
