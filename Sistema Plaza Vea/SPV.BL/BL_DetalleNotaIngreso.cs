using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;
namespace SPV.BL
{
    public class BL_DetalleNotaIngreso
    {
        public DA_DetalleNotaIngreso oDA_DetalleNotaIngreso;
        public List<EN_DetalleNotaIngreso> Listar(int ncodNotaIngreso)
        {
            oDA_DetalleNotaIngreso = DA_DetalleNotaIngreso.getInstancia();
            return oDA_DetalleNotaIngreso.Listar(ncodNotaIngreso);
        }
    }
}
