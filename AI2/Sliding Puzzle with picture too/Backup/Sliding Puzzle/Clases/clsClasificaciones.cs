using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Sliding_Puzzle
{
    #region "Estructura Proveedores NIC"
        public struct structClasificacion
        {
            public string Player;
            public DateTime TimeElapsed;
            public string BoardSize;
            public int Moves;
        }
    #endregion
    public class clsClasificaciones
    {
            #region "Variables Globales"
                string BBDD_Path = Application.StartupPath + @"\" + "Clasificaciones.mdb";
                string Cadena_Conexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Clasificaciones.mdb";
                OleDbCommand DataCommand;
                OleDbDataReader DataReader;
                OleDbConnection DataConnection;
            #endregion
            #region "Eventos"
                public delegate void _General_Exception(Exception ex);
                public event _General_Exception General_Exception;
                public delegate void _Error_BBDD_Not_Found();
                public event _Error_BBDD_Not_Found BBDD_Not_Found;
            #endregion
            #region "Constructor"
                public clsClasificaciones()
                {
                    if (this.BBDD_Exist() == true)
                    {
                        DataConnection = new OleDbConnection(this.Cadena_Conexion);
                    }
                }
            #endregion
            #region "Métodos Públicos"
                /// <summary>
                /// Devuelve una lista que contiene las puntuaciones obtenidas de todos los jugadores.
                /// </summary>
                /// <param name="boardFilter">Filtra el resultado por el tamaño del tablero</param>
                /// <returns>
                /// Retorna una lista que contiene todas las puntuaciones guardadas, 
                /// ordenadas segun tiempo transcurrido y movimientos realizados
                /// </returns>
                public List<structClasificacion> GetClasificaciones(string boardFilter)
                {
                    string Sentencia = "Select player, timeElapsed, boardSize, moves From partidas where boardSize='" + boardFilter + "' Order By format(timeElapsed,'hh:mm:ss'), moves Asc";
                    List<structClasificacion> Lista_Calificaciones = new List<structClasificacion>();
                    structClasificacion Clasificacion;
                    try
                    {
                        if ((this.BBDD_Exist() == true) && (this.BBDD_Connected() == true))
                        {
                            this.DataCommand = new OleDbCommand(Sentencia, this.DataConnection);
                            this.DataReader = this.DataCommand.ExecuteReader();
                            if (this.DataReader.HasRows == true)
                            {
                                while (this.DataReader.Read())
                                {
                                    Clasificacion = new structClasificacion();
                                    Clasificacion.Player = Convert.ToString(this.DataReader["player"]);
                                    Clasificacion.Moves = Convert.ToInt32(this.DataReader["moves"]);
                                    Clasificacion.BoardSize = Convert.ToString(this.DataReader["boardSize"]);
                                    Clasificacion.TimeElapsed = Convert.ToDateTime(this.DataReader["timeElapsed"].ToString());
                                    Lista_Calificaciones.Add(Clasificacion);
                                }
                            }
                        }
                        return Lista_Calificaciones;
                    }
                    catch (Exception ex)
                    {
                        if (this.General_Exception != null)
                        {
                            this.General_Exception(ex);
                        }
                        return Lista_Calificaciones;
                    }
                }
                /// <summary>
                /// Introduce una partida en la BBDD de las clasificaciones
                /// </summary>
                /// <param name="Clasificacion">Estructura que contiene la partida que se desea insertar</param>
                public void InsertarClasificacion(structClasificacion Clasificacion)
                {
                    string Sentencia = "Insert Into partidas (player, timeElapsed, boardSize, moves) ";
                    Sentencia += "values ('" + Clasificacion.Player + "'," + this.DateFormat(Clasificacion.TimeElapsed) + ",'" + Clasificacion.BoardSize + "'," + Clasificacion.Moves.ToString() + ")";
                    try
                    {
                        if ((this.BBDD_Exist() == true) && (this.BBDD_Connected() == true))
                        {
                            this.DataCommand = new OleDbCommand(Sentencia, this.DataConnection);
                            this.DataCommand.ExecuteNonQuery();                            
                        }
                    }
                    catch (Exception ex)
                    {
                        if (this.General_Exception != null)
                        {
                            this.General_Exception(ex);
                        }
                    }
                }
                /// <summary>
                /// Determina si la BBDD existe o no
                /// </summary>
                /// <returns>Retorna true en caso de existir y false en caso de no existir.</returns>
                public bool Check_DB_Exist()
                {
                    return this.BBDD_Exist();
                }
                /// <summary>
                /// Se encarga de conectar la instancia de la clase a la BBDD
                /// </summary>
                /// <returns>Retorna true en caso de haberse podido conectar y false en caso de no haber podido conectarse</returns>
                public bool Conectar_BBDD_Clasificaciones()
                {
                    try
                    {
                        bool Resultado;
                        if (this.BBDD_Exist() == true)
                        {
                            if (DataConnection.State == ConnectionState.Closed)
                            { 
                                DataConnection.Open();
                            }
                            Resultado = true;
                        }
                        else
                        {
                            if (this.BBDD_Not_Found != null)
                            { 
                                this.BBDD_Not_Found();
                            }
                            Resultado = false;
                        }
                        return Resultado;
                    }
                    catch (Exception ex)
                    {
                        if (this.General_Exception != null)
                        {
                            this.General_Exception(ex);
                        }
                        return false;
                    }
                }
                /// <summary>
                /// Se encarga de desconectar la instancia de la clase de la BBDD.
                /// </summary>
                public void Desconectar_BBDD_Clasificaciones()
                {
                    if (this.BBDD_Exist() == true)
                    {
                        if (this.DataConnection.State != ConnectionState.Closed)
                        { 
                            this.DataConnection.Close();
                        }
                    }   
                }
            #endregion
            #region "Métodos Privados"
                /// <summary>
                /// Determina si la base de datos existe o no
                /// </summary>
                /// <returns>Retorna true en caso de existir y false en caso de no existir.</returns>
                private bool BBDD_Exist()
                {
                    try
                    {
                        if (File.Exists(this.BBDD_Path) == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (this.General_Exception != null)
                        {
                            this.General_Exception(ex);
                        }
                        return false;
                    }
                }
                /// <summary>
                /// Determina si la instancia de la clase esta o no conectada a la BBDD de clasificaciones
                /// </summary>
                /// <returns>Retorna true en caso de estar conectada y false en caso de no estarlo</returns>
                private bool BBDD_Connected()
                {
                    try
                    {
                        bool Result = false;
                        switch (this.DataConnection.State)
                        {
                            case ConnectionState.Open:
                                {
                                    Result = true;
                                    break;
                                }
                            default:
                                {
                                    Result = false;
                                    break;
                                }
                        }
                        return Result;
                    }
                    catch (Exception ex)
                    {
                        if (this.General_Exception != null)
                        { 
                            this.General_Exception(ex);
                        }
                        return false;
                    }
                }
                /// <summary>
                /// Se encarga de formatear una variable fecha para que esta pueda ser insertada sin
                /// incompatibilidades por el sistema operativo.
                /// </summary>
                /// <param name="fecha">Fecha que se desea formatear</param>
                /// <returns>retorna un string con la fecha formateada</returns>
                private string DateFormat(DateTime fecha)
                {
                    string DD = fecha.Day.ToString();
                    string MM = fecha.Month.ToString();
                    string YYYY = fecha.Year.ToString();
                    string hh = fecha.Hour.ToString();
                    string mm = fecha.Minute.ToString();
                    string ss = fecha.Second.ToString();
                    return "format('" + DD + "/" + MM + "/" + YYYY + " " + hh + ":" + mm + ":" + ss + "','DD/MM/YYYY HH:MM:SS')"; 
                }
            #endregion
    }
}
