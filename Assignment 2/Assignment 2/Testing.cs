using System;
using System.Diagnostics;

namespace Assignment_2
{
    class Testing
    {
        public void sevensOut(int result)
        {
            Game sevensOutTesting = new Game();
            int checkResult = result;
            Debug.Assert(checkResult != 7, "Error: sum of die equals 7");

        }

        public void threeOrMore(string player1Name, string player2Name, int score1, int score2)
        {
            Console.WriteLine();

            Player1Score FirstPlayerScore = new Player1Score();

            Player2Score SecondPlayerScore = new Player2Score();

            Debug.Assert(score1 < 20, $"Player {player1Name} WINS! (score: {score1})");
            Debug.Assert(score2 < 20, $"Player {player2Name} WINS!  (score: {score2})");
        }
    }
}
