using System;

namespace MMALigaSumulation.Shared.FightEngine.Utils
{
    public static class RandomUtils
    {

        private static Random _random = new Random();

        public static int GetFixedRandom(double value)
        {
            if (value < 0)
            {
                return 0;
            }

            int aux = (int)Math.Floor(value);
            double doubleValue = value - aux;
            int range = aux / 2;
            return (int)Math.Round(range + _random.Next(range) + 1 + doubleValue);
        }

        // Overloaded
        public static int GetFixedRandom(int value)
        {
            if (value < 0)
            {
                return 0;
            }

            int range = value / 2;
            return range + _random.Next(range) + 1;
        }

        public static int GetBalancedRandom(int value)
        {
            if (value < 0)
                return 0;

            int sum = 0;
            for (int rounds = 5; rounds > 0; rounds--)
            {
                sum += _random.Next(value);
            }
            return sum / 5;
        }

        public static int GetBalancedRandom(double value)
        {
            if (value < 0)
                return 0;

            int sum = 0;
            int roundValue = (int)Math.Round(value);
            for (int rounds = 5; rounds > 0; rounds--)
            {
                sum += _random.Next(roundValue);
            }
            return sum / 5;
        }
    }

}

