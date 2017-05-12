using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MusicApp.Models
{
    public class AlbumSong:StringOperation,IAlbumSong
    {
        public string ArtistName { get; set; }
        public string ArtistImagetUrl { get; set; }
        public string Name { get; set; }
        public List<AlbumSongName> AlbumSongsNames = new List<AlbumSongName>();
        public string CovertUrl { get; set; }

        private readonly GetJsonAsync _getJson = new GetJsonAsync();

        public async Task<AlbumSong> GetAlbumSongs(Album album,int id)
        {
            string albumName = album.AlbumElementses.Find(a => a.AlbumId == id).AlbumName;
            Uri urladdress =
                new Uri(
                    $"http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=f888d5f469cb97bf8a68b72c9c721cbc&artist={album.ArtistName}&album={albumName}&format=json");

            var jsons = await _getJson.GetJsonSongsAsync(urladdress);
            var jsonobj = JObject.Parse(jsons);
            var jsonsearch = jsonobj["album"];

            int counter = jsonsearch.ToArray().Length;


            AlbumSong albumsong = new AlbumSong
            {
                ArtistName = album.ArtistName,
                Name = albumName,
                CovertUrl = jsonsearch["image"][3]["#text"].ToString(),
                ArtistImagetUrl = album.ArtistImgUrl
            };


            var trackArray = jsonsearch["tracks"]["track"];

            for (int i = 0; i < trackArray.ToArray().Length - 1; i++)
            {
                AlbumSongName albumSongName = new AlbumSongName
                {
                    Id = i,
                    SongName = EncodeStringUtf8(trackArray[i]["name"].ToString())
                };
                albumsong.AlbumSongsNames.Add(albumSongName); 
            }


            return albumsong;
        }
    }

    public class AlbumSongName
    {
        public int Id { get; set; }
        public  string SongName { get; set; }
        
    }
}