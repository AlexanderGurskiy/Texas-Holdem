using Poker.Core.Analyzers;
using Poker.Core.CardFactory;
using Poker.Core.Domain;
using Poker.Core.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "4cKs4h8s7s Ad4s Ac4d As9s KhKd 5d6d";
            ICardRankStore cardRankStore = new CardRankStore();
            ICardSuitStore cardSuitStore = new CardSuitStore();
            PokerFactory holdemFactory = new HoldemFactory(cardRankStore, cardSuitStore);

            var board = holdemFactory.CreateBoard(input);
            var players = holdemFactory.CreatePlayers(input);

            var comboAnalyzers = new List<IComboAnalyzer>()
            {
                new FallbackAnalyzer(),
                new PairAnalyzer(),
                new TwoPairsAnalyzer(),
                new ThreeOfKindAnalyzer(),
                new StraightAnalyzer(),
                new FlushAnalyzer(),
                new FullHouseAnalyzer(),
                new FourOfKindAnalyzer(),
                new StraightFlushAnalyzer(),
            }
            .OrderByDescending(analyzer => analyzer.Weight)
            .ToList();

            var playerComboAnalyzer = new PlayerComboAnalyzer(comboAnalyzers, board);

            foreach (var player in players)
            {
                playerComboAnalyzer.PatchPlayerCombo(player);
            }

            var sortedPlayers = players
                .OrderBy(player => player.AnalyzedComboResult.ComboWeight)
                .ToList();

            string output = string.Empty;
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                string delimiter = string.Empty;
                if (i > 0)
                {
                    delimiter = " ";
                    var currentWeight = sortedPlayers[i].AnalyzedComboResult.ComboWeight;
                    var prevWeight = sortedPlayers[i - 1].AnalyzedComboResult.ComboWeight;
                    if (currentWeight == prevWeight)
                    {
                        delimiter = "=";
                    }
                }
                output += $"{delimiter}{sortedPlayers[i].EncodedHand}";
            }

            Console.ReadLine();
        }
    }
}
