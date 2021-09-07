

using System.Data.SqlClient;
using System.Data;

using System.Configuration;

using CRS_DAT.Properties;
using System;

namespace CRS_DAT
{
    public class conexion_a
    {

        public string va_ser_bda = Settings.Default.va_ser_bda;  // Nombre del Servidor
        public string va_ins_bda = Settings.Default.va_ins_bda;  // Nombre de la Instancia
        public string va_nom_bda = Settings.Default.va_nom_bda;  // Nombre de la BD
        public string va_ide_usr = Settings.Default.va_ide_usr;  // ID Usuario
        public string va_pas_usr = Settings.Default.va_pas_usr;  // Contraseña Usuario

        SqlConnection va_cxn_sql = new SqlConnection();
        SqlCommand va_sql_cmd = new SqlCommand();     //Instancia el Objeto de Comando de SQL
        string Cadena;

        public void Login(string va_ide_uni, string ag_ser_bda , string ag_ide_usr , string ag_pas_usr )
        {

            int ser_bda = 0;
            int ins_bda = 0;
            int nom_bda = 0;

            //Obtiene el indice del Servidor y la Instancia
            ser_bda = ag_ser_bda.LastIndexOf("\\");
            ins_bda = ag_ser_bda.LastIndexOf(":");
            nom_bda = ag_ser_bda.Length;

            //Obtiene los datos de Conexion
            va_ide_usr = ag_ide_usr;
            va_pas_usr = ag_pas_usr;
            va_ser_bda = ag_ser_bda.Substring(0, ser_bda);
            va_ins_bda = ag_ser_bda.Substring(ser_bda + 1, ins_bda - ser_bda - 1);
            va_nom_bda = ag_ser_bda.Substring(ins_bda + 1, nom_bda - ins_bda - 1);

            //Graba los argumentos de conexion en la Configuración
            Settings.Default.va_ide_uni = va_ide_uni;
            Settings.Default.va_ser_bda = va_ser_bda;
            Settings.Default.va_ins_bda = va_ins_bda;
            Settings.Default.va_nom_bda = va_nom_bda;
            Settings.Default.va_ide_usr = va_ide_usr;
            Settings.Default.va_pas_usr = va_pas_usr;
        }

        /// <summary>
        /// Funcion Conexion inicial (Al loguearse)
        /// </summary>
        public string fe_abr_cnx()
        {
            try
            {
                //Obtiene los argumentos de conexion
                va_ser_bda = Settings.Default.va_ser_bda;
                va_ins_bda = Settings.Default.va_ins_bda;
                va_nom_bda = Settings.Default.va_nom_bda;
                va_ide_usr = Settings.Default.va_ide_usr;
                va_pas_usr = Settings.Default.va_pas_usr;
                //Obtiene la Cadena de Conexion
                Cadena = ("Data Source=" + va_ser_bda + "\\" + va_ins_bda + "; Initial Catalog = " + va_nom_bda + "; User Id = " + va_ide_usr + "; Password = " + va_pas_usr + "");
                //Coneta con el Servidor
                if (va_cxn_sql.State == ConnectionState.Closed)
                {
                    va_cxn_sql.ConnectionString = Cadena;
                    va_cxn_sql.Open();
                }
            
                return "OK";
            }
            catch (System.Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Cierra la coneccion
        /// </summary>
        public string fe_cer_cnx()
        {
            try
            {
                va_cxn_sql.Close();
                return "OK";
            }
            catch (System.Exception ex)
            {

                return ex.ToString();
            }  
        }



        #region METODOS PARA EJECUTAR CONSULTAS A SQL
 
        /// <summary>
        /// Funcion que Ejecuta comando SQL CON RETORNO
        /// </summary>
        /// <param name="cad_sql">Consulta(query) a ejecutar</param>
        /// <returns></returns>
        public DataTable fe_exe_sql(string StrQuery)  
        {
            try
            {
                DataTable dts = new DataTable();
                fe_abr_cnx();
                SqlDataAdapter Adaptador = new SqlDataAdapter(StrQuery, va_cxn_sql);
                Adaptador.Fill(dts);
                fe_cer_cnx();
                return dts;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                fe_cer_cnx();
            }
        }

        /// <summary>
        /// Funcion que Ejecuta comando SQL CON RETORNO, con el Usuario (crssql)
        /// </summary>
        /// <param name="StrQuery">Consulta(query) a ejecutar</param>
        /// <param name="ag_usr_sql">Usuario SQL</param>
        /// /// <param name="ag_pas_sql">Contraseña SQL</param>
        /// <returns></returns>
        public DataTable fe_exe_sql(string StrQuery, string ag_ser_bda, string ag_usr_sql, string ag_pas_sql)
        {
            try
            {
                DataTable dts = new DataTable();
                //Obtiene los argumentos de conexion               
                int ser_bda = 0;
                int ins_bda = 0;
                int nom_bda = 0;

                //Obtiene el indice del Servidor y la Instancia
                ser_bda = ag_ser_bda.LastIndexOf("\\");
                ins_bda = ag_ser_bda.LastIndexOf(":");
                nom_bda = ag_ser_bda.Length;

                //Obtiene los datos de Conexion
                va_ide_usr = ag_usr_sql;
                va_pas_usr = ag_pas_sql;
                va_ser_bda = ag_ser_bda.Substring(0, ser_bda);
                va_ins_bda = ag_ser_bda.Substring(ser_bda + 1, ins_bda - ser_bda - 1);
                va_nom_bda = ag_ser_bda.Substring(ins_bda + 1, nom_bda - ins_bda - 1);

                //Obtiene la Cadena de Conexion
                Cadena = ("Data Source=" + va_ser_bda + "\\" + va_ins_bda + "; Initial Catalog = " + va_nom_bda + "; User Id = " + va_ide_usr + "; Password = " + va_pas_usr + "");
                //Coneta con el Servidor
                if (va_cxn_sql.State == ConnectionState.Closed)
                {
                    va_cxn_sql.ConnectionString = Cadena;
                    va_cxn_sql.Open();
                }
                SqlDataAdapter Adaptador = new SqlDataAdapter(StrQuery, va_cxn_sql);
                Adaptador.Fill(dts);
                fe_cer_cnx();
                return dts;
            }
            catch (Exception)
            {
                DataTable table = new DataTable();
                return table;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                fe_cer_cnx();
            }
        }

        /// <summary>
        /// Funcion que guarda imagen a Base de Datos
        /// </summary>
        /// <param name="va_cad_sql">Cadena de consulta a SQL</param>
        /// <param name="va_nom_img">Nombre de Variable Temporal de Imagen</param>
        /// <param name="va_byt_img">Byte de la Imagen a guardar</param>
        public string fu_exe_sql_img(string va_cad_sql, string va_nom_img, byte[] va_byt_img)
        {
            try
            {
               va_sql_cmd = new SqlCommand();     //Instancia el Objeto de Comando de SQL


                //Abre la Conexion  
                fe_abr_cnx();


                va_sql_cmd.CommandText = va_cad_sql;   //Llena la Consulta al Objeto Comando de SQL
                va_sql_cmd.Connection = va_cxn_sql;   //Asigna el objeto Conexion SQL al Comando

                //Agrega Parametro con la imagen
                va_sql_cmd.Parameters.Add(va_nom_img, SqlDbType.VarBinary, va_byt_img.Length).Value = va_byt_img;
                va_sql_cmd.ExecuteNonQuery();      //Ejecuta la Consulta

                //Cierra la Conexion
                va_cxn_sql.Close();
                return "OK";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierra La conexion depues de ejecutar comando
                fe_cer_cnx();
            }
        }



        #endregion















    }
}
