using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbum
    {
        int AlbumId { get; set; }
        string AlbumName { get; set; }
        string AlbumCovertUrl { get; set; }
        string ArtistName { get; set; }
        string ArtistImgUrl { get; set; }



        Task<List<Album>> GetArtistAlbumsAsync(Artist artist);
    }
}
