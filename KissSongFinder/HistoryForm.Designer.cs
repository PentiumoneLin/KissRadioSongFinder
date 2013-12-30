namespace KissSongFinder
{
    partial class HistoryForm
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
            this.HistoryListView = new System.Windows.Forms.ListView();
            this.GetAllButton = new System.Windows.Forms.Button();
            this.TimeLenthComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HistoryListView
            // 
            this.HistoryListView.HideSelection = false;
            this.HistoryListView.Location = new System.Drawing.Point(8, 104);
            this.HistoryListView.Name = "HistoryListView";
            this.HistoryListView.Size = new System.Drawing.Size(368, 448);
            this.HistoryListView.TabIndex = 0;
            this.HistoryListView.UseCompatibleStateImageBehavior = false;
            // 
            // GetAllButton
            // 
            this.GetAllButton.Location = new System.Drawing.Point(8, 72);
            this.GetAllButton.Name = "GetAllButton";
            this.GetAllButton.Size = new System.Drawing.Size(75, 23);
            this.GetAllButton.TabIndex = 1;
            this.GetAllButton.Text = "Get";
            this.GetAllButton.UseVisualStyleBackColor = true;
            this.GetAllButton.Click += new System.EventHandler(this.GetAllButton_Click);
            // 
            // TimeLenthComboBox
            // 
            this.TimeLenthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeLenthComboBox.FormattingEnabled = true;
            this.TimeLenthComboBox.Items.AddRange(new object[] {
            "今日",
            "最近一周",
            "最近一個月",
            "自訂"});
            this.TimeLenthComboBox.Location = new System.Drawing.Point(80, 12);
            this.TimeLenthComboBox.Name = "TimeLenthComboBox";
            this.TimeLenthComboBox.Size = new System.Drawing.Size(121, 20);
            this.TimeLenthComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "選擇長度: ";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Location = new System.Drawing.Point(272, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 88);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(80, 8);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(16, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(8, 40);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(48, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(8, 8);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(48, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeLenthComboBox);
            this.Controls.Add(this.GetAllButton);
            this.Controls.Add(this.HistoryListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Text = "播放歷史";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView HistoryListView;
        private System.Windows.Forms.Button GetAllButton;
        private System.Windows.Forms.ComboBox TimeLenthComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CloseButton;

    }
}