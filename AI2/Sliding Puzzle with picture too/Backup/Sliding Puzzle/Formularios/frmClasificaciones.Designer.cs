namespace Sliding_Puzzle
{
    partial class frmClasificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClasificaciones));
            this.PanelPuntuaciones = new System.Windows.Forms.Panel();
            this.lvwPuntuaciones = new System.Windows.Forms.ListView();
            this.ColumnaPosicion = new System.Windows.Forms.ColumnHeader();
            this.ColumnaJugador = new System.Windows.Forms.ColumnHeader();
            this.ColumnaTiempo = new System.Windows.Forms.ColumnHeader();
            this.ColumnaSize = new System.Windows.Forms.ColumnHeader();
            this.ColumnaMoves = new System.Windows.Forms.ColumnHeader();
            this.PanelPuntuaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelPuntuaciones
            // 
            this.PanelPuntuaciones.BackColor = System.Drawing.Color.Transparent;
            this.PanelPuntuaciones.Controls.Add(this.lvwPuntuaciones);
            this.PanelPuntuaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelPuntuaciones.Location = new System.Drawing.Point(0, 0);
            this.PanelPuntuaciones.Name = "PanelPuntuaciones";
            this.PanelPuntuaciones.Size = new System.Drawing.Size(564, 269);
            this.PanelPuntuaciones.TabIndex = 0;
            // 
            // lvwPuntuaciones
            // 
            this.lvwPuntuaciones.BackColor = System.Drawing.Color.White;
            this.lvwPuntuaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwPuntuaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnaPosicion,
            this.ColumnaJugador,
            this.ColumnaTiempo,
            this.ColumnaSize,
            this.ColumnaMoves});
            this.lvwPuntuaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPuntuaciones.FullRowSelect = true;
            this.lvwPuntuaciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPuntuaciones.Location = new System.Drawing.Point(0, 0);
            this.lvwPuntuaciones.Name = "lvwPuntuaciones";
            this.lvwPuntuaciones.Size = new System.Drawing.Size(564, 269);
            this.lvwPuntuaciones.TabIndex = 0;
            this.lvwPuntuaciones.UseCompatibleStateImageBehavior = false;
            this.lvwPuntuaciones.View = System.Windows.Forms.View.Details;
            // 
            // ColumnaPosicion
            // 
            this.ColumnaPosicion.Text = "Posición";
            this.ColumnaPosicion.Width = 56;
            // 
            // ColumnaJugador
            // 
            this.ColumnaJugador.Text = "Jugador";
            this.ColumnaJugador.Width = 170;
            // 
            // ColumnaTiempo
            // 
            this.ColumnaTiempo.Text = "Tiempo";
            this.ColumnaTiempo.Width = 95;
            // 
            // ColumnaSize
            // 
            this.ColumnaSize.Text = "Tamaño del tablero";
            this.ColumnaSize.Width = 111;
            // 
            // ColumnaMoves
            // 
            this.ColumnaMoves.Text = "Movimientos realizados";
            this.ColumnaMoves.Width = 126;
            // 
            // frmClasificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(564, 372);
            this.Controls.Add(this.PanelPuntuaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClasificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clasificaciones";
            this.PanelPuntuaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelPuntuaciones;
        private System.Windows.Forms.ListView lvwPuntuaciones;
        private System.Windows.Forms.ColumnHeader ColumnaJugador;
        private System.Windows.Forms.ColumnHeader ColumnaTiempo;
        private System.Windows.Forms.ColumnHeader ColumnaSize;
        private System.Windows.Forms.ColumnHeader ColumnaMoves;
        private System.Windows.Forms.ColumnHeader ColumnaPosicion;
    }
}