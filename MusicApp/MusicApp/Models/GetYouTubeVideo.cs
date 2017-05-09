using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Net.Http;


namespace MusicApp.Models
{
    public class GetYouTubeVideo
    {
        public async Task<string> GetYouTubeVideoUrl(string search)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDkS9sfEA6DExEN_N621zEXslxXLTjzbOM",
                ApplicationName = "RimacAudioPlayer"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = $"{search} ";
            searchListRequest.MaxResults = 2;

            var searchListResponse = await searchListRequest.ExecuteAsync();
            var youTubeUrl = searchListResponse.Items.First().Id.VideoId;
            return youTubeUrl;
        }

    }
}