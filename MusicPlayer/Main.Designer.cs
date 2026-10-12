namespace MusicPlayer
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            music_trackbar = new TrackBar();
            groupBox1 = new GroupBox();
            searchInput_textbox = new TextBox();
            label1 = new Label();
            musicList_listview = new ListView();
            selectDirectory_btn = new Button();
            play_btn = new Button();
            pause_btn = new Button();
            stop_btn = new Button();
            musicPicture_pictureBox = new PictureBox();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            mute_btn = new Button();
            volume_trackbar = new TrackBar();
            volumePercent_lbl = new Label();
            groupBox3 = new GroupBox();
            shuffle_checkbox = new CheckBox();
            repeat_checkbox = new CheckBox();
            playbackTime_lbl = new Label();
            playedMusic_lbl = new Label();
            playback_timer = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)music_trackbar).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)musicPicture_pictureBox).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)volume_trackbar).BeginInit();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // music_trackbar
            // 
            music_trackbar.Location = new Point(6, 511);
            music_trackbar.Name = "music_trackbar";
            music_trackbar.Size = new Size(526, 45);
            music_trackbar.TabIndex = 6;
            music_trackbar.TickStyle = TickStyle.None;
            music_trackbar.Scroll += music_trackbar_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(searchInput_textbox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(musicList_listview);
            groupBox1.Controls.Add(selectDirectory_btn);
            groupBox1.Location = new Point(12, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 624);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Music Selector";
            // 
            // searchInput_textbox
            // 
            searchInput_textbox.Location = new Point(60, 56);
            searchInput_textbox.Name = "searchInput_textbox";
            searchInput_textbox.Size = new Size(325, 23);
            searchInput_textbox.TabIndex = 3;
            searchInput_textbox.TextChanged += searchInput_textbox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 59);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 2;
            label1.Text = "Search :";
            // 
            // musicList_listview
            // 
            musicList_listview.Location = new Point(6, 85);
            musicList_listview.Name = "musicList_listview";
            musicList_listview.Size = new Size(379, 533);
            musicList_listview.TabIndex = 1;
            musicList_listview.UseCompatibleStateImageBehavior = false;
            musicList_listview.MouseDoubleClick += musicList_listview_MouseDoubleClick;
            // 
            // selectDirectory_btn
            // 
            selectDirectory_btn.Location = new Point(6, 22);
            selectDirectory_btn.Name = "selectDirectory_btn";
            selectDirectory_btn.Size = new Size(379, 31);
            selectDirectory_btn.TabIndex = 0;
            selectDirectory_btn.Text = "Select Directory";
            selectDirectory_btn.UseVisualStyleBackColor = true;
            selectDirectory_btn.Click += selectDirectory_btn_Click;
            // 
            // play_btn
            // 
            play_btn.Location = new Point(330, 592);
            play_btn.Name = "play_btn";
            play_btn.Size = new Size(82, 23);
            play_btn.TabIndex = 1;
            play_btn.Text = "Play";
            play_btn.UseVisualStyleBackColor = true;
            play_btn.Click += play_btn_Click;
            // 
            // pause_btn
            // 
            pause_btn.Location = new Point(434, 592);
            pause_btn.Name = "pause_btn";
            pause_btn.Size = new Size(80, 23);
            pause_btn.TabIndex = 2;
            pause_btn.Text = "Pause";
            pause_btn.UseVisualStyleBackColor = true;
            pause_btn.Click += pause_btn_Click;
            // 
            // stop_btn
            // 
            stop_btn.Location = new Point(534, 592);
            stop_btn.Name = "stop_btn";
            stop_btn.Size = new Size(80, 23);
            stop_btn.TabIndex = 3;
            stop_btn.Text = "Stop";
            stop_btn.UseVisualStyleBackColor = true;
            stop_btn.Click += stop_btn_Click;
            // 
            // musicPicture_pictureBox
            // 
            musicPicture_pictureBox.BorderStyle = BorderStyle.FixedSingle;
            musicPicture_pictureBox.Location = new Point(6, 37);
            musicPicture_pictureBox.Name = "musicPicture_pictureBox";
            musicPicture_pictureBox.Size = new Size(608, 468);
            musicPicture_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            musicPicture_pictureBox.TabIndex = 4;
            musicPicture_pictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientActiveCaption;
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(stop_btn);
            groupBox2.Controls.Add(playbackTime_lbl);
            groupBox2.Controls.Add(music_trackbar);
            groupBox2.Controls.Add(playedMusic_lbl);
            groupBox2.Controls.Add(musicPicture_pictureBox);
            groupBox2.Controls.Add(pause_btn);
            groupBox2.Controls.Add(play_btn);
            groupBox2.Location = new Point(409, 24);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(620, 624);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Music";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(mute_btn);
            groupBox4.Controls.Add(volume_trackbar);
            groupBox4.Controls.Add(volumePercent_lbl);
            groupBox4.Location = new Point(6, 541);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(320, 74);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Volume";
            // 
            // mute_btn
            // 
            mute_btn.Location = new Point(232, 44);
            mute_btn.Name = "mute_btn";
            mute_btn.Size = new Size(82, 23);
            mute_btn.TabIndex = 11;
            mute_btn.Text = "Not Muted";
            mute_btn.UseVisualStyleBackColor = true;
            mute_btn.Click += mute_btn_Click;
            // 
            // volume_trackbar
            // 
            volume_trackbar.Location = new Point(3, 22);
            volume_trackbar.Maximum = 100;
            volume_trackbar.Name = "volume_trackbar";
            volume_trackbar.Size = new Size(223, 45);
            volume_trackbar.TabIndex = 8;
            volume_trackbar.TickStyle = TickStyle.None;
            volume_trackbar.Value = 50;
            volume_trackbar.Scroll += volume_trackbar_Scroll;
            // 
            // volumePercent_lbl
            // 
            volumePercent_lbl.AutoSize = true;
            volumePercent_lbl.Location = new Point(232, 20);
            volumePercent_lbl.Name = "volumePercent_lbl";
            volumePercent_lbl.Size = new Size(50, 15);
            volumePercent_lbl.TabIndex = 10;
            volumePercent_lbl.Text = "Volume ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(shuffle_checkbox);
            groupBox3.Controls.Add(repeat_checkbox);
            groupBox3.Location = new Point(332, 541);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(282, 45);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Controls";
            // 
            // shuffle_checkbox
            // 
            shuffle_checkbox.AutoSize = true;
            shuffle_checkbox.Location = new Point(84, 20);
            shuffle_checkbox.Name = "shuffle_checkbox";
            shuffle_checkbox.Size = new Size(63, 19);
            shuffle_checkbox.TabIndex = 1;
            shuffle_checkbox.Text = "Shuffle";
            shuffle_checkbox.UseVisualStyleBackColor = true;
            // 
            // repeat_checkbox
            // 
            repeat_checkbox.AutoSize = true;
            repeat_checkbox.Location = new Point(6, 20);
            repeat_checkbox.Name = "repeat_checkbox";
            repeat_checkbox.Size = new Size(62, 19);
            repeat_checkbox.TabIndex = 0;
            repeat_checkbox.Text = "Repeat";
            repeat_checkbox.UseVisualStyleBackColor = true;
            // 
            // playbackTime_lbl
            // 
            playbackTime_lbl.AutoSize = true;
            playbackTime_lbl.Location = new Point(538, 511);
            playbackTime_lbl.Name = "playbackTime_lbl";
            playbackTime_lbl.Size = new Size(38, 15);
            playbackTime_lbl.TabIndex = 7;
            playbackTime_lbl.Text = "label2";
            // 
            // playedMusic_lbl
            // 
            playedMusic_lbl.AutoSize = true;
            playedMusic_lbl.Location = new Point(6, 19);
            playedMusic_lbl.Name = "playedMusic_lbl";
            playedMusic_lbl.Size = new Size(38, 15);
            playedMusic_lbl.TabIndex = 5;
            playedMusic_lbl.Text = "label2";
            // 
            // playback_timer
            // 
            playback_timer.Interval = 500;
            playback_timer.Tick += playback_timer_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1041, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 653);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)music_trackbar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)musicPicture_pictureBox).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)volume_trackbar).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button selectDirectory_btn;
        private ListView musicList_listview;
        private TextBox searchInput_textbox;
        private Label label1;
        private Button play_btn;
        private Button pause_btn;
        private Button stop_btn;
        private PictureBox musicPicture_pictureBox;
        private GroupBox groupBox2;
        private Label playedMusic_lbl;
        private TrackBar music_trackbar;
        private System.Windows.Forms.Timer playback_timer;
        private Label playbackTime_lbl;
        private TrackBar volume_trackbar;
        private Label volumePercent_lbl;
        private GroupBox groupBox3;
        private CheckBox repeat_checkbox;
        private CheckBox shuffle_checkbox;
        private GroupBox groupBox4;
        private Button mute_btn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
