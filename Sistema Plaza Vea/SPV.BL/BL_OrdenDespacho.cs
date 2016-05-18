using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_OrdenDespacho
    {
        public DA_OrdenDespacho oDA_OrdenDespacho;
        public EN_OrdenDespacho Consultar(EN_OrdenDespacho oEN_OrdenDespacho)
        {
            oDA_OrdenDespacho = DA_OrdenDespacho.getInstancia();
            return oDA_OrdenDespacho.Consultar(oEN_OrdenDespacho);
        }
    }
}
