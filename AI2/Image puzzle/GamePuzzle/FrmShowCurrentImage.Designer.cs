namespace GamePuzzle
{
    partial class FrmShowCurrentImage
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
            this.PictureBoxMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxMain
            // 
            this.PictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxMain.Location = new System.Drawing.Point(3, 3);
            this.PictureBoxMain.Name = "PictureBoxMain";
            this.PictureBoxMain.Size = new System.Drawing.Size(288, 265);
            this.PictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxMain.TabIndex = 0;
            this.PictureBoxMain.TabStop = false;
            this.PictureBoxMain.Click += new System.EventHandler(this.PictureBoxMain_Click);
            // 
            // FrmShowCurrentImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 271);
            this.Controls.Add(this.PictureBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FrmShowCurrentImage";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmShowCurrentImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMain;
    }
}