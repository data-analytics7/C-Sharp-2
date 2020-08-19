namespace MapApplication
{
    partial class ChoiceForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tweetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookstatusupdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracklogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddEvent_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Inspect Event";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.InspectEvent_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tweetToolStripMenuItem,
            this.facebookstatusupdateToolStripMenuItem,
            this.photoToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.tracklogToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // tweetToolStripMenuItem
            // 
            this.tweetToolStripMenuItem.Name = "tweetToolStripMenuItem";
            this.tweetToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.tweetToolStripMenuItem.Text = "tweet";
            this.tweetToolStripMenuItem.Click += new System.EventHandler(this.TweetToolStripMenuItem_Click);
            // 
            // facebookstatusupdateToolStripMenuItem
            // 
            this.facebookstatusupdateToolStripMenuItem.Name = "facebookstatusupdateToolStripMenuItem";
            this.facebookstatusupdateToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.facebookstatusupdateToolStripMenuItem.Text = "facebook-status-update";
            this.facebookstatusupdateToolStripMenuItem.Click += new System.EventHandler(this.FacebookstatusupdateToolStripMenuItem_Click);
            // 
            // photoToolStripMenuItem
            // 
            this.photoToolStripMenuItem.Name = "photoToolStripMenuItem";
            this.photoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.photoToolStripMenuItem.Text = "photo";
            this.photoToolStripMenuItem.Click += new System.EventHandler(this.PhotoToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.videoToolStripMenuItem.Text = "video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.VideoToolStripMenuItem_Click);
            // 
            // tracklogToolStripMenuItem
            // 
            this.tracklogToolStripMenuItem.Name = "tracklogToolStripMenuItem";
            this.tracklogToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.tracklogToolStripMenuItem.Text = "tracklog";
            this.tracklogToolStripMenuItem.Click += new System.EventHandler(this.TracklogToolStripMenuItem_Click);
            // 
            // ChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 98);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ChoiceForm";
            this.Text = "ChoiceForm";
            this.Load += new System.EventHandler(this.ChoiceForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tweetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookstatusupdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tracklogToolStripMenuItem;
    }
}