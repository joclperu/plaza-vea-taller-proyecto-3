using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Compras
{
    public class SolicitudCompraDA
    {
        public SolicitudCompraBEList GetAll()
        {
            SolicitudCompraBEList Lista = new SolicitudCompraBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "compras.spv_sps_bandeja_solicitudcompra";
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    SolicitudCompraBE OSolicitudCompraBE = CrearEntidad(DReader);
                    Lista.Add(OSolicitudCompraBE);
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

        private SolicitudCompraBE CrearEntidad(IDataReader DReader)
        {
            SolicitudCompraBE OSolicitudCompraBE = new SolicitudCompraBE();
            int Indice;

            Indice = DReader.GetOrdinal("ncodsolicitud");
            if (!DReader.IsDBNull(Indice)) { OSolicitudCompraBE.ncodsolicitud = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("defecha");
            OSolicitudCompraBE.defecha = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OSolicitudCompraBE;
        }
    }
}