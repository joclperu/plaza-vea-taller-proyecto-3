using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BL.SPV_Proveedores
{
    public class Proveedor

    {

        public  DataTable ListarCandidatoPropuesta(int ncodconvocatoria, string cdescripconvocatoria, string crazonsocialCandidato)
        {
            
            DataTable dtListaCandidatos = new DataTable();
            SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();

            dtListaCandidatos = daProveedor.ListarCandidatoPropuesta(ncodconvocatoria, cdescripconvocatoria, crazonsocialCandidato).Tables[0];

            return dtListaCandidatos;
        }
        public DataTable ListarConvocatoria()
        {

            DataTable dtListaConvocatorias = new DataTable();
            SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();

            dtListaConvocatorias = daProveedor.ListarConvocatoria().Tables[0];

            return dtListaConvocatorias;
        }


    }
}
