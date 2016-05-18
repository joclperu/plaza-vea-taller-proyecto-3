using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class Pages_Popup_PopupDetalleProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int codProducto = int.Parse(Request.QueryString["param"]);


            EN_Producto oEN_Producto = new EN_Producto();
            oEN_Producto.NCodProducto = codProducto;
            oEN_Producto.NcodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

            EN_Producto result = new EN_Producto();
            result = new BL_Producto().Consultar(oEN_Producto);

            this.txtProducto.Text = result.CDescripcion;
            this.txtCodigo.Text = result.NCodProducto.ToString();
            this.txtProveedor.Text = result.nom_proveedor;
            this.txtStockActual.Text = result.NStock.ToString();
            this.txtfecActStock.Text = result.DFecha.ToShortDateString();

            this.txtProducto.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtProveedor.Enabled = false;
            this.txtStockActual.Enabled = false;
            this.txtfecActStock.Enabled = false;

            this.imgProducto.ImageUrl = string.Format("../../Images/productos/{0}.jpg", result.NCodProducto.ToString());


            oEN_Producto = new EN_Producto();
            oEN_Producto.NCodProducto = codProducto;
            List<EN_Producto> olst = new List<EN_Producto>();
            olst = new BL_Producto().ListarDetalleProducto(oEN_Producto);

            if (olst.Any())
            {
                this.gvProductos.DataSource = olst;
                this.gvProductos.DataBind();
            }
            else
            {
                gvProductos_Vacio();
            }

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

}