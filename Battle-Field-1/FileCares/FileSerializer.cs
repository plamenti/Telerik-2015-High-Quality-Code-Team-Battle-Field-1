namespace BattleFieldGame.FileCares
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using BattleFieldGame.Mementos;

    /// <summary>
    /// Class that serialize and deserialize Memento objects
    /// </summary>
    public class FileSerializer : IFileSerializable
    {
        /// <summary>
        /// Serialize object in binary format
        /// </summary>
        /// <param name="serializableObject">Object that will be serialized</param>
        /// <param name="fileName">Name of binary file</param>
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

        /// <summary>
        /// Deserialize Memento object
        /// </summary>
        /// <param name="fileName">Name of binary file that will be serialized</param>
        /// <returns></returns>
        public Memento DeserializeObject(string fileName)
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