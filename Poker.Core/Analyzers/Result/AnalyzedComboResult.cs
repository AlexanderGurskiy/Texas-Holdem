using Poker.Core.Domain;
using System.Collections.Generic;

namespace Poker.Core.Analyzers.Result
{
    public class AnalyzedComboResult
    {
        public bool IsCombo { get; private set; }
        public IReadOnlyList<Card> Combo { get; private set; }
        public ComboWeight ComboWeight { get; private set; }
        private AnalyzedComboResult(bool isCombo, IReadOnlyList<Card> combo, ComboWeight comboWeight)
        {
            IsCombo = isCombo;
            Combo = combo;
            ComboWeight = comboWeight;
        }        

        public static AnalyzedComboResult DefaultResult
        {
            get
            {
                return new AnalyzedComboResult(false, null, ComboWeight.Unknown);
            }
        }

        public static AnalyzedComboResult FromCombo(IReadOnlyList<Card> combo, ComboWeight comboWeight)
        {
            return new AnalyzedComboResult(true, combo, comboWeight);
        }       
    }    
}