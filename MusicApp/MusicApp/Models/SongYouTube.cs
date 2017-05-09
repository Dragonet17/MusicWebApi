using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.Models
{
    public class SongYouTube:ISongYouTube
    {
        public Song Song { get; set; }
        public string YouTubeVideoUrl { get; set; }

        private readonly GetYouTubeVideo _getyt = new GetYouTubeVideo();

        public async  Task<SongYouTube> ConvertSongToYouTubeSong(Song song)
        {
            SongYouTube songYouTube =  new SongYouTube{Song = song};
            string search = $"{song.ArtistName} {song.SongName}";
            songYouTube.YouTubeVideoUrl = await  _getyt.GetYouTubeVideoUrl(search);
            return songYouTube;
        }

        
    }
}