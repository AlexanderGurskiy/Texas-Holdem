using Poker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Store
{
    public interface ICardSuitStore
    {
        CardSuit GetCardSuit(char ch);
    }
}
