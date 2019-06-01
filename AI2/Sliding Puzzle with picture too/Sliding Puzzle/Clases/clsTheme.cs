using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace Sliding_Puzzle
{
    #region "Enumeraciones"
        public enum enumThemes
        { 
            Zen = 0,
            Aluminium = 1,
        }
    #endregion
    public class clsTheme
    {
        #region Eventos
            public delegate void ThemeChangedEventHandler();
            public event ThemeChangedEventHandler ThemeChanged;
        #endregion
        #region Variables Globales
            private enumThemes Theme;
        #endregion
        #region Variables Imagenes
            private Image tmpImg1;
            private Image tmpImg2;
            private Image tmpImg3;
            private Image tmpImg4;
            private Image tmpImg5;
            private Image tmpImg6;
            private Image tmpImg7;
            private Image tmpImg8;
            private Image tmpImg9;
            private Image tmpImg10;
            private Image tmpImg11;
            private Image tmpImg12;
            private Image tmpImg13;
            private Image tmpImg14;
            private Image tmpImg15;
            private Image tmpImg16;
            private Image tmpImg17;
            private Image tmpImg18;
            private Image tmpImg19;
            private Image tmpImg20;
            private Image tmpImg21;
            private Image tmpImg22;
            private Image tmpImg23;
            private Image tmpImg24;
            private Image tmpImg25;
            private Image tmpImg_Empty;
            private Image tmpBackgroundMenu;
            private Image tmpBackgroundStatus;
            private Image tmpTexturaFondo;
        #endregion
        #region Propiedades Generales
            public enumThemes Theme_Actual
            {
                get
                {
                    return this.Theme;
                }
            }
        #endregion
        #region Propiedades Imagenes
            public Image img1
            {
                get
                {
                    return this.tmpImg1;
                }
            }
            public Image img2
            {
                get
                {
                    return this.tmpImg2;
                }
            }
            public Image img3
            {
                get
                {
                    return this.tmpImg3;
                }
            }
            public Image img4
            {
                get
                {
                    return this.tmpImg4;
                }
            }
            public Image img5
            {
                get
                {
                    return this.tmpImg5;
                }
            }
            public Image img6
            {
                get
                {
                    return this.tmpImg6;
                }
            }
            public Image img7
            {
                get
                {
                    return this.tmpImg7;
                }
            }
            public Image img8
            {
                get
                {
                    return this.tmpImg8;
                }
            }
            public Image img9
            {
                get
                {
                    return this.tmpImg9;
                }
            }
            public Image img10
            {
                get
                {
                    return this.tmpImg10;
                }
            }
            public Image img11
            {
                get
                {
                    return this.tmpImg11;
                }
            }
            public Image img12
            {
                get
                {
                    return this.tmpImg12;
                }
            }
            public Image img13
            {
                get
                {
                    return this.tmpImg13;
                }
            }
            public Image img14
            {
                get
                {
                    return this.tmpImg14;
                }
            }
            public Image img15
            {
                get
                {
                    return this.tmpImg15;
                }
            }
            public Image img16
            {
                get
                {
                    return this.tmpImg16;
                }
            }
            public Image img17
            {
                get
                {
                    return this.tmpImg17;
                }
            }
            public Image img18
            {
                get
                {
                    return this.tmpImg18;
                }
            }
            public Image img19
            {
                get
                {
                    return this.tmpImg19;
                }
            }
            public Image img20
            {
                get
                {
                    return this.tmpImg20;
                }
            }
            public Image img21
            {
                get
                {
                    return this.tmpImg21;
                }
            }
            public Image img22
            {
                get
                {
                    return this.tmpImg22;
                }
            }
            public Image img23
            {
                get
                {
                    return this.tmpImg23;
                }
            }
            public Image img24
            {
                get
                {
                    return this.tmpImg24;
                }
            }
            public Image img25
            {
                get
                {
                    return this.tmpImg25;
                }
            }
            public Image imgEmpty
            {
                get
                {
                    return this.tmpImg_Empty;
                }
            }
            public Image imgBackgroundMenu
            {
                get
                {
                    return this.tmpBackgroundMenu;
                }
            }
            public Image imgBackgroundStatus
            {
                get
                {
                    return this.tmpBackgroundStatus;
                }
            }
            public Image imgTexturaFondo
            {
                get
                {
                    return this.tmpTexturaFondo;
                }
            }
        #endregion
        #region Constructor
            public clsTheme()
            {
                //Prepara el tema por defecto
                this.Cargar_Theme(enumThemes.Zen);
            }
        #endregion
        #region Metodos Publicos 
            /// <summary>
            /// Prepara el tema especificado
            /// </summary>
            /// <param name="Theme">Tema que se desea cargar</param>
            public void Cargar_Theme(enumThemes Theme)
            {
                switch (Theme)
                {
                    case enumThemes.Zen:
                        this.Theme = enumThemes.Zen;
                        this.Cargar_Wood_Theme();
                        break;
                    case enumThemes.Aluminium:
                        this.Theme = enumThemes.Aluminium;
                        this.Cargar_Metal_Theme();
                        break;
                }
                if (ThemeChanged != null)
                { 
                    ThemeChanged();
                }
            }
        #endregion
        #region Metodos Privados
            private void Cargar_Wood_Theme()
            {
                this.tmpImg1 = Properties.Resources.wood_img1;
                this.tmpImg2 = Properties.Resources.wood_img2;
                this.tmpImg3 = Properties.Resources.wood_img3;
                this.tmpImg4 = Properties.Resources.wood_img4;
                this.tmpImg5 = Properties.Resources.wood_img5;
                this.tmpImg6 = Properties.Resources.wood_img6;
                this.tmpImg7 = Properties.Resources.wood_img7;
                this.tmpImg8 = Properties.Resources.wood_img8;
                this.tmpImg9 = Properties.Resources.wood_img9;
                this.tmpImg10 = Properties.Resources.wood_img10;
                this.tmpImg11 = Properties.Resources.wood_img11;
                this.tmpImg12 = Properties.Resources.wood_img12;
                this.tmpImg13 = Properties.Resources.wood_img13;
                this.tmpImg14 = Properties.Resources.wood_img14;
                this.tmpImg15 = Properties.Resources.wood_img15;
                this.tmpImg16 = Properties.Resources.wood_img16;
                this.tmpImg17 = Properties.Resources.wood_img17;
                this.tmpImg18 = Properties.Resources.wood_img18;
                this.tmpImg19 = Properties.Resources.wood_img19;
                this.tmpImg20 = Properties.Resources.wood_img20;
                this.tmpImg21 = Properties.Resources.wood_img21;
                this.tmpImg22 = Properties.Resources.wood_img22;
                this.tmpImg23 = Properties.Resources.wood_img23;
                this.tmpImg24 = Properties.Resources.wood_img24;
                this.tmpImg25 = Properties.Resources.wood_img25;
                this.tmpImg_Empty = Properties.Resources.wood_imgEmpty;
                this.tmpBackgroundMenu = Properties.Resources.wood_BackGroundMenu;
                this.tmpBackgroundStatus = Properties.Resources.wood_BackGroundStatus;
                this.tmpTexturaFondo = Properties.Resources.wood_TexturaFondo;
            }
            private void Cargar_Metal_Theme()
            {
                this.tmpImg1 = Properties.Resources.metal_img1;
                this.tmpImg2 = Properties.Resources.metal_img2;
                this.tmpImg3 = Properties.Resources.metal_img3;
                this.tmpImg4 = Properties.Resources.metal_img4;
                this.tmpImg5 = Properties.Resources.metal_img5;
                this.tmpImg6 = Properties.Resources.metal_img6;
                this.tmpImg7 = Properties.Resources.metal_img7;
                this.tmpImg8 = Properties.Resources.metal_img8;
                this.tmpImg9 = Properties.Resources.metal_img9;
                this.tmpImg10 = Properties.Resources.metal_img10;
                this.tmpImg11 = Properties.Resources.metal_img11;
                this.tmpImg12 = Properties.Resources.metal_img12;
                this.tmpImg13 = Properties.Resources.metal_img13;
                this.tmpImg14 = Properties.Resources.metal_img14;
                this.tmpImg15 = Properties.Resources.metal_img15;
                this.tmpImg16 = Properties.Resources.metal_img16;
                this.tmpImg17 = Properties.Resources.metal_img17;
                this.tmpImg18 = Properties.Resources.metal_img18;
                this.tmpImg19 = Properties.Resources.metal_img19;
                this.tmpImg20 = Properties.Resources.metal_img20;
                this.tmpImg21 = Properties.Resources.metal_img21;
                this.tmpImg22 = Properties.Resources.metal_img22;
                this.tmpImg23 = Properties.Resources.metal_img23;
                this.tmpImg24 = Properties.Resources.metal_img24;
                this.tmpImg25 = Properties.Resources.metal_img25;
                this.tmpImg_Empty = Properties.Resources.metal_imgEmpty;
                this.tmpBackgroundMenu = Properties.Resources.metal_BackGroundMenu;
                this.tmpBackgroundStatus = Properties.Resources.metal_BackGroundStatus;
                this.tmpTexturaFondo = Properties.Resources.metal_TexturaFondo;
            }
        #endregion
    }
}
