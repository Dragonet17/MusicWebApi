using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface ISongYouTube
    {
         Song Song { get; set; }
         string YouTubeVideoUrl { get; set; }

        Task<SongYouTube> ConvertSongToYouTubeSong(Song song);
    }
}
