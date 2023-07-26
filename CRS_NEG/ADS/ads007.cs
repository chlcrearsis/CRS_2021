using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    /// <summary>
    /// Clase USUARIO
    /// </summary>
    public class ads007
    {
        //######################################################################
        //##       Tabla: ads007                                              ##
        //##      Nombre: Usuario                                             ##
        //## Descripcion: Inicio Sesion Usuario                               ##         
        //##       Autor: JEJR - (05-01-2019)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registra Nuevo Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_usr">Nombre de Usuario</param>
        /// <param name="tel_usr">Teléfono</param>
        /// <param name="car_usr">Cargo Usuario</param>
        /// <param name="dir_tra">Directorio Trabajo</param>
        /// <param name="ema_usr">Email</param>
        /// <param name="ven_max">Máximo de Ventanas Abiertas</param>
        /// <param name="ide_per">ID. Persona</param>
        /// <param name="ide_tus">Tipo de Usuario</param>
        /// <param name="usr_new">Usuario Nuevo (1=Nuevo; 2=Antiguo)</param>
        public void Fe_nue_reg(string ide_usr, string nom_usr, string tel_usr, string car_usr,
                               string dir_tra, string ema_usr, int ven_max, int ide_per,
                                  int ide_tus, int usr_new)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_02a_p01 '" + ide_usr + "', '" + nom_usr + "', '" + tel_usr + "', '" + car_usr + "',");
                cadena.AppendLine("                       '" + dir_tra + "', '" + ema_usr + "',  " + ven_max + ",   " + ide_per + ",");
                cadena.AppendLine("                        " + ide_tus + ",   " + usr_new + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="nom_usr">Nombre de Usuario</param>
        /// <param name="tel_usr">Teléfono</param>
        /// <param name="car_usr">Cargo Usuario</param>
        /// <param name="dir_tra">Directorio Trabajo</param>
        /// <param name="ema_usr">Email</param>
        /// <param name="ven_max">Máximo de Ventanas Abiertas</param>
        /// <param name="ide_per">ID. Persona</param>
        /// <param name="ide_tus">Tipo de Usuario</param>
        public void Fe_edi_tar(string ide_usr, string nom_usr, string tel_usr, string car_usr,
                               string dir_tra, string ema_usr, int ven_max, int ide_per, int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads007 SET va_nom_usr = '" + nom_usr + "', va_tel_usr = '" + tel_usr + "',");
                cadena.AppendLine("                  va_car_usr = '" + car_usr + "', va_dir_tra = '" + dir_tra + "',");
                cadena.AppendLine("                  va_ema_usr =  " + ema_usr + ",  va_ven_max =  " + ven_max + ",");
                cadena.AppendLine("                  va_ide_per =  " + ide_per + ",  va_ide_tus =  " + ide_tus + "");
                cadena.AppendLine("            WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        public void Fe_hab_des(string ide_usr, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads007 SET va_est_ado = '" + est_ado + "' WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        public void Fe_eli_min(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads007_06_p01 '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica que el usuario SQL este definida en el SQL-Server
        /// </summary>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="usr_sql">ID. Usuario SQL</param>
        /// <param name="pas_sql">Contraseña SQL</param>
        /// <returns></returns>
        public DataTable Fe_usr_sql(string ser_bda, string usr_sql, string pas_sql)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT name FROM master.sys.server_principals WHERE name = '" + usr_sql + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString(), ser_bda, usr_sql, pas_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta SI el Usuario Logeado tiene los permisos 
        /// necesario para Ingresar al Sistema
        /// </summary>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public DataTable Fe_ver_usr(string ser_bda, string ide_usr, string pas_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads000_01a_p01 '" + ide_usr + "', '" + pas_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString(), ser_bda, ide_usr, pas_usr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion: Ingreso al Sistema (Primera Conexion)
        /// </summary>
        /// <param name="ide_uni">Identificador Unico de Conexion</param>
        /// <param name="ser_bda">Servidor/Base de Datos</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string Fe_ing_sis(string ide_uni, string ser_bda, string ide_usr, string pas_usr)
        {            
            try
            {
                ob_con_ecA.fe_log_usr(ide_uni, ser_bda, ide_usr, pas_usr);
                return ob_con_ecA.fe_abr_cnx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion: Ingreso al Sistema (Segunda Conexion)
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pas_usr">Contraseña</param>
        /// <returns></returns>
        public string Fe_ing_sis(string ide_usr, string pas_usr)
        {
            try
            {
                ob_con_ecA.Fe_log_sql(ide_usr, pas_usr);
                return ob_con_ecA.fe_abr_cnx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        /// cambia tipo de usuario al usuario
        /// </summary>
        /// <param name="ag_ide_usr">identificador</param>
        /// <param name="ag_ide_tus">Tipo de usuario a asignar</param>
        public void Fe_cam_tus(string ag_ide_usr, string ag_ide_tus)
        {
            cadena = " execute ads007_03d_p01 '" + ag_ide_usr + "','" + ag_ide_tus + "'";

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
        /// Inicializa contraseña de usuario a la por defecto
        /// </summary>
        /// <param name="ag_ide_usr">ID. Usuario</param>
        public void Fe_ini_psw(string ag_ide_usr)
        {
            cadena = " execute ads007_03c_p01 '" + ag_ide_usr + "' ";

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

        /// <summary>
        /// Consulta Usuario por ID. Tipo de Usuario
        /// </summary>
        /// <param name="ag_ide_usr"> Ide exacto del usuario a consultar</param>
        /// <returns></returns>
        public DataTable Fe_con_tus(int ide_tus, string est_ado = "T")
        {
            cadena = " Select * from ads007";
            cadena += " where va_ide_tus = " + ide_tus + "";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Buscar Usuario por similitud en id/nombre (like)
        /// </summary>
        /// <param name="ag_par_ame"> argumento parametro por que se buscara</param>
        /// <param name="ag_val_or"> argumento valor que se buscara</param>
        /// <returns></returns>
        public DataTable Fe_bus_usu(string ag_tex_bus, int ag_prm_bus, int ag_est_bus, int ag_tip_usr = 0)
        {
            cadena = " SELECT ads007.va_ide_usr, ads007.va_nom_usr, ads007.va_tel_usr, " +
                     "ads007.va_car_usr, ads006.va_nom_tus, ads007.va_est_ado " +
                     " FROM ads007 ,ads006 ";
            cadena += " WHERE ads006.va_ide_tus = ads007.va_tip_usr ";

            if(ag_prm_bus == 1)
                cadena += " AND ads007.va_ide_usr like '" + ag_tex_bus + "%'";
            if(ag_prm_bus == 2)
                cadena += " AND ads007.va_nom_usr like '" + ag_tex_bus + "%'";

            if(ag_est_bus == 1)
                cadena += " AND ads007.va_est_ado = 'H'";
            if (ag_est_bus == 2)
                cadena += " AND ads007.va_est_ado = 'N'";

            if(ag_tip_usr != 0)
                cadena += " AND ads007.va_tip_usr = " + ag_tip_usr ;

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
