using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Comun;
namespace SPV.BL.SPV_Comun
{
    public class ProveedorBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento de Proveedor
        public ProveedorBEList GetAllUserControl()
        {
            ProveedorDA OProveedorDA = new ProveedorDA();
            try
            {
                return OProveedorDA.GetAllUserControlProveedor();
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