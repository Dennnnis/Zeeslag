using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeeslag
{
    static class Sounds
    {
        public static bool allowSound = true;

        static System.Media.SoundPlayer audioPlayer = new System.Media.SoundPlayer();
        static readonly Random rnd = new Random();

        public static void Miss()
        {
            switch(rnd.Next(0,3))
            {
                case 0: audioPlayer.Stream = Properties.Resources.miss1; break;
                case 1: audioPlayer.Stream = Properties.Resources.miss2; break;
                case 2: audioPlayer.Stream = Properties.Resources.miss3; break;
            }
            audioPlayer.Play();
        }

        public static void Hit()
        {
            switch (rnd.Next(0, 4))
            {
                case 0: audioPlayer.Stream = Properties.Resources.hit1; break;
                case 1: audioPlayer.Stream = Properties.Resources.hit2; break;
                case 2: audioPlayer.Stream = Properties.Resources.hit3; break;
                case 3: audioPlayer.Stream = Properties.Resources.hit4; break;
            }
            audioPlayer.Play();
        }
    }
}
