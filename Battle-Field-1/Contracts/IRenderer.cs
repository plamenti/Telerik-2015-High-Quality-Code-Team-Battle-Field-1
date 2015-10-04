namespace BattleFieldGame.Contracts
{
    public interface IRenderer
    {
        void RenderPlayfield(IPlayfield playfield);

        void RenderMessage(string message);
    }
}