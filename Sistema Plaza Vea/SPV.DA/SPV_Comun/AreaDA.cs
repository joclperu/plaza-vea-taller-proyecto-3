using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Comun
{
    public class AreaDA
    {
        #region Mantenimiento Area
        public AreaBEList GetAllUserControlArea()
        {
            AreaBEList Lista = new AreaBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "general.spv_sps_usercontrol_area";
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    AreaBE OAreaBE = CrearEntidadUserControl(DReader);
                    Lista.Add(OAreaBE);
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
        private AreaBE CrearEntidadUserControl(IDataReader DReader)
        {
            AreaBE OAreaBE = new AreaBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_area");
            if (!DReader.IsDBNull(Indice)) { OAreaBE.id_area = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_area");
            OAreaBE.de_area = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OAreaBE;
        }
        #endregion
    }
}