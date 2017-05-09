using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MusicApp.Models
{
    public class Album : StringOperation, IAlbum
    {

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumCovertUrl { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImgUrl { get; set; }


        private readonly GetJsonAsync _getJson = new GetJsonAsync();

        public async Task<List<Album>> GetArtistAlbumsAsync(Artist artist)
        {
            Uri urladdress =
                new Uri(
                    $"http://ws.audioscrobbler.com/2.0/?method=artist.gettopalbums&artist={artist.ArtistName}&api_key=f888d5f469cb97bf8a68b72c9c721cbc&format=json");

            var jsons = await _getJson.GetJsonSongsAsync(urladdress);

            var jsonobj = JObject.Parse(jsons);
            var jsonsearch = jsonobj["topalbums"]["album"];
            int counter = jsonsearch.ToArray().Length;


            List<Album> albums = new List<Album>();
            if (counter > 10) counter = 10;
            for (int i = 0; i <= counter - 1; i++)
            {
                Album album = new Album();
                album.AlbumId = i;
                album.ArtistName = artist.ArtistName;

                album.AlbumName = EncodeStringUtf8(jsonsearch[i]["name"].ToString());

                album.AlbumCovertUrl = EncodeStringUtf8(jsonsearch[i]["image"][3]["#text"].ToString());
                album.ArtistImgUrl = artist.ArtistImgUrl;
                albums.Add(album);

            }

            return albums;
        }
    }
}