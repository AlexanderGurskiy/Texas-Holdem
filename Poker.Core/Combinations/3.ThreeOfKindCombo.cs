using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class ThreeOfKindCombo : Combo
    {
        public ThreeOfKindCombo(IReadOnlyList<Card> combo, IReadOnlyList<Card> kickers) 
            : base(combo, kickers)
        {
        }

        public override ComboWeight Weight => ComboWeight.ThreeOfKind;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

            var compareCombo = combo as ThreeOfKindCombo;

            var sourceRank = ComboCards.Max(card => card.Rank);
            var compareRank = compareCombo.ComboCards.Max(card => card.Rank);

            var sourceCards = Kickers.Select(card => card.Rank).OrderByDescending(rank => rank).ToList();
            var compareCards = compareCombo.Kickers.Select(card => card.Rank).OrderByDescending(rank => rank).ToList();

            sourceCards.Insert(0, sourceRank);
            compareCards.Insert(0, compareRank);

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

            var compareCombo = combo as ThreeOfKindCombo;

            var sourceRank = ComboCards.Max(card => card.Rank);
            var compareRank = compareCombo.ComboCards.Max(card => card.Rank);

            var sourceCards = Kickers.Select(card => card.Rank).OrderByDescending(rank => rank).ToList();
            var compareCards = compareCombo.Kickers.Select(card => card.Rank).OrderByDescending(rank => rank).ToList();

            sourceCards.Insert(0, sourceRank);
            compareCards.Insert(0, compareRank);

            bool greater = false;
            for (int i = 0; i < sourceCards.Count; i++)
            {
                if (sourceCards[i] > compareCards[i])
                {
                    greater = false;
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
