using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Logica
{
    public class GuiaRemision
    {

        public void RegistraGuiaRemision(string GuiaRemision, int CodOC, string Fecha, string Transportista, string Placa, string Observacion)
        {
            Datos.GuiaRemision Guia = new Datos.GuiaRemision();
            Guia.RegistraGuiaRemision( GuiaRemision,  CodOC,  Fecha,  Transportista,  Placa , Observacion);
        }

    }
}
