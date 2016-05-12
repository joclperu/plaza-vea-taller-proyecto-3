using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SPV.BL.SPV_Compras;

/// <summary>
/// Descripción breve de WebService_Compras
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService_Compras : System.Web.Services.WebService {

    public WebService_Compras () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Int32 CerrarOrdenCompra(Int32 id_cabecera_orden_compra, Int32 id_usuario_cambio)
    {
        /*
         MENSAJES DE ERROR:
         * -10: NO EXISTE LA ORDEN DE COMPRA
         * -20: ESTADO NO CORRECTO
         * -30: FECHA INCORRRECTA
         */
        Int32 va_retorno = 0;
        CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
        va_retorno = oCabeceraOrdenCompraBL.CerrarOrdenCompra(id_cabecera_orden_compra, id_usuario_cambio);
        return va_retorno;
    }  
}