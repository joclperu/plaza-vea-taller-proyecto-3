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
    public class DA_DetalleNotaDocumento : DA_Base
    {
        //Patron Singleton
        private static DA_DetalleNotaDocumento Instancia = null;
        public static DA_DetalleNotaDocumento getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_DetalleNotaDocumento();
            }
            return Instancia;
        }

        public int Registrar(EN_DetalleNotaDocumento objEn,int codDespacho)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_Registrar_DetalleDocumento"))
                    {
                        db.AddInParameter(dbCmd, "@NCodDocumento", DbType.Int32, Formateo_Numero(objEn.nCodDocumento));
                        db.AddInParameter(dbCmd, "@NCodProducto", DbType.Int32, Formateo_Numero(objEn.NCodProducto));
                        db.AddInParameter(dbCmd, "@NCantidad", DbType.Int32, Formateo_Numero(objEn.NCantidad));
                        db.AddInParameter(dbCmd, "@NCodTienda", DbType.Int32, Formateo_Numero(objEn.ncodTienda));
                        db.AddInParameter(dbCmd, "@NcodDespacho", DbType.Int32, Formateo_Numero(codDespacho));

                        
                        
                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();
                        
                        Resultado = 1;
                        conn.Close();
                        return Resultado;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RegistrarIngreso(EN_DetalleNotaDocumento objEn, int codOc)
        {

            try
            {
                int Resultado = 0;
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    using (DbCommand dbCmd = db.GetStoredProcCommand("sp_Registrar_DetDocumento_ingreso"))
                    {
                        db.AddInParameter(dbCmd, "@NCodDocumento", DbType.Int32, Formateo_Numero(objEn.nCodDocumento));
                        db.AddInParameter(dbCmd, "@NCodProducto", DbType.Int32, Formateo_Numero(objEn.NCodProducto));
                        db.AddInParameter(dbCmd, "@NCantidad", DbType.Int32, Formateo_Numero(objEn.NCantidad));
                        db.AddInParameter(dbCmd, "@NCodTienda", DbType.Int32, Formateo_Numero(objEn.ncodTienda));
                        db.AddInParameter(dbCmd, "@NCodigoOC", DbType.Int32, Formateo_Numero(codOc));

                        db.ExecuteNonQuery(dbCmd, trans);
                        trans.Commit();

                        Resultado = 1;
                        conn.Close();
                        return Resultado;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<EN_DetalleNotaDocumento> Listar(int codDocumento)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_Listar_DetalleSalida"))
                    {
                        db.AddInParameter(cmd, "@NCodDocumento", DbType.Int32, Formateo_Numero(codDocumento));
                        conn.Open();

                        List<EN_DetalleNotaDocumento> listResult = new List<EN_DetalleNotaDocumento>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_DetalleNotaDocumento obj = new EN_DetalleNotaDocumento();

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    obj.NCodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                if (!Convert.IsDBNull(dr["NCantidad"]))
                                    obj.NCantidad = Convert.ToInt32(dr["NCantidad"]);

                                if (!Convert.IsDBNull(dr["nom_unidad"]))
                                    obj.nom_unidad = Convert.ToString(dr["nom_unidad"]);

                                if (!Convert.IsDBNull(dr["nom_producto"]))
                                    obj.nom_producto = Convert.ToString(dr["nom_producto"]);

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
