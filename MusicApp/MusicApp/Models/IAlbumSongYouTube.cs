using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbumSongYouTube
    {
        int SongId { get; set; }
        string SongName { get; set; }
        string ArtistName { get; set; }
        string AlbumCovertUrl { get; set; }
        string YouTubeVideoUrl { get; set; }


        Task<AlbumSongYouTube> ConvertAlbumSongToYouTubeAlbumSong(AlbumSong albumsong,int id);
    }
}
