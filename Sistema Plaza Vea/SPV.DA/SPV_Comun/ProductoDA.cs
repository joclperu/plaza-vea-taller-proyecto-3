using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPV.BE;

namespace SPV.DA.SPV_Comun
{
    public class ProductoDA
    {
        #region Mantenimiento Producto
        public ProductoBEList GetAllProducto(String de_descripcion)
        {
            ProductoBEList Lista = new ProductoBEList();
            IDataReader DReader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "general.spv_sps_bandeja_producto";
                    db.AddParameter("@de_descripcion", DbType.String, ParameterDirection.Input, de_descripcion);
                    DReader = db.GetDataReader();
                }
                while (DReader.Read())
                {
                    ProductoBE OProductoBE = CrearEntidad(DReader);
                    Lista.Add(OProductoBE);
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
        private ProductoBE CrearEntidad(IDataReader DReader)
        {
            ProductoBE OProductoBE = new ProductoBE();
            int Indice;

            Indice = DReader.GetOrdinal("id_producto");
            if (!DReader.IsDBNull(Indice)) { OProductoBE.id_producto = DReader.GetInt32(Indice); }

            Indice = DReader.GetOrdinal("de_descripcion");
            OProductoBE.de_descripcion = DReader.IsDBNull(Indice) ? String.Empty : DReader.GetString(Indice);

            return OProductoBE;
        }
        #endregion
    }
}