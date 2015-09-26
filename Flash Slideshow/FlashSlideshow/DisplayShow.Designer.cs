namespace FlashSlideshow
{
    partial class DisplayShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayShow));
            this.axShockwaveFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).BeginInit();
            this.SuspendLayout();
            // 
            // axShockwaveFlash
            // 
            this.axShockwaveFlash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axShockwaveFlash.Enabled = true;
            this.axShockwaveFlash.Location = new System.Drawing.Point(0, 0);
            this.axShockwaveFlash.Name = "axShockwaveFlash";
            this.axShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash.OcxState")));
            this.axShockwaveFlash.Size = new System.Drawing.Size(512, 400);
            this.axShockwaveFlash.TabIndex = 0;
            // 
            // DisplayShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 400);
            this.Controls.Add(this.axShockwaveFlash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayShow";
            this.Text = "Flash Slideshow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.DisplayShow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash;
    }
}

