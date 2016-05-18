using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SPV_Proveedores_SPV_ListarConvocatorias : System.Web.UI.Page
{
    SPV.BL.SPV_Proveedores.Proveedor blProveedor = new SPV.BL.SPV_Proveedores.Proveedor();
    UtilitarioWeb objUtil = new UtilitarioWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objUtil.cargarComboYSeleccione(ddlCategoria, blProveedor.ListarCategoriaProducto(), "nombre", "codigo", "Todos..");
            cargarConvocatorias();
        }


    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        cargarConvocatorias();
    }
    private void cargarConvocatorias()
    {
        DataTable dtConvocatorias = new DataTable();
        dtConvocatorias=blProveedor.ListarConvocatoriaParametro(Convert.ToInt32(ddlTipoConvocatoria.SelectedValue.ToString()),txtFechaInicio.Text.Trim(),txtFechaFin.Text.Trim(),Convert.ToInt32(ddlCategoria.SelectedValue.ToString()));
        gdvConvocatorias.DataSource=dtConvocatorias;
        gdvConvocatorias.DataBind();


    }


    protected void gdvConvocatorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = gdvConvocatorias.SelectedIndex;

        //string strIdIndicador = gdvConvocatorias.DataKeys[index].Values[0].ToString();
        //string strEstado = gdvConvocatorias.DataKeys[index].Values[1].ToString();
        //string stridProceso = gdvConvocatorias.DataKeys[index].Values[2].ToString();

        GridViewRow row = gdvConvocatorias.Rows[index];
        txtConvocatoria.Text = Server.HtmlDecode(row.Cells[0].Text);
        txtFecha.Text = Server.HtmlDecode(row.Cells[2].Text) + " - " + Server.HtmlDecode(row.Cells[3].Text);
        txtDescripcion.Text = Server.HtmlDecode(row.Cells[1].Text);
        txtCategoriaProducto.Text = Server.HtmlDecode(row.Cells[4].Text);

        txtCandidato.Text = Session["ncodcandidato"].ToString();
        txtRazonSocial.Text=Session["razonsocial"].ToString();
        txtRuc.Text=Session["ruc"].ToString();

        txtMonto.Text = "";
        lblmsjeModal.Text = "";

        //TextBox2.Text = Server.HtmlDecode(row.Cells[1].Text);
        //ddlProcesos.SelectedItem.Text = Server.HtmlDecode(row.Cells[0].Text);
       /* ddlProcesos.SelectedValue = stridProceso;
        TextBox4.Text = Server.HtmlDecode(row.Cells[2].Text);
        TextBox5.Text = Server.HtmlDecode(row.Cells[3].Text);
        TextBox6.Text = Server.HtmlDecode(row.Cells[4].Text);*/


        mpeRegistrarPropuesta.Show();


    }
    protected void btnGrabar0_Click(object sender, EventArgs e)
    {
       DataTable dtResultado = new DataTable();
       dtResultado = blProveedor.ValidarRegistroPropuesta(Convert.ToInt32(txtConvocatoria.Text.Trim()), Convert.ToInt32(txtCandidato.Text.Trim()));

       if (dtResultado.Rows[0]["CANT"].ToString() == "0")
       {
       blProveedor.RegistrarPropuesta(Convert.ToInt32(txtConvocatoria.Text.Trim()),Convert.ToInt32(txtCandidato.Text.Trim()),Convert.ToInt32(txtMonto.Text.Trim()));
       lblmsjeModal.Text = "Propuesta registrada satisfactoriamente";
       mpeRegistrarPropuesta.Show();
       }
       else
       {
           lblmsjeModal.Text = "No se puede registar la propuesta,ya esta inscrito en esta convocatoria.";
           mpeRegistrarPropuesta.Show();

       }
    }
}