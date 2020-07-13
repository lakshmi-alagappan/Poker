using System.Linq;

namespace Poker_Hand_Sorter
{
    public class Poker_Game
    {

        // return 1 if player wins, otherwise return 0;
        public static int Judge(string Poker_Hands)
        {
            var cards = Poker_Hands.Split(' ');
            var _player1 = new Poker_Hand(cards.Take(5));
            var _player2 = new Poker_Hand(cards.Skip(5).Take(5));

            if (_player1.Weight.Item1 == _player2.Weight.Item1)
            {
                return _player1.Weight.Item2 >= _player2.Weight.Item2 ? 1 : 0;
            }

            return _player1.Weight.Item1 > _player2.Weight.Item1 ? 1 : 0;
        }
    }
}
