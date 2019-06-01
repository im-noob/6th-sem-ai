using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamePuzzle
{
    public partial class FrmShowCurrentImage : Form
    {
        public FrmShowCurrentImage(Bitmap Img)
        {
            InitializeComponent();
            this.PictureBoxMain.Image = Img;
        }

        public Bitmap Img
        {
            set
            {
                this.PictureBoxMain.Image = value;
            }
        }

        private void FrmShowCurrentImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public new void Show()
        {
            base.Show();
            base.BringToFront();
        }

        private void PictureBoxMain_Click(object sender, EventArgs e)
        {

        }
    }
}
