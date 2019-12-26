using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Combinations
{
    public class FourOfKindCombo : Combo
    {
        public FourOfKindCombo(IReadOnlyList<Card> combo, IReadOnlyList<Card> kickers) 
            : base(combo, kickers)
        {
        }

        public override ComboWeight Weight => ComboWeight.FourOfKind;

        public override bool EqualsTo(ICombo combo)
        {
            if (!base.EqualsTo(combo)) return false;

            var compareCombo = combo as FourOfKindCombo;

            var sourceRank = ComboCards.First().Rank;
            var compareRank = compareCombo.ComboCards.First().Rank;

            return sourceRank == compareRank
                && Kickers.First().Rank == compareCombo.Kickers.First().Rank;
        }

        public override bool GreaterThen(ICombo combo)
        {
            if (base.GreaterThen(combo)) return true;
            if (base.LessThen(combo)) return false;

            var compareCombo = combo as FourOfKindCombo;

            var sourceRank = ComboCards.First().Rank;
            var compareRank = compareCombo.ComboCards.First().Rank;

            if(sourceRank > compareRank) return true;


            return (sourceRank == compareRank) 
                && (Kickers.First().Rank > compareCombo.Kickers.First().Rank);
        }

        public override bool LessThen(ICombo combo)
        {
            return !(EqualsTo(combo) || GreaterThen(combo));
        }
    }
}
