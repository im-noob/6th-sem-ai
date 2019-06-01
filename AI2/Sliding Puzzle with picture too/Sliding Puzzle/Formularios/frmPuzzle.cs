using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Sliding_Puzzle
{
    #region "Enumeraciones Globales"
        public enum enumDireccion
        {
            Arriba = 0,
            Abajo = 1,
            Izquierda = 2,
            Derecha = 3
        }
    #endregion
    public partial class frmPuzzle : Form
    {
        #region "Variables Globales"
            //Contiene la dirección web por defecto del creador
            private string WebSite = "http://www.dxsoft.es";
            //Contiene el estado de la partida
            private enumGameStatus EstadoPartida;
            //Tamaño del tablero actual
            private enumBoardSize BoardSize;
            //Segundos transcurridos durante el juego pausado
            private long PauseElapseTime = 0;
            //Tiempo transcurrido durante la partida
            private DateTime TiempoPartida;
            //Movimientos realizados durante la partida
            private int MovimientosPartida = 0;
            //Declaramos una instancia de la clase Imagen
            private clsImage Imagen = new clsImage();
            //Declaramos una instancia de la clase Theme
            private clsTheme Theme = new clsTheme();
            //Declaramos una instancia de la clase Clasificaciones
            private clsClasificaciones Clasificaciones = new clsClasificaciones();
            //Variable que contendrá el tipo de juego
            private enumTipoJuego GameType;
            //Variable que contiene un booleano que indica si se numeran las imagenes o no
            private bool NumerarImagenes;
            //Bloquea el movimiento de la celda si esta se esta moviendo ya
            private bool moveInAction = false;
            //Indica si la partida está o no previsualizandose
            private bool previewInAction = false;
        #endregion
        #region "Estructura Ficha"
            private struct structFicha
            {
                public int Posicion;
                public int Valor;
                public bool Comodin;
            }
        #endregion
        #region "Enumeraciones"
            private enum enumTipoJuego
            {
                Numeros = 0,
                Imagen = 1
            }
            private enum enumGameStatus
            { 
                Iniciada = 0,
                Pausada = 1,
                Finalizada = 2,
                Scramble = 3,
            }
            private enum enumBoardSize
            { 
                Size_3x3 = 0,
                Size_4x4 = 1,
                Size_5x5 = 2,
            }
        #endregion
        #region "Capturador de eventos"
            private void TeclaPulsada(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        this.MoverCelda(enumDireccion.Arriba, true);
                        break;
                    case Keys.Down:
                        this.MoverCelda(enumDireccion.Abajo, true);
                        break;
                    case Keys.Left:
                        this.MoverCelda(enumDireccion.Izquierda, true);
                        break;
                    case Keys.Right:
                        this.MoverCelda(enumDireccion.Derecha, true);
                        break;
                }
            }
            private void PictureBox_Click(object sender, System.EventArgs e)
            {
                PictureBox tmpPicture = (PictureBox)sender;
                PictureBox tmpComodin = this.GetPictureComodin();
                if ((tmpPicture.Location.Y == tmpComodin.Location.Y) && (tmpPicture.Location.X - tmpPicture.Width == tmpComodin.Location.X)) //movimiento izquierda
                {
                    this.MoverCelda(enumDireccion.Izquierda, true);
                }
                else if ((tmpPicture.Location.Y == tmpComodin.Location.Y) && (tmpPicture.Location.X + tmpPicture.Width == tmpComodin.Location.X)) //movimiento derecha
                {
                    this.MoverCelda(enumDireccion.Derecha, true);
                }
                else if ((tmpPicture.Location.X == tmpComodin.Location.X) && (tmpComodin.Location.Y - tmpComodin.Height == tmpPicture.Location.Y)) //movimiento abajo
                {
                    this.MoverCelda(enumDireccion.Abajo, true);
                }
                else if ((tmpPicture.Location.X == tmpComodin.Location.X) && (tmpComodin.Location.Y + tmpComodin.Height == tmpPicture.Location.Y)) //movimiento arriba
                {
                    this.MoverCelda(enumDireccion.Arriba, true);
                }
            }
            private void Tema_Cambiado()
            {
                this.MenuPrincipal.BackgroundImage = this.Theme.imgBackgroundMenu;
                this.BarraEstado.BackgroundImage = this.Theme.imgBackgroundStatus;
                this.PanelJuego.BackgroundImage = this.Theme.imgEmpty;
            }
        #endregion
        #region "Formulario"
            #region "Contructor/Destructor"
                public frmPuzzle()
                {
                    InitializeComponent();
                    Theme.ThemeChanged += new clsTheme.ThemeChangedEventHandler(this.Tema_Cambiado);
                    this.Load_Configuration();
                    this.EstadoPartida = enumGameStatus.Finalizada;
                }
                private void frmPuzzle_FormClosed(object sender, FormClosedEventArgs e)
                {     
                    this.Save_Configuration();
                }
            #endregion
            #region "Configuracion"
                private void Load_Configuration()
                {
                    this.GameType = enumTipoJuego.Numeros;
                    Theme.Cargar_Theme((enumThemes)Properties.Settings.Default.conf_Theme);
                    this.NumerarImagenes = Properties.Settings.Default.conf_NumeredImages;
                    this.Imagen.Numerar_Imagenes = this.NumerarImagenes;
                    this.BoardSize = (enumBoardSize)Properties.Settings.Default.conf_PuzzleSize;
                    this.ChangeBoardSize(this.BoardSize);
                }
                private void Save_Configuration()
                {
                    Properties.Settings.Default.conf_NumeredImages = this.NumerarImagenes;
                    Properties.Settings.Default.conf_Theme = Convert.ToInt32(Theme.Theme_Actual);
                    Properties.Settings.Default.conf_PuzzleSize = Convert.ToInt32(this.BoardSize);
                    Properties.Settings.Default.Save();
                }
            #endregion
            #region "GameClock"
                private void GameClock_Tick(object sender, EventArgs e)
                {
                    DateTime tmpDate = DateTime.MinValue;
                    switch (this.EstadoPartida)
                    {
                        case enumGameStatus.Iniciada:
                            { 
                                tmpDate = new DateTime(DateTime.Now.Subtract(this.TiempoPartida).Ticks);
                                this.lblTimeValue.Text = tmpDate.ToLongTimeString();
                                this.PauseElapseTime = 0;
                                break;
                            }
                        case enumGameStatus.Pausada:
                            {
                                if (this.PauseElapseTime == 0)
                                {
                                    this.PauseElapseTime = DateTime.Now.Subtract(this.TiempoPartida).Ticks;
                                }
                                this.TiempoPartida = new DateTime(DateTime.Now.Ticks - this.PauseElapseTime);
                                break;
                            }
                    }
                }
            #endregion
            #region "Menus"
                #region "Menu Juego"
                    #region "Desplegable Principal"
                        private void MenuJuego_DropDownOpening(object sender, EventArgs e)
                        {
                            switch (this.EstadoPartida)
                            {
                                case enumGameStatus.Iniciada:
                                    {
                                        this.MenuPartidaNueva.Enabled = false;
                                        this.MenuPausar.Enabled = true;
                                        this.MenuFinalizar.Enabled = true;
                                        this.MenuTipoJuego.Enabled = false;
                                        this.MenuGameSize.Enabled = false;
                                        this.MenuTheme.Enabled = false;
                                        this.MenuPreview.Enabled = true;
                                        this.MenuCerrar.Enabled = true;
                                        this.MenuPausar.Checked = false;
                                        break;
                                    }
                                case enumGameStatus.Pausada:
                                    {
                                        this.MenuPausar.Checked = true;
                                        break;
                                    }
                                case enumGameStatus.Finalizada:
                                    {
                                        this.MenuPartidaNueva.Enabled = true;
                                        this.MenuPausar.Enabled = false;
                                        this.MenuFinalizar.Enabled = false;
                                        this.MenuTipoJuego.Enabled = true;
                                        this.MenuGameSize.Enabled = true;
                                        this.MenuTheme.Enabled = true;
                                        this.MenuPreview.Enabled = false;
                                        this.MenuCerrar.Enabled = true;
                                        this.MenuPausar.Checked = false;
                                        this.MenuPreview.Checked = false;
                                        break;
                                    }
                                case enumGameStatus.Scramble:
                                    {
                                        this.MenuPartidaNueva.Enabled = false;
                                        this.MenuPausar.Enabled = false;
                                        this.MenuFinalizar.Enabled = false;
                                        this.MenuTipoJuego.Enabled = false;
                                        this.MenuGameSize.Enabled = false;
                                        this.MenuTheme.Enabled = false;
                                        this.MenuPreview.Enabled = false;
                                        this.MenuCerrar.Enabled = true;
                                        this.MenuPausar.Checked = false;
                                        this.MenuPreview.Checked = false;
                                        break;
                                    }
                            }
                        }
                        private void MenuPartidaNueva_Click(object sender, EventArgs e)
                        {
                            this.IniciarPartida();
                        }
                        private void MenuPausar_Click(object sender, EventArgs e)
                        {
                            this.PausarPartida();
                        }
                        private void MenuFinalizar_Click(object sender, EventArgs e)
                        {
                            this.FinalizarPartida(false);
                        }
                        private void MenuPreview_Click(object sender, EventArgs e)
                        {
                            this.previewInAction = !this.previewInAction;
                            if (this.previewInAction == true)
                            {
                                this.PausarPartida();
                                this.MenuPreview.Checked = true;
                                this.PanelPreview.Visible = true;
                            }
                            else 
                            {
                                this.PausarPartida();
                                this.MenuPreview.Checked = false;
                                this.PanelPreview.Visible = false;
                            }                            
                        }
                        private void MenuEstadisticas_Click(object sender, EventArgs e)
                        {
                            string boardSizeParam = "";
                            switch (this.BoardSize)
                            {
                                case enumBoardSize.Size_3x3:
                                    {
                                        boardSizeParam = "3x3";
                                        break;
                                    }
                                case enumBoardSize.Size_4x4:
                                    {
                                        boardSizeParam = "4x4";
                                        break;
                                    }
                                case enumBoardSize.Size_5x5:
                                    {
                                        boardSizeParam = "5x5";
                                        break;
                                    }
                            }
                        }
                        private void MenuCerrar_Click(object sender, EventArgs e)
                        {
                            this.Close();
                        }
                    #endregion
                    #region "Desplegable Tipo Juego"
                        private void MenuTipoJuego_DropDownOpening(object sender, EventArgs e)
                        {
                            switch (this.GameType)
                            {
                                case enumTipoJuego.Numeros:
                                    {
                                        this.MenuTipoJuegoNumerico.Checked = true;
                                        this.MenuTipoJuegoImagenes.Checked = false;
                                        break;
                                    }
                                case enumTipoJuego.Imagen:
                                    {
                                        this.MenuTipoJuegoNumerico.Checked = false;
                                        this.MenuTipoJuegoImagenes.Checked = true;
                                        break;
                                    }
                            }
                            if (this.NumerarImagenes == true)
                            {
                                this.MenuNumerarImagenes.Checked = true;
                            }
                            else
                            {
                                this.MenuNumerarImagenes.Checked = false;
                            }
                        }
                        private void MenuTipoJuegoNumerico_Click(object sender, EventArgs e)
                        {
                            if (this.GameType != enumTipoJuego.Numeros)
                            {
                                this.GameType = enumTipoJuego.Numeros;
                            }  
                        }
                        private void MenuTipoJuegoImagenes_Click(object sender, EventArgs e)
                        {
                            if (this.GameType != enumTipoJuego.Imagen)
                            {
                                DialogResult dlgResult;
                                OpenFileDialog oFile;
                                oFile = new OpenFileDialog();
                                oFile.Filter = "Formatos soportados " + "(*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
                                oFile.Multiselect = false;
                                oFile.Title = "Selecciona la imagen que deseas cargar en el tablero";
                                dlgResult = oFile.ShowDialog(this);
                                switch (dlgResult)
                                {
                                    case DialogResult.OK:
                                        {
                                            this.Imagen.Establecer_Ruta = oFile.FileName;
                                            if (this.ReloadImage() == true)
                                            { 
                                                this.GameType = enumTipoJuego.Imagen;
                                            }
                                            break;
                                        }
                                }
                            }  
                        }
                        private void MenuNumerarImagenes_Click(object sender, EventArgs e)
                        {
                            this.NumerarImagenes = !this.NumerarImagenes;
                            this.Imagen.Numerar_Imagenes = this.NumerarImagenes;
                            if (this.GameType == enumTipoJuego.Imagen)
                            {
                                this.ReloadImage();
                            }
                        }
                    #endregion
                    #region "Desplegable Tamaño Tablero"
                        private void MenuGameSize_DropDownOpening(object sender, EventArgs e)
                        {
                            switch (this.BoardSize)
                            {
                                case enumBoardSize.Size_3x3:
                                    {
                                        this.MenuGameSize_3x3.Checked = true;
                                        this.MenuGameSize_4x4.Checked = false;
                                        this.MenuGameSize_5x5.Checked = false;
                                        break;
                                    }
                                case enumBoardSize.Size_4x4:
                                    {
                                        this.MenuGameSize_3x3.Checked = false;
                                        this.MenuGameSize_4x4.Checked = true;
                                        this.MenuGameSize_5x5.Checked = false;
                                        break;
                                    }
                                case enumBoardSize.Size_5x5:
                                    {
                                        this.MenuGameSize_3x3.Checked = false;
                                        this.MenuGameSize_4x4.Checked = false;
                                        this.MenuGameSize_5x5.Checked = true;
                                        break;
                                    }
                            }
                        }
                        private void MenuGameSize_3x3_Click(object sender, EventArgs e)
                        {
                            this.ChangeBoardSize(enumBoardSize.Size_3x3);
                        }
                        private void MenuGameSize_4x4_Click(object sender, EventArgs e)
                        {
                            this.ChangeBoardSize(enumBoardSize.Size_4x4);
                        }
                        private void MenuGameSize_5x5_Click(object sender, EventArgs e)
                        {
                            this.ChangeBoardSize(enumBoardSize.Size_5x5);
                        }
                    #endregion
                    #region "Desplegable Tema Juego"
                        private void MenuTheme_DropDownOpening(object sender, EventArgs e)
                        {
                            switch (Theme.Theme_Actual)
                            {
                                case enumThemes.Zen:
                                    {
                                        this.MenuThemeZen.Checked = true;
                                        this.MenuThemeAluminium.Checked = false;
                                        break;
                                    }
                                case enumThemes.Aluminium:
                                    {
                                        this.MenuThemeZen.Checked = false;
                                        this.MenuThemeAluminium.Checked = true;
                                        break;
                                    }
                            }
                        }
                        private void MenuThemeZen_Click(object sender, EventArgs e)
                        {
                            if (Theme.Theme_Actual != enumThemes.Zen)
                            {
                                this.EliminarTablero(true);
                                Theme.Cargar_Theme(enumThemes.Zen);
                            }
                        }
                        private void MenuThemeAluminium_Click(object sender, EventArgs e)
                        {
                            if (Theme.Theme_Actual != enumThemes.Aluminium)
                            {
                                this.EliminarTablero(true);
                                Theme.Cargar_Theme(enumThemes.Aluminium);
                            }
                        }
                    #endregion
                #endregion
                #region "Menu Información"
                    private void MenuInformacion_DropDownOpening(object sender, EventArgs e)
                    {
                        if (this.EstadoPartida == enumGameStatus.Finalizada)
                        {
                            this.MenuAcerca.Enabled = true;
                        }
                        else 
                        {
                            this.MenuAcerca.Enabled = false;
                        }
                    }
                    private void MenuAcerca_Click(object sender, EventArgs e)
                    {
                        frmAbout About = new frmAbout();
                        About.ShowDialog(this);
                    }
                    private void MenuWeb_Click(object sender, EventArgs e)
                    {
                        Process.Start(this.WebSite);
                    }
                #endregion
            #endregion
        #endregion
        #region "Metodos Privados"
            private bool ReloadImage()
            {
                bool tmpResult = false;
                int boardWidth = 0;
                int boardHeight = 0;
                switch (this.BoardSize)
                {
                    case enumBoardSize.Size_3x3:
                        {
                            boardHeight = 3;
                            boardWidth = 3;
                            break;
                        }
                    case enumBoardSize.Size_4x4:
                        {
                            boardHeight = 4;
                            boardWidth = 4;
                            break;
                        }
                    case enumBoardSize.Size_5x5:
                        {
                            boardHeight = 5;
                            boardWidth = 5;
                            break;
                        }
                }
                if (this.Imagen.Preparar_Imagen(boardWidth, boardHeight, this.Theme.img1.Height, this.Theme.img1.Width) == true)
                {
                    tmpResult = true;
                }
                else
                {
                    this.GameType = enumTipoJuego.Numeros;
                }
                return tmpResult;
            }
            private void IniciarPartida()
            {
                this.MovimientosPartida = 0;
                this.lblStepsValue.Text = "0";
                this.lblTimeValue.Text = "0:00:00";
                this.EstadoPartida = enumGameStatus.Scramble;
                this.CrearPrevisualizador();
                this.CrearTablero();
                this.Scramble();
                this.EstadoPartida = enumGameStatus.Iniciada;
                this.TiempoPartida = new DateTime(DateTime.Now.Ticks);
                PictureBox tmpComodin = GetPictureComodin();
                if (tmpComodin != null)
                { 
                    tmpComodin.Image = this.Imagen.InsertarArrows(this.Theme.imgEmpty, this.Movimientos_Posibles(tmpComodin));  
                }
                this.EstadoPartida = enumGameStatus.Iniciada;
            }
            private void PausarPartida()
            {
                if (this.EstadoPartida == enumGameStatus.Pausada)
                {
                    if (this.previewInAction != true)
                    { 
                        this.EstadoPartida = enumGameStatus.Iniciada;
                    }
                }
                else
                {
                    this.EstadoPartida = enumGameStatus.Pausada;
                }
            }
            private void FinalizarPartida(bool FinDePartida)
            {
                this.EstadoPartida = enumGameStatus.Finalizada;
                if (this.PanelPreview.Visible == true)
                {
                    this.PanelPreview.Visible = false;
                    this.previewInAction = false;
                }
                switch (FinDePartida)
                {
                    case true:
                        {
                            this.MostrarCeldaVacia();
                            structClasificacion tmpClasificacion = new structClasificacion();
                            tmpClasificacion.Player = Properties.Settings.Default.conf_LastUser;
                            switch (this.BoardSize)
                            {
                                case enumBoardSize.Size_3x3:
                                    {
                                        tmpClasificacion.BoardSize = "3x3";
                                        break;
                                    }
                                case enumBoardSize.Size_4x4:
                                    {
                                        tmpClasificacion.BoardSize = "4x4";
                                        break;
                                    }
                                case enumBoardSize.Size_5x5:
                                    {
                                        tmpClasificacion.BoardSize = "5x5";
                                        break;
                                    }
                            }
                            tmpClasificacion.Moves = this.MovimientosPartida;
                            DateTime timeElapsed = new DateTime(DateTime.Now.Subtract(this.TiempoPartida).Ticks);
                            tmpClasificacion.TimeElapsed = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeElapsed.Hour, timeElapsed.Minute, timeElapsed.Second);
                            frmWin tmpFrmWin = new frmWin(ref this.Clasificaciones, ref tmpClasificacion);
                            tmpFrmWin.ShowDialog(this);
                            break;
                        }
                    case false:
                        {
                            this.lblStepsValue.Text = "0";
                            this.lblTimeValue.Text = "0:00:00";
                            //Eliminamos todos los eventos capturados de los pictureBox del tablero
                            this.EliminarTablero(true);
                            break;
                        }
                }
            }
            /// <summary>
            /// Muestra el contenido teórico que debería de tener la celda vacía una vez se ha resuelto el tablero
            /// </summary>
            private void MostrarCeldaVacia()
            {
                PictureBox tmpComodin = this.GetPictureComodin();
                if (this.GameType == enumTipoJuego.Numeros)
                {
                    tmpComodin.Image = this.GetImageFromIndex(((structFicha)tmpComodin.Tag).Valor);
                }
                else
                {
                    tmpComodin.Image = this.Imagen.GetImageFromIndex(((structFicha)tmpComodin.Tag).Valor);
                }
            }
            /// <summary>
            /// Se encarga de crear el tablero de juego. Inicialmente lo crea ordenado.
            /// </summary>
            private void CrearTablero()
            {
                if (this.PanelJuego.Controls.Count > 0)
                {
                    this.EliminarTablero(true);
                }
                PictureBox tmpPicture = null;
                int columns = 0;
                int rows = 0;
                structFicha tmpFicha;
                //Descodificamos las dimesiones del tablero de la enumeracion
                switch (this.BoardSize)
                {
                    case enumBoardSize.Size_3x3:
                        {
                            columns = 3;
                            rows = 3;
                            break;
                        }
                    case enumBoardSize.Size_4x4:
                        {
                            columns = 4;
                            rows = 4;
                            break;
                        }
                    case enumBoardSize.Size_5x5:
                        {
                            columns = 5;
                            rows = 5;
                            break;
                        }
                }
                int Count = 1;
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        //Creamos un nuevo objeto del tipo pictureBox
                        tmpPicture = new PictureBox();
                        //Posicionamos el pictureBox en el tablero
                        tmpPicture.Location = new Point((x * Theme.img1.Height), (y * Theme.img1.Width));
                        //Establecemos las dimensiones del pictureBox
                        tmpPicture.Height = Theme.img1.Height;
                        tmpPicture.Width = Theme.img1.Width;
                        //Creamos la estructura que contendrá la información en el pictureBox
                        tmpFicha = new structFicha();
                        tmpFicha.Posicion = Count;
                        tmpFicha.Valor = Count;
                        //Asociamos la imagen correspondiente al pictureBox
                        if (Count == (columns * rows))
                        {
                            tmpPicture.Image = this.GetImageFromIndex(-1);
                            tmpFicha.Comodin = true;
                        }
                        else 
                        {
                            switch (this.GameType)
                            {
                                case enumTipoJuego.Numeros:
                                    {
                                        tmpPicture.Image = this.GetImageFromIndex(Count);
                                        break;
                                    }
                                case enumTipoJuego.Imagen:
                                    {
                                        tmpPicture.Image = this.Imagen.GetImageFromIndex(Count);
                                        break;
                                    }
                            }
                            tmpFicha.Comodin = false;
                        }
                        //Asignamos la estructura que contendrá la información del pictureBox
                        tmpPicture.Tag = tmpFicha;
                        //Asociamos el evento Click del pictureBox
                        tmpPicture.Click += new EventHandler(this.PictureBox_Click);
                        //Añadimos el pictureBox en el tablero
                        this.PanelJuego.Controls.Add(tmpPicture);
                        Count++;
                    }
                }
            }
            /// <summary>
            /// Se encarga de crear la previsualización de la solución del tablero
            /// </summary>
            private void CrearPrevisualizador()
            {
                if (this.PanelPreview.Controls.Count > 0)
                {
                    this.PanelPreview.Controls.Clear();
                }
                PictureBox tmpPicture = null;
                int columns = 0;
                int rows = 0;
                //Descodificamos las dimesiones del tablero de la enumeracion
                switch (this.BoardSize)
                {
                    case enumBoardSize.Size_3x3:
                        {
                            columns = 3;
                            rows = 3;
                            break;
                        }
                    case enumBoardSize.Size_4x4:
                        {
                            columns = 4;
                            rows = 4;
                            break;
                        }
                    case enumBoardSize.Size_5x5:
                        {
                            columns = 5;
                            rows = 5;
                            break;
                        }
                }
                int Count = 1;
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < columns; x++)
                    {
                        //Creamos un nuevo objeto del tipo pictureBox
                        tmpPicture = new PictureBox();
                        //Posicionamos el pictureBox en el tablero
                        tmpPicture.Location = new Point((x * Theme.img1.Height), (y * Theme.img1.Width));
                        //Establecemos las dimensiones del pictureBox
                        tmpPicture.Height = Theme.img1.Height;
                        tmpPicture.Width = Theme.img1.Width;
                        tmpPicture.Visible = true;
                        //Asociamos la imagen correspondiente al pictureBox
                        switch (this.GameType)
                        {
                            case enumTipoJuego.Numeros:
                                {
                                    tmpPicture.Image = this.Imagen.ToGrayScale(this.GetImageFromIndex(Count));
                                    break;
                                }
                            case enumTipoJuego.Imagen:
                                {
                                    tmpPicture.Image = this.Imagen.ToGrayScale(this.Imagen.GetImageFromIndex(Count));
                                    break;
                                }
                        }
                        //Añadimos el pictureBox en el tablero
                        this.PanelPreview.Controls.Add(tmpPicture);
                        Count++;
                    }
                }
            }
            private Image GetImageFromIndex(int index)
            {
                Image tmpImage = null;
                switch (index)
                {
                    case 1:
                        {
                            tmpImage = Theme.img1;
                            break;
                        }
                    case 2:
                        {
                            tmpImage = Theme.img2;
                            break;
                        }
                    case 3:
                        {
                            tmpImage = Theme.img3;
                            break;
                        }
                    case 4:
                        {
                            tmpImage = Theme.img4;
                            break;
                        }
                    case 5:
                        {
                            tmpImage = Theme.img5;
                            break;
                        }
                    case 6:
                        {
                            tmpImage = Theme.img6;
                            break;
                        }
                    case 7:
                        {
                            tmpImage = Theme.img7;
                            break;
                        }
                    case 8:
                        {
                            tmpImage = Theme.img8;
                            break;
                        }
                    case 9:
                        {
                            tmpImage = Theme.img9;
                            break;
                        }
                    case 10:
                        {
                            tmpImage = Theme.img10;
                            break;
                        }
                    case 11:
                        {
                            tmpImage = Theme.img11;
                            break;
                        }
                    case 12:
                        {
                            tmpImage = Theme.img12;
                            break;
                        }
                    case 13:
                        {
                            tmpImage = Theme.img13;
                            break;
                        }
                    case 14:
                        {
                            tmpImage = Theme.img14;
                            break;
                        }
                    case 15:
                        {
                            tmpImage = Theme.img15;
                            break;
                        }
                    case 16:
                        {
                            tmpImage = Theme.img16;
                            break;
                        }
                    case 17:
                        {
                            tmpImage = Theme.img17;
                            break;
                        }
                    case 18:
                        {
                            tmpImage = Theme.img18;
                            break;
                        }
                    case 19:
                        {
                            tmpImage = Theme.img19;
                            break;
                        }
                    case 20:
                        {
                            tmpImage = Theme.img20;
                            break;
                        }
                    case 21:
                        {
                            tmpImage = Theme.img21;
                            break;
                        }
                    case 22:
                        {
                            tmpImage = Theme.img22;
                            break;
                        }
                    case 23:
                        {
                            tmpImage = Theme.img23;
                            break;
                        }
                    case 24:
                        {
                            tmpImage = Theme.img24;
                            break;
                        }
                    case 25:
                        {
                            tmpImage = Theme.img25;
                            break;
                        }
                    case -1:
                        {
                            tmpImage = Theme.imgEmpty;
                            break;
                        }
                }
                return tmpImage;
            }
            /// <summary>
            /// Se encarga de eliminar las fichas que hay en el tablero, así como eliminar sus eventos capturados
            /// </summary>
            /// <param name="DeleteEvents">Determina si se desea desvincular el programa de los eventos que puedan generar esos pictureBox</param>
            private void EliminarTablero(bool DeleteEvents)
            {
                if (this.PanelJuego.Controls.Count > 0)
                { 
                    if (DeleteEvents == true)
                    { 
                        //Eliminamos todas las capturas de eventos de los pictureBox del tablero
                        foreach (Control tmpControl in this.PanelJuego.Controls)
                        {
                            if (tmpControl is PictureBox)
                            {
                                ((PictureBox)tmpControl).Click -= new System.EventHandler(this.PictureBox_Click);
                            }
                        }                
                    }
                    //Eliminamos todos los pictureBox del tablero
                    this.PanelJuego.Controls.Clear();                
                }
            }
            /// <summary>
            /// Se encarga de buscar y retornar la ficha vacía que hace de comodín
            /// </summary>
            /// <returns>Retorna la ficha vacía que hace de comodín</returns>
            private PictureBox GetPictureComodin()
            {
                PictureBox tmpPicResult = null;
                foreach (Control tmpControl in this.PanelJuego.Controls)
                {
                    if (tmpControl is PictureBox)
                    {
                        if (((structFicha)((PictureBox)tmpControl).Tag).Comodin == true)
                        {
                            tmpPicResult = (PictureBox)tmpControl;
                        }
                    }
                }               
                return tmpPicResult;
            }
            /// <summary>
            /// Se encarga de devolver la ficha que está ubicada en unas coordenadas en concreto del tablero
            /// </summary>
            /// <param name="Localizacion">Posición teórica donde esta la ficha</param>
            /// <returns>Retorna la ficha que está ubicada en esas coordenadas</returns>
            private PictureBox GetPictureFromPoints(Point Localizacion)
            {
                PictureBox tmpPicResult = null;
                foreach (Control tmpControl in this.PanelJuego.Controls)
                {
                    if (tmpControl is PictureBox)
                    {
                        if (((PictureBox)tmpControl).Location.Equals(Localizacion) == true)
                        {
                            tmpPicResult = (PictureBox)tmpControl;
                        }
                    }
                }
                return tmpPicResult;
            }
            /// <summary>
            /// Mueve la ficha
            /// </summary>
            /// <param name="Direccion">Dirección en la que se desea mover la ficha</param>
            /// <param name="WithEfect">Permite realizar el efecto de deslizamiento en caso de true</param>
            private void MoverCelda(enumDireccion Direccion, bool WithEfect)
            {
                if ((this.PanelJuego.Controls.Count > 0) && ((this.EstadoPartida == enumGameStatus.Iniciada) || (this.EstadoPartida == enumGameStatus.Scramble)) && (this.moveInAction == false))
                {
                    this.moveInAction = true;
                    PictureBox tmpImagen = null;
                    Point tmpPoint = new Point();
                    bool movimientoValido = false;
                    bool FinPartida = false;
                    PictureBox tmpComodin = GetPictureComodin();
                    switch (Direccion)
                    {
                        case enumDireccion.Abajo:
                            if (tmpComodin.Top != 0)
                            {
                                tmpComodin.Visible = false;
                                tmpImagen = this.GetPictureFromPoints(new Point(tmpComodin.Location.X, tmpComodin.Location.Y - tmpComodin.Height));
                                tmpPoint = new Point(tmpImagen.Location.X, tmpImagen.Location.Y);
                                if (WithEfect == true)
                                {
                                    int posY = tmpImagen.Location.Y;
                                    for (int i = posY; i <= tmpComodin.Location.Y; i++)
                                    {
                                        tmpImagen.Location = new Point(tmpComodin.Location.X, i);
                                    }
                                }
                                else 
                                { 
                                    tmpImagen.Location = new Point(tmpComodin.Location.X, tmpComodin.Location.Y);
                                }
                                tmpComodin.Location = new Point(tmpPoint.X, tmpPoint.Y);
                                this.TooglePicturePosition(ref tmpImagen, ref tmpComodin);
                                movimientoValido = true;
                                tmpComodin.Visible = true;
                            }
                            break;
                        case enumDireccion.Arriba:
                            if (tmpComodin.Bottom != this.PanelJuego.Height)
                            {
                                tmpComodin.Visible = false;
                                tmpImagen = this.GetPictureFromPoints(new Point(tmpComodin.Location.X, tmpComodin.Location.Y + tmpComodin.Height));
                                tmpPoint = new Point(tmpImagen.Location.X, tmpImagen.Location.Y);
                                if (WithEfect == true)
                                {
                                    int posY = tmpImagen.Location.Y;
                                    for (int i = posY; i >= tmpComodin.Location.Y; i--)
                                    {
                                        tmpImagen.Location = new Point(tmpComodin.Location.X, i);
                                    }
                                }
                                else
                                {
                                    tmpImagen.Location = new Point(tmpComodin.Location.X, tmpComodin.Location.Y);
                                }
                                tmpComodin.Location = new Point(tmpPoint.X, tmpPoint.Y);
                                this.TooglePicturePosition(ref tmpImagen, ref tmpComodin);
                                movimientoValido = true;
                                tmpComodin.Visible = true;
                            }
                            break;
                        case enumDireccion.Derecha:
                            if (tmpComodin.Left != 0)
                            {
                                tmpComodin.Visible = false;
                                tmpImagen = this.GetPictureFromPoints(new Point(tmpComodin.Location.X - tmpComodin.Width, tmpComodin.Location.Y));
                                tmpPoint = new Point(tmpImagen.Location.X, tmpImagen.Location.Y);
                                if (WithEfect == true)
                                {
                                    int posX = tmpImagen.Location.X;
                                    for (int i = posX; i <= tmpComodin.Location.X; i++)
                                    {
                                        tmpImagen.Location = new Point(i, tmpComodin.Location.Y);
                                    }
                                }
                                else
                                {
                                    tmpImagen.Location = new Point(tmpComodin.Location.X, tmpComodin.Location.Y);
                                }
                                tmpComodin.Location = new Point(tmpPoint.X, tmpPoint.Y);
                                this.TooglePicturePosition(ref tmpImagen, ref tmpComodin);
                                movimientoValido = true;
                                tmpComodin.Visible = true;
                            }
                            break;
                        case enumDireccion.Izquierda:
                            if (tmpComodin.Right != this.PanelJuego.Width)
                            {
                                tmpComodin.Visible = false;
                                tmpImagen = this.GetPictureFromPoints(new Point(tmpComodin.Location.X + tmpComodin.Width, tmpComodin.Location.Y));
                                tmpPoint = new Point(tmpImagen.Location.X, tmpImagen.Location.Y);
                                if (WithEfect == true)
                                {
                                    int posX = tmpImagen.Location.X;
                                    for (int i = posX; i >= tmpComodin.Location.X; i--)
                                    {
                                        tmpImagen.Location = new Point(i, tmpComodin.Location.Y);
                                    }
                                }
                                else
                                {
                                    tmpImagen.Location = new Point(tmpComodin.Location.X, tmpComodin.Location.Y);
                                }
                                tmpComodin.Location = new Point(tmpPoint.X, tmpPoint.Y);
                                this.TooglePicturePosition(ref tmpImagen, ref tmpComodin);
                                movimientoValido = true;
                                tmpComodin.Visible = true;
                            }
                            break;
                    }
                    if (this.EstadoPartida == enumGameStatus.Iniciada)
                    {
                        if (movimientoValido == true)
                        {
                            this.MovimientosPartida += 1;
                            this.lblStepsValue.Text = Convert.ToString(this.MovimientosPartida);
                            if (((structFicha)tmpComodin.Tag).Posicion == ((structFicha)tmpComodin.Tag).Valor)
                            {
                                FinPartida = this.EvaluarFinJuego();
                            }
                            if (FinPartida != true)
                            {
                                tmpComodin.Image = this.Imagen.InsertarArrows(this.Theme.imgEmpty, this.Movimientos_Posibles(tmpComodin));
                            }
                        }
                    }
                    this.moveInAction = false;
                }
            }
            /// <summary>
            /// Evalua si se ha resuelto el tablero o no.
            /// </summary>
            /// <returns>Retorna true en caso de haber finalizado la partida y false en caso de no estar resuelto por el momento.</returns>
            private bool EvaluarFinJuego()
            {
                bool FinalPartida = true;
                foreach (object Controles in this.PanelJuego.Controls)
                {
                    structFicha tempVar = (structFicha)(((PictureBox)Controles).Tag);
                    if (tempVar.Posicion != tempVar.Valor)
                    {
                        FinalPartida = false;
                    }
                }
                if (FinalPartida == true)
                {
                    this.FinalizarPartida(true);
                }
                return FinalPartida;
            }
            /// <summary>
            /// Se encarga de intercambiar las estructuras que contienen los dos pictureBox
            /// </summary>
            /// <param name="tmpPicture">pictureBox que intercambi su valor</param>
            /// <param name="tmpComodin">pictureBox que intercambi su valor</param>
            private void TooglePicturePosition(ref PictureBox tmpPicture, ref PictureBox tmpComodin)
            {
                structFicha tmpStructure1 = new structFicha();
                structFicha tmpStructure2 = new structFicha();
                int tmpValue = 0;
                structFicha tempVar = (structFicha)tmpPicture.Tag;
                tmpStructure1.Posicion = tempVar.Posicion;
                tmpStructure1.Comodin = tempVar.Comodin;
                tmpStructure1.Valor = tempVar.Valor;
                structFicha tempVar2 = (structFicha)tmpComodin.Tag;
                tmpStructure2.Posicion = tempVar2.Posicion;
                tmpStructure2.Comodin = tempVar2.Comodin;
                tmpStructure2.Valor = tempVar2.Valor;
                tmpValue = tmpStructure1.Posicion;
                tmpStructure1.Posicion = tmpStructure2.Posicion;
                tmpStructure2.Posicion = tmpValue;
                tmpPicture.Tag = tmpStructure1;
                tmpComodin.Tag = tmpStructure2;
            }
            /// <summary>
            /// Redimensiona el tamaño del tablero
            /// </summary>
            /// <param name="paramBoardSize"></param>
            private void ChangeBoardSize(enumBoardSize paramBoardSize)
            {
                this.BoardSize = paramBoardSize;
                this.lblStepsValue.Text = "0";
                this.lblTimeValue.Text = "0:00:00";
                this.EliminarTablero(true);
                if (this.GameType == enumTipoJuego.Imagen)
                {
                    this.ReloadImage();
                }
                switch (paramBoardSize)
                {
                    case enumBoardSize.Size_3x3:
                        {
                            this.ClientSize = new Size(Properties.Resources.metal_img1.Width * 3, Properties.Resources.metal_img1.Height * 3 + this.BarraEstado.Height + this.MenuPrincipal.Height);
                            break;
                        }
                    case enumBoardSize.Size_4x4:
                        {
                            this.ClientSize = new Size(Properties.Resources.metal_img1.Width * 4, Properties.Resources.metal_img1.Height * 4 + this.BarraEstado.Height + this.MenuPrincipal.Height);
                            break;
                        }
                    case enumBoardSize.Size_5x5:
                        {
                            this.ClientSize = new Size(Properties.Resources.metal_img1.Width * 5, Properties.Resources.metal_img1.Height * 5 + this.BarraEstado.Height + this.MenuPrincipal.Height);
                            break;
                        }
                }
            }
            /// <summary>
            /// Se encarga de calcular los diferentes movimientos que puede realizar una ficha 
            /// (En concreto a la ficha comodín)
            /// </summary>
            /// <param name="Img">Imagen en la que se desea calcular sus posibles movimientos</param>
            /// <returns>
            /// Retorna una lista que contiene las diferentes direcciones que puede tomar la ficha de 
            /// manera válida
            /// </returns>
            private List<enumDireccion> Movimientos_Posibles(PictureBox Img)
            {
                List<enumDireccion> Arrow_List = new List<enumDireccion>();
                if (Img.Top != 0)
                {
                    Arrow_List.Add(enumDireccion.Abajo);
                }
                if (Img.Bottom != this.PanelJuego.Height)
                {
                    Arrow_List.Add(enumDireccion.Arriba);
                }
                if (Img.Left != 0)
                {
                    Arrow_List.Add(enumDireccion.Derecha);
                }
                if (Img.Right != this.PanelJuego.Width)
                {
                    Arrow_List.Add(enumDireccion.Izquierda);
                }
                return Arrow_List;
            }
            /// <summary>
            /// Se encarga de barajar las fichas del tablero
            /// </summary>
            private void Scramble()
            {
                List<enumDireccion> PosiblesDirecciones;
                PictureBox tmpComodin = this.GetPictureComodin();
                Random rndDirection = new Random();
                enumDireccion LastPosition = enumDireccion.Abajo;
                enumDireccion CurrentDirection;
                bool firstMove = true;
                int moves = 0;
                while (moves < 100)
                { 
                    PosiblesDirecciones = Movimientos_Posibles(tmpComodin);
                    CurrentDirection = PosiblesDirecciones[rndDirection.Next(0, PosiblesDirecciones.Count)];
                    if (firstMove != true)
                    {
                        if (LastPosition.Equals(CurrentDirection) == false)
                        {
                            LastPosition = this.DireccionContraria(CurrentDirection);
                            Application.DoEvents();
                            this.MoverCelda(CurrentDirection, true);
                            moves++;
                        }
                    }
                    else
                    {
                        firstMove = false;
                        LastPosition = this.DireccionContraria(CurrentDirection);
                        this.MoverCelda(CurrentDirection, true);
                        moves++;
                    }
                }
            }
            /// <summary>
            /// Esta función retorna la direccion contraria a la que se ha movido la ficha. 
            /// Sirve para cuando se hace el scramble, no haga el efecto rebote y siempre tome una dirección
            /// de la cual no venga ya.
            /// </summary>
            /// <param name="direction">Dirección en la cual se ha movido la ficha.</param>
            /// <returns>Retorna la dirección por la que no puede volver la ficha, para evitar un rebote.</returns>
            private enumDireccion DireccionContraria(enumDireccion direction)
            {
                enumDireccion tmpResultado = enumDireccion.Abajo;
                switch (direction)
                {
                    case enumDireccion.Abajo:
                        {
                            tmpResultado = enumDireccion.Arriba;
                            break;
                        }
                    case enumDireccion.Arriba:
                        {
                            tmpResultado = enumDireccion.Abajo;
                            break;
                        }
                    case enumDireccion.Derecha:
                        {
                            tmpResultado = enumDireccion.Izquierda;
                            break;
                        }
                    case enumDireccion.Izquierda:
                        {
                            tmpResultado = enumDireccion.Derecha;
                            break;
                        }
                }
                return tmpResultado;
            }
        #endregion

        private void MenuTheme_Click(object sender, EventArgs e)
        {

        }
    }
}
