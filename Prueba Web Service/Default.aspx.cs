using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnProcesar_Click(object sender, EventArgs e)
    {
        ServicioCompras.WebService_ComprasSoapClient oServicio = new ServicioCompras.WebService_ComprasSoapClient();
        Int32 id_orden_compra = 0, va_result = 0;
        Int32.TryParse(txtNumero.Text.ToString(),out id_orden_compra);
        va_result = oServicio.CerrarOrdenCompra(id_orden_compra, 1);

        if (va_result > 0) txtMensaje.Text = "SE CAMBIO EL ESTADO CORRECTAMENTE";
        else if (va_result == -10) txtMensaje.Text = "ERROR: LA ORDEN DE COMPRA NO EXISTE";
        else if (va_result == -20) txtMensaje.Text = "ERROR: LA ORDEN DE COMPRA NO ESTA EN EL ESTADO CORRECTO";
    }
}
