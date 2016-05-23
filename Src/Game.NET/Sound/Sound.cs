using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.NET.Sound
{
    public class Sound : Resource
    {
        public byte[] SoundBytes { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}
