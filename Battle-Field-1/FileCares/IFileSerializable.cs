namespace BattleFieldGame.FileCares
{
    using BattleFieldGame.Mementos;

    public interface IFileSerializable
    {
        void SerializeObject(Memento serializableObject, string fileName);

        Memento DeserializeObject(string fileName);
    }
}