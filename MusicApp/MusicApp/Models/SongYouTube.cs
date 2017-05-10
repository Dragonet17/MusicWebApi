using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.Models
{
    public class SongYouTube:GetYouTubeVideo,ISongYouTube
    {
        public Song Song { get; set; }


        public async  Task<SongYouTube> ConvertSongToYouTubeSong(Song song)
        {
            SongYouTube songYouTube =  new SongYouTube{Song = song};
            string search = $"{song.ArtistName} {song.SongName}";
            songYouTube.YouTubeVideoUrl = await  GetYouTubeVideoUrl(search);
            return songYouTube;
        }

        
    }
}