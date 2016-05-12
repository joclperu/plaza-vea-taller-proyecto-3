using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Comun;

namespace SPV.BL.SPV_Comun
{
    public class MaestroBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        #region Mantenimiento de Unidad Medida
        public MaestroBEList GetAllUserControl(Int32 id_padre)
        {
            MaestroDA OMaestroDA = new MaestroDA();
            try
            {
                return OMaestroDA.GetAllUserControlMaestro(id_padre);
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
