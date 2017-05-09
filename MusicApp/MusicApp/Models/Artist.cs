using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;
using Newtonsoft.Json.Linq;

namespace MusicApp.Models
{
    public class Artist : StringOperation, IArtist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImgUrl { get; set; }

        private readonly GetJsonAsync _getJson = new GetJsonAsync();

        public async Task<List<Artist>> GetArtistsAsync(string search)
        {
            Uri urladdress =
                new Uri(
                    $"http://ws.audioscrobbler.com/2.0/?method=artist.search&artist={search}&api_key=f888d5f469cb97bf8a68b72c9c721cbc&format=json");

            var jsons = await _getJson.GetJsonSongsAsync(urladdress);
            var jsonobj = JObject.Parse(jsons);
            var jsonsearch = jsonobj["results"]["artistmatches"]["artist"];
            int counter = jsonsearch.ToArray().Length;
            int addC = 0;

            List<Artist> artistsList = new List<Artist>();
            if (counter > 10) counter = 10;
            for (int i = 0; i <= counter - 1 + addC; i++)
            {


                Artist artist = new Artist();

                artist.ArtistId = i;
                artist.ArtistName = EncodeStringUtf8(jsonsearch[i]["name"].ToString());



                artist.ArtistImgUrl = jsonsearch[i]["image"][3]["#text"].ToString();

                if (artist.ArtistImgUrl.IsEmpty())
                    artist.ArtistImgUrl =
                        "https://lastfm-img2.akamaized.net/i/u/300x300/300a940c99336f7629444215d14c4dac.png";

                var checkArtist = artistsList.Where(s => s.ArtistName == artist.ArtistName).ToList();
                if (checkArtist.Count > 0)
                    addC = addC + 1;
                else artistsList.Add(artist);

            }



            return artistsList;
        }
    }
}