using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Writer
{
    public class OutputWriter
    {
        public string Write(IReadOnlyList<Player> players)
        {
            string output = string.Empty;
            for (int i = 0; i < players.Count; i++)
            {
                string delimiter = string.Empty;
                if (i > 0)
                {
                    delimiter = " ";
                    var currentWeight = players[i].AnalyzedComboResult.ComboWeight;
                    var prevWeight = players[i - 1].AnalyzedComboResult.ComboWeight;
                    if (currentWeight == prevWeight)
                    {
                        delimiter = "=";
                    }
                }
                output += $"{delimiter}{players[i].EncodedHand}";
            }
            return output;
        }
    }
}
