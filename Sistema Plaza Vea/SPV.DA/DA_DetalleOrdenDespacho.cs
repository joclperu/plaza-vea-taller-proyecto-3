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
    public class DA_DetalleOrdenDespacho : DA_Base
    {
        //Patron Singleton
        private static DA_DetalleOrdenDespacho Instancia = null;
        public static DA_DetalleOrdenDespacho getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_DetalleOrdenDespacho();
            }
            return Instancia;
        }


        public List<EN_DetalleOrdenDespacho> Listar(EN_OrdenDespacho oEN_OrdenDespacho)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_consultar_DetalleOrdenDespacho"))
                    {
                        db.AddInParameter(cmd, "@NCodDespacho", DbType.Int32, Formateo_Numero(oEN_OrdenDespacho.ncodDespacho));
                        conn.Open();

                        List<EN_DetalleOrdenDespacho> listResult = new List<EN_DetalleOrdenDespacho>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_DetalleOrdenDespacho obj = new EN_DetalleOrdenDespacho();

                                if (!Convert.IsDBNull(dr["NCodItem"]))
                                    obj.ncodItem = Convert.ToInt32(dr["NCodItem"]);

                                if (!Convert.IsDBNull(dr["NCodDespacho"]))
                                    obj.ncodDespacho = Convert.ToInt32(dr["NCodDespacho"]);

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    obj.ncodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                if (!Convert.IsDBNull(dr["NCantPedido"]))
                                    obj.nCantPedido = Convert.ToInt32(dr["NCantPedido"]);

                                if (!Convert.IsDBNull(dr["NCantReposicion"]))
                                    obj.nCantReposicion = Convert.ToInt32(dr["NCantReposicion"]);

                                if (!Convert.IsDBNull(dr["NCantDiferencia"]))
                                    obj.nCantDiferencia = Convert.ToInt32(dr["NCantDiferencia"]);

                                if (!Convert.IsDBNull(dr["nom_producto"]))
                                    obj.nom_producto = Convert.ToString(dr["nom_producto"]);

                                if (!Convert.IsDBNull(dr["nom_unidad"]))
                                    obj.nom_unidad = Convert.ToString(dr["nom_unidad"]);

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
