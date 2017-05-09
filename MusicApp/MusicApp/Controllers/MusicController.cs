using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Http;
using MusicApp.Cache;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class MusicController : ApiController
    {
        private MemoryCacher _cache = new MemoryCacher();
        public async Task<IEnumerable<Song>> GetSongs(string search)
        {
            ISong song = new Song();
            var songs = await song.GetSongsListAsync(search);
           
            _cache.Add(MemoryCacher.DateToCache.Songs.ToString(), songs, DateTimeOffset.UtcNow.AddMinutes(30));
            return songs.AsEnumerable();
        }

        [HttpGet]
        public  Song ChooseSong(int id)
        {
            var songs = (List<Song>)_cache.GetValue(MemoryCacher.DateToCache.Songs.ToString());
            var song = songs?.Find(s => s.SongId == id);
            return song;
        }
    }
}
