using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IArtist
    {
        int ArtistId { get; set; }
        string ArtistName { get; set; }
        string ArtistImgUrl { get; set; }
        Task<List<Artist>> GetArtistsAsync(string search);

    }
}
