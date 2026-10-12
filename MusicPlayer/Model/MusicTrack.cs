using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Model
{
    public class MusicTrack
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public TimeSpan Duration { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string FormattedDuration => Duration.ToString(@"mm\:ss");
    }
}
