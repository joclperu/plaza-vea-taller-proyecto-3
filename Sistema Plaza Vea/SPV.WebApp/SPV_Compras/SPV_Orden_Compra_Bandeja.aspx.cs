using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BE;
using SPV.BL.SPV_Compras;
using System.Collections.Generic;
using ASP;
using System.IO;

public partial class SPV_Compras_SPV_Orden_Compra_Bandeja : PaginaBase
{
    #region "Atributos"
    private CabeceraOrdenCompraBE OCabeceraOrdenCompraBE;
    CabeceraOrdenCompraBEList OCabeceraOrdenCompraBEList;
    public Int32 IdCabeceraOrdenCompra;
    private bool _onError;
    #endregion

    #region "Propiedades"
    public bool onError
    {
        get
        {
            return this._onError;
        }
        set
        {
            this.Master.onError = value;
            this._onError = value;
        }
    }
    #endregion

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (ViewState["OCabeceraOrdenCompraBEList"] != null &&
            this.GrwData != null &&
            this.GrwData.Rows.Count > 0 &&
            this.GrwData.PageCount > 1)
        {
            GridViewRow oRow = this.GrwData.BottomPagerRow;
            if (oRow != null)
            {
                Label oTotalReg = new Label();
                oTotalReg.Text = String.Format("Total Reg. {0}", ((CabeceraOrdenCompraBEList)ViewState["OCabeceraOrdenCompraBEList"]).Count);
                oRow.Cells[0].Controls.AddAt(0, oTotalReg);
                Table oTablaPaginacion = (Table)oRow.Cells[0].Controls[1];
                oTablaPaginacion.CellPadding = 0;
                oTablaPaginacion.CellSpacing = 0;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["OrdenLista"] = SortDirection.Descending;
            InicializaPagina();
        }
    }

    #region "Carga de página"
    private void InicializaPagina()
    {
        try
        {
            CabeceraOrdenCompraBEList OCabeceraOrdenCompraBEList = new CabeceraOrdenCompraBEList();
            OCabeceraOrdenCompraBEList.Add(new CabeceraOrdenCompraBE());

            this.GrwData.DataSource = OCabeceraOrdenCompraBEList;
            this.GrwData.DataBind();
            this.GrwData.PageSize = Profile.PageSizeMant;

            cboEstado.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS, 4);
            
            BtnModificar.Style.Add("display", "none");
            ViewState["OCabeceraOrdenCompraBEList"] = OCabeceraOrdenCompraBEList;
            BtnBuscar_Click(null, null);

            VerificaAcceso();
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    private void VerificaAcceso()
    {
        try
        {
            Int32 id_rol;
            Int32.TryParse(Profile.Usuario.id_rol.ToString(), out id_rol);

            BtnNuevoRequerimiento.Visible = false;
            BtnNuevoSolicitud.Visible = false;
            BtnEliminar.Visible = false;

            #region "VERIFICACION DE ACCESO POR ROL"
            if (id_rol == 15)//GERENTE DE COMPRAS
            {
            }
            else if (id_rol == 16)//JEFE DE COMPRAS
            {
            }
            else if (id_rol == 17)//ASISTENTE DE COMPRAS
            {
                BtnNuevoRequerimiento.Visible = true;
                BtnNuevoSolicitud.Visible = true;
                BtnEliminar.Visible = true;
            }
            else if (id_rol == 18)//SOLICITANTE
            {

            }
            #endregion
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region "Metodos Grilla GrwData"
    protected void GrwData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Int32 aux;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataKey dataKey = this.GrwData.DataKeys[e.Row.RowIndex];
                Int32.TryParse(dataKey.Values["id_cabecera_orden_compra"].ToString(), out aux);
                if (aux == 0)
                {
                    e.Row.Visible = false;
                    return;
                }

                e.Row.Style["cursor"] = "pointer";
                e.Row.Attributes["onclick"] = String.Format("javascript: fc_SeleccionaFilaSimple(this); document.getElementById('{0}').value = '{1}'"
                                                , Txhid_cabecera_orden_compra.ClientID, dataKey.Values["id_cabecera_orden_compra"].ToString());
                e.Row.Attributes["ondblclick"] = String.Format("javascript: location.href='SPV_Orden_Compra_Mantenimiento.aspx?IdCabeceraOrdenCompra={0}'", dataKey.Values["id_cabecera_orden_compra"].ToString());
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void GrwData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            OCabeceraOrdenCompraBEList = (CabeceraOrdenCompraBEList)ViewState["OCabeceraOrdenCompraBEList"];
            this.GrwData.DataSource = OCabeceraOrdenCompraBEList;
            this.GrwData.PageIndex = e.NewPageIndex;
            this.GrwData.DataBind();
            Txhid_cabecera_orden_compra.Value = String.Empty;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void GrwData_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            OCabeceraOrdenCompraBEList = (CabeceraOrdenCompraBEList)ViewState["OCabeceraOrdenCompraBEList"];
            SortDirection IndOrden = (SortDirection)ViewState["OrdenLista"];
            Txhid_cabecera_orden_compra.Value = String.Empty;
            if (OCabeceraOrdenCompraBEList != null)
            {
                if (IndOrden == SortDirection.Ascending)
                {
                    OCabeceraOrdenCompraBEList.Ordenar(e.SortExpression, direccionOrden.Descending);
                    ViewState["OrdenLista"] = SortDirection.Descending;
                }
                else
                {
                    OCabeceraOrdenCompraBEList.Ordenar(e.SortExpression, direccionOrden.Ascending);
                    ViewState["OrdenLista"] = SortDirection.Ascending;
                }
            }
            this.GrwData.DataSource = OCabeceraOrdenCompraBEList;
            this.GrwData.DataBind();
            ViewState["OCabeceraOrdenCompraBEList"] = OCabeceraOrdenCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region "Metodos Botones"
    protected void BtnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Int32.TryParse(Txhid_cabecera_orden_compra.Value, out IdCabeceraOrdenCompra);
            if (IdCabeceraOrdenCompra == 0)
            {
                Response.Redirect(String.Format("SPV_Orden_Compra_Mantenimiento.aspx?IdCabeceraOrdenCompra={0}", IdCabeceraOrdenCompra), false);
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnNuevoRequerimiento_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Int32.TryParse(Txhid_cabecera_orden_compra.Value, out IdCabeceraOrdenCompra);
            if (IdCabeceraOrdenCompra == 0)
            {
                Response.Redirect(String.Format("SPV_Requerimiento_Compra_Lista.aspx"), false);
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnNuevoSolicitud_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Int32.TryParse(Txhid_cabecera_orden_compra.Value, out IdCabeceraOrdenCompra);
            if (IdCabeceraOrdenCompra == 0)
            {
                Response.Redirect(String.Format("SPV_SolicitudCompra_Lista.aspx"), false);
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL OCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            OCabeceraOrdenCompraBL.ErrorEvent += new CabeceraOrdenCompraBL.ErrorDelegate(General_ErrorEvent);
            Int32 Indicador = 0;
            String Resultado = String.Empty;
            if (!(Txhid_cabecera_orden_compra.Value.Equals("")))
            {
                OCabeceraOrdenCompraBE = new CabeceraOrdenCompraBE();
                OCabeceraOrdenCompraBE.id_cabecera_orden_compra = Int32.Parse(Txhid_cabecera_orden_compra.Value.ToString());
                OCabeceraOrdenCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;

                Indicador = OCabeceraOrdenCompraBL.Eliminar(OCabeceraOrdenCompraBE);
                if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyNoEliminoRelacionado, ""); }
                if (Indicador > 0) { JavaScriptHelper.Alert(this, Message.keyElimino, ""); }
                else { JavaScriptHelper.Alert(this, Message.keyNoElimino, ""); }
                BtnBuscar_Click(null, null);
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keySeleccioneUno, "");
            }
            Txhid_cabecera_orden_compra.Value = String.Empty;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL OCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            OCabeceraOrdenCompraBL.ErrorEvent += new CabeceraOrdenCompraBL.ErrorDelegate(General_ErrorEvent);
            Txhid_cabecera_orden_compra.Value = String.Empty;

            Int32 id_estado, id_cabecera_orden_compra;
            String fe_inicio, fe_fin;

            Int32.TryParse(cboEstado.SelectedValue.ToString(), out id_estado);
            Int32.TryParse(txtNumSerie.Text.ToString(), out id_cabecera_orden_compra);
            fe_inicio = TxtFecIni.Text;
            fe_fin = TxtFecFin.Text;
            OCabeceraOrdenCompraBEList = OCabeceraOrdenCompraBL.GetAll(id_estado, fe_inicio, fe_fin, id_cabecera_orden_compra);

            if (OCabeceraOrdenCompraBEList == null || OCabeceraOrdenCompraBEList.Count == 0)
            {
                JavaScriptHelper.Alert(this, Message.keyNoRegistros, "");
                OCabeceraOrdenCompraBEList.Add(new CabeceraOrdenCompraBE());
            }
            this.GrwData.DataSource = OCabeceraOrdenCompraBEList;
            this.GrwData.DataBind();
            ViewState["OCabeceraOrdenCompraBEList"] = OCabeceraOrdenCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region "Excepciones"
    public void Transaction_ErrorEvent(object sender, Exception ex)
    {
        this.Master.Transaction_ErrorEvent(sender, ex);
        this.onError = true;
    }

    public void Web_ErrorEvent(object sender, Exception ex)
    {
        this.Master.Web_ErrorEvent(sender, ex);
        this.onError = true;
    }
    #endregion
}