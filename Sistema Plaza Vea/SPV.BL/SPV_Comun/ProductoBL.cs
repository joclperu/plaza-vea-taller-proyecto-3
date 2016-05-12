using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Comun;

namespace SPV.BL.SPV_Comun
{
    public class ProductoBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento de Unidad Medida
        public ProductoBEList GetAllProducto(String de_descripcion)
        {
            ProductoDA OProductoDA = new ProductoDA();
            try
            {
                return OProductoDA.GetAllProducto(de_descripcion);
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }
        #endregion
    }
}