using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: VENDEDORES
    /// </summary>
    public class cmr014
    {
        //######################################################################
        //##       Tabla: cmr014                                              ##
        //##      Nombre: VENDEDORES                                          ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (15-09-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA VENDEDORES/COBRADOR"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        /// <param name="nom_ven">Nombre del Vendedor/Cobrador</param>
        /// <param name="tel_cel">Telefono Celular</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="pro_ced">Procedencia (1=Empresa ; 2=Externo)</param>
        /// <param name="tip_cms">Tipo comisión (1=General Venta; 2=Familia, 3=Producto)</param>
        /// <param name="cms_con">Porcentaje comision general al contado</param>
        /// <param name="cms_cre">Porcentaje comision general al credito</param>
        public void Fe_nue_reg(int ide_tip, int cod_ven, string nom_ven, string tel_cel, string ema_ail,
                               int pro_ced, int tip_cms, decimal cms_con, decimal cms_cre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO cmr014 VALUES (" + ide_tip + ", " + cod_ven + ", '" + nom_ven + "', '" + tel_cel + "', '" + ema_ail + "', " + pro_ced + ", " + tip_cms + ", '" + cms_con + "', '" + cms_cre + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "EDITA VENDEDORES/COBRADORES"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        /// <param name="nom_ven">Nombre del Vendedor/Cobrador</param>
        /// <param name="tel_cel">Telefono Celular</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="pro_ced">Procedencia (1=Empresa ; 2=Externo)</param>
        public void Fe_edi_reg(int ide_tip, int cod_ven, string nom_ven, string tel_cel, string ema_ail, int pro_ced)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE cmr014 SET va_nom_bre = '" + nom_ven + "', va_tel_cel = '" + tel_cel + "', va_ema_ail = '" + ema_ail + "', va_pro_ced = " + pro_ced + "");
                cadena.AppendLine("            WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("              AND va_cod_ide = " + cod_ven + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "EDITA COMISION DE VENDEDOR/COBRADOR"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        /// <param name="tip_cms">Tipo comisión (1=General Venta; 2=Familia, 3=Producto)</param>
        /// <param name="cms_con">Porcentaje comision general al contado</param>
        /// <param name="cms_cre">Porcentaje comision general al credito</param>
        public void Fe_edi_com(int ide_tip, int cod_ven, int tip_cms, decimal cms_con, decimal cms_cre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE cmr014 SET va_tip_cms = " + tip_cms + ", va_cms_con = '" + cms_con + "', va_cms_cre = '" + cms_cre + "'");
                cadena.AppendLine("            WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("              AND va_cod_ide = " + cod_ven + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA VENDEDORES/COBRADORES"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        public void Fe_hab_ili(int ide_tip, int cod_ven)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE cmr014 SET va_est_ado = 'H' WHERE va_ide_tip = " + ide_tip + " AND va_cod_ide = " + cod_ven + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "DESHABILITA VENDEDORES/COBRADORES"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        public void Fe_des_hab(int ide_tip, int cod_ven)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE cmr014 SET va_est_ado = 'N' WHERE va_ide_tip = " + ide_tip + " AND va_cod_ide = " + cod_ven + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA VENDEDORES/COBRADORES"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        public void Fe_eli_ven(int ide_tip, int cod_ven)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE cmr014 WHERE va_ide_tip = " + ide_tip + " AND va_cod_ide = " + cod_ven + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "CONSULTA VENDEDORES/COBRADORES"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ven">Codigo identificador(4 numeros)</param>
        public DataTable Fe_con_ven(int cod_ven, int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_ide, va_nom_bre, va_tel_cel, va_ema_ail,");
                cadena.AppendLine("       va_pro_ced, va_tip_cms, va_cms_con, va_cms_cre, va_est_ado ");
                cadena.AppendLine("  FROM cmr014");
                cadena.AppendLine(" WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("   AND va_cod_ide = " + cod_ven + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA TIPO DE ATRIBUTO POR NOMBRE"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="nom_bre">Nombre del Vendedor/Cobrador</param>
        /// <param name="cod_ide">Código Vendedor/Cobrador</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(int ide_tip, string nom_bre, int cod_ide = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_ide, va_nom_bre, va_tel_cel,");
                cadena.AppendLine("       va_ema_ail, va_pro_ced, va_tip_cms, va_cms_con,");
                cadena.AppendLine("       va_cms_cre, va_est_ado");
                cadena.AppendLine("  FROM cmr014");
                cadena.AppendLine(" WHERE va_ide_tip =  " + ide_tip + "");
                cadena.AppendLine("   AND va_nom_bre = '" + nom_bre + "'");
                if (cod_ide > 0)
                    cadena.AppendLine(" AND va_cod_ide <> " + cod_ide + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función : "BUSCAR VENDEDOR / COBRADOR"
        /// </summary>
        /// <param name="tex_bus">Texto a Buscar</param>
        /// <param name="par_ame">Parametro</param>
        /// <param name="est_ado">Estado</param>
        /// <param name="ide_tip">Tipo (1=Vendedor; 2=Cobrador)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string tex_bus, int par_ame, string est_ado, int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_ide, va_nom_bre, va_tel_cel, va_ema_ail,");
                cadena.AppendLine("       va_pro_ced, va_tip_cms, va_cms_con, va_cms_cre, va_est_ado ");
                cadena.AppendLine("  FROM cmr014");
                if (par_ame == 0)
                    cadena.AppendLine(" WHERE va_cod_ide like '" + tex_bus + "%'");
                if (par_ame == 1)
                    cadena.AppendLine(" WHERE va_nom_bre like '" + tex_bus + "%'");
                if (est_ado != "T")
                    cadena.AppendLine(" AND va_est_ado ='" + est_ado + "'");

                cadena.AppendLine(" AND va_ide_tip ='" + ide_tip + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA DE USUARIO PERMISO P/VENDEDOR O COBRADOR"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1=Vendedor ; 2=Cobrador)</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(int ide_tip, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_ide, va_nom_bre, va_tel_cel, va_ema_ail,");
                cadena.AppendLine("       va_pro_ced, va_tip_cms, va_cms_con, va_cms_cre, va_est_ado");
                cadena.AppendLine("  FROM cmr014");
                cadena.AppendLine(" WHERE va_ide_tip =  " + ide_tip + "");
                cadena.AppendLine("   AND va_est_ado = '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA DE USUARIO PERMISO P/VENDEDOR O COBRADOR"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <param name="cod_ide">Código Vendedor/Cobrador</param>
        /// <returns></returns>
        public DataTable Fe_lis_usr(int ide_tip, int cod_ide)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE cmr014_08a_p01 " + ide_tip + ", " + cod_ide + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. DEL VENDEDOR O COBRADOR"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo (1= Vendedor ; 2= Cobrador)</param>
        /// <returns></returns>
        public DataTable Fe_obt_ide(int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_cod_ide INT ");
                cadena.AppendLine(" SELECT @va_cod_ide = ISNULL(MAX(va_cod_ide), 0) FROM cmr014 WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine(" SELECT @va_cod_ide + 1 AS va_cod_ide");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
