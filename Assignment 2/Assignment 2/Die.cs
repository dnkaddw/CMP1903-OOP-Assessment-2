using System;

namespace Assignment_2
{
    public class Die
    {
        Random rnd = new Random();

        public int Roll()
        {
            int dieRoll = rnd.Next(1, 7);
            return dieRoll;
        }
    }
}
