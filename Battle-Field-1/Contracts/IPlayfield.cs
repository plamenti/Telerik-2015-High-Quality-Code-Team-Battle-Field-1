namespace BattleFieldGame.Contracts
{
    public interface IPlayfield
    {
        int Size { get; }

        string GetCell(IPosition position);

        string GetCell(int row, int col);

        void SetCell(IPosition position, string symbol);

        void SetCell(int row, int col, string symbol);

        void FillPlayfield(IRandomNumberGenerator rng);
    }
}