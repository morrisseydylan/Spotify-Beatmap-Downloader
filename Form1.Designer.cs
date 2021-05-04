
namespace Spotify_Beatmap_Downloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.spotifyBttn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.playlistView = new System.Windows.Forms.ListView();
            this.playlistColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.playlistColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.openPlaylistsBttn = new System.Windows.Forms.Button();
            this.songView = new System.Windows.Forms.ListView();
            this.songColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.songColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.songColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.findBeatmapsBttn = new System.Windows.Forms.Button();
            this.downloadAllBttn = new System.Windows.Forms.Button();
            this.downloadSelectedBttn = new System.Windows.Forms.Button();
            this.downloadView = new System.Windows.Forms.ListView();
            this.downloadColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.downloadColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.downloadColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.startDownloadBttn = new System.Windows.Forms.Button();
            this.removeBeatmapBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Spotify Beatmap Downloader. Select your playlist(s) on the left to get" +
    " started.";
            // 
            // spotifyBttn
            // 
            this.spotifyBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spotifyBttn.AutoSize = true;
            this.spotifyBttn.Location = new System.Drawing.Point(609, 12);
            this.spotifyBttn.Name = "spotifyBttn";
            this.spotifyBttn.Size = new System.Drawing.Size(179, 25);
            this.spotifyBttn.TabIndex = 1;
            this.spotifyBttn.Text = "Use a different Spotify account";
            this.spotifyBttn.UseVisualStyleBackColor = true;
            this.spotifyBttn.Click += new System.EventHandler(this.SpotifyBttn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Playlists";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Songs";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Downloads";
            // 
            // playlistView
            // 
            this.playlistView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playlistColumnHeader1,
            this.playlistColumnHeader2});
            this.playlistView.FullRowSelect = true;
            this.playlistView.GridLines = true;
            this.playlistView.HideSelection = false;
            this.playlistView.Location = new System.Drawing.Point(12, 62);
            this.playlistView.Name = "playlistView";
            this.playlistView.Size = new System.Drawing.Size(149, 319);
            this.playlistView.TabIndex = 5;
            this.playlistView.UseCompatibleStateImageBehavior = false;
            this.playlistView.View = System.Windows.Forms.View.Details;
            // 
            // playlistColumnHeader1
            // 
            this.playlistColumnHeader1.Text = "Name";
            this.playlistColumnHeader1.Width = 100;
            // 
            // playlistColumnHeader2
            // 
            this.playlistColumnHeader2.Text = "Size";
            this.playlistColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.playlistColumnHeader2.Width = 45;
            // 
            // openPlaylistsBttn
            // 
            this.openPlaylistsBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openPlaylistsBttn.AutoSize = true;
            this.openPlaylistsBttn.Location = new System.Drawing.Point(37, 387);
            this.openPlaylistsBttn.Name = "openPlaylistsBttn";
            this.openPlaylistsBttn.Size = new System.Drawing.Size(99, 25);
            this.openPlaylistsBttn.TabIndex = 6;
            this.openPlaylistsBttn.Text = "Open playlist(s)";
            this.openPlaylistsBttn.UseVisualStyleBackColor = true;
            this.openPlaylistsBttn.Click += new System.EventHandler(this.OpenPlaylistsBttn_Click);
            // 
            // songView
            // 
            this.songView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.songView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.songColumnHeader1,
            this.songColumnHeader2,
            this.songColumnHeader3});
            this.songView.FullRowSelect = true;
            this.songView.GridLines = true;
            this.songView.HideSelection = false;
            this.songView.Location = new System.Drawing.Point(167, 62);
            this.songView.Name = "songView";
            this.songView.Size = new System.Drawing.Size(303, 319);
            this.songView.TabIndex = 7;
            this.songView.UseCompatibleStateImageBehavior = false;
            this.songView.View = System.Windows.Forms.View.Details;
            // 
            // songColumnHeader1
            // 
            this.songColumnHeader1.Text = "Artist(s)";
            this.songColumnHeader1.Width = 109;
            // 
            // songColumnHeader2
            // 
            this.songColumnHeader2.Text = "Title";
            this.songColumnHeader2.Width = 109;
            // 
            // songColumnHeader3
            // 
            this.songColumnHeader3.Text = "Beatmap?";
            this.songColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.songColumnHeader3.Width = 64;
            // 
            // findBeatmapsBttn
            // 
            this.findBeatmapsBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.findBeatmapsBttn.AutoSize = true;
            this.findBeatmapsBttn.Location = new System.Drawing.Point(279, 387);
            this.findBeatmapsBttn.Name = "findBeatmapsBttn";
            this.findBeatmapsBttn.Size = new System.Drawing.Size(95, 25);
            this.findBeatmapsBttn.TabIndex = 8;
            this.findBeatmapsBttn.Text = "Find beatmaps";
            this.findBeatmapsBttn.UseVisualStyleBackColor = true;
            this.findBeatmapsBttn.Click += new System.EventHandler(this.FindBeatmapsBttn_Click);
            // 
            // downloadAllBttn
            // 
            this.downloadAllBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadAllBttn.AutoSize = true;
            this.downloadAllBttn.Location = new System.Drawing.Point(168, 418);
            this.downloadAllBttn.Name = "downloadAllBttn";
            this.downloadAllBttn.Size = new System.Drawing.Size(141, 25);
            this.downloadAllBttn.TabIndex = 9;
            this.downloadAllBttn.Text = "Download all beatmaps";
            this.downloadAllBttn.UseVisualStyleBackColor = true;
            this.downloadAllBttn.Click += new System.EventHandler(this.DownloadAllBttn_Click);
            // 
            // downloadSelectedBttn
            // 
            this.downloadSelectedBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadSelectedBttn.AutoSize = true;
            this.downloadSelectedBttn.Location = new System.Drawing.Point(313, 418);
            this.downloadSelectedBttn.Name = "downloadSelectedBttn";
            this.downloadSelectedBttn.Size = new System.Drawing.Size(172, 25);
            this.downloadSelectedBttn.TabIndex = 10;
            this.downloadSelectedBttn.Text = "Download selected beatmaps";
            this.downloadSelectedBttn.UseVisualStyleBackColor = true;
            this.downloadSelectedBttn.Click += new System.EventHandler(this.DownloadSelectedBttn_Click);
            // 
            // downloadView
            // 
            this.downloadView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.downloadColumnHeader1,
            this.downloadColumnHeader2,
            this.downloadColumnHeader3});
            this.downloadView.FullRowSelect = true;
            this.downloadView.GridLines = true;
            this.downloadView.HideSelection = false;
            this.downloadView.Location = new System.Drawing.Point(476, 62);
            this.downloadView.Name = "downloadView";
            this.downloadView.Size = new System.Drawing.Size(312, 319);
            this.downloadView.TabIndex = 11;
            this.downloadView.UseCompatibleStateImageBehavior = false;
            this.downloadView.View = System.Windows.Forms.View.Details;
            // 
            // downloadColumnHeader1
            // 
            this.downloadColumnHeader1.Text = "Artist(s)";
            this.downloadColumnHeader1.Width = 109;
            // 
            // downloadColumnHeader2
            // 
            this.downloadColumnHeader2.Text = "Title";
            this.downloadColumnHeader2.Width = 109;
            // 
            // downloadColumnHeader3
            // 
            this.downloadColumnHeader3.Text = "Status";
            this.downloadColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.downloadColumnHeader3.Width = 71;
            // 
            // startDownloadBttn
            // 
            this.startDownloadBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startDownloadBttn.AutoSize = true;
            this.startDownloadBttn.Location = new System.Drawing.Point(526, 387);
            this.startDownloadBttn.Name = "startDownloadBttn";
            this.startDownloadBttn.Size = new System.Drawing.Size(97, 25);
            this.startDownloadBttn.TabIndex = 12;
            this.startDownloadBttn.Text = "Start download";
            this.startDownloadBttn.UseVisualStyleBackColor = true;
            this.startDownloadBttn.Click += new System.EventHandler(this.StartDownloadBttn_Click);
            // 
            // removeBeatmapBttn
            // 
            this.removeBeatmapBttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeBeatmapBttn.AutoSize = true;
            this.removeBeatmapBttn.Location = new System.Drawing.Point(629, 387);
            this.removeBeatmapBttn.Name = "removeBeatmapBttn";
            this.removeBeatmapBttn.Size = new System.Drawing.Size(123, 25);
            this.removeBeatmapBttn.TabIndex = 13;
            this.removeBeatmapBttn.Text = "Remove beatmap(s)";
            this.removeBeatmapBttn.UseVisualStyleBackColor = true;
            this.removeBeatmapBttn.Click += new System.EventHandler(this.RemoveBeatmapBttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeBeatmapBttn);
            this.Controls.Add(this.startDownloadBttn);
            this.Controls.Add(this.downloadView);
            this.Controls.Add(this.downloadSelectedBttn);
            this.Controls.Add(this.downloadAllBttn);
            this.Controls.Add(this.findBeatmapsBttn);
            this.Controls.Add(this.songView);
            this.Controls.Add(this.openPlaylistsBttn);
            this.Controls.Add(this.playlistView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spotifyBttn);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Spotify Beatmap Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button spotifyBttn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView playlistView;
        private System.Windows.Forms.ColumnHeader playlistColumnHeader1;
        private System.Windows.Forms.ColumnHeader playlistColumnHeader2;
        private System.Windows.Forms.Button openPlaylistsBttn;
        private System.Windows.Forms.ListView songView;
        private System.Windows.Forms.ColumnHeader songColumnHeader1;
        private System.Windows.Forms.ColumnHeader songColumnHeader2;
        private System.Windows.Forms.ColumnHeader songColumnHeader3;
        private System.Windows.Forms.Button findBeatmapsBttn;
        private System.Windows.Forms.Button downloadAllBttn;
        private System.Windows.Forms.Button downloadSelectedBttn;
        private System.Windows.Forms.ListView downloadView;
        private System.Windows.Forms.ColumnHeader downloadColumnHeader1;
        private System.Windows.Forms.ColumnHeader downloadColumnHeader2;
        private System.Windows.Forms.ColumnHeader downloadColumnHeader3;
        private System.Windows.Forms.Button startDownloadBttn;
        private System.Windows.Forms.Button removeBeatmapBttn;
    }
}

