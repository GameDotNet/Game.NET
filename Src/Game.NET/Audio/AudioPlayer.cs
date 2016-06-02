using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.NET.Audio;
using NAudio.Wave;

namespace Game.NET
{
    //TODO: Id? Talk about that class and Sound class
    public class AudioPlayer<T> : IAudioPlayer where T : WaveStream
    {
        public WaveStream SoundStream { get; }
        public string Extension { get; }

        public AudioPlayer(string resourceName)
        {
            var resourceManager = new ResourceManager(); //TODO: ResourceManager will be some type of singleton in future, so it will be necessary to improve this line
            var sound = resourceManager.Get<Sound>(resourceName);
            var memoryStream = new MemoryStream(sound.SoundArray);

            SoundStream = (T)Activator.CreateInstance(typeof(T), memoryStream);
            Extension = sound.FileExtension;
        }

        // TODO: Ctor probably will be removed in the future
        public AudioPlayer(Sound sound)
        {
            var memoryStream = new MemoryStream(sound.SoundArray);
            SoundStream = (T)Activator.CreateInstance(typeof(T), memoryStream);
            Extension = sound.FileExtension;
        }
    }
}
