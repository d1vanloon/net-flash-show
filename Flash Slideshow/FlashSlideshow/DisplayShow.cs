using System;
using System.IO;
using System.Windows.Forms;

namespace FlashSlideshow
{
    /// <summary>
    /// Displays a series of .swf files full-screen 
    /// looped in sequence.
    /// </summary>
    public partial class DisplayShow : Form
    {
        /// <summary>
        /// The in-memory collection of filenames 
        /// corresponding to the .swf files to show.
        /// </summary>
        private string[] filenames;
        /// <summary>
        /// An instance variable indicating the index of the 
        /// currently displayed file in the filenames array.
        /// </summary>
        /// <seealso cref="filenames"/>
        private int currentFile = 0;
        /// <summary>
        /// The timer used to poll the flash player component
        /// for play status.
        /// </summary>
        private Timer intervals;

        /// <summary>
        /// Constructor to initialize the UI elements.
        /// </summary>
        public DisplayShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Aquire the file names to display. This is either
        /// by prompting the user with a file selection dialog
        /// or by scanning the folder specified by the command
        /// line argument.
        /// </summary>
        /// <returns>An array of file names corresponding 
        /// to .swf files to display.</returns>
        /// <seealso cref="filenames"/>
        private string[] GetFileNames()
        {
            string commandLineDirectory = GetFolderCommandLineArgument();

            if (commandLineDirectory == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Filter = "Shockwave Flash | *.swf";
                dialog.ShowDialog(this);

                return dialog.FileNames;
            }
            else
            {
                return Directory.GetFiles(
                    Path.GetFullPath(commandLineDirectory), 
                    "*.swf", SearchOption.TopDirectoryOnly);
            }
        }

        /// <summary>
        /// Returns the command line argument describing the folder
        /// containing file names to display, if it exists.
        /// </summary>
        /// <returns>A string describing the folder containing the 
        /// file names to display, or null if the argument was not
        /// provided.</returns>
        private string GetFolderCommandLineArgument()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                return args[1];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Event handler for the Timer tick event.
        /// </summary>
        /// <seealso cref="intervals"/>
        /// <seealso cref="Timer.Tick"/>
        private void Intervals_Tick(object sender, EventArgs e)
        {
            MonitorMovieStatus();
        }

        /// <summary>
        /// Sets the currently displayed .swf file to be
        /// the file in the filenames array indicated by
        /// the currentFile index.
        /// </summary>
        /// <seealso cref="filenames"/>
        /// <seealso cref="currentFile"/>
        private void ShowCurrentMovie()
        {
            axShockwaveFlash.Movie = filenames[currentFile];
            axShockwaveFlash.Loop = false;
            axShockwaveFlash.Play();
            BringToFront();
            Activate();
        }

        /// <summary>
        /// Polls the .swf movie status to determine if
        /// it is currently playing. If not, the next movie
        /// is shown.
        /// </summary>
        /// <seealso cref="ShowCurrentMovie"/>
        private void MonitorMovieStatus()
        {
            if (axShockwaveFlash.IsPlaying() == false || axShockwaveFlash.Movie == null)
            {
                ShowCurrentMovie();
                currentFile = (currentFile + 1) % filenames.Length;
            }
        }

        /// <summary>
        /// Begins the show by hiding the cursor and setting up
        /// the polling Timer.
        /// </summary>
        private void StartShow()
        {
            if (filenames.Length > 0)
            {
                Cursor.Hide();

                intervals = new Timer();
                intervals.Interval = 500;
                intervals.Tick += Intervals_Tick;
                intervals.Start();
            }
            else
            {
                MessageBox.Show(this, "No files were selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Event handler for when the form is shown. This
        /// triggers the request for file names followed by
        /// the beginning of the show.
        /// </summary>
        /// <seealso cref="Form.Shown"/>
        /// <seealso cref="GetFileNames"/>
        /// <seealso cref="StartShow"/>
        private void DisplayShow_Shown(object sender, EventArgs e)
        {
            filenames = GetFileNames();
            
            StartShow();
        }
    }
}
