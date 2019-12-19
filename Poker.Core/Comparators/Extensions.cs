using Poker.Core.Analyzers.Result;
using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core.Comparators
{
    public static class Extensions
    {
        public static bool EqualsTo(this AnalyzedComboResult source, AnalyzedComboResult comparable)
        {
            if (source.ComboWeight != comparable.ComboWeight) return false;

            if (comparable.ComboWeight == ComboWeight.FullHouse)
            {
                var sourcePower = CalculateFullHouseComboPower(source);
                var comparablePower = CalculateFullHouseComboPower(comparable);

                return sourcePower.Item1 == comparablePower.Item1 && sourcePower.Item2 == comparablePower.Item2;
            }
            else
            {
                var sourcePower = CalculateComboPower(source);
                var comparablePower = CalculateComboPower(comparable);
                return sourcePower == comparablePower;
            }
        }

        public static bool GreaterThen(this AnalyzedComboResult source, AnalyzedComboResult comparable)
        {
            if (source.ComboWeight > comparable.ComboWeight) return true;
            if (source.ComboWeight < comparable.ComboWeight) return false;

            if (comparable.ComboWeight == ComboWeight.FullHouse)
            {
                var sourcePower = CalculateFullHouseComboPower(source);
                var comparablePower = CalculateFullHouseComboPower(comparable);


                return sourcePower.Item1 > comparablePower.Item1 ||
                        (
                            sourcePower.Item1 == comparablePower.Item1 &&
                            sourcePower.Item2 > comparablePower.Item2
                        );
            }
            else
            {
                var sourcePower = CalculateComboPower(source);
                var comparablePower = CalculateComboPower(comparable);
                return sourcePower > comparablePower;
            }
        }

        public static bool LessThen(this AnalyzedComboResult source, AnalyzedComboResult comparable)
        {
            return !(source.EqualsTo(comparable) || source.GreaterThen(comparable));
        }


        private static int CalculateComboPower(AnalyzedComboResult result)
        {
            var size = result.ComboWeight == ComboWeight.Straight ? 1 : result.Combo.Count;
            // exclude case when lowest straight card ranks total win.
            // TODO: Weak part - it requires ordered by desc straight combo

            return result.Combo.Take(size).Sum(card => (int)card.Rank);
        }

        /// <summary>
        /// Item1 - three of a king
        /// Item2 - pair
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static Tuple<int, int> CalculateFullHouseComboPower(AnalyzedComboResult result)
        {
            var threeOfKindPower = result.Combo
                  .GroupBy(card => card.Rank)
                  .Where(group => group.Count() == 3)
                  .First()
                  .Max(card => (int)card.Rank);

            var pairPower = result.Combo
                  .GroupBy(card => card.Rank)
                  .Where(group => group.Count() == 2)
                  .First()
                  .Max(card => (int)card.Rank);

            return new Tuple<int, int>(threeOfKindPower, pairPower);
        }
    }
}
