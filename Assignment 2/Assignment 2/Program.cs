using System;
using System.Linq;
using System.Xml.Linq;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string chosenGame;
            bool valid = false;


            do
            {
                Console.WriteLine("Do you play \'Sevens Out\' or \'Three Or More\'  Game");
                Console.WriteLine("(Enter SO or TOM to play):");
                chosenGame = Console.ReadLine();
                
                valid = allLetters(chosenGame);
                
                if (!valid)
                {
                    Console.WriteLine("ERROR: wrong format");
                }
            } while (!valid);
            
            Game gme = new Game();
            if (chosenGame == "SO")
            {
                gme.SevensOut();
            }
            else if (chosenGame == "TOM")
            {
                gme.ThreeOrMore();
            }

            Console.ReadLine();
        }

        static bool allLetters(string chosenGame)
        {
            foreach (char character in chosenGame)
            {
                if (!Char.IsLetter(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
