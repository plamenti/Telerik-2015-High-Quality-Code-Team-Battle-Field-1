namespace BattleFieldGame.FileCares
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using BattleFieldGame.Mementos;

    public class FileSerializer
    {
        public void SerializeObject(Memento serializableObject, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                                    fileName,
                                     FileMode.Create,
                                     FileAccess.Write,
                                     FileShare.None);
            formatter.Serialize(stream, serializableObject);
            stream.Close();
        }

        public Memento DeSerializeObject(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                                    fileName,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            Memento obj = (Memento)formatter.Deserialize(stream);
            stream.Close();

            return obj;
        }
    }
}