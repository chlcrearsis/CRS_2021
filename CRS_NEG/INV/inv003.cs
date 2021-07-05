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
    /// Clase: FAMILIA DE PRODUCTOS
    /// </summary>
    public class inv003
    {
        //######################################################################
        //##       Tabla: inv003                                              ##
        //##      Nombre: BODEGAS                                             ##
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



        public inv003()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_cod_fam, string ar_nom_fam, string ar_tip_fam, string ar_est_ado)
        {
            cadena = " INSERT INTO inv003 VALUES('" + ar_cod_fam + "', '" + ar_nom_fam + "', " +
                "'" + ar_tip_fam + "', 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_fam(string ar_cod_fam, string ar_nom_fam)
        {
            cadena = " UPDATE inv003 SET va_nom_fam = '" + ar_nom_fam + "' " + 
                    " WHERE va_cod_fam = '" + ar_cod_fam + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(string ar_cod_fam )
        {
            cadena = " UPDATE inv003 SET va_est_ado = 'H'" +
                    " WHERE va_cod_fam = '" + ar_cod_fam + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(string ar_cod_fam )
        {
            cadena = " inv003_04a_p01 '" + ar_cod_fam + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_fam(string ar_cod_fam )
        {
            cadena = " inv003_06a_p01 '" + ar_cod_fam + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_fam( string ar_cod_fam)
        {
            cadena = " inv003_05a_p01 '" + ar_cod_fam + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM inv003 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_fam like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_fam like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_tip_fam = " + ar_tex_bus + "";


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Funcion Externa para Restaurant, solo filtra las familias que no sean Matriz ni Combo
        /// </summary>
        /// <param name="ar_tex_bus"> Texto a buscar</param>
        /// <param name="ar_par_ame">Parametro 1= Codigo; 2=Nombre</param>
        /// <param name="ar_est_ado">Estado T=Todos; H=Habilitado ; N=deshabilitado</param>
        /// <returns></returns>
        public DataTable Fe_bus_car_2(string ar_tex_bus, int ar_par_ame, string ar_est_ado)
        {
            cadena = " SELECT * FROM inv003 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_fam like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_fam like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_tip_fam = " + ar_tex_bus + "";


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

            cadena += " AND va_tip_fam <> 'M'";
            cadena += " AND va_tip_fam <> 'C'";


            return ob_con_ecA.fe_exe_sql(cadena);
        }



        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: Familia de producto
        /// </summary>
        /// <param name="ar_cod_fam"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_inv003_R01( string ar_est_ado)
        {   
            cadena = " inv003_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
