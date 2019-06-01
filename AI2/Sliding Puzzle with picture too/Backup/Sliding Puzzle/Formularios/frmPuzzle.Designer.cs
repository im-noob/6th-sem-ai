namespace Sliding_Puzzle
{
    partial class frmPuzzle
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuzzle));
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblStepsText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStepsValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuJuego = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPartidaNueva = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparador1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPausar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFinalizar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparador2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTipoJuego = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTipoJuegoNumerico = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTipoJuegoImagenes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNumerarImagenes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGameSize = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGameSize_3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGameSize_4x4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGameSize_5x5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThemeZen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThemeAluminium = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparador3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuClasificaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparador4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuInformacion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAcerca = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.GameClock = new System.Windows.Forms.Timer(this.components);
            this.PanelJuego = new System.Windows.Forms.Panel();
            this.PanelPreview = new System.Windows.Forms.Panel();
            this.PanelsContainer = new System.Windows.Forms.Panel();
            this.BarraEstado.SuspendLayout();
            this.MenuPrincipal.SuspendLayout();
            this.PanelsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraEstado
            // 
            this.BarraEstado.BackgroundImage = global::Sliding_Puzzle.Properties.Resources.wood_BackGroundStatus;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStepsText,
            this.lblStepsValue,
            this.lblSeparator1,
            this.lblTimeText,
            this.lblTimeValue});
            this.BarraEstado.Location = new System.Drawing.Point(0, 239);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(213, 22);
            this.BarraEstado.SizingGrip = false;
            this.BarraEstado.TabIndex = 0;
            // 
            // lblStepsText
            // 
            this.lblStepsText.BackColor = System.Drawing.Color.Transparent;
            this.lblStepsText.Name = "lblStepsText";
            this.lblStepsText.Size = new System.Drawing.Size(40, 17);
            this.lblStepsText.Text = "Pasos:";
            // 
            // lblStepsValue
            // 
            this.lblStepsValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStepsValue.Name = "lblStepsValue";
            this.lblStepsValue.Size = new System.Drawing.Size(13, 17);
            this.lblStepsValue.Text = "0";
            // 
            // lblSeparator1
            // 
            this.lblSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.lblSeparator1.Name = "lblSeparator1";
            this.lblSeparator1.Size = new System.Drawing.Size(10, 17);
            this.lblSeparator1.Text = "|";
            // 
            // lblTimeText
            // 
            this.lblTimeText.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeText.Name = "lblTimeText";
            this.lblTimeText.Size = new System.Drawing.Size(51, 17);
            this.lblTimeText.Text = "Tiempo:";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(43, 17);
            this.lblTimeValue.Text = "0:00:00";
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.BackgroundImage = global::Sliding_Puzzle.Properties.Resources.wood_BackGroundMenu;
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuJuego,
            this.MenuInformacion});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(213, 24);
            this.MenuPrincipal.TabIndex = 1;
            // 
            // MenuJuego
            // 
            this.MenuJuego.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPartidaNueva,
            this.MenuSeparador1,
            this.MenuPausar,
            this.MenuFinalizar,
            this.MenuSeparador2,
            this.MenuPreview,
            this.toolStripSeparator1,
            this.MenuTipoJuego,
            this.MenuGameSize,
            this.MenuTheme,
            this.MenuSeparador3,
            this.MenuClasificaciones,
            this.MenuSeparador4,
            this.MenuCerrar});
            this.MenuJuego.Image = ((System.Drawing.Image)(resources.GetObject("MenuJuego.Image")));
            this.MenuJuego.Name = "MenuJuego";
            this.MenuJuego.Size = new System.Drawing.Size(66, 20);
            this.MenuJuego.Text = "Juego";
            this.MenuJuego.DropDownOpening += new System.EventHandler(this.MenuJuego_DropDownOpening);
            // 
            // MenuPartidaNueva
            // 
            this.MenuPartidaNueva.Image = ((System.Drawing.Image)(resources.GetObject("MenuPartidaNueva.Image")));
            this.MenuPartidaNueva.Name = "MenuPartidaNueva";
            this.MenuPartidaNueva.Size = new System.Drawing.Size(191, 22);
            this.MenuPartidaNueva.Text = "Partida nueva";
            this.MenuPartidaNueva.Click += new System.EventHandler(this.MenuPartidaNueva_Click);
            // 
            // MenuSeparador1
            // 
            this.MenuSeparador1.Name = "MenuSeparador1";
            this.MenuSeparador1.Size = new System.Drawing.Size(188, 6);
            // 
            // MenuPausar
            // 
            this.MenuPausar.Image = ((System.Drawing.Image)(resources.GetObject("MenuPausar.Image")));
            this.MenuPausar.Name = "MenuPausar";
            this.MenuPausar.Size = new System.Drawing.Size(191, 22);
            this.MenuPausar.Text = "Pausar la partida";
            this.MenuPausar.Click += new System.EventHandler(this.MenuPausar_Click);
            // 
            // MenuFinalizar
            // 
            this.MenuFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("MenuFinalizar.Image")));
            this.MenuFinalizar.Name = "MenuFinalizar";
            this.MenuFinalizar.Size = new System.Drawing.Size(191, 22);
            this.MenuFinalizar.Text = "Finalizar la partida";
            this.MenuFinalizar.Click += new System.EventHandler(this.MenuFinalizar_Click);
            // 
            // MenuSeparador2
            // 
            this.MenuSeparador2.Name = "MenuSeparador2";
            this.MenuSeparador2.Size = new System.Drawing.Size(188, 6);
            // 
            // MenuPreview
            // 
            this.MenuPreview.Image = ((System.Drawing.Image)(resources.GetObject("MenuPreview.Image")));
            this.MenuPreview.Name = "MenuPreview";
            this.MenuPreview.Size = new System.Drawing.Size(191, 22);
            this.MenuPreview.Text = "Previsualizar resultado";
            this.MenuPreview.Click += new System.EventHandler(this.MenuPreview_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // MenuTipoJuego
            // 
            this.MenuTipoJuego.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTipoJuegoNumerico,
            this.MenuTipoJuegoImagenes,
            this.MenuNumerarImagenes});
            this.MenuTipoJuego.Image = ((System.Drawing.Image)(resources.GetObject("MenuTipoJuego.Image")));
            this.MenuTipoJuego.Name = "MenuTipoJuego";
            this.MenuTipoJuego.Size = new System.Drawing.Size(191, 22);
            this.MenuTipoJuego.Text = "Tipo de juego";
            this.MenuTipoJuego.DropDownOpening += new System.EventHandler(this.MenuTipoJuego_DropDownOpening);
            // 
            // MenuTipoJuegoNumerico
            // 
            this.MenuTipoJuegoNumerico.Image = ((System.Drawing.Image)(resources.GetObject("MenuTipoJuegoNumerico.Image")));
            this.MenuTipoJuegoNumerico.Name = "MenuTipoJuegoNumerico";
            this.MenuTipoJuegoNumerico.Size = new System.Drawing.Size(192, 22);
            this.MenuTipoJuegoNumerico.Text = "Con números";
            this.MenuTipoJuegoNumerico.Click += new System.EventHandler(this.MenuTipoJuegoNumerico_Click);
            // 
            // MenuTipoJuegoImagenes
            // 
            this.MenuTipoJuegoImagenes.Image = ((System.Drawing.Image)(resources.GetObject("MenuTipoJuegoImagenes.Image")));
            this.MenuTipoJuegoImagenes.Name = "MenuTipoJuegoImagenes";
            this.MenuTipoJuegoImagenes.Size = new System.Drawing.Size(192, 22);
            this.MenuTipoJuegoImagenes.Text = "Con imágenes";
            this.MenuTipoJuegoImagenes.Click += new System.EventHandler(this.MenuTipoJuegoImagenes_Click);
            // 
            // MenuNumerarImagenes
            // 
            this.MenuNumerarImagenes.Image = ((System.Drawing.Image)(resources.GetObject("MenuNumerarImagenes.Image")));
            this.MenuNumerarImagenes.Name = "MenuNumerarImagenes";
            this.MenuNumerarImagenes.Size = new System.Drawing.Size(192, 22);
            this.MenuNumerarImagenes.Text = "Numerar las imágenes";
            this.MenuNumerarImagenes.Click += new System.EventHandler(this.MenuNumerarImagenes_Click);
            // 
            // MenuGameSize
            // 
            this.MenuGameSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGameSize_3x3,
            this.MenuGameSize_4x4,
            this.MenuGameSize_5x5});
            this.MenuGameSize.Image = ((System.Drawing.Image)(resources.GetObject("MenuGameSize.Image")));
            this.MenuGameSize.Name = "MenuGameSize";
            this.MenuGameSize.Size = new System.Drawing.Size(191, 22);
            this.MenuGameSize.Text = "Tamaño del tablero";
            this.MenuGameSize.DropDownOpening += new System.EventHandler(this.MenuGameSize_DropDownOpening);
            // 
            // MenuGameSize_3x3
            // 
            this.MenuGameSize_3x3.Image = ((System.Drawing.Image)(resources.GetObject("MenuGameSize_3x3.Image")));
            this.MenuGameSize_3x3.Name = "MenuGameSize_3x3";
            this.MenuGameSize_3x3.Size = new System.Drawing.Size(97, 22);
            this.MenuGameSize_3x3.Text = "3 x 3";
            this.MenuGameSize_3x3.Click += new System.EventHandler(this.MenuGameSize_3x3_Click);
            // 
            // MenuGameSize_4x4
            // 
            this.MenuGameSize_4x4.Image = ((System.Drawing.Image)(resources.GetObject("MenuGameSize_4x4.Image")));
            this.MenuGameSize_4x4.Name = "MenuGameSize_4x4";
            this.MenuGameSize_4x4.Size = new System.Drawing.Size(97, 22);
            this.MenuGameSize_4x4.Text = "4 x 4";
            this.MenuGameSize_4x4.Click += new System.EventHandler(this.MenuGameSize_4x4_Click);
            // 
            // MenuGameSize_5x5
            // 
            this.MenuGameSize_5x5.Image = ((System.Drawing.Image)(resources.GetObject("MenuGameSize_5x5.Image")));
            this.MenuGameSize_5x5.Name = "MenuGameSize_5x5";
            this.MenuGameSize_5x5.Size = new System.Drawing.Size(97, 22);
            this.MenuGameSize_5x5.Text = "5 x 5";
            this.MenuGameSize_5x5.Click += new System.EventHandler(this.MenuGameSize_5x5_Click);
            // 
            // MenuTheme
            // 
            this.MenuTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuThemeZen,
            this.MenuThemeAluminium});
            this.MenuTheme.Image = ((System.Drawing.Image)(resources.GetObject("MenuTheme.Image")));
            this.MenuTheme.Name = "MenuTheme";
            this.MenuTheme.Size = new System.Drawing.Size(191, 22);
            this.MenuTheme.Text = "Tema del juego";
            this.MenuTheme.DropDownOpening += new System.EventHandler(this.MenuTheme_DropDownOpening);
            // 
            // MenuThemeZen
            // 
            this.MenuThemeZen.Image = ((System.Drawing.Image)(resources.GetObject("MenuThemeZen.Image")));
            this.MenuThemeZen.Name = "MenuThemeZen";
            this.MenuThemeZen.Size = new System.Drawing.Size(134, 22);
            this.MenuThemeZen.Text = "Zen";
            this.MenuThemeZen.Click += new System.EventHandler(this.MenuThemeZen_Click);
            // 
            // MenuThemeAluminium
            // 
            this.MenuThemeAluminium.Image = ((System.Drawing.Image)(resources.GetObject("MenuThemeAluminium.Image")));
            this.MenuThemeAluminium.Name = "MenuThemeAluminium";
            this.MenuThemeAluminium.Size = new System.Drawing.Size(134, 22);
            this.MenuThemeAluminium.Text = "Aluminium";
            this.MenuThemeAluminium.Click += new System.EventHandler(this.MenuThemeAluminium_Click);
            // 
            // MenuSeparador3
            // 
            this.MenuSeparador3.Name = "MenuSeparador3";
            this.MenuSeparador3.Size = new System.Drawing.Size(188, 6);
            // 
            // MenuClasificaciones
            // 
            this.MenuClasificaciones.Image = ((System.Drawing.Image)(resources.GetObject("MenuClasificaciones.Image")));
            this.MenuClasificaciones.Name = "MenuClasificaciones";
            this.MenuClasificaciones.Size = new System.Drawing.Size(191, 22);
            this.MenuClasificaciones.Text = "Ver las clasificaciones";
            this.MenuClasificaciones.Click += new System.EventHandler(this.MenuEstadisticas_Click);
            // 
            // MenuSeparador4
            // 
            this.MenuSeparador4.Name = "MenuSeparador4";
            this.MenuSeparador4.Size = new System.Drawing.Size(188, 6);
            // 
            // MenuCerrar
            // 
            this.MenuCerrar.Image = ((System.Drawing.Image)(resources.GetObject("MenuCerrar.Image")));
            this.MenuCerrar.Name = "MenuCerrar";
            this.MenuCerrar.Size = new System.Drawing.Size(191, 22);
            this.MenuCerrar.Text = "Cerrar la aplicación";
            this.MenuCerrar.Click += new System.EventHandler(this.MenuCerrar_Click);
            // 
            // MenuInformacion
            // 
            this.MenuInformacion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuInformacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAcerca,
            this.MenuWeb});
            this.MenuInformacion.Image = ((System.Drawing.Image)(resources.GetObject("MenuInformacion.Image")));
            this.MenuInformacion.Name = "MenuInformacion";
            this.MenuInformacion.Size = new System.Drawing.Size(100, 20);
            this.MenuInformacion.Text = "Información";
            this.MenuInformacion.DropDownOpening += new System.EventHandler(this.MenuInformacion_DropDownOpening);
            // 
            // MenuAcerca
            // 
            this.MenuAcerca.Image = ((System.Drawing.Image)(resources.GetObject("MenuAcerca.Image")));
            this.MenuAcerca.Name = "MenuAcerca";
            this.MenuAcerca.Size = new System.Drawing.Size(201, 22);
            this.MenuAcerca.Text = "Acerca de Sliding Puzzle";
            this.MenuAcerca.Click += new System.EventHandler(this.MenuAcerca_Click);
            // 
            // MenuWeb
            // 
            this.MenuWeb.Image = ((System.Drawing.Image)(resources.GetObject("MenuWeb.Image")));
            this.MenuWeb.Name = "MenuWeb";
            this.MenuWeb.Size = new System.Drawing.Size(201, 22);
            this.MenuWeb.Text = "Ir a la web del autor";
            this.MenuWeb.Click += new System.EventHandler(this.MenuWeb_Click);
            // 
            // GameClock
            // 
            this.GameClock.Enabled = true;
            this.GameClock.Tick += new System.EventHandler(this.GameClock_Tick);
            // 
            // PanelJuego
            // 
            this.PanelJuego.BackgroundImage = global::Sliding_Puzzle.Properties.Resources.wood_imgEmpty;
            this.PanelJuego.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelJuego.Location = new System.Drawing.Point(0, 0);
            this.PanelJuego.Name = "PanelJuego";
            this.PanelJuego.Size = new System.Drawing.Size(213, 215);
            this.PanelJuego.TabIndex = 2;
            // 
            // PanelPreview
            // 
            this.PanelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPreview.Location = new System.Drawing.Point(0, 0);
            this.PanelPreview.Name = "PanelPreview";
            this.PanelPreview.Size = new System.Drawing.Size(213, 215);
            this.PanelPreview.TabIndex = 3;
            this.PanelPreview.Visible = false;
            // 
            // PanelsContainer
            // 
            this.PanelsContainer.Controls.Add(this.PanelPreview);
            this.PanelsContainer.Controls.Add(this.PanelJuego);
            this.PanelsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelsContainer.Location = new System.Drawing.Point(0, 24);
            this.PanelsContainer.Name = "PanelsContainer";
            this.PanelsContainer.Size = new System.Drawing.Size(213, 215);
            this.PanelsContainer.TabIndex = 4;
            // 
            // frmPuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 261);
            this.Controls.Add(this.PanelsContainer);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.MenuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuPrincipal;
            this.MaximizeBox = false;
            this.Name = "frmPuzzle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sliding Puzzle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPuzzle_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeclaPulsada);
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.PanelsContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuJuego;
        private System.Windows.Forms.ToolStripMenuItem MenuInformacion;
        private System.Windows.Forms.ToolStripMenuItem MenuAcerca;
        private System.Windows.Forms.ToolStripMenuItem MenuWeb;
        private System.Windows.Forms.Timer GameClock;
        private System.Windows.Forms.ToolStripMenuItem MenuPartidaNueva;
        private System.Windows.Forms.ToolStripSeparator MenuSeparador1;
        private System.Windows.Forms.ToolStripMenuItem MenuPausar;
        private System.Windows.Forms.ToolStripMenuItem MenuFinalizar;
        private System.Windows.Forms.ToolStripSeparator MenuSeparador2;
        private System.Windows.Forms.ToolStripMenuItem MenuTipoJuego;
        private System.Windows.Forms.ToolStripMenuItem MenuGameSize;
        private System.Windows.Forms.ToolStripMenuItem MenuTheme;
        private System.Windows.Forms.ToolStripSeparator MenuSeparador3;
        private System.Windows.Forms.ToolStripMenuItem MenuClasificaciones;
        private System.Windows.Forms.ToolStripSeparator MenuSeparador4;
        private System.Windows.Forms.ToolStripMenuItem MenuCerrar;
        private System.Windows.Forms.ToolStripMenuItem MenuThemeZen;
        private System.Windows.Forms.ToolStripMenuItem MenuThemeAluminium;
        private System.Windows.Forms.ToolStripMenuItem MenuTipoJuegoNumerico;
        private System.Windows.Forms.ToolStripMenuItem MenuTipoJuegoImagenes;
        private System.Windows.Forms.ToolStripMenuItem MenuNumerarImagenes;
        private System.Windows.Forms.ToolStripMenuItem MenuGameSize_3x3;
        private System.Windows.Forms.ToolStripMenuItem MenuGameSize_4x4;
        private System.Windows.Forms.ToolStripMenuItem MenuGameSize_5x5;
        private System.Windows.Forms.Panel PanelJuego;
        private System.Windows.Forms.ToolStripStatusLabel lblStepsText;
        private System.Windows.Forms.ToolStripStatusLabel lblStepsValue;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeText;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeValue;
        private System.Windows.Forms.ToolStripMenuItem MenuPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel PanelPreview;
        private System.Windows.Forms.Panel PanelsContainer;
    }
}

