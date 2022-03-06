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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serverListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.scrobbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.discordRichPresenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerTrackbar = new System.Windows.Forms.Timer(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.artistAlbumTree = new System.Windows.Forms.TreeView();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.listSongQueue = new System.Windows.Forms.ListView();
			this.columnPlaying = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnArtistAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSongNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListQueue = new System.Windows.Forms.ImageList(this.components);
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusBarSongInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerDiscord = new System.Windows.Forms.Timer(this.components);
			this.buttonSkipForwards = new System.Windows.Forms.Button();
			this.buttonPlayPause = new System.Windows.Forms.Button();
			this.buttonSkipBackwards = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusStrip.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.preferencesToolStripMenuItem,
			this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.menuStrip1.Size = new System.Drawing.Size(886, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.serverListToolStripMenuItem,
			this.toolStripMenuItem1,
			this.scrobbleToolStripMenuItem,
			this.discordRichPresenceToolStripMenuItem});
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.preferencesToolStripMenuItem.Text = "&Preferences";
			// 
			// serverListToolStripMenuItem
			// 
			this.serverListToolStripMenuItem.Name = "serverListToolStripMenuItem";
			this.serverListToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.serverListToolStripMenuItem.Text = "Server &List";
			this.serverListToolStripMenuItem.Click += new System.EventHandler(this.serverListToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
			// 
			// scrobbleToolStripMenuItem
			// 
			this.scrobbleToolStripMenuItem.CheckOnClick = true;
			this.scrobbleToolStripMenuItem.Name = "scrobbleToolStripMenuItem";
			this.scrobbleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.scrobbleToolStripMenuItem.Text = "&Scrobble";
			this.scrobbleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.scrobbleToolStripMenuItem_CheckedChanged);
			// 
			// discordRichPresenceToolStripMenuItem
			// 
			this.discordRichPresenceToolStripMenuItem.CheckOnClick = true;
			this.discordRichPresenceToolStripMenuItem.Name = "discordRichPresenceToolStripMenuItem";
			this.discordRichPresenceToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.discordRichPresenceToolStripMenuItem.Text = "&Discord Rich Presence";
			this.discordRichPresenceToolStripMenuItem.CheckedChanged += new System.EventHandler(this.discordRichPresenceToolStripMenuItem_CheckedChanged);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.sourceCodeToolStripMenuItem,
			this.versionToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// sourceCodeToolStripMenuItem
			// 
			this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
			this.sourceCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.sourceCodeToolStripMenuItem.Text = "Source Code";
			this.sourceCodeToolStripMenuItem.Click += new System.EventHandler(this.sourceCodeToolStripMenuItem_Click);
			// 
			// versionToolStripMenuItem
			// 
			this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
			this.versionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.versionToolStripMenuItem.Text = "Version";
			// 
			// timerTrackbar
			// 
			this.timerTrackbar.Interval = 333;
			this.timerTrackbar.Tick += new System.EventHandler(this.timerTrackbar_Tick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 65);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1MinSize = 256;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listSongQueue);
			this.splitContainer1.Size = new System.Drawing.Size(886, 566);
			this.splitContainer1.SplitterDistance = 256;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.artistAlbumTree);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
			this.splitContainer2.Panel2MinSize = 256;
			this.splitContainer2.Size = new System.Drawing.Size(256, 566);
			this.splitContainer2.SplitterDistance = 306;
			this.splitContainer2.TabIndex = 0;
			// 
			// artistAlbumTree
			// 
			this.artistAlbumTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.artistAlbumTree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.artistAlbumTree.Indent = 20;
			this.artistAlbumTree.Location = new System.Drawing.Point(0, 0);
			this.artistAlbumTree.Name = "artistAlbumTree";
			this.artistAlbumTree.Size = new System.Drawing.Size(256, 306);
			this.artistAlbumTree.TabIndex = 0;
			this.artistAlbumTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.artistAlbumTree_NodeMouseClick);
			this.artistAlbumTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.artistAlbumTree_NodeMouseDoubleClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.ImageLocation = "";
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.MinimumSize = new System.Drawing.Size(256, 256);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 256);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// listSongQueue
			// 
			this.listSongQueue.AllowColumnReorder = true;
			this.listSongQueue.AutoArrange = false;
			this.listSongQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnPlaying,
			this.columnArtistAlbum,
			this.columnSongNumber,
			this.columnTitle,
			this.columnDuration});
			this.listSongQueue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSongQueue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listSongQueue.FullRowSelect = true;
			this.listSongQueue.GridLines = true;
			this.listSongQueue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listSongQueue.HideSelection = false;
			this.listSongQueue.Location = new System.Drawing.Point(0, 0);
			this.listSongQueue.Name = "listSongQueue";
			this.listSongQueue.Size = new System.Drawing.Size(626, 566);
			this.listSongQueue.SmallImageList = this.imageListQueue;
			this.listSongQueue.TabIndex = 0;
			this.listSongQueue.UseCompatibleStateImageBehavior = false;
			this.listSongQueue.View = System.Windows.Forms.View.Details;
			this.listSongQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listSongQueue_KeyUp);
			this.listSongQueue.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSongQueue_MouseDoubleClick);
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
			this.columnSongNumber.Width = 32;
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
			// imageListQueue
			// 
			this.imageListQueue.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListQueue.ImageStream")));
			this.imageListQueue.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListQueue.Images.SetKeyName(0, "play");
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.statusBarSongInfo,
			this.toolStripConnectionLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 634);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(886, 22);
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// statusBarSongInfo
			// 
			this.statusBarSongInfo.Name = "statusBarSongInfo";
			this.statusBarSongInfo.Size = new System.Drawing.Size(69, 17);
			this.statusBarSongInfo.Text = "Not Playing";
			// 
			// toolStripConnectionLabel
			// 
			this.toolStripConnectionLabel.Name = "toolStripConnectionLabel";
			this.toolStripConnectionLabel.Size = new System.Drawing.Size(88, 17);
			this.toolStripConnectionLabel.Text = "Not Connected";
			this.toolStripConnectionLabel.Click += new System.EventHandler(this.toolStripConnectionLabel_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.playNowToolStripMenuItem,
			this.addToQueueToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
			// 
			// playNowToolStripMenuItem
			// 
			this.playNowToolStripMenuItem.Name = "playNowToolStripMenuItem";
			this.playNowToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.playNowToolStripMenuItem.Text = "Play Now";
			this.playNowToolStripMenuItem.Click += new System.EventHandler(this.playNowToolStripMenuItem_Click);
			// 
			// addToQueueToolStripMenuItem
			// 
			this.addToQueueToolStripMenuItem.Name = "addToQueueToolStripMenuItem";
			this.addToQueueToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.addToQueueToolStripMenuItem.Text = "Add to Queue";
			this.addToQueueToolStripMenuItem.Click += new System.EventHandler(this.addToQueueToolStripMenuItem_Click);
			// 
			// timerDiscord
			// 
			this.timerDiscord.Interval = 5000;
			this.timerDiscord.Tick += new System.EventHandler(this.timerDiscord_Tick);
			// 
			// buttonSkipForwards
			// 
			this.buttonSkipForwards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSkipForwards.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonSkipForwards.Image = global::DeMonic.Properties.Resources.skip_forward;
			this.buttonSkipForwards.Location = new System.Drawing.Point(81, 24);
			this.buttonSkipForwards.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSkipForwards.Name = "buttonSkipForwards";
			this.buttonSkipForwards.Size = new System.Drawing.Size(36, 36);
			this.buttonSkipForwards.TabIndex = 3;
			this.buttonSkipForwards.UseVisualStyleBackColor = true;
			this.buttonSkipForwards.Click += new System.EventHandler(this.buttonSkipForwards_Click);
			// 
			// buttonPlayPause
			// 
			this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayPause.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonPlayPause.Image = global::DeMonic.Properties.Resources.play;
			this.buttonPlayPause.Location = new System.Drawing.Point(45, 24);
			this.buttonPlayPause.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayPause.Name = "buttonPlayPause";
			this.buttonPlayPause.Size = new System.Drawing.Size(36, 36);
			this.buttonPlayPause.TabIndex = 3;
			this.buttonPlayPause.UseVisualStyleBackColor = true;
			this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
			// 
			// buttonSkipBackwards
			// 
			this.buttonSkipBackwards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSkipBackwards.ForeColor = System.Drawing.SystemColors.Control;
			this.buttonSkipBackwards.Image = global::DeMonic.Properties.Resources.skip_back;
			this.buttonSkipBackwards.Location = new System.Drawing.Point(9, 24);
			this.buttonSkipBackwards.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSkipBackwards.Name = "buttonSkipBackwards";
			this.buttonSkipBackwards.Size = new System.Drawing.Size(36, 36);
			this.buttonSkipBackwards.TabIndex = 3;
			this.buttonSkipBackwards.UseVisualStyleBackColor = true;
			this.buttonSkipBackwards.Click += new System.EventHandler(this.buttonSkipBackwards_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.AutoSize = false;
			this.trackBar1.Enabled = false;
			this.trackBar1.LargeChange = 50;
			this.trackBar1.Location = new System.Drawing.Point(120, 21);
			this.trackBar1.Maximum = 1000;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(766, 40);
			this.trackBar1.SmallChange = 10;
			this.trackBar1.TabIndex = 1;
			this.trackBar1.TickFrequency = 1000;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// FormMusicBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 656);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.buttonSkipForwards);
			this.Controls.Add(this.buttonPlayPause);
			this.Controls.Add(this.buttonSkipBackwards);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.trackBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMusicBrowser";
			this.Text = "DeMonic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMusicBrowser_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Timer timerTrackbar;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TreeView artistAlbumTree;
		private System.Windows.Forms.ListView listSongQueue;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonSkipBackwards;
		private System.Windows.Forms.Button buttonPlayPause;
		private System.Windows.Forms.Button buttonSkipForwards;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ColumnHeader columnPlaying;
		private System.Windows.Forms.ColumnHeader columnArtistAlbum;
		private System.Windows.Forms.ColumnHeader columnSongNumber;
		private System.Windows.Forms.ColumnHeader columnTitle;
		private System.Windows.Forms.ColumnHeader columnDuration;
		private System.Windows.Forms.ImageList imageListQueue;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem playNowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToQueueToolStripMenuItem;
		private System.Windows.Forms.Timer timerDiscord;
		private System.Windows.Forms.ToolStripStatusLabel statusBarSongInfo;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serverListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem scrobbleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem discordRichPresenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripConnectionLabel;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
	}
}

