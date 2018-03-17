using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace MusicRepoAndPlayer
{



    public partial class frmMusicPlayer : Form
    {

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll")]
        private static extern bool GetCaretPos(out Point point);

        [DllImport("user32.dll")]
        private static extern uint GetCaretBlinkTime();



        public enum KeyModifier
        {
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        private static int _ThreadDelay = 4000;
        public static Task CopyRunTask = new Task(() => CopyRun());
        public static CancellationToken cancelToken;
        public static CancellationTokenSource cancelTokenSource;
        private bool LQDone = false;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312) //0x0312 = WM_HOTKEY
            {
                int key = (int)m.LParam >> 16 & 0xFFFF;
                int modifier = (int)m.LParam & 0xFFFF;
                CancellationTokenSource ts = new CancellationTokenSource();
                CancellationToken ct = ts.Token;
                cancelTokenSource = ts;
                cancelToken = ct;
                if (key == (int)Keys.V && modifier == (int)(KeyModifier.Alt | KeyModifier.Control))
                {

                    //If Ctrl + Alt + V Pressed
                    if (CheckIfActiveProcess("Discord"))
                    {
                      
                        if (CopyRunTask.Status != TaskStatus.Running)
                        {
                            
                            if (chkLq.Checked && !LQDone)
                            {
                                SendKeys.SendWait("!lq {enter}");
                                LQDone = true;

                            }
                            CopyRunTask.Start();
                            if (chkShuffle.Checked)
                            {
                                SendKeys.SendWait("!shuffle");
                            }
                        }

                        //task.Wait();
                    }
                }

            }
        }

        public static bool CheckIfActiveProcess(string processName, bool checkCusor = false)
        {
            if (GetForegroundWindow() == IntPtr.Zero)
            {
                return false;
            }
            GetWindowThreadProcessId(GetForegroundWindow(), out int procID);

            // return activeProcId == procId;
            return Process.GetProcessById(procID).ProcessName == processName;

        }

        private int _hotkeyID = 15;
        private int _hotkey = (int)Keys.V; //0x56

        private bool _UpdateSearch = false;
        private static Music _Music;
        private static string _SelectedPlaylist = null;

        private void PopulateTreeView(Music music)
        {
            tvPlaylists.Nodes.Clear();
            foreach (KeyValuePair<string, Playlist> playlist in music.Playlists)
            {
                TreeNode currentNode = tvPlaylists.Nodes.Add(playlist.Key);
                foreach (string trackName in playlist.Value.Tracks.Keys)
                {
                    currentNode.Nodes.Add(trackName);
                }
            }
        }

        private TreeNode RecursiveFindRootNode(TreeNode childNode)
        {
            if (childNode.Level == 0 || childNode.Parent == null)
            {
                return childNode;
            }

            return RecursiveFindRootNode(childNode.Parent);

        }

        public frmMusicPlayer()
        {
            InitializeComponent();
        }

        private void btnNewPlaylist_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for your new playlist", "Add a new Playlist");
            if (input != null && input != string.Empty)
            {
                Playlist playlist = new Playlist(input);
                if (tvPlaylists.Nodes.CaseSensitiveFind(input) != null)
                {
                    //Playlist might be overwritten
                    if (_Music.AddPlaylist(playlist, true))
                    {
                        tvPlaylists.BeginUpdate();
                        tvPlaylists.Nodes.Remove(tvPlaylists.Nodes.CaseSensitiveFind(input));
                        tvPlaylists.Nodes.Add(input);
                        tvPlaylists.EndUpdate();
                    }
                }
                else
                {
                    _Music.AddPlaylist(playlist);
                    tvPlaylists.Nodes.Add(input);
                }

            }


        }

        private void frmMusicPlayer_Load(object sender, EventArgs e)
        {
            tvPlaylists.LabelEdit = false;
            tvPlaylists.Sorted = true;
            lblTrackInfoLink.Text = "No Track Selected";
            lblTrackInfoSearchableName.Text = "No Track Selected";
            lblTrackInfoTrackName.Text = "No Track Selected";
            _Music = JSONSerialisation.ReadFromFile<Music>(JSONSerialisation.DefaultPath);
            if (_Music != null)
            {
                PopulateTreeView(_Music);
            }
            else
            {
                _Music = new Music();
            }
            bool test = RegisterHotKey(this.Handle, _hotkeyID, (int)(KeyModifier.Alt | KeyModifier.Control), _hotkey);

        }

        private void tvPlaylists_DoubleClick(object sender, EventArgs e)
        {
            if (tvPlaylists.LabelEdit == true)
            {
                tvPlaylists.SelectedNode.BeginEdit();
            }

        }

        private void txtTrackName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearchableName.Text == "" || txtTrackName.Text == txtSearchableName.Text)
            {
                _UpdateSearch = true;
                txtSearchableName.Text = txtTrackName.Text;
            }
        }

        private void txtTrackName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchableName.Text == "" || _UpdateSearch || txtTrackName.Text == txtSearchableName.Text)
            {
                _UpdateSearch = false;
                txtSearchableName.Text = txtTrackName.Text;
            }
        }

        private void btnAddNewTrack_Click(object sender, EventArgs e)
        {
            if (_SelectedPlaylist != null)
            {
                if (txtSearchableName.Text != "" && txtSearchableName.Text != "" && txtLinkToTrack.Text != "" && tvPlaylists.SelectedNode != null)
                {
                    TreeNode node = tvPlaylists.SelectedNode;
                    if (node.Level != 0 || node.Parent != null)
                    {
                        //recursively find parent
                        node = RecursiveFindRootNode(node);
                    }

                    string searchTerm = txtSearchableName.Text;
                    string trackName = txtTrackName.Text;
                    string link = txtLinkToTrack.Text;

                    Track track = new Track(trackName, link, searchTerm);

                    TrackOptions trackOptions = _Music.AddTrack(track, node.Text, true);
                    if (trackOptions == TrackOptions.Overwrite)
                    {
                        tvPlaylists.BeginUpdate();
                        node.Nodes.Remove(node.Nodes.CaseSensitiveFind(track.TrackName));
                        node.Nodes.Add(track.TrackName);
                        tvPlaylists.EndUpdate();
                        txtSearchableName.Clear();
                        txtTrackName.Clear();
                        txtLinkToTrack.Clear();
                    }
                    else if (trackOptions == TrackOptions.Success)
                    {
                        node.Nodes.Add(track.TrackName);
                        txtSearchableName.Clear();
                        txtTrackName.Clear();
                        txtLinkToTrack.Clear();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a playlist first!", "Error");
            }
        }

        private void frmMusicPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Music != null)
            {
                JSONSerialisation.WriteToFile(_Music, JSONSerialisation.DefaultPath);
            }

            UnregisterHotKey(this.Handle, _hotkeyID);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Music != null)
            {
                JSONSerialisation.WriteToFile(_Music, JSONSerialisation.DefaultPath);
            }
        }

        private void tvPlaylists_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null) //If it is a top level node (a playlist)
            {
                lblDisplayPlaylist.Text = e.Node.Text;
                _SelectedPlaylist = e.Node.Text;
                lblTrackInfoTrackName.Text = "No Track Selected";
                lblTrackInfoSearchableName.Text = "No Track Selected";
                lblTrackInfoLink.Text = "No Track Selected";
            }
            else
            {
                Track track = _Music.FindTrack(e.Node.Text, RecursiveFindRootNode(e.Node).Text);
                lblTrackInfoTrackName.Text = track.TrackName;
                lblTrackInfoSearchableName.Text = track.SearchString;
                lblTrackInfoLink.Text = track.Link;
            }

        }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (_SelectedPlaylist != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the " + _SelectedPlaylist + " Playlist? \n This will delete all the tracks as well!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    _Music.DeletePlaylist(_SelectedPlaylist);
                    TreeNode node = tvPlaylists.SelectedNode.Parent == null ? tvPlaylists.SelectedNode : RecursiveFindRootNode(tvPlaylists.SelectedNode);
                    node.Remove();

                }

            }
        }


        private void tvPlaylists_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string type = tvPlaylists.SelectedNode.Parent == null ? "Playlist" : "track";

                string name = tvPlaylists.SelectedNode.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete the " + name + " " + type + "?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    if (type == "Playlist")
                    {
                        _Music.DeletePlaylist(name);

                    }
                    else
                    {
                        string trackName = tvPlaylists.SelectedNode.Text;
                        string playlistName = RecursiveFindRootNode(tvPlaylists.SelectedNode).Text;
                        _Music.DeleteTrack(trackName, playlistName);
                    }

                    tvPlaylists.SelectedNode.Remove();
                }
            }
        }

        public static void CopyRun()
        {

            List<Track> tracks =  _Music.GetPlaylist(_SelectedPlaylist);
            foreach (Track track in tracks)
            {
if (cancelToken.IsCancellationRequested)
                {
                    break;
                }
                else
                {

                    if (!CheckIfActiveProcess("Discord"))
                    {
                        cancelTokenSource.Cancel();
                    }

                    Thread.Sleep(_ThreadDelay);
                    SendKeys.SendWait("!p " + track.SearchString + "{enter}");
                    Console.WriteLine("Adding " + track.TrackName);
                }
            }
           
                
            
        }

        private void lblTrackInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Navigate(lblTrackInfoLink.Text);
        }

        private void numThreadDelay_ValueChanged(object sender, EventArgs e)
        {
            _ThreadDelay = (int)numThreadDelay.Value;
        }
    }

    static class TreeNodeCollectionExtensions
    {
        public static TreeNode CaseSensitiveFind(this TreeNodeCollection tnc, string textToFind)
        {
            foreach (TreeNode tn in tnc)
            {
                if (tn.Text == textToFind)
                {
                    return tn;
                }
            }
            return null;
        }
    }

}
