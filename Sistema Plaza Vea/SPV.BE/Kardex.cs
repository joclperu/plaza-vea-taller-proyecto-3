using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class Kardex
    {
        string strSql;
        string strCadenaConexion;

        public Kardex()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }


        public void RegistraKardex(int CodNotaIngreso, int CodProducto, int CodTienda, int Cantidad, string Fecha)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_ins_Kardex", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodNotaIngreso", SqlDbType.Int).Value = CodNotaIngreso;
            cmd.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
            cmd.Parameters.Add("@CodTienda", SqlDbType.Int).Value = CodTienda;
            cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}
