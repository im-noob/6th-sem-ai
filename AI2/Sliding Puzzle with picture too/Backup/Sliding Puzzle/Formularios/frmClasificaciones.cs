using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sliding_Puzzle
{
    public partial class frmClasificaciones : Form
    {
        #region "Constructor"
            public frmClasificaciones(ref clsClasificaciones Clasificaciones, string boardFilter)
            {
                InitializeComponent();
                int countClasificaciones = 1;
                //Conectamos la instancia de la clase a la BBDD
                Clasificaciones.Conectar_BBDD_Clasificaciones();
                //Recuperamos la lista con las clasificaciones para el tablero especificado y las insertamos
                //en el listView
                foreach (structClasificacion Clasificacion in Clasificaciones.GetClasificaciones(boardFilter))
                {
                    ListViewItem Item;
                    Item = this.lvwPuntuaciones.Items.Add(countClasificaciones.ToString());
                    Item.SubItems.Add(Clasificacion.Player);
                    Item.SubItems.Add(Clasificacion.TimeElapsed.ToLongTimeString());
                    Item.SubItems.Add(Clasificacion.BoardSize);
                    Item.SubItems.Add(Clasificacion.Moves.ToString());
                    countClasificaciones++;
                }
                //Desconectamos la instancia de la clase de la BBDD
                Clasificaciones.Desconectar_BBDD_Clasificaciones();
            }
        #endregion
    }
}
