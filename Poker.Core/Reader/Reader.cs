using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Reader
{
    public class Reader : IReader
    {
        private readonly string _input;
        private int _currentIndex = -1;

        private readonly IList<char> _encodedCards = new List<char>();

        public Reader(string input)
        {
            _input = input;
        }

        public Reader(string input, int skip)
        {
            _input = input;
            _currentIndex = skip;
        }

        public bool Read()
        {
            _encodedCards.Clear();

            if (_currentIndex >= _input.Length) return false;

            while (++_currentIndex < _input.Length && !char.IsWhiteSpace(_input[_currentIndex]))
            {
                _encodedCards.Add(_input[_currentIndex]);
            }

            return true;
        }

        public string GetEncodedCards() => string.Concat(_encodedCards);        
    }
}
