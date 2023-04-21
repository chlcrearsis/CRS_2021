using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: LISTA DE PRECIO
    /// </summary>
    public class cmr001
    {
        //######################################################################
        //##       Tabla: cmr001                                              ##
        //##      Nombre: LISTA DE PRECIO                                     ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        string DateFornat = "dd.MM.yyyy hh:mm:ss";



        public cmr001()
        {
            
        }
 
        public void Fe_nue_reg(int ar_cod_lis, string ar_nom_lis, string ar_mon_lis, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_nro_dec)
        {
            try
            {
                cadena = " INSERT INTO cmr001 VALUES(" + ar_cod_lis + ", '" + ar_nom_lis + "', " +
                "'" + ar_mon_lis + "','" + ar_fec_ini.ToString(DateFornat) + "','" + ar_fec_fin.ToString(DateFornat) + "', "+ ar_nro_dec +", 'H')";

                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

      
        public void Fe_edi_tar(int ar_cod_lis, string ar_nom_lis, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_nro_dec)
        {
            try
            { 
                cadena = " UPDATE cmr001 SET va_nom_lis = '" + ar_nom_lis + "' , " +
                    " va_fec_ini = '" + ar_fec_ini.ToString(DateFornat) + "', va_fec_fin = '" + ar_fec_fin.ToString(DateFornat) + "'," +
                     " va_nro_dec = '" + ar_nro_dec + "'" +
                        " WHERE va_cod_lis = " + ar_cod_lis;
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }

        public void Fe_hab_ili(int ar_cod_lis )
        {
            try { 
                cadena = " UPDATE cmr001 SET va_est_ado = 'H'" +
                        " WHERE va_cod_lis = " + ar_cod_lis;
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fe_des_hab(int ar_cod_lis )
        {
            try { 
                cadena = " UPDATE cmr001 SET va_est_ado = 'N'" ;
                cadena += " WHERE va_cod_lis = '" + ar_cod_lis + "'";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Fe_eli_lis(int ar_cod_lis)
        {
            try { 
                cadena = " DELETE cmr001 " ;
                cadena += " WHERE va_cod_lis = '" + ar_cod_lis + "'";
                ob_con_ecA.fe_exe_sql(cadena);

                cadena = " DELETE cmr002 ";
                cadena += " WHERE va_cod_lis = '" + ar_cod_lis + "'";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_con_lis( int ar_cod_lis)
        {
            try { 
                cadena = " SELECT * FROM cmr001 WHERE va_cod_lis = " + ar_cod_lis + " ";
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// BUSCAR LISTA DE PRECIOS ABM
        /// </summary>
        /// <param name="ar_tex_bus"></param>
        /// <param name="ar_par_ame"></param>
        /// <param name="ar_est_ado"></param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            try { 
                cadena = " EXECUTE cmr001_01a_p01  '" + ar_tex_bus + "' , " + ar_par_ame + " , '" + ar_est_ado  + "'";
           
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// BUSCAR LISTA DE PRECIOS PERMITIDAS
        /// </summary>
        /// <param name="ar_tex_bus"></param>
        /// <param name="ar_par_ame"></param>
        /// <param name="ar_est_ado"></param>
        /// <returns></returns>
        public DataTable Fe_bus_car_b(string ar_tex_bus, int ar_par_ame, string ar_est_ado)
        {
            try { 
                cadena = " EXECUTE cmr001_01b_p01  '" + ar_tex_bus + "' , " + ar_par_ame + " , '" + ar_est_ado + "'";

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_lis"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr001_R01( string ar_est_ado)
        {
            try { 
                cadena = " cmr001_R01 '" + ar_est_ado + "'" ;

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
