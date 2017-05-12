using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IAlbum
    {

        string ArtistName { get; set; }
        string ArtistImgUrl { get; set; }


        Task<Album> GetArtistAlbumsAsync(Artist artist);
    }
}
