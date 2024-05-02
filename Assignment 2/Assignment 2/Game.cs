using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Assignment_2
{
    class SwapPlayer
    {
        private CurrentPlayer[] players;
        public int currentPlayer;


        public SwapPlayer(CurrentPlayer[] players)
        {
            this.players = players;
            this.currentPlayer = 0;
        }

        public void Game() //calculates which players turn it is using Mod
        {
            currentPlayer = (currentPlayer + 1) % players.Length;
        }

        public void PlayCurrentPlayer() //out puts which player is currently playing
        {
            players[currentPlayer].Playing();
        }

    }



    class Game
    {
        public int Dice1;
        public int Dice2;
        private int result { get; set; }
        public string name1;
        public string name2;
        public double integerList1;

        public void SevensOut()
        {
            Die dieValues = new Die();
            string quit = "";



            CurrentPlayer[] players = new CurrentPlayer[] { };

            Console.WriteLine("Do you want to play against the Computer (comp) or another Player (AP)");
            string choice = Console.ReadLine();

            if (choice == "comp")
            {
                Console.WriteLine("Enter a name for player 1: ");
                name1 = Console.ReadLine();

                name2 = "Computer";

                players = new Player[] { new Player { Name = name1 }, new Player { Name = name2 } };
                Console.WriteLine();
            }
            else if (choice == "AP")
            {
                Console.WriteLine("Enter a name for player 1: ");
                name1 = Console.ReadLine();

                Console.WriteLine("Enter a name for player 2: ");
                name2 = Console.ReadLine();

                players = new Player[] { new Player { Name = name1 }, new Player { Name = name2 } };
                Console.WriteLine();
            }

            Player1Score integerList1 = new Player1Score();
            Player2Score integerList2 = new Player2Score();
            SwapPlayer swap = new SwapPlayer(players); //allows the swap class to have the names of the different players

            numberOfplays1 player1Plays = new numberOfplays1();
            numberOfplays2 player2Plays = new numberOfplays2();


            Testing testValues = new Testing();

            while (quit != "quit")
            {
                Console.WriteLine("-----------------------------------------------------------");

                swap.PlayCurrentPlayer();//calculates the current player
                swap.Game();//outputs which player is currently playing

                Dice1 = dieValues.Roll();
                Dice2 = dieValues.Roll();

                result = Dice1 + Dice2;


                Console.WriteLine("Die 1: " + Dice1);
                Console.WriteLine("Die 2: " + Dice2);
                Console.WriteLine("Sum of die: " + result);

                testValues.sevensOut(result); //allows us to check if the result is equal to 7

                int playerNow = swap.currentPlayer;


                if (Dice1 == Dice2)
                {
                    if (players[(playerNow + 1) % players.Length].Name == name1)
                    {
                        integerList1.AddNumbers1(result * 2);
                        player1Plays.AddPlay1(1);
                    }
                    else if (players[(playerNow + 1) % players.Length].Name == name2)
                    {
                        integerList2.AddNumbers2(result * 2);
                        player2Plays.AddPlay2(1);
                    }
                }
                else
                {
                    if (players[(playerNow + 1) % players.Length].Name == name1)
                    {
                        integerList1.AddNumbers1(result);
                        player1Plays.AddPlay1(1);
                    }
                    else if (players[(playerNow + 1) % players.Length].Name == name2)
                    {
                        integerList2.AddNumbers2(result);
                        player2Plays.AddPlay2(1);
                    }
                }

                
                

                var player1score = integerList1.Sum1();
                var player2score = integerList2.Sum2();

                var plays1 = player1Plays.totalPlays1();
                var plays2 = player2Plays.totalPlays2();

                if (players[(playerNow + 1) % players.Length].Name == name1)
                {
                    Console.WriteLine($"{name1} Total score: {player1score}");
                    Console.WriteLine("number of plays: " + plays1);
                    
                }
                else if (players[(playerNow + 1) % players.Length].Name == name2)
                {
                    Console.WriteLine($"{name2} Total score: {player2score}");
                    Console.WriteLine("number of plays: " + plays2);
                    
                }


                
                Console.WriteLine("Press enter to roll again or enter 'quit' to exit: ");
                quit = (Console.ReadLine()).ToLower();
            }

            Player1Score score1 = new Player1Score();
            Player2Score score2 = new Player2Score();
            var playerOneScore = integerList1.Sum1();
            var playerTwoScore = integerList2.Sum2();

            Console.WriteLine("Do you want to know who got the highest score (y/n): ");
            string knowHS = Console.ReadLine().ToLower();


            if (knowHS == "y")
            {
                HighScore winner = new HighScore(); //high score of the game is calculated and displayed
                winner.playerHighScore(name1, name2, (double)playerOneScore, (double)playerTwoScore);
            }

        }



        public void ThreeOrMore()
        {
            string quit = "";

            CurrentPlayer[] players = new CurrentPlayer[] { };

            Console.WriteLine("Do you want to play against the Computer (comp) or another Player (AP)");
            string choice = Console.ReadLine();

            if (choice == "comp")
            {
                Console.WriteLine("Enter a name for player 1: ");
                name1 = Console.ReadLine();

                name2 = "Computer";

                players = new Player[] { new Player { Name = name1 }, new Player { Name = name2 } };
                Console.WriteLine();
            }
            else if (choice == "AP")
            {
                Console.WriteLine("Enter a name for player 1: ");
                name1 = Console.ReadLine();

                Console.WriteLine("Enter a name for player 2: ");
                name2 = Console.ReadLine();

                players = new Player[] { new Player { Name = name1 }, new Player { Name = name2 } };
                Console.WriteLine();
            }

            var list1 = new Player1Score();
            var list2 = new Player2Score();
            SwapPlayer swap = new SwapPlayer(players);

            Testing TOMtestValues = new Testing();

            numberOfplays1 player1Plays = new numberOfplays1();
            numberOfplays2 player2Plays = new numberOfplays2();


            while (quit != "quit")
            {
                Console.WriteLine("-----------------------------------------------------------");

                swap.PlayCurrentPlayer();
                swap.Game();
                List<int> dieorigionalList = new List<int>();

                Die DiceValues = new Die();

                for (int i = 0; i < 5; i++) //gets randomly generated dice rolls
                {
                    dieorigionalList.Add(DiceValues.Roll());
                }

                for (int z = 0; z < dieorigionalList.Count; z++) //adds these to a list
                {
                    Console.WriteLine($"Die {z+1}: {dieorigionalList[z]}");
                }



                List<int> moreThanOneNumber = new List<int>();
                for (int i = 0; i < dieorigionalList.Count; i++) //iterates through list and checks if there are more than one of a number
                {
                    for (int j = i + 1; j < dieorigionalList.Count; j++)
                    {
                        if (dieorigionalList[i] == dieorigionalList[j] && !moreThanOneNumber.Contains(dieorigionalList[i]))
                        {
                            moreThanOneNumber.Add(dieorigionalList[i]); //adds the number that there is more than one of to a different list
                            break;
                        }
                    }
                }


                int counter = 0;
                int number = 0;
                int playerNow = swap.currentPlayer;

                Dictionary<int, int> values = new Dictionary<int, int>();

                foreach (int item in moreThanOneNumber)
                {
                    counter = 0;
                    number = item;
                    for (int i = 0; i < dieorigionalList.Count; i++)
                    {
                        if (item == dieorigionalList[i])
                        {
                            counter++;
                        }
                    }

                    values.Add(item, counter); //adds the number that has more than one of and then the amount of times it appears to a dictionary
                }

                

                if (counter > 0)
                {
                    var maxValue = values.Values.Max();
                    var numOfMax = values.FirstOrDefault(x => x.Value == maxValue);
                    var maxNum = numOfMax.Key;
                    Console.WriteLine($"{maxNum} was rolled {maxValue} times");
                    Console.WriteLine();

                    if (counter == 2)
                    {
                        Console.WriteLine("You rolled a 2-of-a-kind");
                        Console.WriteLine("Would you like to rethrow all or the remaining dice (enter 'all' or 'remaining'): ");
                        string Rethrow = Console.ReadLine();

                        List<int> newdieorigionalList = new List<int>();
                        if (Rethrow == "all")
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                newdieorigionalList.Add(DiceValues.Roll());
                            }

                            for (int z = 0; z < newdieorigionalList.Count; z++)
                            {
                                Console.WriteLine($"Die {z + 1}: {newdieorigionalList[z]}");
                            }


                            List<int> moreThanOneNumberNew = new List<int>();
                            for (int i = 0; i < newdieorigionalList.Count; i++)
                            {
                                for (int j = i + 1; j < newdieorigionalList.Count; j++)
                                {
                                    if (newdieorigionalList[i] == newdieorigionalList[j] && !moreThanOneNumberNew.Contains(newdieorigionalList[i]))
                                    {
                                        moreThanOneNumberNew.Add(newdieorigionalList[i]);
                                        break;
                                    }
                                }
                            }


                            int newcounter = 0;
                            int newnumber = 0;
                            int newplayerNow = swap.currentPlayer;

                            Dictionary<int, int> newvalues = new Dictionary<int, int>();

                            foreach (int item in moreThanOneNumberNew)
                            {
                                newcounter = 0;
                                newnumber = item;
                                for (int i = 0; i < newdieorigionalList.Count; i++)
                                {
                                    if (item == newdieorigionalList[i])
                                    {
                                        newcounter++;
                                    }
                                }

                                newvalues.Add(item, newcounter);
                            }

                            if (newcounter == 3)
                            {
                                if (players[(newplayerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(3);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(newplayerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(3);
                                    player2Plays.AddPlay2(1);
                                }
                            }
                            else if (newcounter == 4)
                            {
                                if (players[(newplayerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(6);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(newplayerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(6);
                                    player2Plays.AddPlay2(1);
                                }

                            }
                            else if (newcounter == 5)
                            {
                                if (players[(newplayerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(12);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(newplayerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(12);
                                    player2Plays.AddPlay2(1);
                                }
                            }
                        }
                        else if (Rethrow == "remaining")
                        {
                            List<int> ReRolllist = new List<int>();
                            int RemainingReroll1 = DiceValues.Roll();
                            int RemainingReroll2 = DiceValues.Roll();
                            int RemainingReroll3 = DiceValues.Roll();
                            ReRolllist.Add(RemainingReroll1);
                            ReRolllist.Add(RemainingReroll2);
                            ReRolllist.Add(RemainingReroll3);

                            Console.WriteLine();
                            Console.WriteLine("Re-roll Die 1: " + RemainingReroll1);
                            Console.WriteLine("Re-roll Die 2: " + RemainingReroll2);
                            Console.WriteLine("Re-roll Die 3: " + RemainingReroll3);

                            int ReRollcounter = 0;
                            for (int i = 0; i < ReRolllist.Count; i++)
                            {
                                if (maxNum == ReRolllist[i])
                                {
                                    ReRollcounter++;
                                }
                            }
                            int newCounter = counter + ReRollcounter;
                            Console.WriteLine($"{maxNum} is found {newCounter} times");


                            if (newCounter == 3)
                            {
                                if (players[(playerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(3);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(playerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(3);
                                    player2Plays.AddPlay2(1);
                                }
                            }
                            else if (newCounter == 4)
                            {
                                if (players[(playerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(6);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(playerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(6);
                                    player2Plays.AddPlay2(1);
                                }

                            }
                            else if (newCounter == 5)
                            {
                                if (players[(playerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(12);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(playerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(12);
                                    player2Plays.AddPlay2(1);
                                }
                            }
                            else
                            {
                                if (players[(playerNow + 1) % players.Length].Name == name1)
                                {
                                    list1.AddNumbers1(0);
                                    player1Plays.AddPlay1(1);
                                }
                                else if (players[(playerNow + 1) % players.Length].Name == name2)
                                {
                                    list2.AddNumbers2(0);
                                    player2Plays.AddPlay2(1);
                                }
                            }
                        }

                    }
                    else if (counter == 3)
                    {
                        if (players[(playerNow + 1) % players.Length].Name == name1)
                        {
                            list1.AddNumbers1(3);
                            player1Plays.AddPlay1(1);
                        }
                        else if (players[(playerNow + 1) % players.Length].Name == name2)
                        {
                            list2.AddNumbers2(3);
                            player2Plays.AddPlay2(1);
                        }
                    }
                    else if (counter == 4)
                    {
                        if (players[(playerNow + 1) % players.Length].Name == name1)
                        {
                            list1.AddNumbers1(6);
                            player1Plays.AddPlay1(1);
                        }
                        else if (players[(playerNow + 1) % players.Length].Name == name2)
                        {
                            list2.AddNumbers2(6);
                            player2Plays.AddPlay2(1);
                        }

                    }
                    else if (counter == 5)
                    {
                        if (players[(playerNow + 1) % players.Length].Name == name1)
                        {
                            list1.AddNumbers1(12);
                            player1Plays.AddPlay1(1);
                        }
                        else if (players[(playerNow + 1) % players.Length].Name == name2)
                        {
                            list2.AddNumbers2(12);
                            player2Plays.AddPlay2(1);
                        }
                    }

                }
                else if (counter == 0)
                {
                    if (players[(playerNow + 1) % players.Length].Name == name1)
                    {
                        list1.AddNumbers1(0);
                        player1Plays.AddPlay1(1);
                    }
                    else if (players[(playerNow + 1) % players.Length].Name == name2)
                    {
                        list2.AddNumbers2(0);
                        player2Plays.AddPlay2(1);
                    }
                }

                

                var score1 = list1.Sum1();
                var score2 = list2.Sum2();

                var plays1 = player1Plays.totalPlays1();
                var plays2 = player2Plays.totalPlays2();

                if (players[(playerNow + 1) % players.Length].Name == name1)
                {
                    Console.WriteLine($"{name1} Total score: {score1}");
                    
                    Console.WriteLine("number of plays: " + plays1);
                }
                else if (players[(playerNow + 1) % players.Length].Name == name2)
                {
                    Console.WriteLine($"{name2} Total score: {score2}");
                    
                    Console.WriteLine("number of plays: " + plays2);
                }

                TOMtestValues.threeOrMore(name1, name2, (int)score1, (int)score2);


                

                Console.WriteLine("Press enter to roll again or enter 'quit' to exit: ");
                quit = (Console.ReadLine()).ToLower();
            }
        }
    }
}
