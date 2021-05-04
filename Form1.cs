using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using SpotifyAPI.Web;

namespace Spotify_Beatmap_Downloader
{
    public partial class Form1 : Form
    {
        readonly List<Button> buttons;
        static SpotifySession spotify;
        List<Beatmap> beatmaps;
        readonly List<Beatmap> downloads = new();

        Form1()
        {
            InitializeComponent();
            buttons = new List<Button> { spotifyBttn, openPlaylistsBttn, findBeatmapsBttn, downloadAllBttn, downloadSelectedBttn, startDownloadBttn, removeBeatmapBttn };
            DisplayPlaylists();
        }

        public static async Task<Form1> Create()
        {
            spotify = await SpotifySession.Start();
            return new Form1();
        }

        void DisplayPlaylists()
        {
            playlistView.Items.Clear();
            for (int i = 0; i < spotify.MyPlaylists.Count; i++)
            {
                playlistView.Items.Add(new ListViewItem(new string[] { spotify.MyPlaylists[i].Name, ((int)spotify.MyPlaylists[i].Tracks.Total).ToString("N0") }));
            }
        }

        void ToggleButtons()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = !button.Enabled;
            }
        }

        private async void SpotifyBttn_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            songView.Items.Clear();
            File.Delete("tokens.txt");
            spotify = await SpotifySession.Start();
            DisplayPlaylists();
            ToggleButtons();
        }

        private async void OpenPlaylistsBttn_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            songView.Items.Clear();
            beatmaps = new List<Beatmap>();
            foreach (int i in playlistView.SelectedIndices)
            {
                foreach (PlaylistTrack<IPlayableItem> playlistItem in await TryGettingPlaylist(i))
                {
                    if (playlistItem.Track is FullTrack song)
                    {
                        bool duplicate = false;
                        for (int j = beatmaps.Count - 1; j >= 0; j--)
                        {
                            if (duplicate = beatmaps[j].IsDuplicate(song))
                                break;
                        }
                        if (!duplicate)
                        {
                            songView.Items.Add(new ListViewItem(new string[] { Beatmap.ArtistsToString(song.Artists, ", "), song.Name }));
                            beatmaps.Add(new Beatmap(song.Artists, song.Name));
                        }
                    }
                }
            }
            ToggleButtons();
        }

        async Task<IList<PlaylistTrack<IPlayableItem>>> TryGettingPlaylist(int index)
        {
            try
            {
                return await spotify.PaginateAll(await spotify.Playlists.GetItems(spotify.MyPlaylists[index].Id));
            }
            catch (APIUnauthorizedException)
            {
                spotify = await spotify.Refresh();
                return await TryGettingPlaylist(index);
            }
        }

        private async void FindBeatmapsBttn_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            bool findAll = songView.SelectedItems.Count == 0;
            bool httpRequestException = false;
            for (int i = 0; i < songView.Items.Count; i++)
            {
                if ((findAll || songView.Items[i].Selected) && songView.Items[i].SubItems.Count == 2 && !httpRequestException)
                {
                    try
                    {
                        if (await beatmaps[i].FindBeatmap())
                        {
                            songView.Items[i].SubItems.Add("Yes");
                            songView.Items[i].Font = new Font(songView.Items[i].Font, FontStyle.Bold);
                        }
                        else
                        {
                            songView.Items[i].SubItems.Add("No");
                        }
                    }
                    catch (System.Net.Http.HttpRequestException)
                    {
                        songView.Items[i].SubItems.Add("No");
                        MessageBox.Show("Too many requests. Please wait a moment.", "Spotify Beatmaps Downloader", MessageBoxButtons.OK);
                        httpRequestException = true;
                    }
                }
            }
            ToggleButtons();
        }

        private void DownloadAllBttn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < songView.Items.Count; i++)
            {
                AddToDownloadQueue(i);
            }
        }

        private void DownloadSelectedBttn_Click(object sender, EventArgs e)
        {
            foreach (int i in songView.SelectedIndices)
            {
                AddToDownloadQueue(i);
            }
        }

        void AddToDownloadQueue(int index)
        {
            if (!songView.Items[index].Font.Bold)
                return;
            bool duplicate = false;
            for (int i = downloads.Count - 1; i >= 0; i--)
            {
                if (duplicate = downloads[i] == beatmaps[index])
                    break;
            }
            if (!duplicate)
            {
                downloadView.Items.Add(new ListViewItem(new string[] { songView.Items[index].Text, songView.Items[index].SubItems[1].Text, "Waiting" }));
                downloads.Add(beatmaps[index]);
            }
        }

        private async void StartDownloadBttn_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            Directory.CreateDirectory("downloads");
            for (int i = 0; i < downloadView.Items.Count; i++)
            {
                if (downloadView.Items[i].SubItems[2].Text == "Completed")
                    continue;
                downloadView.Items[i].SubItems[2].Text = "In Progress";
                await downloads[i].Download();
                downloadView.Items[i].SubItems[2].Text = "Completed";
            }
            MessageBox.Show("All beatmaps finished downloading.", "Spotify Beatmap Downloader", MessageBoxButtons.OK);
            ToggleButtons();
        }

        private void RemoveBeatmapBttn_Click(object sender, EventArgs e)
        {
            foreach (int i in downloadView.SelectedIndices)
            {
                downloadView.Items.RemoveAt(i);
                downloads.RemoveAt(i);
            }
        }
    }
}