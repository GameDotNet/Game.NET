using NAudio.Wave;

namespace Game.NET.Audio
{
    public interface IAudioPlayer
    {
        WaveStream SoundStream { get; }
        string Extension { get; }
    }
}
