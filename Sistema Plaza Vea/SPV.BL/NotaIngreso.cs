using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SPV.BL
{
    public class NotaIngreso
    {
        public int ObtenerCorrelativoNotaIngreso()
        {
            SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
          int codigo;
          codigo = Ing.ObtenerCorrelativoNotaIngreso();
          return codigo;

        }

        public void RegistraNotaIngreso(int CodNotaIngreso, string CodGuiaRemision, string Fecha)
        {
            SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
            Ing.RegistraNotaIngreso(CodNotaIngreso, CodGuiaRemision, Fecha);
        }


        public void RegistraDetalleNotaIngreso(int CodNotaIngreso, int CodProducto, int Cantidad)
        {
            SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
            Ing.RegistraDetalleNotaIngreso(CodNotaIngreso, CodProducto, Cantidad);
        }


        public DataTable ListaNotaIngresoCodigoOC(int CodigoOC)
        {
            try
            {
                SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
                DataTable dt = new DataTable();

                dt = Ing.ListaNotaIngresoCodigoOC(CodigoOC);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable ListaNotaIngreso(int NotaIngreso)
        {
            try
            {
                SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
                DataTable dt = new DataTable();

                dt = Ing.ListaNotaIngreso(NotaIngreso);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable ListaDetalleNotaIngreso(int NotaIngreso)
        {
            try
            {
                SPV.BE.NotaIngreso Ing = new SPV.BE.NotaIngreso();
                DataTable dt = new DataTable();

                dt = Ing.ListaDetalleNotaIngreso(NotaIngreso);

                return dt;
            }
            catch
            {
                return null;
            }
        }


    }
}
