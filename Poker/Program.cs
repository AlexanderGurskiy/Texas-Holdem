using Poker.Core.Analyzers;
using Poker.Core.CardFactory;
using Poker.Core.Store;
using Poker.Core.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));
            foreach (var line in lines)
            {
                ICardRankStore cardRankStore = new CardRankStore();
                ICardSuitStore cardSuitStore = new CardSuitStore();
                PokerFactory holdemFactory = new HoldemFactory(cardRankStore, cardSuitStore);

                var board = holdemFactory.CreateBoard(line);
                var players = holdemFactory.CreatePlayers(line);

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

                string output = new OutputWriter().Write(sortedPlayers);
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}