namespace BattleFieldGame.Contracts
{
    public interface IRandomNumberGenerator
    {
        int Next(int min, int max);
    }
}