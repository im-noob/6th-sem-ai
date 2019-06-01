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
                this.lblVersion.Text = "Versión del producto: v" + Application.ProductVersion.Substring(0, 3);
                Fecha_Revision = Format_Int(Fecha.Day) + "/" + Format_Int(Fecha.Month) + "/" + Format_Int(Fecha.Year);
                this.lblRevision.Text = "Fecha de la última revisión: " + Fecha_Revision;
            }
        #endregion
        #region "Metodos Privados"
            private string Format_Int(int num)
            {
                return (num > 9) ? num.ToString() : "0" + num.ToString();
            }
        #endregion    
    }
}
