using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface ISong
    {
        int SongId { get; set; }
        string SongName { get; set; }
        string ArtistName { get; set; }
        string ArtistImageUrl { get; set; }

        Task<List<Song>> GetSongsListAsync(string search);



    }
}
