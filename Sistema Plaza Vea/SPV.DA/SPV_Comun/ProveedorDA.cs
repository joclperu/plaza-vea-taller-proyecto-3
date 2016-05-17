using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Comun
{
    public class ProveedorDA
    {
        #region Mantenimiento Proveedor
        public ProveedorBEList GetAllUserControlProveedor()
        {
            ProveedorBEList Lista = new ProveedorBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "proveedor.spv_sps_usercontrol_proveedor";
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    ProveedorBE OProveedorBE = CrearEntidadUserControl(DReader);
                    Lista.Add(OProveedorBE);
                }
                DReader.Close();
            }
            catch
            {
                if (DReader != null && !DReader.IsClosed) { DReader.Close(); }
                throw;
            }
            return Lista;
        }
        #endregion

        #region Constructores
        private ProveedorBE CrearEntidadUserControl(IDataReader DReader)
        {
            ProveedorBE OProveedorBE = new ProveedorBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_proveedor");
            if (!DReader.IsDBNull(Indice)) { OProveedorBE.id_proveedor = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_proveedor");
            OProveedorBE.de_proveedor = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OProveedorBE;
        }
        #endregion
    }
}