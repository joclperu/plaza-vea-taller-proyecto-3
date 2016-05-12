using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Comun
{
    public class MaestroDA
    {
        #region Mantenimiento Maestro
        public MaestroBEList GetAllUserControlMaestro(Int32 id_padre)
        {
            MaestroBEList Lista = new MaestroBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "general.spv_sps_usercontrol_maestro";
                    db.AddParameter("@id_padre", DbType.Int32, ParameterDirection.Input, id_padre);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    MaestroBE OMaestroBE = CrearEntidadUserControl(DReader);
                    Lista.Add(OMaestroBE);
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
        private MaestroBE CrearEntidadUserControl(IDataReader DReader)
        {
            MaestroBE OMaestroBE = new MaestroBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_maestro");
            if (!DReader.IsDBNull(Indice)) { OMaestroBE.id_maestro = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_maestro");
            OMaestroBE.de_maestro = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OMaestroBE;
        }
        #endregion
    }
}