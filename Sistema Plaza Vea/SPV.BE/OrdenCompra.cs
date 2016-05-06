using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class OrdenCompra
    {
        string strSql;
        string strCadenaConexion;

        public OrdenCompra()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }

        public void ActualizaDetalleOrdenCompra(int CodigoOC, int CodProducto, int Cantidad)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_upd_DetalleOrdenCompra", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoOC", SqlDbType.Int).Value = CodigoOC;
            cmd.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        public void ActualizaEstadoOrdenCompra(int CodigoOC)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_upd_EstadoOrdenCompra", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoOC", SqlDbType.Int).Value = CodigoOC;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}
