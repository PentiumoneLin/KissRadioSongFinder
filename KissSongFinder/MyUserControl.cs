using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Youtube;

namespace KissSongFinder
{
    public partial class MyUserControl : SmallViewerControl
    {
        public Youtube.SmallViewerControl MyBase 
        {
            get { return m_MyBase; }
            set
            {
                this.srcVideo = value.srcVideo;
            }
        }

        Youtube.SmallViewerControl m_MyBase = null;

        public MyUserControl()
        {
            InitializeComponent();
        }
    }
}
