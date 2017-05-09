using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbumSongYouTube
    {
         AlbumSong AlbumSong { get; set; }
         string YouTubeVideoUrl { get; set; }

        Task<AlbumSongYouTube> ConvertAlbumSongToYouTubeAlbumSong(AlbumSong albumsong,int id);
    }
}
