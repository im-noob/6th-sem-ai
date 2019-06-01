using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sliding_Puzzle
{
    public partial class frmAbout : Form
    {
        #region "Constructor"
            public frmAbout()
            {
                InitializeComponent();
                string Fecha_Revision = "";
                DateTime Fecha = System.IO.File.GetLastWriteTime(Application.ExecutablePath).Date;
                Fecha_Revision = Format_Int(Fecha.Day) + "/" + Format_Int(Fecha.Month) + "/" + Format_Int(Fecha.Year);
            }
        #endregion
        #region "Metodos Privados"
            private string Format_Int(int num)
            {
                return (num > 9) ? num.ToString() : "0" + num.ToString();
            }
        #endregion

        private void lblAutor_Click(object sender, EventArgs e)
        {

        }
    }
}
