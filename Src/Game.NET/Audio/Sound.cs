using System.IO;

namespace Game.NET
{
    public class Sound : Resource
    {
        public byte[] SoundArray { get; }

        public string FileName { get; }

        public string FileExtension { get; }

        public Sound(byte[] soundArray, string fileName)
        {
            SoundArray = soundArray;
            FileName = fileName;
            FileExtension = Path.GetExtension(fileName);
        }
    }
}
