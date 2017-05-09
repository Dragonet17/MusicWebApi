using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.Models
{
    public class AlbumSongYouTube:IAlbumSongYouTube
    {
        public AlbumSong AlbumSong { get; set; }
        public string YouTubeVideoUrl { get; set; }

        private readonly GetYouTubeVideo _getyt = new GetYouTubeVideo();

        public async Task<AlbumSongYouTube> ConvertAlbumSongToYouTubeAlbumSong(AlbumSong albumsong,int id)
        {
            AlbumSongYouTube albumSongsYt = new AlbumSongYouTube {AlbumSong = albumsong};
            string search = $"{albumsong.ArtistName} {albumsong.SongNames[id]}";
            albumSongsYt.YouTubeVideoUrl = await _getyt.GetYouTubeVideoUrl(search);
            return albumSongsYt;
        }

    }
}