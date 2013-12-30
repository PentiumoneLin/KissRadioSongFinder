using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Youtube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            this.Text = "Searching";
            YouTubeRequestSettings settings = new YouTubeRequestSettings("example app", "AIzaSyBjaQ7To9culOC6LjMXtyFl_o76jR5Jckk", "pentiumone@gmail.com", "52720610");
            YouTubeRequest request = new YouTubeRequest(settings);

            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

            //order results by the number of views (most viewed first)
            query.OrderBy = "viewCount";

            // search for puppies and include restricted content in the search results
            // query.SafeSearch could also be set to YouTubeQuery.SafeSearchValues.Moderate
            query.Query = "puppy";
            query.SafeSearch = YouTubeQuery.SafeSearchValues.None;

            Feed<Video> videoFeed = request.Get<Video>(query);

            Videos = videoFeed.Entries.ToList<Video>();
            this.Text = "Finish";
        }

        List<Video> Videos = new List<Video>();

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (Videos.Count > 0)
            {
                string msgstr = "https://www.youtube.com/v/" + Videos[0].WatchPage.AbsoluteUri.Split('=')[1];
                this.axShockwaveFlash1.Movie = msgstr;
            }
        }
    }
}
