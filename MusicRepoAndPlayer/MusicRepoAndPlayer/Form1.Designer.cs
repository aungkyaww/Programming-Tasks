namespace MusicRepoAndPlayer
{
    partial class frmMusicPlayer
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
            this.tvPlaylists = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnNewPlaylist = new System.Windows.Forms.Button();
            this.btnAddNewTrack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearchableName = new System.Windows.Forms.TextBox();
            this.txtLinkToTrack = new System.Windows.Forms.TextBox();
            this.lblSearchable = new System.Windows.Forms.Label();
            this.lblLinkToTrack = new System.Windows.Forms.Label();
            this.lblTrackName = new System.Windows.Forms.Label();
            this.txtTrackName = new System.Windows.Forms.TextBox();
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.lblDisplayPlaylist = new System.Windows.Forms.Label();
            this.gpbxTrackInfo = new System.Windows.Forms.GroupBox();
            this.lblTrackSelectedSearchable = new System.Windows.Forms.Label();
            this.lblTrackSelectedLink = new System.Windows.Forms.Label();
            this.lblTrackSelected = new System.Windows.Forms.Label();
            this.lblTrackInfoSearchableName = new System.Windows.Forms.Label();
            this.lblTrackInfoLink = new System.Windows.Forms.LinkLabel();
            this.lblTrackInfoTrackName = new System.Windows.Forms.Label();
            this.btnDeletePlaylist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkLq = new System.Windows.Forms.CheckBox();
            this.chkShuffle = new System.Windows.Forms.CheckBox();
            this.lblThreadDelay = new System.Windows.Forms.Label();
            this.numThreadDelay = new System.Windows.Forms.NumericUpDown();
            this.gpbxTrackInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // tvPlaylists
            // 
            this.tvPlaylists.Location = new System.Drawing.Point(12, 12);
            this.tvPlaylists.Name = "tvPlaylists";
            this.tvPlaylists.Size = new System.Drawing.Size(214, 526);
            this.tvPlaylists.TabIndex = 0;
            this.tvPlaylists.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPlaylists_AfterSelect);
            this.tvPlaylists.DoubleClick += new System.EventHandler(this.tvPlaylists_DoubleClick);
            this.tvPlaylists.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvPlaylists_KeyUp);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(288, 295);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(893, 387);
            this.webBrowser1.TabIndex = 1;
            // 
            // btnNewPlaylist
            // 
            this.btnNewPlaylist.Location = new System.Drawing.Point(232, 12);
            this.btnNewPlaylist.Name = "btnNewPlaylist";
            this.btnNewPlaylist.Size = new System.Drawing.Size(143, 46);
            this.btnNewPlaylist.TabIndex = 2;
            this.btnNewPlaylist.Text = "Add New Playlist";
            this.btnNewPlaylist.UseVisualStyleBackColor = true;
            this.btnNewPlaylist.Click += new System.EventHandler(this.btnNewPlaylist_Click);
            // 
            // btnAddNewTrack
            // 
            this.btnAddNewTrack.Location = new System.Drawing.Point(591, 10);
            this.btnAddNewTrack.Name = "btnAddNewTrack";
            this.btnAddNewTrack.Size = new System.Drawing.Size(143, 46);
            this.btnAddNewTrack.TabIndex = 3;
            this.btnAddNewTrack.Text = "Add New Track";
            this.btnAddNewTrack.UseVisualStyleBackColor = true;
            this.btnAddNewTrack.Click += new System.EventHandler(this.btnAddNewTrack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 46);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save All";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearchableName
            // 
            this.txtSearchableName.Location = new System.Drawing.Point(854, 64);
            this.txtSearchableName.Name = "txtSearchableName";
            this.txtSearchableName.Size = new System.Drawing.Size(271, 20);
            this.txtSearchableName.TabIndex = 21;
            // 
            // txtLinkToTrack
            // 
            this.txtLinkToTrack.Location = new System.Drawing.Point(854, 38);
            this.txtLinkToTrack.Name = "txtLinkToTrack";
            this.txtLinkToTrack.Size = new System.Drawing.Size(271, 20);
            this.txtLinkToTrack.TabIndex = 20;
            // 
            // lblSearchable
            // 
            this.lblSearchable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchable.Location = new System.Drawing.Point(740, 63);
            this.lblSearchable.Name = "lblSearchable";
            this.lblSearchable.Size = new System.Drawing.Size(108, 41);
            this.lblSearchable.TabIndex = 19;
            this.lblSearchable.Text = "Searchable Name";
            // 
            // lblLinkToTrack
            // 
            this.lblLinkToTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkToTrack.Location = new System.Drawing.Point(740, 37);
            this.lblLinkToTrack.Name = "lblLinkToTrack";
            this.lblLinkToTrack.Size = new System.Drawing.Size(108, 20);
            this.lblLinkToTrack.TabIndex = 18;
            this.lblLinkToTrack.Text = "Link to Track";
            // 
            // lblTrackName
            // 
            this.lblTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackName.Location = new System.Drawing.Point(737, 10);
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Size = new System.Drawing.Size(101, 20);
            this.lblTrackName.TabIndex = 17;
            this.lblTrackName.Text = "Track Name";
            // 
            // txtTrackName
            // 
            this.txtTrackName.Location = new System.Drawing.Point(854, 12);
            this.txtTrackName.Name = "txtTrackName";
            this.txtTrackName.Size = new System.Drawing.Size(271, 20);
            this.txtTrackName.TabIndex = 16;
            this.txtTrackName.TextChanged += new System.EventHandler(this.txtTrackName_TextChanged);
            this.txtTrackName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrackName_KeyDown);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaylist.Location = new System.Drawing.Point(381, 66);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(132, 46);
            this.lblPlaylist.TabIndex = 22;
            this.lblPlaylist.Text = "Current Playlist:";
            this.lblPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplayPlaylist
            // 
            this.lblDisplayPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayPlaylist.Location = new System.Drawing.Point(507, 66);
            this.lblDisplayPlaylist.Name = "lblDisplayPlaylist";
            this.lblDisplayPlaylist.Size = new System.Drawing.Size(157, 46);
            this.lblDisplayPlaylist.TabIndex = 23;
            this.lblDisplayPlaylist.Text = "Select a Playlist";
            this.lblDisplayPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbxTrackInfo
            // 
            this.gpbxTrackInfo.Controls.Add(this.lblTrackSelectedSearchable);
            this.gpbxTrackInfo.Controls.Add(this.lblTrackSelectedLink);
            this.gpbxTrackInfo.Controls.Add(this.lblTrackSelected);
            this.gpbxTrackInfo.Controls.Add(this.lblTrackInfoSearchableName);
            this.gpbxTrackInfo.Controls.Add(this.lblTrackInfoLink);
            this.gpbxTrackInfo.Controls.Add(this.lblTrackInfoTrackName);
            this.gpbxTrackInfo.Location = new System.Drawing.Point(12, 544);
            this.gpbxTrackInfo.Name = "gpbxTrackInfo";
            this.gpbxTrackInfo.Size = new System.Drawing.Size(270, 138);
            this.gpbxTrackInfo.TabIndex = 24;
            this.gpbxTrackInfo.TabStop = false;
            this.gpbxTrackInfo.Text = "Track Information";
            // 
            // lblTrackSelectedSearchable
            // 
            this.lblTrackSelectedSearchable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackSelectedSearchable.Location = new System.Drawing.Point(0, 89);
            this.lblTrackSelectedSearchable.Name = "lblTrackSelectedSearchable";
            this.lblTrackSelectedSearchable.Size = new System.Drawing.Size(110, 20);
            this.lblTrackSelectedSearchable.TabIndex = 23;
            this.lblTrackSelectedSearchable.Text = "Searchable:";
            // 
            // lblTrackSelectedLink
            // 
            this.lblTrackSelectedLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackSelectedLink.Location = new System.Drawing.Point(0, 58);
            this.lblTrackSelectedLink.Name = "lblTrackSelectedLink";
            this.lblTrackSelectedLink.Size = new System.Drawing.Size(110, 20);
            this.lblTrackSelectedLink.TabIndex = 22;
            this.lblTrackSelectedLink.Text = "Track Link:";
            // 
            // lblTrackSelected
            // 
            this.lblTrackSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackSelected.Location = new System.Drawing.Point(0, 25);
            this.lblTrackSelected.Name = "lblTrackSelected";
            this.lblTrackSelected.Size = new System.Drawing.Size(110, 20);
            this.lblTrackSelected.TabIndex = 21;
            this.lblTrackSelected.Text = "Track Name:";
            // 
            // lblTrackInfoSearchableName
            // 
            this.lblTrackInfoSearchableName.AutoSize = true;
            this.lblTrackInfoSearchableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackInfoSearchableName.Location = new System.Drawing.Point(116, 94);
            this.lblTrackInfoSearchableName.Name = "lblTrackInfoSearchableName";
            this.lblTrackInfoSearchableName.Size = new System.Drawing.Size(70, 15);
            this.lblTrackInfoSearchableName.TabIndex = 20;
            this.lblTrackInfoSearchableName.Text = "Searchable";
            // 
            // lblTrackInfoLink
            // 
            this.lblTrackInfoLink.AutoSize = true;
            this.lblTrackInfoLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackInfoLink.LinkColor = System.Drawing.Color.Blue;
            this.lblTrackInfoLink.Location = new System.Drawing.Point(116, 60);
            this.lblTrackInfoLink.Name = "lblTrackInfoLink";
            this.lblTrackInfoLink.Size = new System.Drawing.Size(63, 15);
            this.lblTrackInfoLink.TabIndex = 19;
            this.lblTrackInfoLink.TabStop = true;
            this.lblTrackInfoLink.Text = "Track Link";
            this.lblTrackInfoLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblTrackInfoLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTrackInfoLink_LinkClicked);
            // 
            // lblTrackInfoTrackName
            // 
            this.lblTrackInfoTrackName.AutoSize = true;
            this.lblTrackInfoTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackInfoTrackName.Location = new System.Drawing.Point(116, 27);
            this.lblTrackInfoTrackName.Name = "lblTrackInfoTrackName";
            this.lblTrackInfoTrackName.Size = new System.Drawing.Size(74, 15);
            this.lblTrackInfoTrackName.TabIndex = 18;
            this.lblTrackInfoTrackName.Text = "Track Name";
            // 
            // btnDeletePlaylist
            // 
            this.btnDeletePlaylist.Location = new System.Drawing.Point(232, 64);
            this.btnDeletePlaylist.Name = "btnDeletePlaylist";
            this.btnDeletePlaylist.Size = new System.Drawing.Size(143, 46);
            this.btnDeletePlaylist.TabIndex = 25;
            this.btnDeletePlaylist.Text = "Delete Selected Playlist";
            this.btnDeletePlaylist.UseVisualStyleBackColor = true;
            this.btnDeletePlaylist.Click += new System.EventHandler(this.btnDeletePlaylist_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(232, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 38);
            this.label1.TabIndex = 26;
            this.label1.Text = "Start Copy Run (Ctrl + Alt + V) Make sure discord is focused";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Discord"});
            this.comboBox1.Location = new System.Drawing.Point(235, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // chkLq
            // 
            this.chkLq.AutoSize = true;
            this.chkLq.Location = new System.Drawing.Point(510, 37);
            this.chkLq.Name = "chkLq";
            this.chkLq.Size = new System.Drawing.Size(59, 17);
            this.chkLq.TabIndex = 29;
            this.chkLq.Text = "Add !lq";
            this.chkLq.UseVisualStyleBackColor = true;
            // 
            // chkShuffle
            // 
            this.chkShuffle.AutoSize = true;
            this.chkShuffle.Location = new System.Drawing.Point(422, 37);
            this.chkShuffle.Name = "chkShuffle";
            this.chkShuffle.Size = new System.Drawing.Size(82, 17);
            this.chkShuffle.TabIndex = 30;
            this.chkShuffle.Text = "Add !shuffle";
            this.chkShuffle.UseVisualStyleBackColor = true;
            // 
            // lblThreadDelay
            // 
            this.lblThreadDelay.AutoSize = true;
            this.lblThreadDelay.Location = new System.Drawing.Point(381, 17);
            this.lblThreadDelay.Name = "lblThreadDelay";
            this.lblThreadDelay.Size = new System.Drawing.Size(101, 13);
            this.lblThreadDelay.TabIndex = 31;
            this.lblThreadDelay.Text = "Change paste delay";
            // 
            // numThreadDelay
            // 
            this.numThreadDelay.Location = new System.Drawing.Point(488, 15);
            this.numThreadDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numThreadDelay.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numThreadDelay.Name = "numThreadDelay";
            this.numThreadDelay.Size = new System.Drawing.Size(97, 20);
            this.numThreadDelay.TabIndex = 32;
            this.numThreadDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numThreadDelay.ValueChanged += new System.EventHandler(this.numThreadDelay_ValueChanged);
            // 
            // frmMusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 694);
            this.Controls.Add(this.numThreadDelay);
            this.Controls.Add(this.lblThreadDelay);
            this.Controls.Add(this.chkShuffle);
            this.Controls.Add(this.chkLq);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeletePlaylist);
            this.Controls.Add(this.gpbxTrackInfo);
            this.Controls.Add(this.lblDisplayPlaylist);
            this.Controls.Add(this.lblPlaylist);
            this.Controls.Add(this.txtSearchableName);
            this.Controls.Add(this.txtLinkToTrack);
            this.Controls.Add(this.lblSearchable);
            this.Controls.Add(this.lblLinkToTrack);
            this.Controls.Add(this.lblTrackName);
            this.Controls.Add(this.txtTrackName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddNewTrack);
            this.Controls.Add(this.btnNewPlaylist);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.tvPlaylists);
            this.Name = "frmMusicPlayer";
            this.Text = "Discord Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMusicPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmMusicPlayer_Load);
            this.gpbxTrackInfo.ResumeLayout(false);
            this.gpbxTrackInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPlaylists;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnNewPlaylist;
        private System.Windows.Forms.Button btnAddNewTrack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSearchableName;
        private System.Windows.Forms.TextBox txtLinkToTrack;
        private System.Windows.Forms.Label lblSearchable;
        private System.Windows.Forms.Label lblLinkToTrack;
        private System.Windows.Forms.Label lblTrackName;
        private System.Windows.Forms.TextBox txtTrackName;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.Label lblDisplayPlaylist;
        private System.Windows.Forms.GroupBox gpbxTrackInfo;
        private System.Windows.Forms.Button btnDeletePlaylist;
        private System.Windows.Forms.Label lblTrackInfoTrackName;
        private System.Windows.Forms.Label lblTrackInfoSearchableName;
        private System.Windows.Forms.LinkLabel lblTrackInfoLink;
        private System.Windows.Forms.Label lblTrackSelectedSearchable;
        private System.Windows.Forms.Label lblTrackSelectedLink;
        private System.Windows.Forms.Label lblTrackSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkLq;
        private System.Windows.Forms.CheckBox chkShuffle;
        private System.Windows.Forms.Label lblThreadDelay;
        private System.Windows.Forms.NumericUpDown numThreadDelay;
    }
}

