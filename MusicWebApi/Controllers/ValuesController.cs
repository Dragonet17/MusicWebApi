using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AudioRimacPlayer.Models;

namespace MusicWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        private List<JsonSong> _jsonSongs = new List<JsonSong>();

        public async Task<IEnumerable<JsonSong>> GetSongs(string search)
        {
            List<JsonSong> jsonSongs = new List<JsonSong>();
            int id = 0;

            IEnumerable<Song> songs = new List<Song>();
            songs = await Song.GetSongsListAsync(search);
            foreach (var item in songs)
            {
                id++;
                JsonSong jsonSong = new JsonSong
                {
                    Id = id,
                    SongName = item.SongName,
                    ArtistName = item.ArtistName,
                    ImgUrl = item.ArtistImagetUrl,


                };
                jsonSongs.Add(jsonSong);

            }
            _jsonSongs = jsonSongs;
            return jsonSongs.AsEnumerable();
        }

        //GET api/values/5
        [HttpGet]
        public async Task<JsonSong> ChooseSong(string search,int id)
        {
            var songs =await GetSongs(search);


            var jsonSong = songs.ToList().Find(s => s.Id == id);
            return jsonSong;
        }

        //POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
