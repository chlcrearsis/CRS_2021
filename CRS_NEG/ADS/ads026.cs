using System;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase BITACORA P/DOCUMENTO
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class ads026
    {
        //######################################################################
        //##       Tabla: ads026                                              ##
        //##      Nombre: BITACORA P/DOCUMENTO                                ##
        //## Descripcion: Informe Bitacora p/Documento                        ##         
        //##       Autor: JEJR  - (22-09-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA BITACORA P/DOCUMENTO"
        /// </summary>
        /// <param name="ges_doc">Gestión</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_doc">Nro. Documento</param>
        /// <param name="fch_reg">Fecha y Hora de Registro</param>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="tip_ope">Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)</param>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="obs_reg">Observación</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ges_doc, string ide_doc, int nro_doc, string fch_reg, 
                               int cod_per, string tip_ope, string ide_usr, string obs_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads026 VALUES (" + ges_doc + ", '" + ide_doc + "',  " + nro_doc + ",  '" + fch_reg + "',");
                cadena.AppendLine("                           " + cod_per + ", '" + tip_ope + "', '" + ide_usr + "', '" + obs_reg + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
