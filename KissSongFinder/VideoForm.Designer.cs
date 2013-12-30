namespace KissSongFinder
{
    partial class VideoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoForm));
            this.MainaxShockwaveFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.OtherResultFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CurrentSearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainaxShockwaveFlash)).BeginInit();
            this.SuspendLayout();
            // 
            // MainaxShockwaveFlash
            // 
            this.MainaxShockwaveFlash.Enabled = true;
            this.MainaxShockwaveFlash.Location = new System.Drawing.Point(8, 40);
            this.MainaxShockwaveFlash.Name = "MainaxShockwaveFlash";
            this.MainaxShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MainaxShockwaveFlash.OcxState")));
            this.MainaxShockwaveFlash.Size = new System.Drawing.Size(552, 512);
            this.MainaxShockwaveFlash.TabIndex = 0;
            // 
            // OtherResultFlowLayoutPanel
            // 
            this.OtherResultFlowLayoutPanel.AutoScroll = true;
            this.OtherResultFlowLayoutPanel.Location = new System.Drawing.Point(568, 40);
            this.OtherResultFlowLayoutPanel.Name = "OtherResultFlowLayoutPanel";
            this.OtherResultFlowLayoutPanel.Size = new System.Drawing.Size(208, 512);
            this.OtherResultFlowLayoutPanel.TabIndex = 1;
            // 
            // CurrentSearchButton
            // 
            this.CurrentSearchButton.Location = new System.Drawing.Point(8, 8);
            this.CurrentSearchButton.Name = "CurrentSearchButton";
            this.CurrentSearchButton.Size = new System.Drawing.Size(75, 23);
            this.CurrentSearchButton.TabIndex = 2;
            this.CurrentSearchButton.Text = "精確搜尋";
            this.CurrentSearchButton.UseVisualStyleBackColor = true;
            this.CurrentSearchButton.Click += new System.EventHandler(this.CurrentSearchButton_Click);
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CurrentSearchButton);
            this.Controls.Add(this.OtherResultFlowLayoutPanel);
            this.Controls.Add(this.MainaxShockwaveFlash);
            this.Name = "VideoForm";
            this.Text = "VideoForm";
            ((System.ComponentModel.ISupportInitialize)(this.MainaxShockwaveFlash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash MainaxShockwaveFlash;
        private System.Windows.Forms.FlowLayoutPanel OtherResultFlowLayoutPanel;
        private System.Windows.Forms.Button CurrentSearchButton;


    }
}