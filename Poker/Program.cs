using Poker.Core.Analyzers;
using Poker.Core.CardFactory;
using Poker.Core.Comparators;
using Poker.Core.Domain;
using Poker.Core.Store;
using Poker.Core.Writer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {            
            
            ICardRankStore cardRankStore = new CardRankStore();
            ICardSuitStore cardSuitStore = new CardSuitStore();
            PokerFactory holdemFactory = new HoldemFactory(cardRankStore, cardSuitStore);

            var board = holdemFactory.CreateBoard(args.First());

            var players = new List<Player>();

            foreach (var arg in args.Skip(1))
            {
                var player = holdemFactory.CreatePlayer(arg);
                players.Add(player);
            }
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

            players.Sort(new PlayerComboComparer());


            string output = new OutputWriter().Write(players);
            Console.WriteLine(output);

        }
    }
}