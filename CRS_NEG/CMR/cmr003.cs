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
    /// Clase: SUCURSAL
    /// </summary>
    public class cmr003
    {
        //######################################################################
        //##       Tabla: cmr003                                              ##
        //##      Nombre: Talonarios                                          ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (15-05-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public cmr003()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_ide_suc, string ar_nom_suc, string ar_des_suc, string ar_dto_suc,
            string ar_ciu_suc, string ar_dir_suc, string ar_enc_suc, string ar_tel_suc, string ar_cel_suc, string ar_cla_wif
            )
        {
            cadena = " INSERT INTO cmr003 VALUES('" + ar_ide_suc + "' , '" + ar_nom_suc + "','" + ar_des_suc  + "'" + 
                 ",'" + ar_dto_suc + "', '" + ar_ciu_suc +"', '"+ ar_dir_suc + "', '"+ ar_enc_suc + "', '" + ar_tel_suc + "'," +
                 "'" + ar_cel_suc + "','" + ar_cla_wif + "','null','H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_edi_suc(string ar_ide_suc, string ar_nom_suc, string ar_des_suc, string ar_dto_suc,
            string ar_ciu_suc, string ar_dir_suc, string ar_enc_suc, string ar_tel_suc, string ar_cel_suc, string ar_cla_wif)
        {
            cadena = " UPDATE cmr003 SET va_nom_suc = '" + ar_nom_suc + "', va_des_suc = '" + ar_des_suc + "', " +
                  " va_dto_suc = '" + ar_dto_suc + "', va_ciu_suc = '" + ar_ciu_suc + "', va_dir_suc ='" + ar_dir_suc + "', " +
                  " va_enc_suc = '" + ar_enc_suc + "', va_tel_suc = '" + ar_tel_suc + "', " +
                  " va_cel_suc ='" + ar_cel_suc + "' , va_cla_wif ='" + ar_cla_wif + "'" +
                  " WHERE va_ide_suc = " + ar_ide_suc + " " ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili( string ar_ide_suc)
        {
            //cadena = " cmr003_04a_p01 '" + ar_ide_suc + "'";

            cadena = " UPDATE cmr003 set va_est_ado = 'H' " +
                " WHERE va_ide_suc = " + ar_ide_suc;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(string ar_ide_suc)
        {
            //cadena = " cmr003_04a_p02 '" + ar_ide_suc + "'" ;
            cadena = " UPDATE cmr003 set va_est_ado = 'N' " +
               " WHERE va_ide_suc = " + ar_ide_suc;
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_suc(string ar_ide_suc)
        {
            cadena = " cmr003_06a_p01 '" + ar_ide_suc + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_suc( string ar_ide_suc)
        {
            //cadena = " cmr003_05a_p01 '" + ar_ide_suc + "'" ;
            cadena = " SELECT * FROM cmr003 WHERE va_ide_suc = '" + ar_ide_suc + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       

        public DataTable Fe_con_suc_permiso(string ar_ide_suc, int ar_nro_suc)
        {
            cadena = " cmr003_05a_p02 '" + ar_ide_suc + "', " + ar_nro_suc;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * " +
                     " FROM cmr003 ";
            cadena += " WHERE va_ide_suc = va_ide_suc ";

            if (ar_par_ame == 0)
                cadena += "AND va_nom_suc LIKE '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += "AND va_ciu_suc LIKE '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += "AND va_dir_suc LIKE '" + ar_tex_bus + "%'";

            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car_permiso(string ar_tex_bus,  string  ar_ide_suc)
        {
            cadena = " cmr003_01b_p01  '" + ar_tex_bus + "%' , '" + ar_ide_suc + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ges_tio"></param>
        /// <returns></returns>
        public DataTable Fe_cmr003_R01(int ar_ide_mod, string ar_est_ado)
        {   
            cadena = " cmr003_R01 " + ar_ide_mod + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

     
    }
}
