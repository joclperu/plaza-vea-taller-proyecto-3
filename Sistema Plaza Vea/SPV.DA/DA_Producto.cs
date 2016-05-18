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
    public class DA_Producto : DA_Base
    {
        public List<EN_Producto> Listar(EN_Producto oEN_Producto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_Listar_Producto"))
                    {
                        db.AddInParameter(cmd, "@NCodTienda", DbType.Int32, Formateo_Numero(oEN_Producto.NcodTienda == 0 ? (object)null : oEN_Producto.NcodTienda));
                        db.AddInParameter(cmd, "@Fecha", DbType.Date, Formateo_Fecha(oEN_Producto.DFecha));
                        db.AddInParameter(cmd, "@NomProducto", DbType.String, Formateo_Texto(oEN_Producto.CDescripcion));
                        conn.Open();

                        List<EN_Producto> listResult = new List<EN_Producto>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_Producto obj = new EN_Producto();

                                if (!Convert.IsDBNull(dr["nom_tienda"]))
                                    obj.nom_tienda = Convert.ToString(dr["nom_tienda"]);

                                if (!Convert.IsDBNull(dr["CDescripcion"]))
                                    obj.CDescripcion = Convert.ToString(dr["CDescripcion"]);

                                if (!Convert.IsDBNull(dr["NStock"]))
                                    obj.NStock = Convert.ToInt32(dr["NStock"]);

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    obj.NCodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                



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
        public List<EN_Producto> ListarDetalleProducto(EN_Producto oEN_Producto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_listar_DetalleProducto"))
                    {
                        db.AddInParameter(cmd, "@NCodProducto", DbType.Int32, Formateo_Numero(oEN_Producto.NCodProducto));
                        conn.Open();

                        List<EN_Producto> listResult = new List<EN_Producto>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_Producto obj = new EN_Producto();

                                if (!Convert.IsDBNull(dr["NcodGuiaRemision"]))
                                    obj.NcodGuiaRemision = Convert.ToString(dr["NcodGuiaRemision"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    obj.DFecha = Convert.ToDateTime(dr["DFecha"]);

                                if (!Convert.IsDBNull(dr["recibida"]))
                                    obj.recibida = Convert.ToInt32(dr["recibida"]);

                                if (!Convert.IsDBNull(dr["solicitada"]))
                                    obj.solicitada = Convert.ToInt32(dr["solicitada"]);

                                if (!Convert.IsDBNull(dr["stock"]))
                                    obj.NStock = Convert.ToInt32(dr["stock"]);



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


        public EN_Producto Consultar(EN_Producto oEN_Producto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_Consultar_Producto"))
                    {

                        db.AddInParameter(cmd, "@NCodProducto", DbType.Int32, Formateo_Numero(oEN_Producto.NCodProducto));
                        db.AddInParameter(cmd, "@NCodTienda", DbType.Int32, Formateo_Numero(oEN_Producto.NcodTienda));
                        conn.Open();

                        EN_Producto en_result = new EN_Producto();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                if (!Convert.IsDBNull(dr["CDescripcion"]))
                                    en_result.CDescripcion = Convert.ToString(dr["CDescripcion"]);

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    en_result.NCodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                if (!Convert.IsDBNull(dr["nom_proveedor"]))
                                    en_result.nom_proveedor = Convert.ToString(dr["nom_proveedor"]);

                                if (!Convert.IsDBNull(dr["stock"]))
                                    en_result.NStock = Convert.ToInt32(dr["stock"]);

                                if (!Convert.IsDBNull(dr["DFecha"]))
                                    en_result.DFecha = Convert.ToDateTime(dr["DFecha"]);
                            
                            }
                            dr.Close();
                            conn.Close();
                        }
                        return en_result;
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
