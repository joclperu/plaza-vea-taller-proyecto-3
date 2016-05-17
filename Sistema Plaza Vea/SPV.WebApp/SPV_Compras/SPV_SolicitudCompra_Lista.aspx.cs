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

public partial class SPV_Compras_SPV_SolicitudCompra_Lista : PaginaBase
{
    #region "Atributos"
    private SolicitudCompraBE OSolicitudCompraBE;
    SolicitudCompraBEList OSolicitudCompraBEList;
    public Int32 IdCabeceraRequerimientoCompra;
    private bool _onError;


    CabeceraOrdenCompraBE OCabeceraOrdenCompraBE;
    CabeceraOrdenCompraBEList OCabeceraOrdenCompraBEList;
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
        if (ViewState["OSolicitudCompraBEList"] != null &&
            this.GrwData != null &&
            this.GrwData.Rows.Count > 0 &&
            this.GrwData.PageCount > 1)
        {
            GridViewRow oRow = this.GrwData.BottomPagerRow;
            if (oRow != null)
            {
                Label oTotalReg = new Label();
                oTotalReg.Text = String.Format("Total Reg. {0}", ((SolicitudCompraBEList)ViewState["OSolicitudCompraBEList"]).Count);
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
            SolicitudCompraBEList OSolicitudCompraBEList = new SolicitudCompraBEList();
            OSolicitudCompraBEList.Add(new SolicitudCompraBE());

            this.GrwData.DataSource = OSolicitudCompraBEList;
            this.GrwData.DataBind();
            this.GrwData.PageSize = Profile.PageSizeMant;

            ViewState["OSolicitudCompraBEList"] = OSolicitudCompraBEList;
            BtnBuscar_Click(null, null);
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
            CheckBox chkSel, chkSelCabecera, chkSelEstado, chkSelCabeceraEstado;
            String valorIdvin, valorEstado;
            Int32 aux;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                this.txhNroFilas.Value = "0";
                chkSelCabecera = (CheckBox)e.Row.FindControl("chkSelCabecera");
                chkSelCabecera.Attributes.Add("onclick", "javascript:Fc_SelecDeselecTodos()");
                if (this.txhFlagChekTodos.Value.Equals("1")) { chkSelCabecera.Checked = true; }
                else { chkSelCabecera.Checked = false; }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataKey dataKey = this.GrwData.DataKeys[e.Row.RowIndex];
                Int32.TryParse(dataKey.Values["ncodsolicitud"].ToString(), out aux);
                if (aux == 0)
                {
                    e.Row.Visible = false;
                    return;
                }

                e.Row.Style["cursor"] = "pointer";
                e.Row.Attributes["onclick"] = String.Format("javascript: fc_SeleccionaFilaSimple(this); document.getElementById('{0}').value = '{1}'"
                                                , Txhid_ncodsolicitud.ClientID, dataKey.Values["ncodsolicitud"].ToString());

                if (e.Row.Visible == true)
                {
                    this.txhNroFilas.Value = Convert.ToString(Convert.ToInt32(this.txhNroFilas.Value) + 1);
                    dataKey = this.GrwData.DataKeys[e.Row.RowIndex];
                    valorIdvin = dataKey.Values["ncodsolicitud"].ToString();
                    chkSel = (CheckBox)e.Row.FindControl("chkSel");
                    chkSel.Attributes.Add("onclick", "javascript:Fc_SeleccionaItemAsig('" + valorIdvin + "')");
                    if (this.txhCadenaSel.Value.Contains("|" + valorIdvin + "|").Equals(true) && chkSel.Enabled == true)
                    { chkSel.Checked = true; }
                    else { chkSel.Checked = false; }
                }
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
            OSolicitudCompraBEList = (SolicitudCompraBEList)ViewState["OSolicitudCompraBEList"];
            this.GrwData.DataSource = OSolicitudCompraBEList;
            this.GrwData.PageIndex = e.NewPageIndex;
            this.GrwData.DataBind();
            Txhid_ncodsolicitud.Value = String.Empty;
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
            OSolicitudCompraBEList = (SolicitudCompraBEList)ViewState["OSolicitudCompraBEList"];
            SortDirection IndOrden = (SortDirection)ViewState["OrdenLista"];
            Txhid_ncodsolicitud.Value = String.Empty;
            if (OSolicitudCompraBEList != null)
            {
                if (IndOrden == SortDirection.Ascending)
                {
                    OSolicitudCompraBEList.Ordenar(e.SortExpression, direccionOrden.Descending);
                    ViewState["OrdenLista"] = SortDirection.Descending;
                }
                else
                {
                    OSolicitudCompraBEList.Ordenar(e.SortExpression, direccionOrden.Ascending);
                    ViewState["OrdenLista"] = SortDirection.Ascending;
                }
            }
            this.GrwData.DataSource = OSolicitudCompraBEList;
            this.GrwData.DataBind();
            ViewState["OSolicitudCompraBEList"] = OSolicitudCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region "Metodos Botones"
    protected void BtnProcesar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            oCabeceraOrdenCompraBL.ErrorEvent += new CabeceraOrdenCompraBL.ErrorDelegate(General_ErrorEvent);

            Int32 Indicador = 0;
            String resultado = String.Empty;
            String cad;
            Int32 id_referencia = 0;
            String[] arrCodigos = txhCadenaSel.Value.Trim().Split('|');
            for (int i = 1; i < arrCodigos.Length - 1; i++)
            {
                OCabeceraOrdenCompraBE = new CabeceraOrdenCompraBE();
                OCabeceraOrdenCompraBE.id_tipo = 33;

                cad = arrCodigos[i];
                Int32.TryParse(cad, out id_referencia);
                OCabeceraOrdenCompraBE.id_referencia = id_referencia;
                OCabeceraOrdenCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;

                Indicador = oCabeceraOrdenCompraBL.Insertar(OCabeceraOrdenCompraBE);

                if (Indicador == -3) { JavaScriptHelper.Alert(this, Message.keyErrorGrabarNulo, ""); }
                else if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
                else if (Indicador > 0)
                {
                    JavaScriptHelper.Alert(this, Message.keyGrabar, "");
                    Txhid_ncodsolicitud.Value = Indicador.ToString();
                    BtnBuscar_Click(null, null);
                }
                else { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
            }
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
            SolicitudCompraBL OSolicitudCompraBL = new SolicitudCompraBL();
            OSolicitudCompraBL.ErrorEvent += new SolicitudCompraBL.ErrorDelegate(General_ErrorEvent);
            Txhid_ncodsolicitud.Value = String.Empty;

            OSolicitudCompraBEList = OSolicitudCompraBL.GetAll();

            if (OSolicitudCompraBEList == null || OSolicitudCompraBEList.Count == 0)
            {
                JavaScriptHelper.Alert(this, Message.keyNoRegistros, "");
                OSolicitudCompraBEList.Add(new SolicitudCompraBE());
            }

            this.txhCadenaTotal.Value = "|";

            for (int i = 0; i < OSolicitudCompraBEList.Count; i++)
            {
                if (OSolicitudCompraBEList[i].ncodsolicitud != null)
                {
                    this.txhCadenaTotal.Value = this.txhCadenaTotal.Value + OSolicitudCompraBEList[i].ncodsolicitud.ToString() + "|";
                }
            }

            this.txhCadenaSel.Value = "";

            this.GrwData.DataSource = OSolicitudCompraBEList;
            this.GrwData.DataBind();
            ViewState["OSolicitudCompraBEList"] = OSolicitudCompraBEList;

            this.txhCadenaSel.Value = "";

            CheckBox chkSelCabecera;
            chkSelCabecera = (CheckBox)this.GrwData.HeaderRow.FindControl("chkSelCabecera");
            chkSelCabecera.Checked = false;
            txhFlagChekTodos.Value = "";
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnRegresar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("SPV_Orden_Compra_Bandeja.aspx", false);
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
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