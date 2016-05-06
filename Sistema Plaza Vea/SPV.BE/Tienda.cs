using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class Tienda
    {
        string strSql;
        string strCadenaConexion;

        public Tienda()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }

        public void ActualizaStockTiendaProducto(string Fecha, int CodTienda, int CodProducto, int Cantidad)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_upd_StockTiendaProducto", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;
            cmd.Parameters.Add("@CodTienda", SqlDbType.Int).Value = CodTienda;
            cmd.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}
