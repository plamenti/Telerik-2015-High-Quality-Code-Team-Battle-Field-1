namespace BattleFieldGame.Contracts
{
    public interface IReader
    {
        int ReadSingleNumber();

        int[] ReadCoordinates();
    }
}