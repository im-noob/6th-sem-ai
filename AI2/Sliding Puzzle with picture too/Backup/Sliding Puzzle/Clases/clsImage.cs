using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Sliding_Puzzle
{
    class clsImage
    {
        #region Variables Globales
            private string Ruta;
            private List<Image> tmpImagenes = new List<Image>();
            private bool NumerarImagenes = false;
        #endregion
        #region Propiedades
            public string Establecer_Ruta
            {
                get
                {
                    return this.Ruta;
                }
                set
                {
                    this.Ruta = value;
                }
            }
            public bool Numerar_Imagenes
            {
                get 
                {
                    return this.NumerarImagenes;
                }
                set 
                {
                    this.NumerarImagenes = value;
                }
            }
        #endregion
        #region Metodos Privados
            private Image Set_Minimum_Size(Image Imagen, Size Wished_Size)
            {
                Bitmap bm = new Bitmap(Imagen);
                Bitmap thumb = new Bitmap(Wished_Size.Width, Wished_Size.Height);
                Graphics g = Graphics.FromImage(thumb);
                //Como la division siempre deja decimales, cojo esos decimales
                double MargenErrorWidth = (Wished_Size.Width % Imagen.Width);
                double MargenErrorHeight = (Wished_Size.Height % Imagen.Height);
                //De los decimales que hemos cogido, solo cojo el primer decimal, los demás son insignificantes
                MargenErrorHeight = System.Convert.ToInt32(System.Convert.ToString(MargenErrorHeight).Substring(0, 1));
                MargenErrorWidth = System.Convert.ToInt32(System.Convert.ToString(MargenErrorWidth).Substring(0, 1));
                //Definimos el modo en el que se pintará la imagen (Resolución)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //Dibujamos la imagen
                g.DrawImage(bm, new Rectangle(0, 0, System.Convert.ToInt32(Wished_Size.Width + MargenErrorWidth), System.Convert.ToInt32(Wished_Size.Height + MargenErrorHeight)), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.Dispose();
                bm.Dispose();
                return thumb;
            }
        #endregion
        #region Metodos Publicos
            /// <summary>
            /// Se encarga de convertir una imagen a color en una imagen en escala de grises.
            /// </summary>
            /// <param name="original">Imagen que se desea convertir a escala de grises</param>
            /// <returns>Retorna la imagen convertida a escala de grises</returns>
            public Image ToGrayScale(Image original)
            {
                //create a blank bitmap the same size as original
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                //get a graphics object from the new image
                Graphics g = Graphics.FromImage(newBitmap);

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][] 
                   {
                       new float[] {.3f, .3f, .3f, 0, 0},
                       new float[] {.59f, .59f, .59f, 0, 0},
                       new float[] {.11f, .11f, .11f, 0, 0},
                       new float[] {0, 0, 0, 1, 0},
                       new float[] {0, 0, 0, 0, 1}
                   });

                 //create some image attributes
                 ImageAttributes attributes = new ImageAttributes();

                 //set the color matrix attribute
                 attributes.SetColorMatrix(colorMatrix);

                 //draw the original image on the new image
                 //using the grayscale color matrix
                 g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                   0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

                 //dispose the Graphics object
                 g.Dispose();
                 return newBitmap;

            }
            /// <summary>
            /// Esta función se encarga de cortar la imagen y preparar su numeración, cada trozo lo almacena
            /// en la lista "tmpImagenes"
            /// </summary>
            /// <param name="Columnas">Columnas que tiene el tablero</param>
            /// <param name="Filas">Filas que tiene el tablero</param>
            /// <param name="Height">Altura de cada celda</param>
            /// <param name="Width">Anchura de cada celda</param>
            /// <returns>Retorna true en caso de haber podido preparar la imagen, y false si por cualquier error no se ha podido preparar</returns>
            public bool Preparar_Imagen(int Columnas, int Filas, int Height, int Width)
            {
                tmpImagenes.Clear();
                bool tmpResult = false;
                try
                {
                    if (File.Exists(this.Ruta) == true)
                    {
                        Image PicMain = null;
                        PicMain = Image.FromFile(this.Ruta);
                        //Comprovamos si la imagen es más pequeña que el tablero, si lo es, la redimensionamos antes de cortarla
                        if ((PicMain.Width < (Width * Columnas)) || (PicMain.Height < (Height * Filas)))
                        {
                            PicMain = this.Set_Minimum_Size(PicMain, new Size(Columnas * Width, Filas * Height));
                        }
                        int TamanyoTrozoWidth = PicMain.Width / Columnas;
                        int TamanyoTrozoHeight = PicMain.Height / Filas;
                        Rectangle Rectangulo_Destino = new Rectangle(0, 0, Width, Height);
                        Bitmap bmpDest = null;
                        Graphics tmpGraficos_Dibujo = null;
                        Graphics tmpGraficos_Numeros = null;
                        Rectangle Rectangulo_Original = new Rectangle();
                        int tmpColumnaActual = 0;
                        int Pixel_X = 0;
                        int Pixel_Y = 0;
                        Pixel_X = 0;
                        Pixel_Y = 0;
                        Font tmpFontBack = new Font("Comic Sanz", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
                        for (int I = 0; I < (Columnas * Filas); I++)
                        {
                            Rectangulo_Original = new Rectangle(Pixel_X, Pixel_Y, TamanyoTrozoWidth, TamanyoTrozoHeight);
                            bmpDest = new Bitmap(TamanyoTrozoWidth, TamanyoTrozoHeight);
                            tmpGraficos_Dibujo = Graphics.FromImage(bmpDest);
                            tmpGraficos_Dibujo.DrawImage(PicMain, Rectangulo_Destino, Rectangulo_Original, GraphicsUnit.Pixel);
                            tmpGraficos_Numeros = Graphics.FromImage(bmpDest);
                            //Insertamos el número dentro del trozo de imagen para numerarla
                            if (this.NumerarImagenes == true)
                            {
                                GraphicsPath Lapiz = new System.Drawing.Drawing2D.GraphicsPath();
                                Lapiz.AddString((I + 1).ToString(), tmpFontBack.FontFamily, Convert.ToInt32(FontStyle.Bold), 20F, new Point(0, 0), StringFormat.GenericTypographic);
                                tmpGraficos_Numeros.FillPath(Brushes.White, Lapiz);
                                tmpGraficos_Numeros.DrawPath(Pens.Black, Lapiz);
                                tmpGraficos_Numeros.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                tmpGraficos_Numeros.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            }
                            tmpImagenes.Add(bmpDest);
                            tmpColumnaActual += 1;
                            Pixel_X += TamanyoTrozoWidth;
                            if (tmpColumnaActual >= Columnas)
                            {
                                tmpColumnaActual = 0;
                                Pixel_X = 0;
                                Pixel_Y += TamanyoTrozoHeight;
                            }
                        }
                        tmpResult = true;
                    }
                    return tmpResult;
                }
                catch
                {
                    return tmpResult;
                }
            }
            /// <summary>
            /// Esta función se encarga de retornar la imagen especificada por parámetro en el "tmpImagenes"
            /// </summary>
            /// <param name="Indice">Indice de la lista donde se encuentra la imagen que desea recuperar</param>
            /// <returns>Retorna la imagen que contenia la lista "tmpImagenes" en ese indice</returns>
            public Image GetImageFromIndex(int Indice)
            {
                return this.tmpImagenes[Indice - 1];
            }
            /// <summary>
            /// Esta función inserta las fechas de dirección en la imagen deseada
            /// </summary>
            /// <param name="Imagen">Imagen en la que se desea insertar las flechas</param>
            /// <param name="Arrows">Lista que contiene las flechas que se desean insertar en la imagen</param>
            /// <returns>Retorna la imagen que se ha pasado como parámetro pero con las flechas ya insertadas en la imagen</returns>
            public Image InsertarArrows(Image Imagen, List<enumDireccion> Arrows)
            {
                Graphics g = null;
                Image tmpImg = null;
                tmpImg = (Image)(Imagen.Clone());
                g = Graphics.FromImage(tmpImg);
                foreach (enumDireccion Arrow in Arrows)
                {
                    switch (Arrow)
                    {
                        case enumDireccion.Arriba:
                            g.DrawImage(Properties.Resources.arrow_up, new Point(30, Imagen.Height - Properties.Resources.arrow_down.Height));
                            break;
                        case enumDireccion.Abajo:
                            g.DrawImage(Properties.Resources.arrow_down, new Point(30, 0));
                            break;
                        case enumDireccion.Izquierda:
                            g.DrawImage(Properties.Resources.arrow_left, new Point(Imagen.Width - Properties.Resources.arrow_down.Width, 30));
                            break;
                        case enumDireccion.Derecha:
                            g.DrawImage(Properties.Resources.arrow_right, new Point(0, 30));
                            break;
                    }
                }
                g.Dispose();
                return tmpImg;
            }
        #endregion
    }
}
