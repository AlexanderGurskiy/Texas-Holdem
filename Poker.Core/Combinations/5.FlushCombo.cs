using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class FlushCombo : Combo
    {
        public FlushCombo(IReadOnlyList<Card> combo) 
            : base(combo)
        {
        }

        public override ComboWeight Weight => ComboWeight.Flush;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

            return ComboCards.Max(card => card.Rank) == (combo as StraightCombo).ComboCards.Max(card => card.Rank);
        }

        public override bool GreaterThen(ICombo combo)
        {
            if (base.GreaterThen(combo)) return true;
            if (base.LessThen(combo)) return false;

            return ComboCards.Max(card => card.Rank) > (combo as StraightCombo).ComboCards.Max(card => card.Rank);
        }

        public override bool LessThen(ICombo combo)
        {
            return !(EqualsTo(combo) || GreaterThen(combo));
        }
    }
}
