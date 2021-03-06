﻿using Poker.Core.Analyzers;
using Poker.Core.CardFactory;
using Poker.Core.Comparators;
using Poker.Core.Domain;
using Poker.Core.Reader;
using Poker.Core.Store;
using Poker.Core.Writer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Program
    {
        static void Main()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                ICardRankStore cardRankStore = new CardRankStore();
                ICardSuitStore cardSuitStore = new CardSuitStore();
                PokerFactory holdemFactory = new HoldemFactory(cardRankStore, cardSuitStore);

                var board = holdemFactory.CreateBoard(line.Substring(0, 10));

                var players = new List<Player>();
                var reader = new Reader(line, 10);
                while (reader.Read())
                {
                    var encoded = reader.GetEncodedCards();
                    var player = holdemFactory.CreatePlayer(encoded);
                    players.Add(player);
                }

                var comboAnalyzers = new List<IComboAnalyzer>()
                {
                    new StraightFlushAnalyzer(),
                    new FourOfKindAnalyzer(),
                    new FullHouseAnalyzer(),
                    new FlushAnalyzer(),
                    new StraightAnalyzer(),
                    new ThreeOfKindAnalyzer(),
                    new TwoPairsAnalyzer(),
                    new PairAnalyzer(),
                    new FallbackAnalyzer(),
                };


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
}