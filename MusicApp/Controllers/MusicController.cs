using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.WebPages;
using MusicApp.Cache;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MusicController : ApiController
    {
        private MemoryCacher _cache = new MemoryCacher();

        [HttpGet]
        public async Task<IEnumerable<Song>> GetSongs(string search)
        {
            ISong song = new Song();
            var songs = await song.GetSongsListAsync(search);

            _cache.ClearCache(MemoryCacher.DateToCache.Songs.ToString());
            _cache.Add(MemoryCacher.DateToCache.Songs.ToString(), songs, DateTimeOffset.UtcNow.AddMinutes(30));

            return songs;
        }

        [HttpGet]
        public async Task<SongYouTube> ChooseSong(int id)
        {
            if (!_cache.IfCacheExsist(MemoryCacher.DateToCache.Songs.ToString())) return null;
            var songs = (List<Song>)_cache.GetValue(MemoryCacher.DateToCache.Songs.ToString());
            var song = songs?.FirstOrDefault(s => s.SongId == id);
            if (song != null)
            {
                SongYouTube songYouTube = new SongYouTube();
                songYouTube = await songYouTube.ConvertSongToYouTubeSong(song);
                _cache.ClearCache(MemoryCacher.DateToCache.ChooseSong.ToString());
                _cache.Add(MemoryCacher.DateToCache.ChooseSong.ToString(), songYouTube, DateTimeOffset.UtcNow.AddMinutes(30));
                return songYouTube;
            }
            return null;
        }

        [HttpGet]
        public  SongYouTube Song()
        {
            if (_cache.IfCacheExsist(MemoryCacher.DateToCache.ChooseSong.ToString()))
            {
                var songYT = (SongYouTube)_cache.GetValue(MemoryCacher.DateToCache.ChooseSong.ToString());
                return songYT;
            }
            return null;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> GetArtists(string search)
        {
            IArtist artist = new Artist();
            var artists = await artist.GetArtistsAsync(search);
           
            _cache.ClearCache(MemoryCacher.DateToCache.Artists.ToString());
            _cache.Add(MemoryCacher.DateToCache.Artists.ToString(), artists, DateTimeOffset.UtcNow.AddMinutes(30));

            return artists;
        }

        [HttpGet]
        public async Task<Album> GetAlbums(int id)
        {
            var artists = (List<Artist>)_cache.GetValue(MemoryCacher.DateToCache.Artists.ToString());
            var artist = artists?.FirstOrDefault(a => a.ArtistId == id);
            if (artist != null)
            {
                IAlbum album = new Album();

                var Album = await album.GetArtistAlbumsAsync(artist);
                _cache.ClearCache(MemoryCacher.DateToCache.Albums.ToString());
                _cache.Add(MemoryCacher.DateToCache.Albums.ToString(), Album, DateTimeOffset.UtcNow.AddMinutes(30));

                return Album;
            }

            return null;
        }
        
        [HttpGet]
        public async Task<AlbumSong> GetAlbumsSongs(int id)
        {
            var albumWithElements = (Album)_cache.GetValue(MemoryCacher.DateToCache.Albums.ToString());

            //var albumWithElements = (Album)_cache.GetValue(MemoryCacher.DateToCache.Albums.ToString());
            //var album = albumWithElements?.     AlbumElementses.FirstOrDefault(a => a.AlbumId == id);
            if (albumWithElements != null)
            {
                IAlbumSong albumSong = new AlbumSong();
                var albumwithSongs = await albumSong.GetAlbumSongs(albumWithElements,id);
                _cache.ClearCache(MemoryCacher.DateToCache.AlbumsSongs.ToString());
                _cache.Add(MemoryCacher.DateToCache.AlbumsSongs.ToString(), albumwithSongs, DateTimeOffset.UtcNow.AddMinutes(30));
                var albumWithSongs = (AlbumSong)_cache.GetValue(MemoryCacher.DateToCache.AlbumsSongs.ToString());

                return albumwithSongs;
            }

            return null;
        }

        [HttpGet]
        public async Task<AlbumSongYouTube> ChooseAlbumSong(int id)
        {
            if (!_cache.IfCacheExsist(MemoryCacher.DateToCache.AlbumsSongs.ToString())) return null;
            var albumWithSongs = (AlbumSong)_cache.GetValue(MemoryCacher.DateToCache.AlbumsSongs.ToString());
            if (albumWithSongs != null)
            {
                IAlbumSongYouTube albumSongYouTube = new AlbumSongYouTube();
                var albumSongYouTubes = await albumSongYouTube.ConvertAlbumSongToYouTubeAlbumSong(albumWithSongs,id);
                _cache.ClearCache(MemoryCacher.DateToCache.ChooseAlbumSong.ToString());
                _cache.Add(MemoryCacher.DateToCache.ChooseAlbumSong.ToString(), albumSongYouTubes, DateTimeOffset.UtcNow.AddMinutes(30));
                return albumSongYouTubes;
            }
            return null;
        }

        [HttpGet]
        public AlbumSongYouTube AlbumSong()
        {
            if (_cache.IfCacheExsist(MemoryCacher.DateToCache.ChooseAlbumSong.ToString()))
            {
                var albumSongYT = (AlbumSongYouTube)_cache.GetValue(MemoryCacher.DateToCache.ChooseSong.ToString());
                return albumSongYT;
            }
            return null;
        }
    }
}
