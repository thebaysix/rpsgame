//////////////////////////////////////////////////////////
//// RPSMain
//// Author: Luke Whitestone
//// Date: 27 March 2016
//////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RPSMain
    {
        static void Main(string[] args)
        {
            var totWins = 0;
            var totTies = 0;
            var totLosses = 0;

            do
            {
                Throw compThrow = GetCompThrow();

                var inputStr = Console.ReadLine();
                Throw inputThrow;
                switch (inputStr)
                {
                    case "r":
                        inputThrow = Throw.Rock;
                        break;
                    case "p":
                        inputThrow = Throw.Paper;
                        break;
                    case "s":
                        inputThrow = Throw.Scissors;
                        break;
                    default:
                        return;
                }

                var result = DetermineWinner(compThrow, inputThrow);
                Console.WriteLine("Computer: {0}", ThrowToString(compThrow));

                if (result == -1)
                {
                    totLosses++;
                    Console.WriteLine("you lost");
                }
                if (result == 0)
                {
                    totTies++;
                    Console.WriteLine("tie");
                }
                if (result == 1)
                {
                    totWins++;
                    Console.WriteLine("you won!");
                }

                Console.WriteLine("WINS: {0}, LOSSES: {1}, TIES: {2}", totWins, totLosses, totTies);

            } while (true);
        }

        public static Throw GetCompThrow()
        {
            return Throw.Rock; // good ol' rock, nothing beats that!
        }

        // 1 -> player1 wins
        // 0 -> tie
        // -1 -> player2 wins
        public static int DetermineWinner(Throw playerOneThrow, Throw playerTwoThrow)
        {
            if (playerOneThrow == Throw.Rock)
            {
                if (playerTwoThrow == Throw.Rock)
                    return 0; // tie
                else if (playerTwoThrow == Throw.Paper)
                    return 1; // paper covers rock
                else
                    return -1; // rock smashes scissors
            }
            else if (playerOneThrow == Throw.Paper)
            {
                if (playerTwoThrow == Throw.Rock)
                    return 1;
                else if (playerTwoThrow == Throw.Paper)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (playerTwoThrow == Throw.Rock)
                    return -1;
                else if (playerTwoThrow == Throw.Paper)
                    return 1;
                else
                    return 0;
            }
        }

        public static string ThrowToString(Throw throwVar)
        {
            if (throwVar == Throw.Rock)
                return "Rock";
            else if (throwVar == Throw.Paper)
                return "Paper";
            else
                return "Scissors";
        }
    }

    enum Throw
    {
        Rock = 0,
        Paper = 1,
        Scissors = 2,
    }
}
