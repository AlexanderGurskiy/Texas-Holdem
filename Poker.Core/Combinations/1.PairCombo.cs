using Poker.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Combinations
{
    public class PairCombo : Combo
    {
        public PairCombo(
                IReadOnlyList<Card> combo,
                IReadOnlyList<Card> kickers
            )
            : base(combo, kickers)
        {
        }

        public override ComboWeight Weight => ComboWeight.Pair;
        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;
          
            var compareCombo = combo as PairCombo;

            var sourceCards = ComboCards
                .Concat(Kickers.OrderByDescending(card => card.Rank))
                .Select(card => card.Rank)
                .ToList();
            var compareCards = compareCombo.ComboCards
                .Concat(compareCombo.Kickers.OrderByDescending(card => card.Rank))
                .Select(card => card.Rank)
                .ToList();

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


            var compareCombo = combo as PairCombo;

            var sourceCards = ComboCards
                .Concat(Kickers.OrderByDescending(card => card.Rank))
                .Select(card => card.Rank)
                .ToList();
            var compareCards = compareCombo.ComboCards
                .Concat(compareCombo.Kickers.OrderByDescending(card => card.Rank))
                .Select(card => card.Rank)
                .ToList();

            bool greater = false;
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
