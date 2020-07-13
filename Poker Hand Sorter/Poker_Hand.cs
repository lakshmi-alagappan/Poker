using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker_Hand_Sorter
{
    public class Poker_Hand
    {

            readonly IEnumerable<IPoker_Rank> _poker_ranks = null;
            readonly IEnumerable<string> _cards = null;

            public Poker_Hand(IEnumerable<string> cards)
            {
                if (cards?.Count() != 5)
                {
                    throw new Exception();
                }
                _cards = cards;

                _poker_ranks = new List<IPoker_Rank> {
                new High_Card(cards),
                new One_Pair(cards),
                new Two_Pairs(cards),
                new Three_Of_Kinds(cards),
                new Straight(cards),
                new Flush(cards),
                new Full_House(cards),
                new Four_Of_Kinds(cards),
                new Straight_Flush(cards),
                new Royal_Flush(cards)
            };
            }

            public Tuple<int, double> Weight
            {
                get
                {
                try
                {
                    return _poker_ranks.Select((r, order) => r.Score(order))
                    .Where(r => r.Item2 > 0)
                    .OrderBy(r => r.Item1)
                    .Last();
                }
                catch(Exception e)
                {
                    return new Tuple<int, double>(0, 0);
                }
                }
            }

            public override string ToString()
            {
                return String.Join(" ", _cards.OrderBy(c => Poker_Rank.Mapper[c[0]]).ToArray()) + " : " + this.Weight.Item1 + " : " + this.Weight.Item2;
            }

    }
}
