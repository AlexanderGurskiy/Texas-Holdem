using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Combinations
{
    public interface ICombo
    {
        ComboWeight Weight { get; }
        bool EqualsTo(ICombo combo);
        bool GreaterThen(ICombo combo);
        bool LessThen(ICombo combo);
    }
}
