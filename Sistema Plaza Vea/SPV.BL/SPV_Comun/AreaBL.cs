using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Comun;

namespace SPV.BL.SPV_Comun
{
    public class AreaBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento de Area
        public AreaBEList GetAllUserControl()
        {
            AreaDA OAreaDA = new AreaDA();
            try
            {
                return OAreaDA.GetAllUserControlArea();
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