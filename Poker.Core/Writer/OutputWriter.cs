using Poker.Core.Comparators;
using Poker.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Writer
{
    public class OutputWriter
    {
        public string Write(IReadOnlyList<Player> players)
        {
            string output = string.Empty;
            var equalsList = new List<string>();
            string equalsDelimiter = "=";
            string delimiter = " ";

            output += players[0].EncodedHand;
            for (int i = 1; i < players.Count; i++)
            {
                delimiter = " ";
                if (players[i].AnalyzedComboResult.EqualsTo(players[i - 1].AnalyzedComboResult))
                {
                    delimiter = "=";
                }
                output += $"{delimiter}{players[i].EncodedHand}";
            }

            string sortedOutput = string.Empty;
            foreach(var splited in output.Split(delimiter))
            {
                var sorted = splited.Split(equalsDelimiter).OrderBy(hand => hand);
                sortedOutput += $"{delimiter}{string.Join(equalsDelimiter, sorted)}";
            }

            return sortedOutput.TrimStart();
        }
    }
}
