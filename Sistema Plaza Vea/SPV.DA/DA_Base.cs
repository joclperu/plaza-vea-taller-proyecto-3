using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPV.DA
{
    public class DA_Base
    {
        #region Metodos Formateo
        //  <summary>
        //  Formateo Dato Decimal
        //  </summary>
        //  <param name="objValor">Dato a Formatear</param>
        //  <returns></returns>
        public object Formateo_Numero(object ObjValor)
        {
            if (((ObjValor != null)
                        && !(ObjValor.Equals(0) || ObjValor.Equals(0.0))))
            {
                return ObjValor;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public object Formateo_Numero_sin_cero(object ObjValor)
        {
            if (((ObjValor != null)
                        && !(ObjValor.Equals(0.0))))
            {
                return ObjValor;
            }
            else
            {
                return DBNull.Value;
            }
        }

        //  <summary>
        //  Formateo Dato Cadena 
        //  </summary>
        //  <param name="objValor">Dato a Formatear</param>
        //  <returns></returns>
        public object Formateo_Texto(string ObjValor)
        {
            if (((ObjValor != null)
                        && (ObjValor != String.Empty)))
            {
                return ObjValor;
            }
            else
            {
                return DBNull.Value;
            }
        }

        //  <summary>
        //  Formateo Dato Fecha
        //  </summary>
        //  <param name="objValor">Dato a Formatear</param>
        //  <returns></returns>
        public object Formateo_Fecha(object ObjValor)
        {
            if (ObjValor != null && Convert.ToString(ObjValor).Substring(0, 10) != "01/01/0001")
            {
                return ObjValor;
            }
            else
            {
                return DBNull.Value;
            }
        }

        #endregion
    }
}
