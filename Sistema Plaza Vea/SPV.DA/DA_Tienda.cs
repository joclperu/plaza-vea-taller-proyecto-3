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
using SPV.BE;
using System.Configuration;

namespace SPV.DA
{
    public class DA_Tienda : DA_Base
    {
        //Patron Singleton
        private static DA_Tienda Instancia = null;
        public static DA_Tienda getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new DA_Tienda();
            }
            return Instancia;
        }

        public List<EN_Tienda> Listar()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection conn = db.CreateConnection())
                {
                    using (DbCommand cmd = db.GetStoredProcCommand("sp_Listar_Tienda"))
                    {
                        conn.Open();

                        List<EN_Tienda> listResult = new List<EN_Tienda>();
                        using (IDataReader dr = db.ExecuteReader(cmd))
                        {

                            while (dr.Read())
                            {
                                EN_Tienda obj = new EN_Tienda();

                                if (!Convert.IsDBNull(dr["NcodTienda"]))
                                    obj.nCodTienda = Convert.ToInt32(dr["NcodTienda"]);

                                if (!Convert.IsDBNull(dr["CDescripcion"]))
                                    obj.cDescripcion = Convert.ToString(dr["CDescripcion"]);

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
