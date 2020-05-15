namespace FootballSimulator.Handlers.Interfaces
{
    public interface IRandomHandler
    {
        double NextDouble();
        int NextInt(int max = int.MaxValue);
    }
}
