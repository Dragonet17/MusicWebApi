using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbumSong
    {
        string ArtistName { get; set; }
        string Name { get; set; }
        string CovertUrl { get; set; }
        string ArtistImagetUrl { get; set; }
        
        Task<AlbumSong> GetAlbumSongs(Album album,int id);

    }
}
