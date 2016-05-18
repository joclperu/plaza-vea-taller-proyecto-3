using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class BL_NotaIngreso
    {
        public DA_NotaIngreso oDA_NotaIngreso;
        public DA_DetalleNotaIngreso oDA_DetalleNotaIngreso;

        public int Registrar(EN_NotaIngreso objEn, List<EN_DetalleNotaIngreso> olst)
        {
            oDA_NotaIngreso = DA_NotaIngreso.getInstancia();
            int codNotaingreso = 0;
            int result = 0;
            codNotaingreso = oDA_NotaIngreso.Registrar(objEn);
            if (codNotaingreso > 0)
            {
                oDA_DetalleNotaIngreso = DA_DetalleNotaIngreso.getInstancia();
                foreach (EN_DetalleNotaIngreso item in olst)
                {
                    item.NCodNotaIngreso = codNotaingreso;
                    result += oDA_DetalleNotaIngreso.Registrar(item);
                }
            }

            return result;
        }

        public int Eliminar(EN_NotaIngreso objEn)
        {
            oDA_NotaIngreso = DA_NotaIngreso.getInstancia();
            return oDA_NotaIngreso.Eliminar(objEn);
        }
    }
}
