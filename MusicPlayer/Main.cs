using MusicPlayer.Model;

namespace MusicPlayer
{
    public partial class Main : Form
    {
        List<MusicTrack> MusicList = new List<MusicTrack>();
        List<string> AllowedMusicFormat = new List<string> {
            ".mp3",
            ".wav",
            ".flac",
            ".aac",
            ".m4a",
            ".ogg",
            ".wma",
            ".aiff",
            ".alac"
        };

        private NAudio.Wave.IWavePlayer waveOutDevice;
        private NAudio.Wave.AudioFileReader audioFileReader;
        private bool isPaused = false;

        private int previousVolume = 50;
        public Main()
        {
            InitializeComponent();
            playedMusic_lbl.Text = string.Empty;
            playbackTime_lbl.Text = string.Empty;
            volumePercent_lbl.Text = $"{volume_trackbar.Value.ToString()}%";
            music_trackbar.Enabled = false;
        }

        private List<MusicTrack> PrepareMusicList(List<string> files)
        {
            var localList = new List<MusicTrack>();
            foreach (var item in files)
            {
                var track = new MusicTrack()
                {
                    Name = Path.GetFileName(item),
                    Path = item,
                    Duration = TimeSpan.Zero,
                    Author = "",
                    Album = "",
                };
                try
                {
                    using (var file = TagLib.File.Create(item))
                    {
                        track.Duration = file.Properties.Duration;
                        if (file.Tag.Performers.Length > 0)
                        {
                            track.Author = string.Join(", ", file.Tag.Performers);
                        }
                        if (!string.IsNullOrEmpty(file.Tag.Album))
                        {
                            track.Album = file.Tag.Album;
                        }
                    }
                }
                catch { }
                localList.Add(track);
            }
            return localList;
        }

        private void PrepareListView(List<MusicTrack> tracks)
        {
            musicList_listview.View = View.Details;
            musicList_listview.FullRowSelect = true;

            musicList_listview.Columns.Clear();
            musicList_listview.Columns.Add("File Name", 200);
            musicList_listview.Columns.Add("Duration", 80);
            musicList_listview.Columns.Add("Author / Artist", 150);
            musicList_listview.Columns.Add("Album", 150);

            musicList_listview.Items.Clear();

            foreach (var track in tracks)
            {
                ListViewItem item = new ListViewItem(track.Name);
                item.SubItems.Add(track.FormattedDuration);
                item.SubItems.Add(track.Author);
                item.SubItems.Add(track.Album);

                // Store the path in the Tag property for easy access later
                item.Tag = track.Path;

                musicList_listview.Items.Add(item);
            }
        }

        private async void selectDirectory_btn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectDirectory_btn.Enabled = false;
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        List<MusicTrack> loadedTracks = await Task.Run(() =>
                        {
                            List<string> files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories)
                                .Where(x => AllowedMusicFormat.Contains(Path.GetExtension(x), StringComparer.OrdinalIgnoreCase))
                                .ToList();
                            if (files.Count > 0)
                            {
                                return PrepareMusicList(files);
                            }
                            return new List<MusicTrack>();
                        });

                        if (loadedTracks.Count > 0)
                        {
                            MusicList = loadedTracks;
                            PrepareListView(MusicList);
                        }
                        else
                        {
                            MessageBox.Show(
                                "The selected directory does not contain any supported music files.",
                                "No Music Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                    finally
                    {
                        selectDirectory_btn.Enabled = true;
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void DisplayAlbumArt(string filePath)
        {
            try
            {
                using (var file = TagLib.File.Create(filePath))
                {
                    if (file.Tag.Pictures.Length > 0)
                    {
                        var bin = file.Tag.Pictures[0].Data.Data;
                        using (var ms = new MemoryStream(bin))
                        {
                            Image originalImage = Image.FromStream(ms);
                            if (musicPicture_pictureBox.Image != null)
                            {
                                musicPicture_pictureBox.Image.Dispose();
                            }
                            musicPicture_pictureBox.Image = new Bitmap(originalImage);
                        }
                    }
                    else
                    {
                        musicPicture_pictureBox.Image = null;
                    }
                }
            }
            catch (Exception)
            {
                musicPicture_pictureBox.Image = null;
            }
        }

        private void musicList_listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (musicList_listview.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList_listview.SelectedItems[0];
                MusicTrack track = MusicList.FirstOrDefault(x => x.Path == (string)selectedItem.Tag);
                PlayMusic(track);
            }
        }

        private void searchInput_textbox_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchInput_textbox.Text.Trim();
            List<MusicTrack> filteredList = MusicList.Where(x => x.Name.ToLower().Contains(keyword.ToLower()) || x.Author.ToLower().Contains(keyword.ToLower())).ToList();
            PrepareListView(filteredList);
        }

        private void PlayMusic(MusicTrack track)
        {
            if (track == null) return;

            try
            {
                StopCurrentAudio();

                DisplayAlbumArt(track.Path);

                // Initialize NAudio playback
                waveOutDevice = new NAudio.Wave.WaveOutEvent();
                audioFileReader = new NAudio.Wave.AudioFileReader(track.Path);
                audioFileReader.Volume = (float)volume_trackbar.Value / 100f;

                waveOutDevice.Init(audioFileReader);

                waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;

                waveOutDevice.Play();
                isPaused = false;

                playedMusic_lbl.Text = track.Name;
                music_trackbar.Enabled = true;
                music_trackbar.Minimum = 0;
                music_trackbar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                music_trackbar.Value = 0;

                playback_timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not play file: {ex.Message}", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WaveOutDevice_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleTrackEnd()));
            }
            else
            {
                HandleTrackEnd();
            }
        }

        private void StopCurrentAudio()
        {
            playback_timer.Stop();

            if (waveOutDevice != null)
            {
                waveOutDevice.PlaybackStopped -= WaveOutDevice_PlaybackStopped;

                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            isPaused = false;
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            // resume
            if (isPaused && waveOutDevice != null)
            {
                waveOutDevice.Play();
                isPaused = false;
                return;
            }
            // nothing played, but an item selected
            if (waveOutDevice == null && musicList_listview.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = musicList_listview.SelectedItems[0];
                MusicTrack track = MusicList.FirstOrDefault(x => x.Path == (string)selectedItem.Tag);
                PlayMusic(track);
            }
            // pause if playing
            else if (waveOutDevice != null && waveOutDevice.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                waveOutDevice.Pause();
                isPaused = true;
            }
        }

        private void pause_btn_Click(object sender, EventArgs e)
        {
            if (waveOutDevice != null && waveOutDevice.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                waveOutDevice.Pause();
                isPaused = true;
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            StopCurrentAudio();
        }

        private void music_trackbar_Scroll(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(music_trackbar.Value);
            }
        }

        private void playback_timer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice != null && waveOutDevice.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                int currentSeconds = (int)audioFileReader.CurrentTime.TotalSeconds;
                if (currentSeconds <= music_trackbar.Maximum)
                {
                    music_trackbar.Value = currentSeconds;

                    string currentFormatted = audioFileReader.CurrentTime.ToString(@"mm\:ss");
                    string totalFormatted = audioFileReader.TotalTime.ToString(@"mm\:ss");

                    playbackTime_lbl.Text = $"{currentFormatted} / {totalFormatted}";
                }
            }
        }

        private void volume_trackbar_Scroll(object sender, EventArgs e)
        {
            volumePercent_lbl.Text = $"{volume_trackbar.Value.ToString()}%";
            if (audioFileReader != null)
            {
                audioFileReader.Volume = (float)volume_trackbar.Value / 100f;
            }
        }

        private void HandleTrackEnd()
        {
            if (repeat_checkbox.Checked && audioFileReader != null)
            {
                audioFileReader.CurrentTime = TimeSpan.Zero;
                waveOutDevice.Play();
            }
            else if (shuffle_checkbox.Checked && MusicList.Count > 0)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(0, MusicList.Count);

                musicList_listview.SelectedItems.Clear();
                musicList_listview.Items[randomIndex].Selected = true;
                musicList_listview.Items[randomIndex].EnsureVisible();

                PlayMusic(MusicList[randomIndex]);
            }
            else
            {
                StopCurrentAudio();
            }
        }

        private void mute_btn_Click(object sender, EventArgs e)
        {
            if (volume_trackbar.Value > 0)
            {
                previousVolume = volume_trackbar.Value;

                volume_trackbar.Value = 0;
                if (audioFileReader != null)
                {
                    audioFileReader.Volume = 0.0f;
                }
                mute_btn.Text = "Unmute";
                volumePercent_lbl.Text = $"0%";
            }
            else
            {
                volume_trackbar.Value = previousVolume;
                if (audioFileReader != null)
                {
                    audioFileReader.Volume = (float)previousVolume / 100f;
                }
                mute_btn.Text = "Mute";
                volumePercent_lbl.Text = $"{previousVolume}%";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "C# Music Player v1.0\n" +
                     "Developed by Qasem Talaee\n\n" +
                     "GitHub: https://github.com/qasem-talaee";

            // Show a message box, or open the link directly if clicked
            DialogResult result = MessageBox.Show(
                $"{message}\n\nDo you want to open my GitHub profile?",
                "About Music Player",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://github.com/qasem-talaee",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open link: {ex.Message}");
                }
            }
        }
    }
}