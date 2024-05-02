using System;
using System.Linq;
using System.Xml.Linq;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you play \'Sevens Out\' or \'Three Or More\'  Game");
            Console.WriteLine("(Enter SO or TOM to play):");
            string chosenGame = Console.ReadLine();

            bool containsLetter;

            int len = 0;
            while(len<chosenGame.Length)
            {
                containsLetter = Char.IsLetter(chosenGame[len]);
                if (containsLetter == false)
                {
                    Console.WriteLine("Do you play \'Sevens Out\' or \'Three Or More\'  Game");
                    Console.WriteLine("(Enter SO or TOM to play):");
                    chosenGame = Console.ReadLine();
                }
                else if (containsLetter == true)
                {
                    Game gme = new Game();
                    if (chosenGame == "SO")
                    {
                        gme.SevensOut();
                    }
                    else if (chosenGame == "TOM")
                    {
                        gme.ThreeOrMore();
                    }

                }
                len++;
            }
            Console.ReadLine();
        }
    }
}
