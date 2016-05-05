using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class SPV_Proveedores_SPV_EvaluarPoliticaCandidato : System.Web.UI.Page
{
    UtilitarioWeb objUtilitario = null;
    SPV.BL.SPV_Proveedores.Proveedor blProveedor = new SPV.BL.SPV_Proveedores.Proveedor();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        if (!IsPostBack)
        {
            objUtilitario = new UtilitarioWeb();
            objUtilitario.cargarComboYSeleccione(ddlConvocatoria, blProveedor.ListarConvocatoria(), "nombre", "codigo", "Todos..");
            listarCandidatos();
        }


    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        listarCandidatos();
    }

    private void listarCandidatos()

    {
      
        DataTable dtListaCandidatos = new DataTable();
        dtListaCandidatos = blProveedor.ListarCandidatoPropuesta(Convert.ToInt32(ddlConvocatoria.SelectedValue), TextBox1.Text.Trim(), TextBox2.Text.Trim());
        gdvCandidatos.DataSource = dtListaCandidatos;
        gdvCandidatos.DataBind();



    }


    protected void gdvCandidatos_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int index = Convert.ToInt32(e.CommandArgument);
        int index;
        index = gdvCandidatos.SelectedIndex;

        GridViewRow row = gdvCandidatos.Rows[index];
        //int index = Convert.ToInt32(e.CommandArgument);
        hdCodPropuesta.Value = gdvCandidatos.DataKeys[index].Values[0].ToString();
        string strCodigoConvocatoria = gdvCandidatos.DataKeys[index].Values[1].ToString();



        lblCodigoConvocatoria.Text = strCodigoConvocatoria;
        lblDescripcion.Text = Server.HtmlDecode(row.Cells[1].Text);
        lblRazonSocial.Text = Server.HtmlDecode(row.Cells[3].Text);
        lblRuc.Text = Server.HtmlDecode(row.Cells[4].Text);
        lnkDescargar.Text = "Descargar Politica de Convocatoria";
        


    }
}