using System;
using System.Windows.Forms;

namespace FlashSlideshow
{
    public partial class DisplayShow : Form
    {
        private string[] filenames;
        private int currentFile = 0;
        private Timer intervals;

        public DisplayShow()
        {
            InitializeComponent();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Shockwave Flash | *.swf";
            dialog.ShowDialog(this);

            filenames = dialog.FileNames;

            Cursor.Hide();

            intervals = new Timer();
            intervals.Interval = 500;
            intervals.Tick += Intervals_Tick;
            intervals.Start();
        }

        private void Intervals_Tick(object sender, EventArgs e)
        {
            monitorMovieStatus();
        }

        private void showNextMovie()
        {
            axShockwaveFlash.Movie = filenames[currentFile];
            axShockwaveFlash.Loop = false;
            axShockwaveFlash.Play();
        }

        private void monitorMovieStatus()
        {
            if (axShockwaveFlash.IsPlaying() == false || axShockwaveFlash.Movie == null)
            {
                showNextMovie();
                currentFile = (currentFile + 1) % filenames.Length;
            }
        }
    }
}
