using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class TwoPairsCombo : Combo
    {
        public TwoPairsCombo(IReadOnlyList<Card> combo, IReadOnlyList<Card> kickers) 
            : base(combo, kickers)
        {
        }

        public override ComboWeight Weight => ComboWeight.TwoPairs;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

            var compareCombo = combo as TwoPairsCombo;
            var source = ComboCards
                 .GroupBy(card => card.Rank)
                 .Select(gr => gr.Key)
                 .OrderByDescending(rank => rank)
                 .ToList();

            var compare = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Select(gr => gr.Key)                 
                 .OrderByDescending(rank => rank)
                 .ToList();

            source.Add(Kickers.First().Rank);
            compare.Add(compareCombo.Kickers.First().Rank);


            bool equals = true;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] != compare[i])
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

            var compareCombo = combo as TwoPairsCombo;
            var source = ComboCards
                 .GroupBy(card => card.Rank)
                 .Select(gr => gr.Key)
                 .OrderByDescending(rank => rank)
                 .ToList();

            var compare = compareCombo.ComboCards
                 .GroupBy(card => card.Rank)
                 .Select(gr => gr.Key)
                 .OrderByDescending(rank => rank)
                 .ToList();

            source.Add(Kickers.First().Rank);
            compare.Add(compareCombo.Kickers.First().Rank);

            bool greater = false;
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] > compare[i])
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
