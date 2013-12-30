using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KissSongFinder
{
    public partial class HistoryForm : Form
    {
         //窗體吸附以後再作...
        DataBaseControl dbControl = new DataBaseControl();

        public HistoryForm()
        {
            InitializeComponent();
            this.HistoryListView.View = View.Details;
            ListViewColumnInitial();
        }

        private void ListViewColumnInitial()
        {
            this.HistoryListView.Columns.Add("編號");
            this.HistoryListView.Columns.Add("時間");
            this.HistoryListView.Columns.Add("歌手");
            this.HistoryListView.Columns.Add("歌名");
        }

        private void GetAllButton_Click(object sender, EventArgs e)
        {
            dbControl.GetAllList();
            Drowlistview(dbControl.dsMain);
        }

        public void Drowlistview(MainDatabaseDataSet Source)
        {
            this.HistoryListView.Items.Clear();
            DataTable dt = Source.dtMusicList;
            foreach (DataRow row in dt.Rows)
            {
                PlayingInfo pi = PlayingInfo.DatarowToPlayingInfo(row);
                ListViewItem lvi = new ListViewItem();

                lvi.Text = pi.Index.ToString();
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, pi.PlayingTime.ToString("HH:mm:ss")));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, pi.Artist));
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, pi.SongName));

                this.HistoryListView.Items.Add(lvi);
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            SecurityForm sf = new SecurityForm();
            sf.Show();
            sf.FormClosed += new FormClosedEventHandler(sf_FormClosed);
        }

        void sf_FormClosed(object sender, FormClosedEventArgs e)
        {
            SecurityForm Tmpform = (SecurityForm)sender;

            if (Tmpform.Permission)
            {
                this.panel1.Visible = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Random Rdn = new Random();

            PlayingInfo pi = new PlayingInfo()
            {
                PlayingTime = DateTime.Now,
                Artist = Rdn.Next().ToString(),
                SongName = Rdn.Next(0, 500).ToString()
            };

            dbControl.InsertPlayingInfo(pi);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }
    }
}
