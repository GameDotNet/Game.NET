using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Game.NET
{
    public class AudioManager
    {
        public List<AudioPlayer> AudioPlayers { get; set; } = new List<AudioPlayer>();

        private readonly WaveOutEvent _waveOut;

        public AudioManager() : this(new WaveOutEvent())
        {

        }

        internal AudioManager(WaveOutEvent waveOut)
        {
            _waveOut = waveOut;
        }

        public void AddPlayer(string resourceName)
        {
            var audioPlayer = new AudioPlayer(resourceName);
            AudioPlayers.Add(audioPlayer);
        }

        // TODO: Method probably will be removed in the future
        public AudioPlayer AddPlayer(Sound sound)
        {
            var audioPlayer = new AudioPlayer(sound);
            AudioPlayers.Add(audioPlayer);

            return audioPlayer;
        }

        public void Play(AudioPlayer player)
        {
            var reader = CreateAudioReader(player);
            _waveOut.Init(reader);
            _waveOut.Play();
            Thread.Sleep(reader.TotalTime);
            player.SoundStream.Seek(0, SeekOrigin.Begin);
        }

        public void PauseAll()
        {
            _waveOut.Pause();
        }

        private WaveStream CreateAudioReader(AudioPlayer player)
        {
            switch (player.Extension)
            {
                case ".mp3":
                    return new Mp3FileReader(player.SoundStream);
                case ".wav":
                    return new WaveFileReader(player.SoundStream);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
