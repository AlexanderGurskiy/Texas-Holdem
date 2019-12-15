using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Reader
{
    public interface IReader : IDisposable
    {
        bool Read();
        string GetEncodedCards();
    }
}
