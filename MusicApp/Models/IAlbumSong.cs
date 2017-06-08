using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbumSong
    {
        string AlbumArtistName { get; set; }
        string AlbumName { get; set; }
        string AlbumCovertUrl { get; set; }
        string AlbumArtistImagetUrl { get; set; }
        
        Task<AlbumSong> GetAlbumSongs(Album album,int id);

    }
}
