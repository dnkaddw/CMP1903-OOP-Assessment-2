using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class CurrentPlayer
    {
        public string Name { get; set; }
        public int NumberOfPlays {  get; set; }
        protected List<double> PLayerOneScore = new List<double>();
        protected List<double> PLayerTwoScore = new List<double>();

        protected List<int> numOfPlays1 = new List<int>();
        protected List<int> numOfPlays2 = new List<int>();


        public virtual void Playing()
        {
            Console.WriteLine($"{Name}");
        }

        public void AddPlay1(int number)
        {
            numOfPlays1.Add(number);
        }

        public void AddPlay2(int number)
        {
            numOfPlays2.Add(number);
        }

        public void AddNumbers1(double number)
        {
            PLayerOneScore.Add(number);
        }

        public void AddNumbers2(double number)
        {
            PLayerTwoScore.Add(number);
        }

        public virtual int totalPlays1()
        {
            int counter = 0;
            foreach (int number in numOfPlays1)
            {
                counter += number;
            }

            return counter;
        }

        public virtual int totalPlays2()
        {
            int counter = 0;
            foreach (int number in numOfPlays2)
            {
                counter += number;
            }

            return counter;
        }

        public virtual double Sum1()
        {
            double counter = 0;
            foreach (var number in PLayerOneScore)
            {
                counter += number;
            }

            return counter;
        }

        public virtual double Sum2()
        {
            double counter = 0;
            foreach (var number in PLayerTwoScore)
            {
                counter += number;
            }

            return counter;
        }

        public virtual void playerHighScore(string name1, string name2, double score1, double score2)
        {

            if (score1 > score2)
            {
                Console.WriteLine($"{name1} WINS!");
            }
            else if (score2 > score1)
            {
                Console.WriteLine($"{name2} WINS!");
            }
        }

    }


    class Player1Score : CurrentPlayer
    {
        public override double Sum1()
        {
            double initial = 0;

            foreach (var number in PLayerOneScore)
            {
                initial += (int)number;
            }

            return initial;
        }
    }

    class Player2Score : CurrentPlayer
    {
        public override double Sum2()
        {
            double initial = 0;

            foreach (var number in PLayerTwoScore)
            {
                initial += (int)number;
            }

            return initial;
        }
    }

    class Player : CurrentPlayer
    {
        public override void Playing()
        {
            Console.WriteLine($"{Name} is currently playing");
        }
    }

    class numberOfplays1 : CurrentPlayer
    {
        public override int totalPlays1()
        {
            int counter = 0;
            foreach (int number in numOfPlays1)
            {
                counter += number;
            }

            return counter;
        }
    }

    class numberOfplays2 : CurrentPlayer
    {
        public override int totalPlays2()
        {
            int counter = 0;
            foreach (int number in numOfPlays2)
            {
                counter += number;
            }

            return counter;
        }
    }

    class HighScore : CurrentPlayer
    {
        public override void playerHighScore(string name1, string name2, double score1, double score2)
        {
            if (score1 > score2)
            {
                Console.WriteLine();
                Console.WriteLine($"{name1} WINS! \n{name1} Score: {score1} \n{name2} Score: {score2}");
            }
            else if(score2 > score1)
            {
                Console.WriteLine($"{name2} WINS! \n\n{name2} Score: {score2} \n{name1} Score: {score1}");
            }
        }
    }
    
}
