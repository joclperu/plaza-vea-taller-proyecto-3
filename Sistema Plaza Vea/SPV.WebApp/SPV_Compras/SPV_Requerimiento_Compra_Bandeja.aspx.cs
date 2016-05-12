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

public partial class SPV_Compras_SPV_Requerimiento_Compra_Bandeja : PaginaBase
{
    #region "Atributos"
    private CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE;
    CabeceraRequerimientoCompraBEList OCabeceraRequerimientoCompraBEList;
    public Int32 IdCabeceraRequerimientoCompra;
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
        if (ViewState["OCabeceraRequerimientoCompraBEList"] != null &&
            this.GrwData != null &&
            this.GrwData.Rows.Count > 0 &&
            this.GrwData.PageCount > 1)
        {
            GridViewRow oRow = this.GrwData.BottomPagerRow;
            if (oRow != null)
            {
                Label oTotalReg = new Label();
                oTotalReg.Text = String.Format("Total Reg. {0}", ((CabeceraRequerimientoCompraBEList)ViewState["OCabeceraRequerimientoCompraBEList"]).Count);
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
            CabeceraRequerimientoCompraBEList OCabeceraRequerimientoCompraBEList = new CabeceraRequerimientoCompraBEList();
            OCabeceraRequerimientoCompraBEList.Add(new CabeceraRequerimientoCompraBE());

            this.GrwData.DataSource = OCabeceraRequerimientoCompraBEList;
            this.GrwData.DataBind();
            this.GrwData.PageSize = Profile.PageSizeMant;

            cboEstado.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS, 4);
            cboArea.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS);
            cboSolicitante.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS, -1);

            BtnModificar.Style.Add("display", "none");
            ViewState["OCabeceraRequerimientoCompraBEList"] = OCabeceraRequerimientoCompraBEList;
            BtnBuscar_Click(null,null);

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

            BtnNuevo.Visible = false;
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
                BtnNuevo.Visible = true;
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
                Int32.TryParse(dataKey.Values["id_cabecera_requerimiento_compra"].ToString(), out aux);
                if (aux == 0)
                {
                    e.Row.Visible = false;
                    return;
                }

                e.Row.Style["cursor"] = "pointer";
                e.Row.Attributes["onclick"] = String.Format("javascript: fc_SeleccionaFilaSimple(this); document.getElementById('{0}').value = '{1}'"
                                                , Txhid_cabecera_requerimiento_compra.ClientID, dataKey.Values["id_cabecera_requerimiento_compra"].ToString());
                e.Row.Attributes["ondblclick"] = String.Format("javascript: location.href='SPV_Requerimiento_Compra_Mantenimiento.aspx?IdCabeceraRequerimientoCompra={0}'", dataKey.Values["id_cabecera_requerimiento_compra"].ToString());
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
            OCabeceraRequerimientoCompraBEList = (CabeceraRequerimientoCompraBEList)ViewState["OCabeceraRequerimientoCompraBEList"];
            this.GrwData.DataSource = OCabeceraRequerimientoCompraBEList;
            this.GrwData.PageIndex = e.NewPageIndex;
            this.GrwData.DataBind();
            Txhid_cabecera_requerimiento_compra.Value = String.Empty;
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
            OCabeceraRequerimientoCompraBEList = (CabeceraRequerimientoCompraBEList)ViewState["OCabeceraRequerimientoCompraBEList"];
            SortDirection IndOrden = (SortDirection)ViewState["OrdenLista"];
            Txhid_cabecera_requerimiento_compra.Value = String.Empty;
            if (OCabeceraRequerimientoCompraBEList != null)
            {
                if (IndOrden == SortDirection.Ascending)
                {
                    OCabeceraRequerimientoCompraBEList.Ordenar(e.SortExpression, direccionOrden.Descending);
                    ViewState["OrdenLista"] = SortDirection.Descending;
                }
                else
                {
                    OCabeceraRequerimientoCompraBEList.Ordenar(e.SortExpression, direccionOrden.Ascending);
                    ViewState["OrdenLista"] = SortDirection.Ascending;
                }
            }
            this.GrwData.DataSource = OCabeceraRequerimientoCompraBEList;
            this.GrwData.DataBind();
            ViewState["OCabeceraRequerimientoCompraBEList"] = OCabeceraRequerimientoCompraBEList;
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
            Int32.TryParse(Txhid_cabecera_requerimiento_compra.Value, out IdCabeceraRequerimientoCompra);
            if (IdCabeceraRequerimientoCompra == 0)
            {
                Response.Redirect(String.Format("SPV_Requerimiento_Compra_Mantenimiento.aspx?IdCabeceraRequerimientoCompra={0}", IdCabeceraRequerimientoCompra), false);
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
            CabeceraRequerimientoCompraBL OCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            OCabeceraRequerimientoCompraBL.ErrorEvent += new CabeceraRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);
            Int32 Indicador = 0;
            String Resultado = String.Empty;
            if (!(Txhid_cabecera_requerimiento_compra.Value.Equals("")))
            {
                OCabeceraRequerimientoCompraBE = new CabeceraRequerimientoCompraBE();
                OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra = Int32.Parse(Txhid_cabecera_requerimiento_compra.Value.ToString());
                OCabeceraRequerimientoCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;

                Indicador = OCabeceraRequerimientoCompraBL.Eliminar(OCabeceraRequerimientoCompraBE);
                if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyNoEliminoRelacionado, ""); }
                if (Indicador > 0) { JavaScriptHelper.Alert(this, Message.keyElimino, ""); }
                else { JavaScriptHelper.Alert(this, Message.keyNoElimino, ""); }
                BtnBuscar_Click(null, null);
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keySeleccioneUno, "");
            }
            Txhid_cabecera_requerimiento_compra.Value = String.Empty;
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
            CabeceraRequerimientoCompraBL OCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            OCabeceraRequerimientoCompraBL.ErrorEvent += new CabeceraRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);
            Txhid_cabecera_requerimiento_compra.Value = String.Empty;

            Int32 id_solicitante, id_estado, id_cabecera_requerimiento_compra;
            String fe_inicio, fe_fin;

            Int32.TryParse(cboSolicitante.SelectedValue.ToString(),out id_solicitante);
            Int32.TryParse(cboEstado.SelectedValue.ToString(), out id_estado);
            Int32.TryParse(txtNumSerie.Text.ToString(),out id_cabecera_requerimiento_compra);
            fe_inicio = TxtFecIni.Text;
            fe_fin = TxtFecFin.Text;
            OCabeceraRequerimientoCompraBEList = OCabeceraRequerimientoCompraBL.GetAll(id_solicitante, id_estado, fe_inicio, fe_fin, id_cabecera_requerimiento_compra);

            if (OCabeceraRequerimientoCompraBEList == null || OCabeceraRequerimientoCompraBEList.Count == 0)
            {
                JavaScriptHelper.Alert(this, Message.keyNoRegistros, "");
                OCabeceraRequerimientoCompraBEList.Add(new CabeceraRequerimientoCompraBE());
            }
            this.GrwData.DataSource = OCabeceraRequerimientoCompraBEList;
            this.GrwData.DataBind();
            ViewState["OCabeceraRequerimientoCompraBEList"] = OCabeceraRequerimientoCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { 
    
    }

    protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 id_area = 0;
        Int32.TryParse(cboArea.SelectedValue.ToString(),out id_area);
        cboSolicitante.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS, id_area);
        cboSolicitante_SelectedIndexChanged(null, null);
    }

    protected void cboSolicitante_SelectedIndexChanged(object sender, EventArgs e)
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