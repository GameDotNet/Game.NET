using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.NET.Audio;
using NAudio.Wave;

namespace Game.NET
{
    public class AudioManager
    {
        private readonly IList<IAudioPlayer> _audioPlayers;
        private readonly WaveOutEvent _waveOut;

        public AudioManager() : this(new WaveOutEvent(), new List<IAudioPlayer>())
        {

        }

        internal AudioManager(WaveOutEvent waveOut, IList<IAudioPlayer> audioPlayers)
        {
            _waveOut = waveOut;
            _audioPlayers = audioPlayers;
        }

        public void AddPlayer(string resourceName, string resourceExtension)  //resourceId in future
        {
            var audioPlayer = CreateAudioPlayer(resourceName, resourceExtension);
            _audioPlayers.Add(audioPlayer);
        }

        // TODO: Method probably will be removed in the future
        public IAudioPlayer AddPlayer(Sound sound)
        {
            var audioPlayer = CreateAudioPlayer(sound);
            _audioPlayers.Add(audioPlayer);

            return audioPlayer;
        }

        public void Play(IAudioPlayer player)
        {
            _waveOut.Init(player.SoundStream);
            _waveOut.Play();
            Thread.Sleep(player.SoundStream.TotalTime);
            player.SoundStream.Seek(0, SeekOrigin.Begin);
            _waveOut.Dispose();
        }

        public void PauseAll()
        {
            _waveOut.Pause();
        }

        private static IAudioPlayer CreateAudioPlayer(string name, string extension)
        {
            switch (extension)
            {
                case ".mp3":
                    return new AudioPlayer<Mp3FileReader>(name);
                case ".wav":
                    return new AudioPlayer<WaveFileReader>(name);
                default:
                    throw new NotSupportedException();
            }
        }

        private static IAudioPlayer CreateAudioPlayer(Sound sound)
        {
            switch (sound.FileExtension)
            {
                case ".mp3":
                    return new AudioPlayer<Mp3FileReader>(sound);
                case ".wav":
                    return new AudioPlayer<WaveFileReader>(sound);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
