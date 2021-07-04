using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
namespace CRS_NEG.ADS
{
    /// <summary>
    /// Clase USUARIO
    /// </summary>
    public class c_ads007
    {
        //######################################################################
        //##       Tabla: ads001_07                                           ##
        //##      Nombre: Usuario                                             ##
        //## Descripcion: Inicio Sesion Usuario                               ##         
        //##       Autor: JEJR - (05-01-2019)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();      

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
       
       
        public c_ads007()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public string Login(string ag_ser_bda, string ag_ide_usr, string ag_pas_usr)
        {
            string msg_ret = "";
            ob_con_ecA.Login(ag_ser_bda, ag_ide_usr, ag_pas_usr);
            
            msg_ret = ob_con_ecA.fe_abr_cnx();

            if (msg_ret == "OK")
            {
                msg_ret = Fi_log_bdo(ag_ide_usr);
            }

            return msg_ret;
        }


        private string Fi_log_bdo( string ag_ser_bda)
        {
            string msg_ret = "";

            cadena = " SELECT name" +
                    " FROM sysusers " +
                    " WHERE(uid > 4) and " +
                    " (issqluser = 1) and " +
                    " name = '"+ ag_ser_bda + "'";
            cadena += " ";
            DataTable tabla =  ob_con_ecA.fe_exe_sql(cadena);
            if (tabla.Rows.Count > 0)
                msg_ret = "OK";
            else
                msg_ret = "El usuario no se encuentra en la base de datos seleccionada";

            return msg_ret;
        }


        public string Fe_ver_edi(string ag_ide_usr)
        {
            try
            {
                cadena = " execute ads007_01a_p02 '" + ag_ide_usr + "'";
                ob_con_ecA.fe_exe_sql(cadena);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Fe_ver_hds(string ag_ide_usr)
        {
            try
            {
                cadena = " execute ads007_01a_p03 '" + ag_ide_usr + "'";
                ob_con_ecA.fe_exe_sql(cadena);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string Fe_ver_con(string ag_ide_usr)
        {
            try
            {
                cadena = " execute ads007_01a_p04 '" + ag_ide_usr + "'";
                ob_con_ecA.fe_exe_sql(cadena);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string Fe_ver_eli(string ag_ide_usr)
        {
            try
            {
                cadena = " execute ads007_01a_p05 '" + ag_ide_usr + "'";
                ob_con_ecA.fe_exe_sql(cadena);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /// <summary>
        /// Crea nuevo usuario
        /// </summary>
        /// <param name="ag_ide_usr">identificador</param>
        /// <param name="ag_nom_usr">nombre</param>
        /// <param name="ag_tel_usr">telefono</param>
        /// <param name="ag_car_usr">cargo</param>
        /// <param name="ag_dir_ect">Directorio de trabajo</param>
        /// <param name="ag_ema_usr">email</param>
        /// <param name="ag_win_max">maximo de ventanas abiertas permitidas</param>
        /// <param name="ag_ide_per">persona relacionada con el usuario</param>
        /// <param name="ag_tip_usr">Tipo de usuario</param>
        public void Fe_exe_nue(string ag_ide_usr, string ag_nom_usr, string ag_tel_usr,
                                  string ag_car_usr, string ag_dir_ect, string ag_ema_usr, int ag_win_max,
                                  int ag_ide_per = 0, int ag_tip_usr = 1, int ag_usr_new = 1)
        {
            cadena = " execute ads007_02a_p01 '" + ag_ide_usr + "','"+ ag_nom_usr + "','";
            cadena += ag_tel_usr + "','" + ag_car_usr + "','" + ag_dir_ect+ "','" + ag_ema_usr + "'," + ag_win_max + ",";
            cadena += ag_ide_per + "," + ag_tip_usr + ", " + ag_usr_new;

             ob_con_ecA.fe_exe_sql(cadena);
        }



        /// <summary>
        /// Edita usuario
        /// </summary>
        /// <param name="ag_ide_usr">identificador</param>
        /// <param name="ag_nom_usr">nombre</param>
        /// <param name="ag_tel_usr">telefono</param>
        /// <param name="ag_car_usr">cargo</param>
        /// <param name="ag_ema_usr">email</param>
        /// <param name="ag_win_max">maximo de ventanas abiertas permitidas</param>
        /// <param name="ag_ide_per">persona relacionada con el usuario</param>
        public void Fe_exe_edi(string ag_ide_usr, string ag_nom_usr, string ag_tel_usr,
                                  string ag_car_usr, string ag_dir_ect, string ag_ema_usr, int ag_win_max,
                                  int ag_ide_per = 0, int ag_tip_usr = 0)
        {
            cadena = " execute ads007_03a_p01 '" + ag_ide_usr + "','" + ag_nom_usr + "','";
            cadena += ag_tel_usr + "','" + ag_car_usr + "','" + ag_dir_ect + "','" + ag_ema_usr + "'," + ag_win_max + ",";
            cadena += ag_ide_per + "," + ag_tip_usr;

            ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Habilitad/Deshabilita usuario
        /// </summary>
        /// <param name="ag_ide_usr">identificador</param>
        /// <param name="ag_est_Ado">estado</param>
        public void Fe_exe_hds(string ag_ide_usr, string ag_est_ado)
        {
            cadena = " execute ads007_04a_p01 '" + ag_ide_usr + "','" + ag_est_ado + "'";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Edita contraseña de usuario
        /// </summary>
        /// <param name="ag_ide_usr">ID. Usuario</param>
        /// <param name="ag_psw_new">Nueva contraseña</param>
        public void Fe_edi_psw(string ag_ide_usr, string ag_psw_new)
        {
            cadena = " execute ads007_03b_p01 '" + ag_ide_usr + "','" + ag_psw_new + "' ";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta Usuario por id exacto
        /// </summary>
        /// <param name="ag_ide_usr"> Ide exacto del usuario a consultar</param>
        /// <returns></returns>
        public DataTable Fe_con_usu(string ag_ide_usr)
        {
            cadena = " Select * from ads007";
            cadena += " where va_ide_usr= '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }



        public enum parametro
        {
            codigo = 1, nombre = 2
        }
        public enum estado
        {
            Todos = 0, Habilitado = 1, Deshabilitado = 2
        }
        /// <summary>
        /// Buscar Usuario por similitud en id/nombre (like)
        /// </summary>
        /// <param name="ag_par_ame"> argumento parametro por que se buscara</param>
        /// <param name="ag_val_or"> argumento valor que se buscara</param>
        /// <returns></returns>
        public DataTable Fe_bus_usu(string ag_tex_bus, int ag_prm_bus, int ag_est_bus, int ag_tip_usr = 0)
        {
            cadena = " Select * from ads007 , ads006 ";
            cadena += " WHERE ads006.va_ide_tus = ads007.va_tip_usr ";

            if(ag_prm_bus == 1)
                cadena += " AND va_ide_usr like '" + ag_tex_bus + "%'";
            if(ag_prm_bus == 2)
                cadena += " AND va_nom_usr like '" + ag_tex_bus + "%'";

            if(ag_est_bus == 1)
                cadena += " AND va_est_ado = 'H'";
            if (ag_est_bus == 2)
                cadena += " AND va_est_ado = 'N'";

            if(ag_tip_usr != 0)
                cadena += " AND va_tip_usr = " + ag_tip_usr ;

            return ob_con_ecA.fe_exe_sql(cadena);

        }

        /// <summary>
        /// Lista de inicios de sesion
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_lis_usu()
        {
            cadena = " SELECT * FROM sys.syslogins ";
            cadena += " where dbcreator = 1";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Reporte Listado de Usuarios
        /// </summary>
        /// <param name="ag_est_ado"> Estado a listar (T=todos; H=Habilitados; N=Deshabilitados)</param>
        /// <returns></returns>
        public DataTable Fe_ads007_R01(string ag_est_ado)
        {
           
            cadena = " ads007_R01 '" + ag_est_ado + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        } 

        #region "PERMISO SOBRE TALONARIO"

        /// <summary>
        /// Obtiene Permiso sobre Talonarios
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre un talonario especifico
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_nro_tal">Nro talonario</param>
        /// <returns></returns>
        public Boolean Fe_ads009_02(string ag_ide_usr,string ag_ide_doc, int ag_nro_tal)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads009 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'AND va_ide_doc ='" + ag_ide_doc + "' AND va_nro_tal =" + ag_nro_tal;
            DataTable tabla =  ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul =  false;
            if (tabla.Rows.Count >0)
                resul= true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre Talonario
        /// </summary>
        /// <param name="ag_ide_usr">usuario</param>
        /// <param name="ag_ide_doc">ide_documento</param>
        /// <param name="ag_nro_tal">nro talonario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_03(string ag_ide_usr, string ag_ide_doc, int ag_nro_tal)
        {
            cadena = " INSERT INTO ads009 VALUES ";
            cadena += " ('" + ag_ide_usr + "','" + ag_ide_doc + "', " + ag_nro_tal + ") ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre talonario
        /// </summary>
        /// <param name="ag_ide_usr">usuario</param>
        /// <param name="ag_ide_doc">ide_documento</param>
        /// <param name="ag_nro_tal">nro talonario</param>
        /// <returns></returns>
        public DataTable Fe_ads009_04(string ag_ide_usr, string ag_ide_doc, int ag_nro_tal)
        {
            cadena = " DELETE ads009 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_ide_doc = '" + ag_ide_doc + "' AND va_nro_tal = " + ag_nro_tal ;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion


        #region "PERMISO SOBRE PLANTILLA DE VENTA"

        /// <summary>
        /// Obtiene Permiso sobre Plantilla de ventas
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <returns></returns>
        public DataTable Fe_ads017_01(string ag_ide_usr)
        {
            cadena = " SELECT * FROM ads017 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta si el usuario tiene permiso sobre una  Plantilla especifico
        /// </summary>
        /// <param name="ag_ide_usr">Ide Usuario</param>
        /// <param name="ag_cod_plv">Cod de plantilla </param>
        /// <returns></returns>
        public Boolean Fe_ads017_02(string ag_ide_usr, int ag_cod_plv)
        {
            bool resul = false;

            cadena = " SELECT * FROM ads017 ";
            cadena += " WHERE  va_ide_usr = '" + ag_ide_usr + "' AND va_cod_plv =" + ag_cod_plv ;
            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count == 0)
                resul = false;
            if (tabla.Rows.Count > 0)
                resul = true;

            return resul;
        }

        /// <summary>
        /// Registra permiso sobre Talonario
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads017_03(string ag_ide_usr, int ag_cod_plv)
        {
            cadena = " INSERT INTO ads017 VALUES ";
            cadena += " ('" + ag_ide_usr + "', " + ag_cod_plv + ") ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Elimna permiso sobre talonario
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads017_04(string ag_ide_usr, int ag_cod_plv)
        {
            cadena = " DELETE ads009 ";
            cadena += " WHERE va_ide_usr ='" + ag_ide_usr + "' AND va_cod_plv = " + ag_cod_plv;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        #endregion
    }
}
