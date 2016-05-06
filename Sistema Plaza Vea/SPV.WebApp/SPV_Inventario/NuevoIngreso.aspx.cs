using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class NuevoIngreso : System.Web.UI.Page
{
    Logica.IngresoMercaderia MercaL = new Logica.IngresoMercaderia();
    Logica.GuiaRemision GuiaL = new Logica.GuiaRemision();
    Logica.NotaIngreso NotaL = new Logica.NotaIngreso();
    Logica.Kardex KardexL = new Logica.Kardex();
    Logica.Tienda TiendaL = new Logica.Tienda();
    Logica.OrdenCompra OrdenL = new Logica.OrdenCompra();

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

        
        DataTable dtp = new DataTable();
        dtp = MercaL.OrdenCompraProductosPendientes((string)Session["CodigoOC"]);

        if (dtp.Rows.Count < 1)
        {
            lblMensaje.Text = "No hay detalle de productos";
            return;
        }

        grdProductos.DataSource = dtp;
        grdProductos.DataBind();

        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      


        bool response;
        bool responseQuantity;

        if (response = validateinputs()) {
            return response;      
        }
        
        response = validateQuantity();

        if (!response) {
            return responseQuantity;        
        }
        
        

        int CodTienda = Convert.ToInt32((string)Session["CodTienda"] );
        int CodigoOC = Convert.ToInt32((string)Session["CodigoOC"] );

        GuiaL.RegistraGuiaRemision(txtGuiaRemision.Text, CodigoOC, txtFecha.Text, txtTransportista.Text, txtPlaca.Text, txtObservacion.Text);

        int codigo = NotaL.ObtenerCorrelativoNotaIngreso();
        
        NotaL.RegistraNotaIngreso(codigo, txtGuiaRemision.Text, txtFecha.Text);

        foreach (GridViewRow row in grdProductos.Rows)
        {
            int producto = Convert.ToInt32(row.Cells[0].Text);
            int ingreso = Convert.ToInt32(((TextBox)row.Cells[6].FindControl("txtIngreso")).Text);

            NotaL.RegistraDetalleNotaIngreso(codigo, producto, ingreso);
            KardexL.RegistraKardex(codigo, producto, CodTienda, ingreso, txtFecha.Text);
            OrdenL.ActualizaDetalleOrdenCompra(CodigoOC, producto, ingreso);
            TiendaL.ActualizaStockTiendaProducto(txtFecha.Text, CodTienda, producto, ingreso);
            
        }

        OrdenL.ActualizaEstadoOrdenCompra(CodigoOC);

        lblMensajeConfirm1.Text = "Operación realizada con éxito ";
        mpeMensajeConfirm1.Show();

    }


    protected void validateInputs()
    {

        if (txtGuiaRemision.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese Guia de Remisión";
            txtGuiaRemision.Focus();
            return;
        }


        if (txtPlaca.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese Placa";
            txtPlaca.Focus();
            return;
        }


        if (txtTransportista.Text.Trim() == "")
        {
            lblMensaje.Text = "Ingrese Transportista";
            txtTransportista.Focus();
            return;
        }

    }

    protected void validateQuantity()
    {
        foreach (GridViewRow row in grdProductos.Rows)
        {
            int Pendiente = Convert.ToInt32(row.Cells[5].Text);
            string ingreso = ((TextBox)row.Cells[6].FindControl("txtIngreso")).Text;

            int number1 = 0;
            bool canConvert = int.TryParse(ingreso, out number1);
            if (canConvert == false)
            {
                lblMensaje.Text = "La cantidad debe ser un número";
                return;
            }

            if (Convert.ToInt32(ingreso) <= -1)
            {
                lblMensaje.Text = "La cantidad debe ser mayor o igual a cero";
                return;
            }

            if (Convert.ToInt32(ingreso) > Pendiente)
            {
                lblMensaje.Text = "La cantidad es mayor a lo pendiente";
                return;
            }

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("IngresoMercaderia.aspx");
    }


    protected void btCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("IngresoMercaderia.aspx");
    }
}