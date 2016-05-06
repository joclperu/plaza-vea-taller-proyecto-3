using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SPV.BE
{
    public class GuiaRemision
    {

        string strSql;
        string strCadenaConexion;

        public GuiaRemision()
        {
            SPV.BE.DA_GENERAL Cadena = new SPV.BE.DA_GENERAL();
            strCadenaConexion = Cadena.ObtenerCadena();
        }


        public void RegistraGuiaRemision(string GuiaRemision, int CodOC, string Fecha, string Transportista, string Placa, string Observacion)
        {
            SqlConnection cn = new SqlConnection(strCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_ins_guiaremision", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GuiaRemision", SqlDbType.VarChar).Value = GuiaRemision;
            cmd.Parameters.Add("@CodOC", SqlDbType.Int).Value = CodOC;
            cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;
            cmd.Parameters.Add("@Transportista", SqlDbType.VarChar).Value = Transportista;
            cmd.Parameters.Add("@Placa", SqlDbType.VarChar).Value = Placa;
            cmd.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Observacion;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


    }
}
