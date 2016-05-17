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

         public void RegistrarInforme(int NCODPROPUESTA ,string CESTADO, string COBSERVACION)
            {
                SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();
                daProveedor.RegistrarInforme(NCODPROPUESTA, CESTADO, COBSERVACION);

            }




         public DataTable ListarConvocatoriaParametro(int ncodtipoconvocatoria, string cfechainicio, string cfechafin,int ncodcatproducto)

        {
            
            DataTable dtListaConvocatoria = new DataTable();
            SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();

            dtListaConvocatoria = daProveedor.ListarConvocatoriaParametros(ncodtipoconvocatoria,cfechainicio,cfechafin,ncodcatproducto).Tables[0];

            return dtListaConvocatoria;
        }

         public DataTable ListarCategoriaProducto()
         {
             DataTable dtCategoriaProducto = new DataTable();
             SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();
             dtCategoriaProducto = daProveedor.ListarCategoriaProductos().Tables[0];
             return dtCategoriaProducto;
         }

         public void RegistrarPropuesta(int NCODCONVOCATORIA,int NCODCANDIDATO, int NMONTOTOTAL)
         {
           

          SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();
         daProveedor.RegistrarPropuesta(NCODCONVOCATORIA, NCODCANDIDATO, NMONTOTOTAL);
            

         }

          public DataTable ValidarRegistroPropuesta(int NCODCONVOCATORIA,int NCODCANDIDATO)
            {
             DataTable dtResultado = new DataTable();
             SPV.DA.SPV_Proveedores.Proveedor daProveedor = new SPV.DA.SPV_Proveedores.Proveedor();
             dtResultado = daProveedor.ValidarRegistroPropuesta(NCODCONVOCATORIA,NCODCANDIDATO).Tables[0];
             return dtResultado;
         }


    }
}
