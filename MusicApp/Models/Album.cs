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


        public string ArtistName { get; set; }
        public string ArtistImgUrl { get; set; }
        public List<AlbumElement> AlbumElementses = new List<AlbumElement>();


        private readonly GetJsonAsync _getJson = new GetJsonAsync();

        public async Task<Album> GetArtistAlbumsAsync(Artist artist)
        {
            Uri urladdress =
                new Uri(
                    $"http://ws.audioscrobbler.com/2.0/?method=artist.gettopalbums&artist={artist.ArtistName}&api_key=f888d5f469cb97bf8a68b72c9c721cbc&format=json");

            var jsons = await _getJson.GetJsonSongsAsync(urladdress);

            var jsonobj = JObject.Parse(jsons);
            var jsonsearch = jsonobj["topalbums"]["album"];
            int counter = jsonsearch.ToArray().Length;
            Album album = new Album
            {
                ArtistName = artist.ArtistName,
                ArtistImgUrl = artist.ArtistImgUrl
            };



            if (counter > 10) counter = 10;
            for (int i = 0; i <= counter - 1; i++)
            {
                AlbumElement albumElement = new AlbumElement
                {
                    AlbumId = i,
                    AlbumName = EncodeStringUtf8(jsonsearch[i]["name"].ToString()),
                    AlbumCovertUrl = EncodeStringUtf8(jsonsearch[i]["image"][3]["#text"].ToString())
                };

                album.AlbumElementses.Add(albumElement);

            }

            return album;
        }
    }
}