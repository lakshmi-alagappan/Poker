using System;
using System.IO;

namespace Poker_Hand_Sorter
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = File.OpenText("poker-hands.txt"))
            {
                var line = reader.ReadLine();
                var player1_wins = 0;
                var player2_wins = 0;

                while (line != null)
                {
                    Console.WriteLine(line);
                    if (Poker_Game.Judge(line) == 1)
                    {
                        Console.WriteLine(":player1");
                        player1_wins++;
                    }
                    else
                    {
                        Console.WriteLine(":Player2");
                        player2_wins++;
                    }
                    line = reader.ReadLine();
                }

                Console.WriteLine("Player 1 wins");
                Console.WriteLine(player1_wins);
                Console.WriteLine("Player 2 wins");
                Console.WriteLine(player2_wins);

                Console.WriteLine("Hello World!");
            }
        }
    }
}
