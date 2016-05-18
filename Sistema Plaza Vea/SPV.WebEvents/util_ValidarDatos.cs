using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.WebEvents
{
    public class util_ValidarDatos
    {
        public string Requerido_Texto(string ObjValor, string atributo)
        {
            if (((ObjValor != null) && (ObjValor != String.Empty)))
            {
                return ObjValor;
            }
            else
            {
                throw new Exception(string.Format("El código del {0} no debe ser vacio", atributo));
            }
        }


        public int Combo_Requerido(int ObjValor, string atributo)
        {
            if (((ObjValor != null) && !(ObjValor.Equals(-1))))
            {
                return ObjValor;
            }
            else
            {
                throw new Exception(string.Format("Seleccione una {0}", atributo));
            }
        }

        public DateTime Requerido_Fecha(String ObjValor, string atributo)
        {
            try
            {
                if (ObjValor != null && Convert.ToString(ObjValor).Substring(0, 10) != "01/01/0001")
                {
                    return Convert.ToDateTime(ObjValor);
                }
                else
                {
                    throw new Exception(string.Format("Debe ingresar una {0}", atributo));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Debe ingresar una fecha");
            }
        }


        public bool Validar_Fecha(String ObjValor, string atributo)
        {
            try
            {
                DateTime valid;
                if (string.IsNullOrEmpty(ObjValor))
                {
                    return true;
                }
                else 
                {
                    valid = Convert.ToDateTime(ObjValor);
                    return true;
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception("Debe ingresar una fecha valida");
            }
        }



    }
}
