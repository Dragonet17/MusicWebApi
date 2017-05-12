using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;
using Newtonsoft.Json.Linq;

namespace MusicApp.Models
{
    public class Song :StringOperation, ISong
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImageUrl { get; set; }
        private readonly GetJsonAsync _getJson =new GetJsonAsync();
        public async Task<List<Song>> GetSongsListAsync(string search)
        {
            Uri urladdress =
                new Uri(
                    $"http://ws.audioscrobbler.com/2.0/?method=track.search&track={search}&api_key=f888d5f469cb97bf8a68b72c9c721cbc&format=json");

            var jsons = await _getJson.GetJsonSongsAsync(urladdress);
            var jsonobj = JObject.Parse(jsons);
            var jsonsearch = jsonobj["results"]["trackmatches"]["track"];
            int counter = jsonsearch.ToArray().Length;
            int addC = 0;

            List<Song> songList = new List<Song>();
            if (counter > 10) counter = 10;
            for (int i = 0; i <= counter - 1 + addC; i++)
            {
                Song song = new Song();

                song.SongId = i;

                song.ArtistName = EncodeStringUtf8(jsonsearch[i]["artist"].ToString());

                song.SongName = EncodeStringUtf8(jsonsearch[i]["name"].ToString());

                song.ArtistImageUrl = jsonsearch[i]["image"][3]["#text"].ToString();

                if (song.ArtistImageUrl.IsEmpty())
                    song.ArtistImageUrl =
                        "https://lastfm-img2.akamaized.net/i/u/300x300/300a940c99336f7629444215d14c4dac.png";


                var checkSongTitle = songList.Where(s => s.SongName == song.SongName).ToList();
                if (checkSongTitle.Count > 0)
                    addC = addC + 1;

                else songList.Add(song);
            }
            return songList;
        }
       
    }
}