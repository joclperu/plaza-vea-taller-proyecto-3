using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace SPV.DA
{
    public class DA_DetalleNotaIngreso : DA_Base
    {
        //Patron Singleton : garantiza que solo abra una sola instancia de la BD
        private static DA_DetalleNotaIngreso Instancia = null;
        public static DA_DetalleNotaIngreso getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_DetalleNotaIngreso();
            }
            return Instancia;
        }

        public int Registrar(EN_DetalleNotaIngreso objEn)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_insDetalleNotaIngreso"))
                    {
                        db.AddInParameter(dbCmd, "@NCodNotaIngreso", DbType.Int32, Formateo_Numero(objEn.NCodNotaIngreso));
                        db.AddInParameter(dbCmd, "@codGuiaRemision", DbType.String, Formateo_Texto(objEn.NCodGuiaRemision));
                        db.AddInParameter(dbCmd, "@NCodProducto", DbType.Int32, Formateo_Numero(objEn.NCodProducto));
                        db.AddInParameter(dbCmd, "@NCantidad", DbType.Int32, Formateo_Numero(objEn.NCantidad));
                        db.AddInParameter(dbCmd, "@NCodTienda", DbType.Int32, Formateo_Numero(objEn.NCodTienda));
                        db.AddInParameter(dbCmd, "@NCodigoOC", DbType.Int32, Formateo_Numero(objEn.NcodOC));

                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();
                        conn.Close();
                        Resultado = 1;
                        return Resultado;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EN_DetalleNotaIngreso> Listar(int CodNotaIngreso)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_listar_DetalleNotaIngreso"))
                    {
                        db.AddInParameter(cmd, "@NCodNotaIngreso", DbType.Int32, Formateo_Numero(CodNotaIngreso));
                        conn.Open();

                        List<EN_DetalleNotaIngreso> listResult = new List<EN_DetalleNotaIngreso>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_DetalleNotaIngreso obj = new EN_DetalleNotaIngreso();

                                if (!Convert.IsDBNull(dr["NCoddetNotaIngreso"]))
                                    obj.NCoddetNotaIngreso = Convert.ToInt32(dr["NCoddetNotaIngreso"]);

                                if (!Convert.IsDBNull(dr["NCodNotaIngreso"]))
                                    obj.NCodNotaIngreso = Convert.ToInt32(dr["NCodNotaIngreso"]);

                                if (!Convert.IsDBNull(dr["NCodGuiaRemision"]))
                                    obj.NCodGuiaRemision = Convert.ToString(dr["NCodGuiaRemision"]);

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    obj.NCodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                if (!Convert.IsDBNull(dr["NCantidad"]))
                                    obj.NCantidad = Convert.ToInt32(dr["NCantidad"]);

                                if (!Convert.IsDBNull(dr["product_name"]))
                                    obj.Product_name = Convert.ToString(dr["product_name"]);

                                if (!Convert.IsDBNull(dr["und_medida"]))
                                    obj.und_medida = Convert.ToString(dr["und_medida"]);

                                
                                
                         
                                listResult.Add(obj);
                            }
                            dr.Close();
                            conn.Close();
                        }
                        return listResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
