using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Youtube;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;
using Google.GData.Extensions;

namespace KissSongFinder
{
    public partial class VideoForm : Form
    {
        YoutubeControl myYoutube = new YoutubeControl();

        List<Video> Lists = new List<Video>();

        public PlayingInfo SearchInfo 
        {
            get { return m_SearchInfo; }
            set 
            {
                m_SearchInfo = value;

                Search(m_SearchInfo.SongName);
            }
        }

        private void Search(string Key)
        {
            myYoutube.Search(Key);

            Lists = myYoutube.Videos;

            this.MainaxShockwaveFlash.Movie = myYoutube.GetMediaLocation();

            foreach (var view in myYoutube.VideoQuickViews)
            {
                MyUserControl muc = new MyUserControl();
                muc.MyBase = view;
                this.OtherResultFlowLayoutPanel.Controls.Add(muc);
            }
        }


        private PlayingInfo m_SearchInfo = null;
        public VideoForm()
        {
            InitializeComponent();
        }

        private void CurrentSearchButton_Click(object sender, EventArgs e)
        {
            Search(m_SearchInfo.Artist + " " + m_SearchInfo.SongName); 
        }
    }
}
