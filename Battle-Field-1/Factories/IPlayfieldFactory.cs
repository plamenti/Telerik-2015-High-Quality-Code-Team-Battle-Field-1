namespace BattleFieldGame.Factories
{
    using BattleFieldGame.Playfields;

    public interface IPlayfieldFactory
    {
        Playfield CreatePlayfield(string size);
    }
}