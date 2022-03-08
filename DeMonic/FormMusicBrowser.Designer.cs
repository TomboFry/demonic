namespace DeMonic
{
	partial class FormMusicBrowser
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
				if (player != null) player.Dispose();
				if (discord != null) discord.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMusicBrowser));
			this.MenuStripMain = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ServerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.ScrobbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DiscordRichPresenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TimerTrackbar = new System.Windows.Forms.Timer(this.components);
			this.SplitContainerLR = new System.Windows.Forms.SplitContainer();
			this.SplitContainerTB = new System.Windows.Forms.SplitContainer();
			this.ArtistAlbumTree = new System.Windows.Forms.TreeView();
			this.PictureBoxCoverArt = new System.Windows.Forms.PictureBox();
			this.ListSongQueue = new System.Windows.Forms.ListView();
			this.columnPlaying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnArtistAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSongNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ImageListQueue = new System.Windows.Forms.ImageList(this.components);
			this.StatusStripBottom = new System.Windows.Forms.StatusStrip();
			this.ToolStripSongInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripQueueInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ContextMenuArtistsAlbums = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PlayNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TimerDiscord = new System.Windows.Forms.Timer(this.components);
			this.ButtonSkipForwards = new System.Windows.Forms.Button();
			this.ButtonPlayPause = new System.Windows.Forms.Button();
			this.ButtonSkipBackwards = new System.Windows.Forms.Button();
			this.TrackBarSeek = new System.Windows.Forms.TrackBar();
			this.MenuStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerLR)).BeginInit();
			this.SplitContainerLR.Panel1.SuspendLayout();
			this.SplitContainerLR.Panel2.SuspendLayout();
			this.SplitContainerLR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerTB)).BeginInit();
			this.SplitContainerTB.Panel1.SuspendLayout();
			this.SplitContainerTB.Panel2.SuspendLayout();
			this.SplitContainerTB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverArt)).BeginInit();
			this.StatusStripBottom.SuspendLayout();
			this.ContextMenuArtistsAlbums.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TrackBarSeek)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuStripMain
			// 
			this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.PreferencesToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
			this.MenuStripMain.Name = "MenuStripMain";
			this.MenuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.MenuStripMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuStripMain.Size = new System.Drawing.Size(886, 24);
			this.MenuStripMain.TabIndex = 0;
			this.MenuStripMain.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "&File";
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.ExitToolStripMenuItem.Text = "E&xit";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// PreferencesToolStripMenuItem
			// 
			this.PreferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerListToolStripMenuItem,
            this.ToolStripMenuItemSeparator,
            this.ScrobbleToolStripMenuItem,
            this.DiscordRichPresenceToolStripMenuItem});
			this.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem";
			this.PreferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.PreferencesToolStripMenuItem.Text = "&Preferences";
			// 
			// ServerListToolStripMenuItem
			// 
			this.ServerListToolStripMenuItem.Name = "ServerListToolStripMenuItem";
			this.ServerListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.ServerListToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.ServerListToolStripMenuItem.Text = "Server &List";
			this.ServerListToolStripMenuItem.Click += new System.EventHandler(this.ServerListToolStripMenuItem_Click);
			// 
			// ToolStripMenuItemSeparator
			// 
			this.ToolStripMenuItemSeparator.Name = "ToolStripMenuItemSeparator";
			this.ToolStripMenuItemSeparator.Size = new System.Drawing.Size(187, 6);
			// 
			// ScrobbleToolStripMenuItem
			// 
			this.ScrobbleToolStripMenuItem.CheckOnClick = true;
			this.ScrobbleToolStripMenuItem.Name = "ScrobbleToolStripMenuItem";
			this.ScrobbleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.ScrobbleToolStripMenuItem.Text = "&Scrobble";
			this.ScrobbleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ScrobbleToolStripMenuItem_CheckedChanged);
			// 
			// DiscordRichPresenceToolStripMenuItem
			// 
			this.DiscordRichPresenceToolStripMenuItem.CheckOnClick = true;
			this.DiscordRichPresenceToolStripMenuItem.Name = "DiscordRichPresenceToolStripMenuItem";
			this.DiscordRichPresenceToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.DiscordRichPresenceToolStripMenuItem.Text = "&Discord Rich Presence";
			this.DiscordRichPresenceToolStripMenuItem.CheckedChanged += new System.EventHandler(this.DiscordRichPresenceToolStripMenuItem_CheckedChanged);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SourceCodeToolStripMenuItem,
            this.VersionToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.HelpToolStripMenuItem.Text = "&Help";
			// 
			// SourceCodeToolStripMenuItem
			// 
			this.SourceCodeToolStripMenuItem.Name = "SourceCodeToolStripMenuItem";
			this.SourceCodeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.SourceCodeToolStripMenuItem.Text = "Source Code";
			this.SourceCodeToolStripMenuItem.Click += new System.EventHandler(this.SourceCodeToolStripMenuItem_Click);
			// 
			// VersionToolStripMenuItem
			// 
			this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
			this.VersionToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.VersionToolStripMenuItem.Text = "Version";
			// 
			// TimerTrackbar
			// 
			this.TimerTrackbar.Interval = 333;
			this.TimerTrackbar.Tick += new System.EventHandler(this.TimerTrackbar_Tick);
			// 
			// SplitContainerLR
			// 
			this.SplitContainerLR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SplitContainerLR.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainerLR.IsSplitterFixed = true;
			this.SplitContainerLR.Location = new System.Drawing.Point(0, 65);
			this.SplitContainerLR.Name = "SplitContainerLR";
			// 
			// SplitContainerLR.Panel1
			// 
			this.SplitContainerLR.Panel1.Controls.Add(this.SplitContainerTB);
			this.SplitContainerLR.Panel1MinSize = 256;
			// 
			// SplitContainerLR.Panel2
			// 
			this.SplitContainerLR.Panel2.Controls.Add(this.ListSongQueue);
			this.SplitContainerLR.Size = new System.Drawing.Size(886, 566);
			this.SplitContainerLR.SplitterDistance = 256;
			this.SplitContainerLR.TabIndex = 2;
			// 
			// SplitContainerTB
			// 
			this.SplitContainerTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainerTB.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.SplitContainerTB.IsSplitterFixed = true;
			this.SplitContainerTB.Location = new System.Drawing.Point(0, 0);
			this.SplitContainerTB.Name = "SplitContainerTB";
			this.SplitContainerTB.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainerTB.Panel1
			// 
			this.SplitContainerTB.Panel1.Controls.Add(this.ArtistAlbumTree);
			// 
			// SplitContainerTB.Panel2
			// 
			this.SplitContainerTB.Panel2.Controls.Add(this.PictureBoxCoverArt);
			this.SplitContainerTB.Panel2MinSize = 256;
			this.SplitContainerTB.Size = new System.Drawing.Size(256, 566);
			this.SplitContainerTB.SplitterDistance = 306;
			this.SplitContainerTB.TabIndex = 0;
			// 
			// ArtistAlbumTree
			// 
			this.ArtistAlbumTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ArtistAlbumTree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ArtistAlbumTree.Indent = 20;
			this.ArtistAlbumTree.Location = new System.Drawing.Point(0, 0);
			this.ArtistAlbumTree.Name = "ArtistAlbumTree";
			this.ArtistAlbumTree.Size = new System.Drawing.Size(256, 306);
			this.ArtistAlbumTree.TabIndex = 0;
			this.ArtistAlbumTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ArtistAlbumTree_NodeMouseClick);
			this.ArtistAlbumTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ArtistAlbumTree_NodeMouseDoubleClick);
			// 
			// PictureBoxCoverArt
			// 
			this.PictureBoxCoverArt.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PictureBoxCoverArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PictureBoxCoverArt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBoxCoverArt.ImageLocation = "";
			this.PictureBoxCoverArt.InitialImage = null;
			this.PictureBoxCoverArt.Location = new System.Drawing.Point(0, 0);
			this.PictureBoxCoverArt.Margin = new System.Windows.Forms.Padding(0);
			this.PictureBoxCoverArt.MinimumSize = new System.Drawing.Size(256, 256);
			this.PictureBoxCoverArt.Name = "PictureBoxCoverArt";
			this.PictureBoxCoverArt.Size = new System.Drawing.Size(256, 256);
			this.PictureBoxCoverArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBoxCoverArt.TabIndex = 0;
			this.PictureBoxCoverArt.TabStop = false;
			// 
			// ListSongQueue
			// 
			this.ListSongQueue.AllowColumnReorder = true;
			this.ListSongQueue.AutoArrange = false;
			this.ListSongQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlaying,
            this.columnArtistAlbum,
            this.columnSongNumber,
            this.columnTitle,
            this.columnDuration});
			this.ListSongQueue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListSongQueue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ListSongQueue.FullRowSelect = true;
			this.ListSongQueue.GridLines = true;
			this.ListSongQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ListSongQueue.HideSelection = false;
			this.ListSongQueue.Location = new System.Drawing.Point(0, 0);
			this.ListSongQueue.Name = "ListSongQueue";
			this.ListSongQueue.Size = new System.Drawing.Size(626, 566);
			this.ListSongQueue.SmallImageList = this.ImageListQueue;
			this.ListSongQueue.TabIndex = 0;
			this.ListSongQueue.UseCompatibleStateImageBehavior = false;
			this.ListSongQueue.View = System.Windows.Forms.View.Details;
			this.ListSongQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListSongQueue_KeyUp);
			this.ListSongQueue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListSongQueue_MouseDoubleClick);
			// 
			// columnPlaying
			// 
			this.columnPlaying.Text = "";
			this.columnPlaying.Width = 24;
			// 
			// columnArtistAlbum
			// 
			this.columnArtistAlbum.Text = "Artist - Album";
			this.columnArtistAlbum.Width = 224;
			// 
			// columnSongNumber
			// 
			this.columnSongNumber.Text = "#";
			this.columnSongNumber.Width = 40;
			// 
			// columnTitle
			// 
			this.columnTitle.Text = "Title";
			this.columnTitle.Width = 256;
			// 
			// columnDuration
			// 
			this.columnDuration.Text = "Length";
			// 
			// ImageListQueue
			// 
			this.ImageListQueue.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListQueue.ImageStream")));
			this.ImageListQueue.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageListQueue.Images.SetKeyName(0, "play");
			// 
			// StatusStripBottom
			// 
			this.StatusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSongInfo,
            this.ToolStripQueueInfo,
            this.ToolStripConnectionLabel});
			this.StatusStripBottom.Location = new System.Drawing.Point(0, 634);
			this.StatusStripBottom.Name = "StatusStripBottom";
			this.StatusStripBottom.Size = new System.Drawing.Size(886, 22);
			this.StatusStripBottom.TabIndex = 4;
			this.StatusStripBottom.Text = "statusStrip1";
			// 
			// ToolStripSongInfo
			// 
			this.ToolStripSongInfo.Name = "ToolStripSongInfo";
			this.ToolStripSongInfo.Size = new System.Drawing.Size(69, 17);
			this.ToolStripSongInfo.Text = "Not Playing";
			// 
			// ToolStripQueueInfo
			// 
			this.ToolStripQueueInfo.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
			this.ToolStripQueueInfo.Name = "ToolStripQueueInfo";
			this.ToolStripQueueInfo.Size = new System.Drawing.Size(165, 17);
			this.ToolStripQueueInfo.Text = "Total: 00:00 (0 songs in queue)";
			// 
			// ToolStripConnectionLabel
			// 
			this.ToolStripConnectionLabel.Margin = new System.Windows.Forms.Padding(8, 3, 0, 2);
			this.ToolStripConnectionLabel.Name = "ToolStripConnectionLabel";
			this.ToolStripConnectionLabel.Size = new System.Drawing.Size(88, 17);
			this.ToolStripConnectionLabel.Text = "Not Connected";
			this.ToolStripConnectionLabel.Click += new System.EventHandler(this.ToolStripConnectionLabel_Click);
			// 
			// ContextMenuArtistsAlbums
			// 
			this.ContextMenuArtistsAlbums.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayNowToolStripMenuItem,
            this.AddToQueueToolStripMenuItem});
			this.ContextMenuArtistsAlbums.Name = "contextMenuStrip1";
			this.ContextMenuArtistsAlbums.Size = new System.Drawing.Size(149, 48);
			// 
			// PlayNowToolStripMenuItem
			// 
			this.PlayNowToolStripMenuItem.Name = "PlayNowToolStripMenuItem";
			this.PlayNowToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.PlayNowToolStripMenuItem.Text = "Play Now";
			this.PlayNowToolStripMenuItem.Click += new System.EventHandler(this.PlayNowToolStripMenuItem_Click);
			// 
			// AddToQueueToolStripMenuItem
			// 
			this.AddToQueueToolStripMenuItem.Name = "AddToQueueToolStripMenuItem";
			this.AddToQueueToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.AddToQueueToolStripMenuItem.Text = "Add to Queue";
			this.AddToQueueToolStripMenuItem.Click += new System.EventHandler(this.AddToQueueToolStripMenuItem_Click);
			// 
			// TimerDiscord
			// 
			this.TimerDiscord.Interval = 5000;
			this.TimerDiscord.Tick += new System.EventHandler(this.TimerDiscord_Tick);
			// 
			// ButtonSkipForwards
			// 
			this.ButtonSkipForwards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonSkipForwards.ForeColor = System.Drawing.SystemColors.Control;
			this.ButtonSkipForwards.Image = global::DeMonic.Properties.Resources.skip_forward;
			this.ButtonSkipForwards.Location = new System.Drawing.Point(81, 26);
			this.ButtonSkipForwards.Margin = new System.Windows.Forms.Padding(0);
			this.ButtonSkipForwards.Name = "ButtonSkipForwards";
			this.ButtonSkipForwards.Size = new System.Drawing.Size(36, 36);
			this.ButtonSkipForwards.TabIndex = 3;
			this.ButtonSkipForwards.UseVisualStyleBackColor = true;
			this.ButtonSkipForwards.Click += new System.EventHandler(this.ButtonSkipForwards_Click);
			// 
			// ButtonPlayPause
			// 
			this.ButtonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonPlayPause.ForeColor = System.Drawing.SystemColors.Control;
			this.ButtonPlayPause.Image = global::DeMonic.Properties.Resources.play;
			this.ButtonPlayPause.Location = new System.Drawing.Point(45, 26);
			this.ButtonPlayPause.Margin = new System.Windows.Forms.Padding(0);
			this.ButtonPlayPause.Name = "ButtonPlayPause";
			this.ButtonPlayPause.Size = new System.Drawing.Size(36, 36);
			this.ButtonPlayPause.TabIndex = 3;
			this.ButtonPlayPause.UseVisualStyleBackColor = true;
			this.ButtonPlayPause.Click += new System.EventHandler(this.ButtonPlayPause_Click);
			// 
			// ButtonSkipBackwards
			// 
			this.ButtonSkipBackwards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonSkipBackwards.ForeColor = System.Drawing.SystemColors.Control;
			this.ButtonSkipBackwards.Image = global::DeMonic.Properties.Resources.skip_back;
			this.ButtonSkipBackwards.Location = new System.Drawing.Point(9, 26);
			this.ButtonSkipBackwards.Margin = new System.Windows.Forms.Padding(0);
			this.ButtonSkipBackwards.Name = "ButtonSkipBackwards";
			this.ButtonSkipBackwards.Size = new System.Drawing.Size(36, 36);
			this.ButtonSkipBackwards.TabIndex = 3;
			this.ButtonSkipBackwards.UseVisualStyleBackColor = true;
			this.ButtonSkipBackwards.Click += new System.EventHandler(this.ButtonSkipBackwards_Click);
			// 
			// TrackBarSeek
			// 
			this.TrackBarSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TrackBarSeek.AutoSize = false;
			this.TrackBarSeek.Enabled = false;
			this.TrackBarSeek.LargeChange = 50;
			this.TrackBarSeek.Location = new System.Drawing.Point(120, 23);
			this.TrackBarSeek.Maximum = 1000;
			this.TrackBarSeek.Name = "TrackBarSeek";
			this.TrackBarSeek.Size = new System.Drawing.Size(766, 40);
			this.TrackBarSeek.SmallChange = 10;
			this.TrackBarSeek.TabIndex = 1;
			this.TrackBarSeek.TickFrequency = 1000;
			this.TrackBarSeek.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.TrackBarSeek.Scroll += new System.EventHandler(this.TrackBarSeek_Scroll);
			// 
			// FormMusicBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 656);
			this.Controls.Add(this.StatusStripBottom);
			this.Controls.Add(this.ButtonSkipForwards);
			this.Controls.Add(this.ButtonPlayPause);
			this.Controls.Add(this.ButtonSkipBackwards);
			this.Controls.Add(this.SplitContainerLR);
			this.Controls.Add(this.MenuStripMain);
			this.Controls.Add(this.TrackBarSeek);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MenuStripMain;
			this.Name = "FormMusicBrowser";
			this.Text = "DeMonic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMusicBrowser_FormClosing);
			this.MenuStripMain.ResumeLayout(false);
			this.MenuStripMain.PerformLayout();
			this.SplitContainerLR.Panel1.ResumeLayout(false);
			this.SplitContainerLR.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerLR)).EndInit();
			this.SplitContainerLR.ResumeLayout(false);
			this.SplitContainerTB.Panel1.ResumeLayout(false);
			this.SplitContainerTB.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerTB)).EndInit();
			this.SplitContainerTB.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxCoverArt)).EndInit();
			this.StatusStripBottom.ResumeLayout(false);
			this.StatusStripBottom.PerformLayout();
			this.ContextMenuArtistsAlbums.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TrackBarSeek)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuStripMain;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		private System.Windows.Forms.Timer TimerTrackbar;
		private System.Windows.Forms.SplitContainer SplitContainerLR;
		private System.Windows.Forms.SplitContainer SplitContainerTB;
		private System.Windows.Forms.TreeView ArtistAlbumTree;
		private System.Windows.Forms.ListView ListSongQueue;
		private System.Windows.Forms.PictureBox PictureBoxCoverArt;
		private System.Windows.Forms.Button ButtonSkipBackwards;
		private System.Windows.Forms.Button ButtonPlayPause;
		private System.Windows.Forms.Button ButtonSkipForwards;
		private System.Windows.Forms.StatusStrip StatusStripBottom;
		private System.Windows.Forms.ColumnHeader columnPlaying;
		private System.Windows.Forms.ColumnHeader columnArtistAlbum;
		private System.Windows.Forms.ColumnHeader columnSongNumber;
		private System.Windows.Forms.ColumnHeader columnTitle;
		private System.Windows.Forms.ColumnHeader columnDuration;
		private System.Windows.Forms.ImageList ImageListQueue;
		private System.Windows.Forms.ContextMenuStrip ContextMenuArtistsAlbums;
		private System.Windows.Forms.ToolStripMenuItem PlayNowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddToQueueToolStripMenuItem;
		private System.Windows.Forms.Timer TimerDiscord;
		private System.Windows.Forms.ToolStripStatusLabel ToolStripSongInfo;
		private System.Windows.Forms.ToolStripMenuItem PreferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ServerListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator ToolStripMenuItemSeparator;
		private System.Windows.Forms.ToolStripMenuItem ScrobbleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DiscordRichPresenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel ToolStripConnectionLabel;
		private System.Windows.Forms.TrackBar TrackBarSeek;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SourceCodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel ToolStripQueueInfo;
	}
}

