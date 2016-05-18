using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BL;
using SPV.BE;
using SPV.WebEvents;

public partial class Pages_ConsultaProductos : System.Web.UI.Page
{
    util_ValidarDatos util = new util_ValidarDatos();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlTienda.DataSource = new BL_Tienda().Listar();
            this.ddlTienda.DataValueField = "nCodTienda";
            this.ddlTienda.DataTextField = "cDescripcion";
            this.ddlTienda.DataBind();

            gvProductos_Vacio();
        }
    }

    private void gvProductos_Vacio()
    {
        EN_Producto objApli = new EN_Producto();
        List<EN_Producto> lstApli = new List<EN_Producto>();
        objApli.nNomRol = "EMPTY";
        lstApli.Add(objApli);
        this.gvProductos.DataSource = lstApli;
        this.gvProductos.DataBind();
        this.gvProductos.Rows[0].Visible = false;
    }

    protected void BtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int ddlTienda = util.Combo_Requerido(int.Parse(this.ddlTienda.SelectedValue), "tienda");
            string nom_producto = util.Requerido_Texto(this.txtProducto.Text, "producto");
            bool FechaValida = util.Validar_Fecha(this.TxtFecIni.Text, "fecha");

            EN_Producto oEN_Producto = new EN_Producto();
            oEN_Producto.NcodTienda = ddlTienda;
            oEN_Producto.CDescripcion = nom_producto;
            if (FechaValida && this.TxtFecIni.Text.Length > 0)
                oEN_Producto.DFecha = Convert.ToDateTime(this.TxtFecIni.Text);

            ListarProductos(oEN_Producto);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('{0}');", ex.Message.ToString()), true);
        }


    }

    private void ListarProductos(EN_Producto oEN_Producto)
    {
        //buscar
        List<EN_Producto> olst = new List<EN_Producto>();
        olst = new BL_Producto().Listar(oEN_Producto);

        if (olst.Any())
        {
            this.gvProductos.DataSource = olst;
            this.gvProductos.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('{0}');", "No existen registros para la búsqueda ingresada"), true);
            gvProductos_Vacio();
        }
        this.lblRegistros.Text = string.Format("Registros encontrados : {0}", olst.Count().ToString());
    }
    protected void BtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        this.txtProducto.Text = "";
        this.ddlTienda.SelectedValue = "-1";
        this.TxtFecIni.Text = "";
    }
    //protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblidProducto = (Label)e.Row.FindControl("lblidProducto");

    //        ImageButton imgConsultarDetalle = (ImageButton)e.Row.FindControl("imgConsultarDetalle");
    //        imgConsultarDetalle.OnClientClick = string.Format("return fn_PopuDetalle('{0}');", lblidProducto.Text);
    //    }
    //}


    private void gvProductosPop_Vacio()
    {
        EN_Producto objApli = new EN_Producto();
        List<EN_Producto> lstApli = new List<EN_Producto>();
        objApli.nNomRol = "EMPTY";
        lstApli.Add(objApli);
        this.gvProductos.DataSource = lstApli;
        this.gvProductos.DataBind();
        this.gvProductos.Rows[0].Visible = false;
    }

    protected void imgConsultarDetalle_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgConsultarDetalle = ((ImageButton)(sender));
        GridViewRow row = ((GridViewRow)(imgConsultarDetalle.NamingContainer));

        Label lblidProducto = (Label)row.FindControl("lblidProducto");

        int codProducto = int.Parse(lblidProducto.Text);


        EN_Producto oEN_Producto = new EN_Producto();
        oEN_Producto.NCodProducto = codProducto;
        oEN_Producto.NcodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

        EN_Producto result = new EN_Producto();
        result = new BL_Producto().Consultar(oEN_Producto);

        this.txtProductoPop.Text = result.CDescripcion;
        this.txtCodigo.Text = result.NCodProducto.ToString();
        this.txtProveedor.Text = result.nom_proveedor;
        this.txtStockActual.Text = result.NStock.ToString();
        this.txtfecActStock.Text = result.DFecha.ToShortDateString();

        this.txtProductoPop.Enabled = false;
        this.txtCodigo.Enabled = false;
        this.txtProveedor.Enabled = false;
        this.txtStockActual.Enabled = false;
        this.txtfecActStock.Enabled = false;

        this.imgProducto.ImageUrl = string.Format("../Images/productos/{0}.jpg", result.NCodProducto.ToString());


        oEN_Producto = new EN_Producto();
        oEN_Producto.NCodProducto = codProducto;
        List<EN_Producto> olst = new List<EN_Producto>();
        olst = new BL_Producto().ListarDetalleProducto(oEN_Producto);

        if (olst.Any())
        {
            this.gvProductosPop.DataSource = olst;
            this.gvProductosPop.DataBind();
            this.Label2.Text = string.Format("Datos del stock del producto: {0}", olst.Count().ToString());


        }
        else
        {
            gvProductosPop_Vacio();
            this.Label2.Text = string.Format("Datos del stock del producto: {0}", olst.Count().ToString());
        }

        modalNuevo.Show();

    }
}