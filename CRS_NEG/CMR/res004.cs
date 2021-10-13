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
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase PLANTILLA DE VENTAS RESTAURANT
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_res004
    {
        //######################################################################
        //##       Tabla: res004                                              ##
        //##      Nombre: PLANTILLA DE VENTAS   RESTAURANT                    ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (12-10-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        StringBuilder cadena;



        public c_res004()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public DataTable Fe_bus_car(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" res004_01a_p01 '" + val_bus +"', "+ prm_bus  + ",'"+ est_bus  + "'  ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Fe_bus_car_permiso(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" res004_01b_p01 '" + val_bus + "', " + prm_bus + ",'" + est_bus + "'  ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REGISTRAR Planilla de Venta
        /// </summary>
        /// <param name="cod_plv">Codigo de plantilla de venta (3 números)</param>
        /// <param name="nom_plv">Nombre de la plantilla</param>
        /// <param name="des_plv">Descripcion de la plantilla</param>
        /// <param name="cod_bod">Codigo de almacen (inv011) (##-##-###) -> compuesto por (va_cod_gru , va_nro_bod)</param>
        /// <param name="cam_bod">Bandera cambia almacen ? (0=NO ; 1=SI)</param>
        /// <param name="cod_cli">Cliente por defecto (adm010) (##-#####) (2 de Grup. Per y 5 de Persona)</param>
        /// <param name="cod_caj">Caja para las ventas al contado (tes001) (5 Números)</param>
        /// <param name="cam_caj">Bandera cambia caja ? (0=NO ; 1=SI)</param>
        /// <param name="cod_lis">Lista de precio por defecto (cmr001)  (8 numeros)</param>
        /// <param name="cam_lis">Bandera, cambia lista ? (0=NO; 1=CAMBIA ; 2=Si o si la Asignada al cliente)</param>
        /// <param name="cod_ven">Codigo del vendedor por defecto (cmr003) (4 numeros)</param>
        /// <param name="cam_ven">Cambia vendedor ? (0=NO; 1=CAMBIA; 2=Obtiene el asignado DEL cliente)</param>
        /// <param name="dia_ret">Dias permitidos para ventas retrasadas ##</param>
        /// <param name="for_pgo">Forma de pago (1=Contado; 2=Credito)</param>
        /// <param name="cam_fpg">Cambia forma de pago ? (0=NO; 1=CAMBIA)</param>
        /// <param name="pgo_cta">en la forma de pago Credito, Permite pago a cuenta ? (0=NO; 1= SI)</param>
        /// <param name="ope_def">Operacion por defecto (1=Factura; 2=Nota de Venta; 3=Pedido; 4=Cotizacion)</param>
        /// <param name="lib_cre">Codigo Libreta para ventas al credito (ecp006) (5 Numeros)</param>
        /// <param name="lib_dev">Codigo Libreta para devoluciones de ventas (ecp006) (5 Numeros)</param>
        /// <param name="bus_pro">Busqueda rapida de producto por (1=nombre; 2= Descripcion; 3=Codigo)</param>
        /// <param name="img_pro">Permite productos repetidos ? (0=NO; 1=SI)</param>
        /// <param name="doc_fac">Documento factura (adm003) (3 Letras)</param>
        /// <param name="tal_fac">Talonario factura  (adm004) (2 numeros)</param>
        /// <param name="doc_ntv">Documento Nota de Venta (adm003) (3 Letras)</param>
        /// <param name="tal_ntv">Talonario Nota de venta (adm004) (2 numeros)</param>
       /// <param name="doc_con">Documento Cotizacion (adm003) (3 Letras)</param>
        /// <param name="tal_con">Talonario Cotizacion (adm004) (2 numeros)</param>
        /// <param name="doc_dcf">Documento DeV C/F (adm003) (3 Letras)</param>
        /// <param name="tal_dcf">Talonario DeV C/F (adm004) (2 numeros)</param>
        /// <param name="doc_dsf">Documento DeV S/F (adm003) (3 Letras)</param>
        /// <param name="tal_dsf">Talonario DeV S/F (adm004) (2 numeros)</param>
        /// <param name="imp_fac">Impresora por defecto para factura</param>
        /// <param name="imp_ntv">Impresora por defecto para Nota de venta</param>
        /// <param name="imp_con">Impresora para cotizacion</param>
        /// <param name="imp_dcf">Impresora para DeV C/F</param>
        /// <param name="imp_dsf">Impresora para DeV S/F</param>
        /// <param name="ban_av1">Imprime aviso de venta 1? (0=NO; 1=SI)</param>
        /// <param name="imp_av1">Impresora para aviso de venta 1</param>
        /// <param name="ban_av2">Imprime aviso de venta 2? (0=NO; 1=SI)</param>
        /// <param name="imp_av2">Impresora para aviso de venta 2</param>
        /// <param name="ban_imp">Bandera de impresion (0=No imprime; 1=Imprime directo ; 2=Pregunta para imprimir)</param>
        public void Fe_crea(string cod_plv, string nom_plv, string des_plv, string cod_bod, string cam_bod, string cod_cli, string cod_caj, string cam_caj,
                        string cod_lis, string cam_lis, string cod_ven, string cam_ven, string cod_del, string cam_del, string dia_ret, string for_pgo,
                        string cam_fpg, string pgo_cta, string ope_def, string lib_cre, string lib_dev, string bus_pro, string img_pro,
                        string doc_fac, string tal_fac, string doc_ntv, string tal_ntv, string doc_opd, string tal_opd, string doc_con, string tal_con,
                        string doc_dcf, string tal_dcf, string doc_dsf, string tal_dsf, string imp_fac, string imp_ntv, string imp_opd, string imp_con,
                        string imp_dcf, string imp_dsf, string ban_av1, string imp_av1, string ban_av2, string imp_av2, string ban_imp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" INSERT INTO res004 VALUES ");
                cadena.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',", cod_plv, nom_plv, des_plv, cod_bod, cam_bod, cod_cli, cod_caj, cam_caj);
                cadena.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',", cod_lis, cam_lis, cod_ven, cam_ven, cod_del, cam_del, dia_ret, for_pgo);
                cadena.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}',", cam_fpg, pgo_cta, ope_def, lib_cre, lib_dev, bus_pro);
                cadena.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',", doc_fac, tal_fac, doc_ntv, tal_ntv, doc_opd, tal_opd, doc_con, tal_con);
                cadena.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}',", doc_dcf, tal_dcf, doc_dsf, tal_dsf, imp_fac, imp_ntv, imp_con);
                cadena.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','H')", imp_dcf, imp_dsf, ban_av1, imp_av1, ban_av2, imp_av2, ban_imp, img_pro);

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ACTUALIZAR Planilla de Venta
        /// </summary>
        /// <param name="cod_plv">Codigo de plantilla de venta (3 números)</param>
        /// <param name="nom_plv">Nombre de la plantilla</param>
        /// <param name="des_plv">Descripcion de la plantilla</param>
        /// <param name="cod_bod">Codigo de almacen (inv011) (##-##-###) -> compuesto por (va_cod_gru , va_nro_bod)</param>
        /// <param name="cam_bod">Bandera cambia almacen ? (0=NO ; 1=SI)</param>
        /// <param name="cod_cli">Cliente por defecto (adm010) (##-#####) (2 de Grup. Per y 5 de Persona)</param>
        /// <param name="cod_caj">Caja para las ventas al contado (tes001) (5 Números)</param>
        /// <param name="cam_caj">Bandera cambia caja ? (0=NO ; 1=SI)</param>
        /// <param name="cod_lis">Lista de precio por defecto (cmr001)  (8 numeros)</param>
        /// <param name="cam_lis">Bandera, cambia lista ? (0=NO; 1=CAMBIA ; 2=Si o si la Asignada al cliente)</param>
        /// <param name="cod_ven">Codigo del vendedor por defecto (cmr003) (4 numeros)</param>
        /// <param name="cam_ven">Cambia vendedor ? (0=NO; 1=CAMBIA; 2=Obtiene el asignado DEL cliente)</param>
        /// <param name="dia_ret">Dias permitidos para ventas retrasadas ##</param>
        /// <param name="for_pgo">Forma de pago (1=Contado; 2=Credito)</param>
        /// <param name="cam_fpg">Cambia forma de pago ? (0=NO; 1=CAMBIA)</param>
        /// <param name="pgo_cta">en la forma de pago Credito, Permite pago a cuenta ? (0=NO; 1= SI)</param>
        /// <param name="ope_def">Operacion por defecto (1=Factura; 2=Nota de Venta; 3=Pedido; 4=Cotizacion)</param>
        /// <param name="lib_cre">Codigo Libreta para ventas al credito (ecp006) (5 Numeros)</param>
        /// <param name="lib_dev">Codigo Libreta para devoluciones de ventas (ecp006) (5 Numeros)</param>
        /// <param name="bus_pro">Busqueda rapida de producto por (1=nombre; 2= Descripcion; 3=Codigo)</param>
        /// <param name="img_pro">Permite productos repetidos ? (0=NO; 1=SI)</param>
        /// <param name="doc_fac">Documento factura (adm003) (3 Letras)</param>
        /// <param name="tal_fac">Talonario factura  (adm004) (2 numeros)</param>
        /// <param name="doc_ntv">Documento Nota de Venta (adm003) (3 Letras)</param>
        /// <param name="tal_ntv">Talonario Nota de venta (adm004) (2 numeros)</param>
        /// <param name="doc_con">Documento Cotizacion (adm003) (3 Letras)</param>
        /// <param name="tal_con">Talonario Cotizacion (adm004) (2 numeros)</param>
        /// <param name="doc_dcf">Documento DeV C/F (adm003) (3 Letras)</param>
        /// <param name="tal_dcf">Talonario DeV C/F (adm004) (2 numeros)</param>
        /// <param name="doc_dsf">Documento DeV S/F (adm003) (3 Letras)</param>
        /// <param name="tal_dsf">Talonario DeV S/F (adm004) (2 numeros)</param>
        /// <param name="imp_fac">Impresora por defecto para factura</param>
        /// <param name="imp_ntv">Impresora por defecto para Nota de venta</param>
        /// <param name="imp_con">Impresora para cotizacion</param>
        /// <param name="imp_dcf">Impresora para DeV C/F</param>
        /// <param name="imp_dsf">Impresora para DeV S/F</param>
        /// <param name="ban_av1">Imprime aviso de venta 1? (0=NO; 1=SI)</param>
        /// <param name="imp_av1">Impresora para aviso de venta 1</param>
        /// <param name="ban_av2">Imprime aviso de venta 2? (0=NO; 1=SI)</param>
        /// <param name="imp_av2">Impresora para aviso de venta 2</param>
        /// <param name="ban_imp">Bandera de impresion (0=No imprime; 1=Imprime directo ; 2=Pregunta para imprimir)</param>
        public void Fe_edi_tar(string cod_plv, string nom_plv, string des_plv, string cod_bod, string cam_bod, string cod_cli, string cod_caj, string cam_caj,
                        string cod_lis, string cam_lis, string cod_ven, string cam_ven, string cod_del, string cam_del, string dia_ret, string for_pgo,
                        string cam_fpg, string pgo_cta, string ope_def, string lib_cre, string lib_dev, string bus_pro, string img_pro,
                        string doc_fac, string tal_fac, string doc_ntv, string tal_ntv, string doc_opd, string tal_opd, string doc_con, string tal_con,
                        string doc_dcf, string tal_dcf, string doc_dsf, string tal_dsf, string imp_fac, string imp_ntv, string imp_opd, string imp_con,
                        string imp_dcf, string imp_dsf, string ban_av1, string imp_av1, string ban_av2, string imp_av2, string ban_imp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE res004 SET ");
                cadena.AppendFormat("va_nom_plv='{0}',va_des_plv='{1}',va_cod_bod={2},va_cam_bod={3},va_cod_caj={4},", nom_plv, des_plv, cod_bod, cam_bod, cod_caj);
                cadena.AppendFormat("va_cod_cli='{0}',va_cod_lis={1},va_cam_lis={2} ,va_dia_ret={3}, va_cod_del={4},va_cam_del={5}, ", cod_cli, cod_lis, cam_lis, dia_ret, cod_del, cam_del);
                cadena.AppendFormat("va_cod_ven={0},va_cam_ven={1}, va_lib_cre={2},va_lib_dev={3},va_for_pgo={4},va_cam_fpg={5},", cod_ven, cam_ven, lib_cre, lib_dev, for_pgo, cam_fpg);
                cadena.AppendFormat("va_pgo_cta={0},va_ope_def={1},va_doc_fac='{2}',va_tal_fac={3},va_doc_ntv='{4}',va_tal_ntv={5},", pgo_cta, ope_def, doc_fac, tal_fac, doc_ntv, tal_ntv);
                cadena.AppendFormat("va_doc_opd='{0}',va_tal_opd={1},va_doc_con='{2}',va_tal_con={3},va_ban_imp={4},va_imp_fac='{5}',", doc_opd, tal_opd,  doc_con, tal_con, ban_imp, imp_fac);
                cadena.AppendFormat("va_imp_ntv='{0}',va_imp_opd='{1}',va_imp_con='{2}',va_ban_av1={3},va_imp_av1='{4}',va_ban_av2={5},", imp_ntv, imp_opd, imp_con, ban_av1, imp_av1, ban_av2);
                cadena.AppendFormat("va_imp_av2='{0}',va_bus_pro={1},va_img_pro='{2}',va_cam_caj={3},va_doc_dcf='{4}',", imp_av2, bus_pro, img_pro, cam_caj, doc_dcf);
                cadena.AppendFormat("va_tal_dcf={0},va_doc_dsf='{1}',va_tal_dsf={2},va_imp_dcf='{3}',va_imp_dsf='{4}'  ", tal_dcf, doc_dsf, tal_dsf, imp_dcf, imp_dsf);
                cadena.AppendFormat(" WHERE va_cod_plv={0}", cod_plv);

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Habilita/Deshabilita Planilla de Venta"
        /// </summary>
        /// <param name="cod_plv">Codigo del Planilla de Venta</param>
        /// <param name="est_ado">Estado del Planilla de Venta</param>
        /// <returns></returns>
        public void Fe_hab_des(string cod_plv, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE res004 SET ");
                cadena.AppendLine(" va_est_ado='" + est_ado + "' ");
                cadena.AppendLine(" WHERE  va_cod_plv =" + cod_plv);

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Planilla de Venta"
        /// </summary>
        /// <param name="cod_plv">Codigo de la plantilla de venta</param>
        /// <returns></returns>
        public DataTable Fe_con_plv(string cod_plv)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM res004 ");
                cadena.AppendLine(" WHERE  va_cod_plv =" + cod_plv);

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta Planilla de Venta (nombres de tablas externas)"
        /// </summary>
        /// <param name="cod_plv">Codigo de la plantilla de venta</param>
        /// <returns></returns>
        public DataTable _05a(string cod_plv)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT plv.va_cod_plv,plv.va_nom_plv,plv.va_des_plv,plv.va_cod_bod,alm.va_nom_bod,plv.va_cam_bod,plv.va_cod_cli,per.va_nom_com,plv.va_cod_caj,caj.va_nom_cjb,plv.va_cam_caj," +
                                      "plv.va_cod_lis,lis.va_nom_lis,plv.va_cam_lis,plv.va_mon_vta,plv.va_cam_mon,plv.va_cod_ven,ven.va_nom_ven,plv.va_cam_ven,plv.va_dia_ret,plv.va_for_pgo,plv.va_cam_fpg,plv.va_pgo_cta," +
                                      "plv.va_ope_def,plv.va_lib_cre,(SELECT va_des_lib FROM ecp006 where va_cod_lib=plv.va_lib_cre) va_des_lib_cre,plv.va_lib_dev,(SELECT va_des_lib FROM ecp006 where va_cod_lib=plv.va_lib_dev) va_des_lib_dev," +
                                      "plv.va_bus_pro,plv.va_des_srv,plv.va_img_pro,plv.va_doc_fac,(SELECT va_nom_doc FROM adm003 where va_cod_doc=plv.va_doc_fac) va_nom_doc_fac,plv.va_tal_fac," +
                                      "(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_fac AND va_nro_tal=plv.va_tal_fac) va_nom_tal_fac,plv.va_doc_nvt,(SELECT va_nom_doc FROM adm003 where va_cod_doc=plv.va_doc_nvt) va_nom_doc_nvt," +
                                      "plv.va_tal_ntv,(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_nvt AND va_nro_tal=plv.va_tal_ntv) va_nom_tal_ntv,plv.va_doc_ped,(SELECT va_nom_doc FROM adm003 where va_cod_doc = plv.va_doc_ped) va_nom_doc_ped," +
                                      "plv.va_tal_ped,(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_ped AND va_nro_tal=plv.va_tal_ped) va_nom_tal_ped,plv.va_doc_con,(SELECT va_nom_doc FROM adm003 where va_cod_doc = plv.va_doc_con) va_nom_doc_con," +
                                      "plv.va_tal_con,(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_con AND va_nro_tal=plv.va_tal_con) va_nom_tal_con,plv.va_doc_dcf,(SELECT va_nom_doc FROM adm003 where va_cod_doc = plv.va_doc_dcf) va_nom_doc_dcf," +
                                      "plv.va_tal_dcf,(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_dcf AND va_nro_tal=plv.va_tal_dcf) va_nom_tal_dcf,plv.va_doc_dsf,(SELECT va_nom_doc FROM adm003 where va_cod_doc = plv.va_doc_dsf) va_nom_doc_dsf," +
                                      "plv.va_tal_dsf,(SELECT va_nom_tal FROM adm004 WHERE va_cod_doc=plv.va_doc_dsf AND va_nro_tal=plv.va_tal_dsf) va_nom_tal_dsf,plv.va_imp_fac,plv.va_imp_ntv,plv.va_imp_ped,plv.va_imp_cot,plv.va_imp_dcf,plv.va_imp_dsf," +
                                      "plv.va_ban_av1,plv.va_imp_av1,plv.va_ban_av2,plv.va_imp_av2,plv.va_ban_imp,plv.va_est_ado");
                cadena.AppendLine(" FROM res004 plv,inv011 alm,adm010 per,tes001 caj,cmr001 lis,cmr003 ven");
                cadena.AppendLine(" WHERE  va_cod_plv =" + cod_plv + " and plv.va_cod_bod=alm.va_cod_bod and plv.va_cod_cli=per.va_cod_per and va_cod_caj=caj.va_cod_cjb and plv.va_cod_lis=lis.va_cod_lis and " +
                                      "plv.va_cod_ven=ven.va_cod_ven");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Planilla de Venta"
        /// </summary>
        /// <param name="cod_plv">Codigo del Planilla de Venta</param>
        /// <returns></returns>
        public void Fe_eli_min(string cod_plv)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" DELETE res004 ");
                cadena.AppendLine(" WHERE  va_cod_plv =" + cod_plv);

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
