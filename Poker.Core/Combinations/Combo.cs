using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Combinations
{
    public abstract class Combo : ICombo
    {       
        public IReadOnlyList<Card> ComboCards { get; private set; }
        public IReadOnlyList<Card> Kickers { get; private set; }
        public abstract ComboWeight Weight { get; }

        public Combo()
        {

        }

        public Combo(IReadOnlyList<Card> combo)
        {
            ComboCards = combo;            
            Kickers = new List<Card>();
        }

        public Combo(IReadOnlyList<Card> combo, IReadOnlyList<Card> kickers)
        {
            ComboCards = combo;           
            Kickers = kickers;
        }

        public virtual bool EqualsTo(ICombo combo)
        {
            return Weight == combo.Weight;
        }

        public virtual bool GreaterThen(ICombo combo)
        {
            return (int)Weight > (int)combo.Weight;
        }

        public virtual bool LessThen(ICombo combo)
        {
            return (int)Weight < (int)combo.Weight;
        }
    }
}
