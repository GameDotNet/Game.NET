using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Game.NET
{
    //TODO: Id? Talk about that clas and Sound class
    public class AudioPlayer
    {
        public MemoryStream SoundStream { get; }
        public string Extension { get; }

        public AudioPlayer(string resourceName)
        {
            var resourceManager = new ResourceManager(); //TODO: ResourceManager will be some type of singleton in future, so it will be necessary to improve this line
            var sound = resourceManager.Get<Sound>(resourceName);
            SoundStream = new MemoryStream(sound.SoundArray);
            Extension = sound.FileExtension;
        }

        // TODO: Ctor probably will be removed in the future
        public AudioPlayer(Sound sound)
        {
            SoundStream = new MemoryStream(sound.SoundArray);
            Extension = sound.FileExtension;
        }
    }
}
