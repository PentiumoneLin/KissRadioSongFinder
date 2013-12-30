using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;

namespace KissSongFinder
{
    public partial class MainForm : Form
    {
        public const string KissRadioWebSide = "http://www.kiss.com.tw/service/songlist/";

        string HtmlDoc = string.Empty;
        bool bShowBalloonTip = true;
        PlayingInfo NowPlaying = new PlayingInfo();
        PlayingInfo LastPlaying = new PlayingInfo();

        HistoryForm viewHistory = new HistoryForm();
        DataBaseControl dbControl = new DataBaseControl();

        System.Timers.Timer MainTimer = new System.Timers.Timer(60000);

        public MainForm()
        {
            InitializeComponent();
            
            GoToWebSide(); //一啟動就先抓一次

            MainTimer.Elapsed += new ElapsedEventHandler(MainTimer_Elapsed);
            MainTimer.Start();            
        }

        void MainTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GoToWebSide();
        }        

        private void GetData()
        {
                          
        }

        public void GoToWebSide() //先瀏覽網頁
        {
            webBrowser1.Navigate(KissRadioWebSide);
        }

        public void GetNowPlaying()
        {
            PlayingInfo pi = new PlayingInfo();
            string nHtml = Regex.Replace(HtmlDoc, "(?is)<.+?>", "");
            string FilterStr = "線上收聽";
            List<string> StringListAfterFilter = new List<string>();
            byte[] byteArray = Encoding.UTF8.GetBytes(nHtml);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        if (str.Contains(FilterStr))
                        {
                            if (str.Contains("現在播放"))
                            {
                                str = str.Replace(" 線上收聽  ", "");
                                str = str.Replace(" 現在播放：", "-");

                                string[] Parts = str.Split('-');

                                pi.PlayingTime = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + Parts[0]);
                                pi.Artist = Parts[1];
                                pi.SongName = Parts[2];

                                CheckChangeMusic(pi);

                                PlayInfoLabel.Text = str;                                
                            }
                            break;
                        }
                    }
                }
            }
        }

        public void CheckChangeMusic(PlayingInfo SourceInfo)
        {
            if (NowPlaying == null)
            {
                NowPlaying = SourceInfo;
                dbControl.InsertPlayingInfo(SourceInfo);
                SetBallonTip();
                return;
            }

            if (NowPlaying != null && LastPlaying != null)
            {
                if (SourceInfo.Artist != NowPlaying.Artist || SourceInfo.SongName != NowPlaying.SongName)
                {
                    LastPlaying = NowPlaying;
                    NowPlaying = SourceInfo;
                    dbControl.InsertPlayingInfo(SourceInfo);
                    SetBallonTip();
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument hd = webBrowser1.Document;
            HtmlDoc = hd.Body.InnerHtml; //取得網頁內容
            GetNowPlaying();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.NowTimeStatusLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetBallonTip();
        }

        private void SetBallonTip()
        {
            if (bShowBalloonTip)
            {
                string str = "歌手:" + NowPlaying.Artist + "\n歌名: " + NowPlaying.SongName;
                MainNotifyIcon.BalloonTipTitle = "現在播放";
                MainNotifyIcon.BalloonTipText = str;
                MainNotifyIcon.ShowBalloonTip(1000);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MainNotifyIcon.Visible = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();                
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.Show();                
            }
        }

        private void MenuSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            switch (tsmi.Text.ToLower())
            { 
                case "open" :
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
                case "normal":
                    bShowBalloonTip = true;
                    break;
                case "meeting":
                    bShowBalloonTip = false;
                    break;
                case "close":
                    Application.Exit();
                    break;
            }
        }

        private void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            if (viewHistory == null)
            {
                viewHistory = new HistoryForm();
            }
            viewHistory.ShowInTaskbar = false;

            viewHistory.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            VideoForm vf = new VideoForm();
            vf.SearchInfo = NowPlaying;
            vf.Show();
        }
    }

    public class PlayingInfo
    {
        public int Index { get; set; }
        public string Artist { get; set; }
        public string SongName { get; set; }
        public DateTime PlayingTime { get; set; }


        public static PlayingInfo DatarowToPlayingInfo(DataRow row)
        {
            if (row.ItemArray.Length != 4)
                throw new Exception("資料長度不符");

            PlayingInfo pi = new PlayingInfo();

            pi.Index = Convert.ToInt32( row.ItemArray[0]);
            pi.PlayingTime = Convert.ToDateTime(row.ItemArray[1]);
            pi.Artist = row.ItemArray[2].ToString();
            pi.SongName = row.ItemArray[3].ToString();

            return pi;
        }
    }
}
