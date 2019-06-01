using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sliding_Puzzle
{
    public partial class frmWin : Form
    {
        #region "Variables Globales"
            clsClasificaciones tmpClasificaciones = null;
            structClasificacion tmpClasificacion;
        #endregion
        #region "Main"
            #region "Constructor"
                public frmWin(ref clsClasificaciones Clasificaciones, ref structClasificacion Clasificacion)
                {
                    InitializeComponent();
                    this.tmpClasificacion = Clasificacion;
                    this.tmpClasificaciones = Clasificaciones;
                    this.txtUser.Text = Clasificacion.Player;
                }
            #endregion
            #region "Destructor"
                private void frmWin_FormClosing(object sender, FormClosingEventArgs e)
                {
                    if (this.txtUser.Text.Trim() != string.Empty)
                    {
                        Properties.Settings.Default.conf_LastUser = this.txtUser.Text.Trim();
                        Properties.Settings.Default.Save();
                        tmpClasificacion.Player = Properties.Settings.Default.conf_LastUser;
                    }
                    tmpClasificaciones.Conectar_BBDD_Clasificaciones();
                    this.tmpClasificaciones.InsertarClasificacion(tmpClasificacion);
                    tmpClasificaciones.Desconectar_BBDD_Clasificaciones();
                }
            #endregion
            #region "Controles"
                private void txtUser_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.Close();
                    }
                }
            #endregion
        #endregion
    }
}
