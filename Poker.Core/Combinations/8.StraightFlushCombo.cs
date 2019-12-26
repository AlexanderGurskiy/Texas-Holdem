using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Combinations
{
    public class StraightFlushCombo : Combo
    {
        public override ComboWeight Weight => ComboWeight.StraightFlush;
    }
}
