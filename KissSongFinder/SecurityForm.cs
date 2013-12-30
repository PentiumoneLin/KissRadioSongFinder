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
    public partial class SecurityForm : Form
    {
        string TopSecurity = "52720610";

        public bool Permission { get; internal set; }

        public SecurityForm()
        {
            InitializeComponent();
            Permission = false;
            this.textBox1.Text = string.Empty;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == TopSecurity)
            {
                Permission = true;
            }
            this.Close();
        }
    }
}
