namespace Poker.Core.Domain
{
    public enum ComboWeight
    {
        Unknown = - 1,
        FallBack = 0,
        Pair = 1,
        TwoPairs = 2,
        ThreeOfKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfKind = 7,
        StraightFlush = 8
    }
}
