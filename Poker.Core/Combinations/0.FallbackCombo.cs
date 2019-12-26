using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class FallbackCombo : Combo
    {
        public FallbackCombo(
                IReadOnlyList<Card> combo,
                IReadOnlyList<Card> kickers               
            )
            : base(combo, kickers)
        {
        }

        public override ComboWeight Weight => ComboWeight.FallBack;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

          
            var compareCombo = combo as FallbackCombo;


            var sourceCards = ComboCards.Concat(Kickers).Select(card => card.Rank).OrderByDescending(card => card).ToList();
            var compareCards = compareCombo.ComboCards.Concat(compareCombo.Kickers).Select(card => card.Rank).OrderByDescending(card => card).ToList();
            bool equals = true;
            for (int i = 0; i < sourceCards.Count; i++)
            {
                if (sourceCards[i] != compareCards[i])
                {
                    equals = false;
                    break;
                }
            }
            return equals;
        }

        public override bool GreaterThen(ICombo combo)
        {
            if (base.GreaterThen(combo)) return true;
            if (base.LessThen(combo)) return false;

            bool greater = false;
            var compareCombo = combo as FallbackCombo;


            var sourceCards = ComboCards.Concat(Kickers).Select(card => card.Rank).OrderByDescending(card => card).ToList();
            var compareCards = compareCombo.ComboCards.Concat(compareCombo.Kickers).Select(card => card.Rank).OrderByDescending(card => card).ToList();

            for (int i = 0; i < sourceCards.Count; i++)
            {
                if (sourceCards[i] > compareCards[i])
                {
                    greater = true;
                    break;
                }
            }
            return greater;
        }

        public override bool LessThen(ICombo combo)
        {
            return !(EqualsTo(combo) || GreaterThen(combo));
        }
    }
}
