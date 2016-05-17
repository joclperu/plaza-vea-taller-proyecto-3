using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Compras;

namespace SPV.BL.SPV_Compras
{
    public class SolicitudCompraBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        public SolicitudCompraBEList GetAll()
        {
            SolicitudCompraDA OSolicitudCompraDA = new SolicitudCompraDA();
            try
            {
                return OSolicitudCompraDA.GetAll();
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return null;
        }
    }
}