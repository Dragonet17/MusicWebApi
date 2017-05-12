using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MusicApp.Models
{
    public class AlbumSongYouTube : GetYouTubeVideo, IAlbumSongYouTube
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumCovertUrl { get; set; }

        public async Task<AlbumSongYouTube> ConvertAlbumSongToYouTubeAlbumSong(AlbumSong albumsong, int id)
        {
            AlbumSongYouTube albumSongsYt = new AlbumSongYouTube
            {
                SongId = 0,
                SongName = (albumsong.AlbumSongsNames.Find(s => s.Id == id).SongName),
                ArtistName = albumsong.ArtistName,
                AlbumCovertUrl = albumsong.CovertUrl
            };


            string search = $"{albumsong.ArtistName} {albumSongsYt.YouTubeVideoUrl}";
            albumSongsYt.YouTubeVideoUrl = await GetYouTubeVideoUrl(search);
            return albumSongsYt;
        }

    }
}