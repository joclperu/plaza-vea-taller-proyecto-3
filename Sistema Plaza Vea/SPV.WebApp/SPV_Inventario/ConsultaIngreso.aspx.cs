using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ConsultaIngreso : System.Web.UI.Page
{
 
    Logica.NotaIngreso NotaL = new Logica.NotaIngreso();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        if ((string)(Session["CodUsu"]) == null)
        {
            Response.Redirect("Login.aspx");
        } 
        
        DateTime dt = DateTime.Now;
        txtFecha.Text = String.Format("{0:dd/MM/yyyy}", dt);
        txtJefAlmacen.Text = (string)(Session["Usuario"]);
        txtOrdenCompra.Text = (string)(Session["OrdenCompra"]);
        txtProveedor.Text = (string)(Session["Proveedor"]);

        string NotaIngreso = (string)(Session["NotaIngreso"]);

        DataTable dt1 = new DataTable();
        dt1 = NotaL.ListaNotaIngreso(Convert.ToInt32(NotaIngreso));

        txtGuiaRemision.Text = dt1.Rows[0]["CodGuiaRemision"].ToString();
        txtPlaca.Text = dt1.Rows[0]["Placa"].ToString();
        txtTransportista.Text = dt1.Rows[0]["Transportista"].ToString();
        txtObservacion.Text = dt1.Rows[0]["Observacion"].ToString();

        DataTable dtp = new DataTable();
        dtp = NotaL.ListaDetalleNotaIngreso(Convert.ToInt32(NotaIngreso));

        if (dtp.Rows.Count < 1)
        {
            lblMensaje.Text = "No hay detalle de productos";
            return;
        }

        grdProductos.DataSource = dtp;
        grdProductos.DataBind();

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("IngresoMercaderia.aspx");
    }


}