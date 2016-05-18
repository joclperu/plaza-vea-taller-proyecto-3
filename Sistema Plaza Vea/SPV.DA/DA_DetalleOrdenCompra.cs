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
    public class DA_DetalleOrdenCompra : DA_Base
    {

        //Patron Singleton
        private static DA_DetalleOrdenCompra Instancia = null;
        public static DA_DetalleOrdenCompra getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_DetalleOrdenCompra();
            }
            return Instancia;
        }

        /// <summary>
        /// Lista el detalle de una orden de compra
        /// </summary>
        /// <param name="objEn"></param>
        /// <returns></returns>
        public List<EN_DetalleOrdenCompra> Listar(EN_OrdenCompra oEN_OrdenCompra)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_listar_detalleOrdenCompra"))
                    {
                        db.AddInParameter(cmd, "@CodigoOc", DbType.Int32, Formateo_Numero(oEN_OrdenCompra.CodigoOC));
                        conn.Open();

                        List<EN_DetalleOrdenCompra> listResult = new List<EN_DetalleOrdenCompra>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_DetalleOrdenCompra obj = new EN_DetalleOrdenCompra();

                                if (!Convert.IsDBNull(dr["NCodItem"]))
                                    obj.nCodigoDetOC = Convert.ToInt32(dr["NCodItem"]);

                                if (!Convert.IsDBNull(dr["NCodigoOC"]))
                                    obj.nCodigoOC = Convert.ToInt32(dr["NCodigoOC"]);

                                if (!Convert.IsDBNull(dr["NCodProducto"]))
                                    obj.nCodProducto = Convert.ToInt32(dr["NCodProducto"]);

                                if (!Convert.IsDBNull(dr["NCantPedido"]))
                                    obj.nCantPedido = Convert.ToInt32(dr["NCantPedido"]);

                                if (!Convert.IsDBNull(dr["NCantReposicion"]))
                                    obj.nCantReposicion = Convert.ToInt32(dr["NCantReposicion"]);

                                if (!Convert.IsDBNull(dr["NCantDiferencia"]))
                                    obj.nCantDiferencia = Convert.ToInt32(dr["NCantDiferencia"]);

                                if (!Convert.IsDBNull(dr["CObservacion"]))
                                    obj.cObservacion = Convert.ToString(dr["CObservacion"]);

                                if (!Convert.IsDBNull(dr["CDescripcion"]))
                                    obj.nNomProducto = Convert.ToString(dr["CDescripcion"]);

                                if (!Convert.IsDBNull(dr["CUnidadMedida"]))
                                    obj.cUnidadMedida = Convert.ToString(dr["CUnidadMedida"]);


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
