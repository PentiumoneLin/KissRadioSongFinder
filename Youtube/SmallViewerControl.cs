using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Youtube
{
    public partial class SmallViewerControl : UserControl
    {
        #region Property
        public Video srcVideo 
        {
            get { return m_srcVideo; }
            set
            {
                m_srcVideo = value;
                this.Tag = m_srcVideo;
                SetTitle(m_srcVideo.Title);
                SetUploader(m_srcVideo.Uploader);
                SetViewCount(m_srcVideo.ViewCount);
                m_Title = m_srcVideo.Title;
                m_Uploader = m_srcVideo.Uploader;
                m_viewCount = m_srcVideo.ViewCount;                
                //m_Photo = m_srcVideo.                    
            }
        }

        public Bitmap Photo
        {
            get { return m_Photo; }
            set 
            {
                m_Photo = value;                
            }
        }

        public string Title
        {
            get { return m_Title; }
            set 
            {
                m_Title = value;
                SetTitle(m_Title);
            }
        }

        public string Uploader
        {
            get { return m_Uploader; }
            set 
            {
                m_Uploader = value;
                SetUploader(m_Uploader);
            }
        }

        public int viewCount
        {
            get { return m_viewCount; }
            set
            {
                m_viewCount = value;
                SetViewCount(m_viewCount);
            }
        }
        #endregion

        #region Field
        Video m_srcVideo = null;
        private Bitmap m_Photo = null;
        string m_Title = string.Empty;
        string m_Uploader = string.Empty;
        int m_viewCount = 0;
        #endregion

        public SmallViewerControl()
        {
            InitializeComponent();            
        }

        public void SetPhotoCut(string url)
        {
            if (m_Photo != null)
            {
                //this.VideoCutPictureBox.Image = m_Photo;
                this.VideoCutPictureBox.ImageLocation = url;
                //m_srcVideo.
            }
        }        

        private void SetTitle(string title)
        {
            this.VideoNameTextBox.Text = title;
        }

        private void SetUploader(string uploader)
        {
            this.UploaderLabel.Text = uploader;
        }

        private void SetViewCount(int Count)
        {
            this.ViewCountLabel.Text = Count.ToString();
        }
    }
}
