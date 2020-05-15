using System;
using FootballSimulator.Handlers.Interfaces;

namespace FootballSimulator.Handlers
{
    public class RandomHandler : IRandomHandler
    {
        //keeping a single random in the application ensures maximum randomness
        private readonly Random _random = new Random();

        //expose random functions as needed
        public double NextDouble()
        {
            return _random.NextDouble();
        }

        public int NextInt(int max = int.MaxValue)
        {
            return _random.Next(max);
        }
    }
}
