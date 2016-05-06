using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class IngresoMercaderia : System.Web.UI.Page
{
    Logica.IngresoMercaderia MercaL = new Logica.IngresoMercaderia();
    Logica.NotaIngreso NotaL = new Logica.NotaIngreso();
    Logica.IngresoMercaderia MercaderiaL = new Logica.IngresoMercaderia();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)(Session["CodUsu"]) == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (string.IsNullOrEmpty((string)Session["OrdenCompra"])){
            txtOrdenCompra.Focus(); 
        }
        else{
            txtOrdenCompra.Text = (string)(Session["OrdenCompra"]);
            Cargar();
        }
        
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if ((string)(Session["CodUsu"]) == null)
        {
            Response.Redirect("Login.aspx");
        }
        
        if (txtOrdenCompra.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese Orden de Compra";
            txtOrdenCompra.Focus();
            return;
        }

        Cargar();
     }

    private void Cargar() {

        
        DataTable dt = new DataTable();
        dt = MercaderiaL.OrdenCompraUsuario(txtOrdenCompra.Text, (string)(Session["CodUsu"]));

        if (dt.Rows.Count < 1)
        {
            lblMensaje.Text = "Resultado no encontrado";
            Limpiar();
            return;
        }

        txtCodOC.Text = dt.Rows[0]["CodigoOC"].ToString();
        txtNroOC.Text = dt.Rows[0]["NroOrdenCompra"].ToString();
        txtFecOC.Text = dt.Rows[0]["Fecha"].ToString();
        txtEstado.Text = dt.Rows[0]["Estado"].ToString();
        txtMonto.Text = dt.Rows[0]["MontoTotal"].ToString();
        txtTienda.Text = dt.Rows[0]["Tienda"].ToString();
        txtProveedor.Text = dt.Rows[0]["Proveedor"].ToString();
        txtEmailProv.Text = dt.Rows[0]["Email"].ToString();
        txtNroDoc.Text = dt.Rows[0]["NumeroIdentidad"].ToString();
        Session["OrdenCompra"] = txtOrdenCompra.Text;
        Session["CodigoOC"] = txtCodOC.Text;
        Session["Proveedor"] = txtProveedor.Text;
        Session["CodTienda"] = dt.Rows[0]["CodTienda"].ToString();

        if (txtEstado.Text == "Pendiente")
        {
            btnNuevo.Visible = true;
        }

        DataTable dtp = new DataTable();
        dtp = MercaL.OrdenCompraProductos(txtCodOC.Text);

        if (dtp.Rows.Count < 1)
        {
            lblMensaje.Text = "No hay detalle de productos";
            return;
        }

        grdProductos.DataSource = dtp;
        grdProductos.DataBind();

        
        DataTable dtp2 = new DataTable();
        dtp2 = NotaL.ListaNotaIngresoCodigoOC(Convert.ToInt32(txtCodOC.Text));

        grdMercaderia.DataSource = dtp2;
        grdMercaderia.DataBind();


        lblMensaje.Text = "";


    }

    private void Limpiar() {

        txtCodOC.Text = "";
        txtNroOC.Text = "";
        txtFecOC.Text = "";
        txtEstado.Text = "";
        txtMonto.Text = "";
        txtTienda.Text = "";
        txtProveedor.Text = "";
        txtEmailProv.Text = "";
        txtNroDoc.Text = "";
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("NuevoIngreso.aspx");
    }


    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["OrdenCompra"] = "";
        Response.Redirect("Menu.aspx");
    }

    protected void grdMercaderia_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdMercaderia.SelectedRow;
        Session["NotaIngreso"] = Server.HtmlDecode(row.Cells[1].Text);
        Response.Redirect("ConsultaIngreso.aspx");
    }


}