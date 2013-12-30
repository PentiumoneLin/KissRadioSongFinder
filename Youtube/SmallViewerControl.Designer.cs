namespace Youtube
{
    partial class SmallViewerControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.VideoCutPictureBox = new System.Windows.Forms.PictureBox();
            this.VideoNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UploaderLabel = new System.Windows.Forms.Label();
            this.ViewCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VideoCutPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoCutPictureBox
            // 
            this.VideoCutPictureBox.Location = new System.Drawing.Point(8, 8);
            this.VideoCutPictureBox.Name = "VideoCutPictureBox";
            this.VideoCutPictureBox.Size = new System.Drawing.Size(60, 60);
            this.VideoCutPictureBox.TabIndex = 0;
            this.VideoCutPictureBox.TabStop = false;
            // 
            // VideoNameTextBox
            // 
            this.VideoNameTextBox.Location = new System.Drawing.Point(80, 8);
            this.VideoNameTextBox.Multiline = true;
            this.VideoNameTextBox.Name = "VideoNameTextBox";
            this.VideoNameTextBox.Size = new System.Drawing.Size(112, 24);
            this.VideoNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "上傳者:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "觀看次數:";
            // 
            // UploaderLabel
            // 
            this.UploaderLabel.AutoSize = true;
            this.UploaderLabel.Location = new System.Drawing.Point(128, 40);
            this.UploaderLabel.Name = "UploaderLabel";
            this.UploaderLabel.Size = new System.Drawing.Size(20, 12);
            this.UploaderLabel.TabIndex = 4;
            this.UploaderLabel.Text = "     ";
            // 
            // ViewCountLabel
            // 
            this.ViewCountLabel.AutoSize = true;
            this.ViewCountLabel.Location = new System.Drawing.Point(136, 56);
            this.ViewCountLabel.Name = "ViewCountLabel";
            this.ViewCountLabel.Size = new System.Drawing.Size(20, 12);
            this.ViewCountLabel.TabIndex = 5;
            this.ViewCountLabel.Text = "     ";
            // 
            // SmallViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ViewCountLabel);
            this.Controls.Add(this.UploaderLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VideoNameTextBox);
            this.Controls.Add(this.VideoCutPictureBox);
            this.Name = "SmallViewerControl";
            this.Size = new System.Drawing.Size(200, 75);            
            ((System.ComponentModel.ISupportInitialize)(this.VideoCutPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VideoCutPictureBox;
        private System.Windows.Forms.TextBox VideoNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UploaderLabel;
        private System.Windows.Forms.Label ViewCountLabel;

    }
}
