using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Youtube
{
    public class YoutubeControl
    {
        YouTubeRequestSettings reqSetting = null;
        YouTubeRequest Request = null;

        public List<Video> Videos = new List<Video>();

        public List<SmallViewerControl> VideoQuickViews 
        {
            get { return m_VideoSmallViews; }
            internal set { m_VideoSmallViews = value; }
        } 

        string m_MediaLocation = string.Empty;

        List<SmallViewerControl> m_VideoSmallViews = null;

        public YoutubeControl()
        {
            reqSetting = new YouTubeRequestSettings("KissSongFinder", YoutubeBase.DeveloperKey);

            Request = new YouTubeRequest(reqSetting);
        }

        public void Search(string SearchKeyWord)
        {
            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

            //order results by the number of views (most viewed first)
            query.OrderBy = "viewCount";

            // search for puppies and include restricted content in the search results
            // query.SafeSearch could also be set to YouTubeQuery.SafeSearchValues.Moderate
            query.Query = SearchKeyWord;
            query.SafeSearch = YouTubeQuery.SafeSearchValues.None;

            Feed<Video> videoFeed = Request.Get<Video>(query);

            Videos = videoFeed.Entries.ToList<Video>();
            CreateVideoControl();
        }

        private void CreateVideoControl()
        {
            if(Videos != null && Videos.Count > 0)
            {
                VideoQuickViews = new List<SmallViewerControl>();
                foreach (var item in Videos)
                {
                    string[] photos = YoutubeBase.GetPhotosOfVideo(item.VideoId);

                    SmallViewerControl svc = new SmallViewerControl();
                    svc.Tag = item;
                    svc.srcVideo = item;
                    svc.SetPhotoCut(photos[0]);
                    VideoQuickViews.Add(svc);
                }
            }
        }

        public string GetMediaLocation()
        {
            if (Videos != null && Videos.Count > 0)            
                return YoutubeBase.GetFeedPlayUrl(Videos[0]);            
            else
                return string.Empty;
        }

    }

    internal class YoutubeBase
    {
        public static string WebBaseString = "https://www.youtube.com/v/";

        public static string PhotoCutWebString = "http://img.youtube.com/vi/"; //+videoid/#.jpg

        public static string DeveloperKey = "AIzaSyBjaQ7To9culOC6LjMXtyFl_o76jR5Jckk";

        public static string GoogleUserName = "tkinww@gmail.com";

        public static string GooglePass = "11792005";

        public static string GetFeedPlayUrl(Video video)
        {
            return WebBaseString + video.VideoId;
        }

        public static string[] GetPhotosOfVideo(string videokey)
        {
            string[] photoWebSides = new string[4];
            for (int i = 0; i < 4; i++)
            {
                photoWebSides[i] = PhotoCutWebString + videokey + "/" + i.ToString() + ".jpg";
            }
            return photoWebSides;
        }
    }
}
