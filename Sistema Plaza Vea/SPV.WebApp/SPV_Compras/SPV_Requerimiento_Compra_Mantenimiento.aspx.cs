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
using SPV.BL.SPV_Comun;
using System.Collections.Generic;
using ASP;

public partial class SPV_Compras_SPV_Requerimiento_Compra_Mantenimiento : PaginaBase
{
    #region Atributos y Propiedades
    private CabeceraRequerimientoCompraBE OCabeceraRequerimientoCompraBE;
    private DetalleRequerimientoCompraBE ODetalleRequerimientoCompraBE;
    private DetalleRequerimientoCompraBEList ODetalleRequerimientoCompraBEList;

    public String TipoAccion = String.Empty;
    public Int32 IdCabecera_requerimiento_compra;
    public Int32 idDetalle_requerimiento_compra;
    public Int32 IdTab;
    public Int32 IndiceTabOn;
    private bool _onError;

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
        if (ViewState["ODetalleRequerimientoCompraBEList"] != null &&
            this.GrwData != null &&
            this.GrwData.Rows.Count > 0 &&
            this.GrwData.PageCount > 1)
        {
            GridViewRow oRow = this.GrwData.BottomPagerRow;
            if (oRow != null)
            {
                Label oTotalReg = new Label();
                oTotalReg.Text = String.Format("Total Reg. {0}", ((DetalleRequerimientoCompraBEList)ViewState["ODetalleRequerimientoCompraBEList"]).Count);
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
            Int32.TryParse(Request.QueryString["IdCabeceraRequerimientoCompra"], out IdCabecera_requerimiento_compra);
            TxhIdCabecera_requerimiento_compra.Value = IdCabecera_requerimiento_compra.ToString();
            InicializaPagina();
            VerificaAcceso();
            if (IdCabecera_requerimiento_compra > 0) { InicializaData(); }
        }

        if (ViewState["IndiceTabOn"] != null)
        {
            this.TabRequerimientoCompra.ActiveTabIndex = (Int32)ViewState["IndiceTabOn"];
            this.IndiceTabOn = (Int32)ViewState["IndiceTabOn"];
            IdTab = (Int32)ViewState["IndiceTabOn"];
        }
        Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value.ToString(), out IdCabecera_requerimiento_compra);
        if (IdCabecera_requerimiento_compra > 0) { TipoAccion = ConstanteBE.TIPO_MODIFICAR; }
        else { TipoAccion = ConstanteBE.TIPO_AGREGAR; }
    }
    
    #region "Carga de página"
    private void InicializaPagina()
    {
        try
        {
            cboEstado.CargarCombo(ConstanteBE.OBJECTO_TIPO_SELECCIONE, 4);
            cboEstado.EnabledValidacion = false;
            cboArea.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS);
            cboSolicitante.CargarCombo(ConstanteBE.OBJECTO_TIPO_TODOS, -1);

            BtnModificar.Style.Add("display", "none");
            TabDetalleRequerimientoCompra.Enabled = false;
            TabRequerimientoCompra_ActiveTabChanged(null, null);
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    private void InicializaData()
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            oCabeceraRequerimientoCompraBL.ErrorEvent += new CabeceraRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);

            OCabeceraRequerimientoCompraBE = oCabeceraRequerimientoCompraBL.GetById(IdCabecera_requerimiento_compra);

            cboArea.SelectedValue = OCabeceraRequerimientoCompraBE.id_area.ToString();
            cboArea_SelectedIndexChanged(null,null);
            cboSolicitante.SelectedValue = OCabeceraRequerimientoCompraBE.id_solicitante.ToString();
            cboEstado.SelectedValue = OCabeceraRequerimientoCompraBE.id_estado.ToString();
            TxtInsertObservación.Text = OCabeceraRequerimientoCompraBE.de_observacion.ToString();
            TxhIdEstado.Value = OCabeceraRequerimientoCompraBE.id_estado.ToString();
            txtNumSerie.Text = OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra.ToString();
            TabDetalleRequerimientoCompra.Enabled = true;

            VerificaAcceso();
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    private void InicializaDetalle()
    {
        try
        {
            //Combo Producto
            ProductoBL OProductoBL = new ProductoBL();
            this.CboProducto.DataSource = (Object)OProductoBL.GetAllProducto(String.Empty);
            this.CboProducto.DataTextField = "de_descripcion";
            this.CboProducto.DataValueField = "id_producto";
            this.CboProducto.WidthText = 120;
            this.CboProducto.Width = 300;            
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
            IndiceTabOn = this.TabRequerimientoCompra.ActiveTabIndex;
            Int32 id_rol, id_estado;
            Int32.TryParse(Profile.Usuario.id_rol.ToString(), out id_rol);
            Int32.TryParse(TxhIdEstado.Value.ToString(), out id_estado);

            BtnEsperaJustificacion.Visible = false;
            BtnEsperaCotizacion.Visible = false;
            BtnCotizado.Visible = false;
            BtnEsperaSolicitante.Visible = false;
            BtnPendienteAprobacion.Visible = false;
            BtnAprobar.Visible = false;
            BtnDesaprobar.Visible = false;

            BtnGrabarCab.Visible = false;
            BtnAgregarDetalle.Visible = false;
            BtnEliminarDet.Visible = false;
            BtnGrabar.Visible = false;
            
            #region "VERIFICACION DE ACCESO POR ROL"
            if (id_rol == 15)//GERENTE DE COMPRAS
            {
                BtnEsperaJustificacion.Visible = VerificaAccesoEstado(BtnEsperaJustificacion, id_estado, IndiceTabOn);
                BtnEsperaCotizacion.Visible = VerificaAccesoEstado(BtnEsperaCotizacion, id_estado, IndiceTabOn);
                BtnCotizado.Visible = VerificaAccesoEstado(BtnCotizado, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);

                BtnGrabarCab.Visible = VerificaAccesoEstado(BtnGrabarCab, id_estado, IndiceTabOn);
                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);
            }
            else if (id_rol == 16)//JEFE DE COMPRAS
            {
                BtnEsperaJustificacion.Visible = VerificaAccesoEstado(BtnEsperaJustificacion, id_estado, IndiceTabOn);
                BtnEsperaCotizacion.Visible = VerificaAccesoEstado(BtnEsperaCotizacion, id_estado, IndiceTabOn);
                BtnCotizado.Visible = VerificaAccesoEstado(BtnCotizado, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);

                BtnGrabarCab.Visible = VerificaAccesoEstado(BtnGrabarCab, id_estado, IndiceTabOn);
                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);
            }
            else if (id_rol == 17)//ASISTENTE DE COMPRAS
            {
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnGrabarCab.Visible = VerificaAccesoEstado(BtnGrabarCab, id_estado, IndiceTabOn);
                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);

                BtnEsperaJustificacion.Visible = VerificaAccesoEstado(BtnEsperaJustificacion, id_estado, IndiceTabOn);
                BtnEsperaCotizacion.Visible = VerificaAccesoEstado(BtnEsperaCotizacion, id_estado, IndiceTabOn);
                BtnCotizado.Visible = VerificaAccesoEstado(BtnCotizado, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);
                BtnGrabarCab.Visible = VerificaAccesoEstado(BtnGrabarCab, id_estado, IndiceTabOn);
                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);
                BtnGrabar.Visible = VerificaAccesoEstado(BtnGrabar, id_estado, IndiceTabOn);
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

    private Boolean VerificaAccesoEstado(ImageButton btn, Int32 id_estado, Int32 IndiceTabOn)
    {        
        #region "VERIFICACION DE ACCESO POR ESTADO"
        if (id_estado == 5) //EN PROCESO
        {
            if (this.IndiceTabOn == 0)
            {
                if (btn.ID.Equals("BtnEsperaJustificacion")) return true;
                else if (btn.ID.Equals("BtnEsperaCotizacion")) return true;
                else if (btn.ID.Equals("BtnDesaprobar")) return true;
                else if (btn.ID.Equals("BtnGrabarCab")) return true;
                else return false;
            }
            else if (this.IndiceTabOn == 1)
            { 
                if (btn.ID.Equals("BtnAgregarDetalle")) return true;
                else if (btn.ID.Equals("BtnEliminarDet")) return true;
                else if (btn.ID.Equals("BtnGrabar")) return true;
                else return false;
            }
        }
        else if (id_estado == 6) //ESPERA JUSTIFICACION
        {
            if (btn.ID.Equals("BtnEsperaCotizacion")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 7) //ANULADO
        {
        }
        else if (id_estado == 8) //ESPERA COTIZACION
        {
            if (btn.ID.Equals("BtnCotizado")) return true;
            else if (btn.ID.Equals("BtnEsperaSolicitante")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 9) //COTIZADO
        {
            if (btn.ID.Equals("BtnEsperaSolicitante")) return true;
            else if (btn.ID.Equals("BtnPendienteAprobacion")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 10) //ESPERA SOLICITANTE
        {
            if (btn.ID.Equals("BtnPendienteAprobacion")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 11) //PENDIENTE APROBACION
        {
            if (btn.ID.Equals("BtnAprobar")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 12) //RECHAZADO
        {
            return false;
        }
        else if (id_estado == 13) //APROBADO
        {
            return false;
        }
        else if (id_estado == 0) //NUEVO REGISTRO
        {
            if (this.IndiceTabOn == 0)
            {
                if (btn.ID.Equals("BtnGrabarCab")) return true;                
                return false;
            }
            else if (this.IndiceTabOn == 1)
            {
                if (btn.ID.Equals("BtnAgregarDetalle")) return true;
                else if (btn.ID.Equals("BtnEliminarDet")) return true;
                else if (btn.ID.Equals("BtnGrabar")) return true;
                return false;
            }
        }
        #endregion
        return false;
    }

    private void BuscarDetalle() {
        try
        {
            DetalleRequerimientoCompraBL ODetalleRequerimientoCompraBL = new DetalleRequerimientoCompraBL();
            ODetalleRequerimientoCompraBL.ErrorEvent += new DetalleRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);
            TxhId_detalle_requerimiento_compra.Value = String.Empty;

            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            ODetalleRequerimientoCompraBEList = ODetalleRequerimientoCompraBL.GetAll(IdCabecera_requerimiento_compra);

            if (ODetalleRequerimientoCompraBEList == null || ODetalleRequerimientoCompraBEList.Count == 0)
            {
                ODetalleRequerimientoCompraBEList.Add(new DetalleRequerimientoCompraBE());
            }
            this.GrwData.DataSource = ODetalleRequerimientoCompraBEList;
            this.GrwData.DataBind();
            ViewState["ODetalleRequerimientoCompraBEList"] = ODetalleRequerimientoCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region "Evento Tab"
    protected void TabRequerimientoCompra_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            IndiceTabOn = this.TabRequerimientoCompra.ActiveTabIndex;
            //RequerimientoCompra RequerimientoCompra
            BtnGrabarCab.Visible = false;
            BtnRegresar.Visible = false;
                        
            //Detalle RequerimientoCompra
            BtnAgregarDetalle.Visible = false;
            BtnEliminarDet.Visible = false;
            BtnAgregar.Visible = false;
            BtnRegresarDet.Visible = false;

            if (this.IndiceTabOn == 0)
            {
                BtnGrabarCab.Visible = true;
                BtnRegresar.Visible = true;
                Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value.ToString(), out IdCabecera_requerimiento_compra);
                if (IdCabecera_requerimiento_compra > 0)
                {
                    InicializaData();
                }                
                IdTab = 0;
            }
            else if (this.IndiceTabOn == 1)
            {
                BtnAgregar.Visible = true;
                BtnRegresarDet.Visible = true;
                BtnAgregarDetalle.Visible = true;
                BtnEliminarDet.Visible = true;
                InicializaDetalle();
                BuscarDetalle();
                IdTab = 1;
            }
            VerificaAcceso();
            ViewState["IndiceTabOn"] = IndiceTabOn;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region Métodos y Botones --RequerimientoCompra RequerimientoCompra
    protected void BtnGrabarCab_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            oCabeceraRequerimientoCompraBL.ErrorEvent += new CabeceraRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);

            Int32 Indicador = 0;
            String resultado = String.Empty;
            CargarEntidadCompraDesdeForm();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);
            if (IdCabecera_requerimiento_compra > 0)
            {
                //Indicador = oCabeceraRequerimientoCompraBL.Modificar(OCabeceraRequerimientoCompraBE);

                if (Indicador == -3) { JavaScriptHelper.Alert(this, Message.keyErrorGrabarNulo, ""); }
                else if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
                else if (Indicador > 0)
                {
                    JavaScriptHelper.Alert(this, Message.keyActualizar, "");
                    TxhIdCabecera_requerimiento_compra.Value = Indicador.ToString();
                    IdCabecera_requerimiento_compra = Indicador;
                    InicializaData();
                }
                else { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
            }
            else
            {
                Indicador = oCabeceraRequerimientoCompraBL.Insertar(OCabeceraRequerimientoCompraBE);

                if (Indicador == -3) { JavaScriptHelper.Alert(this, Message.keyErrorGrabarNulo, ""); }
                else if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
                else if (Indicador > 0)
                {
                    JavaScriptHelper.Alert(this, Message.keyGrabar, "");
                    TxhIdCabecera_requerimiento_compra.Value = Indicador.ToString();
                    IdCabecera_requerimiento_compra = Indicador;
                    InicializaData();
                    TabRequerimientoCompra.ActiveTabIndex = 1;
                    TabRequerimientoCompra_ActiveTabChanged(null, null);
                    BuscarDetalle();
                }
                else { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnRegresar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("SPV_Requerimiento_Compra_Bandeja.aspx", false);
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    private void CargarEntidadCompraDesdeForm()
    {
        try
        {
            OCabeceraRequerimientoCompraBE = new CabeceraRequerimientoCompraBE();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);
            Int32 id_solicitante;

            Int32.TryParse(cboSolicitante.SelectedValue.ToString(), out id_solicitante);

            OCabeceraRequerimientoCompraBE.id_cabecera_requerimiento_compra = IdCabecera_requerimiento_compra;
            OCabeceraRequerimientoCompraBE.id_solicitante = id_solicitante;
            OCabeceraRequerimientoCompraBE.id_usuario_creacion = Profile.Usuario.id_usuario;
            OCabeceraRequerimientoCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;
            OCabeceraRequerimientoCompraBE.de_observacion = TxtInsertObservación.Text;
            TxhIdCabecera_requerimiento_compra.Value = String.Empty;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 id_area = 0;
        Int32.TryParse(cboArea.SelectedValue.ToString(), out id_area);
        cboSolicitante.CargarCombo(ConstanteBE.OBJECTO_TIPO_SELECCIONE, id_area);
        cboSolicitante_SelectedIndexChanged(null, null);
    }

    protected void cboSolicitante_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #region "botones de estados"
    protected void BtnEsperaJustificacion_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 1);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnEsperaCotizacion_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 3);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnCotizado_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 4);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnEsperaSolicitante_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 5);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnPendienteAprobacion_Click(object sender, ImageClickEventArgs e) {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 6);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnAprobar_Click(object sender, ImageClickEventArgs e) {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 8);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnDesaprobar_Click(object sender, ImageClickEventArgs e) {
        try
        {
            CabeceraRequerimientoCompraBL oCabeceraRequerimientoCompraBL = new CabeceraRequerimientoCompraBL();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);

            Int32 id_respuesta = oCabeceraRequerimientoCompraBL.CambiarEstado(IdCabecera_requerimiento_compra, Profile.Usuario.id_usuario, 7);
            if (id_respuesta > 0)
            {
                JavaScriptHelper.Alert(this, Message.keyCambioEstado, "");
                InicializaData();
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keyErrorGrabar, "");
            }
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion
    #endregion

    #region Métodos y Botones -- Detalle RequerimientoCompra
    protected void BtnAgregarDetalle_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Int32.TryParse(TxhId_detalle_requerimiento_compra.Value, out idDetalle_requerimiento_compra);
            if (idDetalle_requerimiento_compra == 0)
            {
                //Limpiar Formulario
                txtCantidad.Text = String.Empty;
                CboProducto.SelectedValue = String.Empty;
                LblTipo.Text = ConstanteBE.TIPO_AGREGAR;
            }
            else
            {
                //Cargo Formulario 
                DetalleRequerimientoCompraBL ODetalleRequerimientoCompraBLL = new DetalleRequerimientoCompraBL();
                ODetalleRequerimientoCompraBLL.ErrorEvent += new DetalleRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);
                ODetalleRequerimientoCompraBE = ODetalleRequerimientoCompraBLL.GetById(idDetalle_requerimiento_compra);

                txtCantidad.Text = ODetalleRequerimientoCompraBE.va_cantidad.ToString();
                CboProducto.SelectedValue = ODetalleRequerimientoCompraBE.id_producto.ToString();
                LblTipo.Text = ConstanteBE.TIPO_MODIFICAR;
            }
            ModalKpi.Show();
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnGrabar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DetalleRequerimientoCompraBL ODetalleRequerimientoCompraBL = new DetalleRequerimientoCompraBL();
            Int32 Indicador = 0;
            String resultado = String.Empty;
            Int32.TryParse(TxhId_detalle_requerimiento_compra.Value, out idDetalle_requerimiento_compra);

            CargarEntidadDesdeForm();
            if (LblTipo.Text == ConstanteBE.TIPO_AGREGAR) { Indicador = ODetalleRequerimientoCompraBL.Insertar(ODetalleRequerimientoCompraBE); }
            else if (LblTipo.Text == ConstanteBE.TIPO_MODIFICAR) { Indicador = ODetalleRequerimientoCompraBL.Modificar(ODetalleRequerimientoCompraBE); }

            if (Indicador == -6) { JavaScriptHelper.Alert(this, Message.KeyErrorDupModificar, ""); }
            if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }
            if (Indicador > 0) { JavaScriptHelper.Alert(this, Message.keyGrabar, ""); }
            else { JavaScriptHelper.Alert(this, Message.keyErrorGrabar, ""); }

            LblTipo.Text = ConstanteBE.TIPO_AGREGAR;
            BtnBuscarDet_Click(null, null);
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnBuscarDet_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            BuscarDetalle();
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnRegresarDet_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("SPV_Requerimiento_Compra_Bandeja.aspx", false);
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }

    protected void BtnEliminarDet_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DetalleRequerimientoCompraBL ODetalleRequerimientoCompraBL = new DetalleRequerimientoCompraBL();
            ODetalleRequerimientoCompraBL.ErrorEvent += new DetalleRequerimientoCompraBL.ErrorDelegate(General_ErrorEvent);
            Int32 Indicador = 0;
            String Resultado = String.Empty;
            if (!(TxhId_detalle_requerimiento_compra.Value.Equals("")))
            {
                ODetalleRequerimientoCompraBE = new DetalleRequerimientoCompraBE();
                ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra = Int32.Parse(TxhId_detalle_requerimiento_compra.Value.ToString());
                ODetalleRequerimientoCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;

                Indicador = ODetalleRequerimientoCompraBL.Eliminar(ODetalleRequerimientoCompraBE);
                if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyNoEliminoRelacionado, ""); }
                if (Indicador > 0) { JavaScriptHelper.Alert(this, Message.keyElimino, ""); }
                else { JavaScriptHelper.Alert(this, Message.keyNoElimino, ""); }
                BtnBuscarDet_Click(null, null);
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keySeleccioneUno, "");
            }
            TxhId_detalle_requerimiento_compra.Value = String.Empty;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }    

    private void CargarEntidadDesdeForm()
    {
        try
        {
            ODetalleRequerimientoCompraBE = new DetalleRequerimientoCompraBE();
            Int32.TryParse(TxhIdCabecera_requerimiento_compra.Value, out IdCabecera_requerimiento_compra);
            Int32.TryParse(TxhId_detalle_requerimiento_compra.Value, out idDetalle_requerimiento_compra);
            Int32 id_producto;
            Decimal va_cantidad = 0;
            Int32.TryParse(CboProducto.SelectedValue.ToString(), out id_producto);
            ODetalleRequerimientoCompraBE.id_detalle_requerimiento_compra = idDetalle_requerimiento_compra;
            ODetalleRequerimientoCompraBE.id_cabecera_requerimiento_compra = IdCabecera_requerimiento_compra;
            ODetalleRequerimientoCompraBE.id_producto = id_producto;
            Decimal.TryParse(txtCantidad.Text.ToString(), out va_cantidad);
            ODetalleRequerimientoCompraBE.va_cantidad = va_cantidad;
            ODetalleRequerimientoCompraBE.id_usuario_creacion = Profile.Usuario.id_usuario;
            ODetalleRequerimientoCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;
            TxhId_detalle_requerimiento_compra.Value = String.Empty;
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
                Int32.TryParse(dataKey.Values["id_detalle_requerimiento_compra"].ToString(), out aux);
                if (aux == 0)
                {
                    e.Row.Visible = false;
                    return;
                }

                e.Row.Style["cursor"] = "pointer";
                e.Row.Attributes["onclick"] = String.Format("javascript: fc_SeleccionaFilaSimple(this); document.getElementById('{0}').value = '{1}'"
                                                , TxhId_detalle_requerimiento_compra.ClientID, dataKey.Values["id_detalle_requerimiento_compra"].ToString());
                e.Row.Attributes["ondblclick"] = String.Format("javascript: document.getElementById('{0}').value = '{1}'; document.getElementById('{2}').click();"
                                                , TxhId_detalle_requerimiento_compra.ClientID, dataKey.Values["id_detalle_requerimiento_compra"].ToString(), this.BtnModificar.ClientID);
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
            ODetalleRequerimientoCompraBEList = (DetalleRequerimientoCompraBEList)ViewState["ODetalleRequerimientoCompraBEList"];
            this.GrwData.DataSource = ODetalleRequerimientoCompraBEList;
            this.GrwData.PageIndex = e.NewPageIndex;
            this.GrwData.DataBind();
            TxhId_detalle_requerimiento_compra.Value = String.Empty;
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
            ODetalleRequerimientoCompraBEList = (DetalleRequerimientoCompraBEList)ViewState["ODetalleRequerimientoCompraBEList"];
            SortDirection IndOrden = (SortDirection)ViewState["OrdenLista"];
            TxhId_detalle_requerimiento_compra.Value = String.Empty;
            if (ODetalleRequerimientoCompraBEList != null)
            {
                if (IndOrden == SortDirection.Ascending)
                {
                    ODetalleRequerimientoCompraBEList.Ordenar(e.SortExpression, direccionOrden.Descending);
                    ViewState["OrdenLista"] = SortDirection.Descending;
                }
                else
                {
                    ODetalleRequerimientoCompraBEList.Ordenar(e.SortExpression, direccionOrden.Ascending);
                    ViewState["OrdenLista"] = SortDirection.Ascending;
                }
            }
            this.GrwData.DataSource = ODetalleRequerimientoCompraBEList;
            this.GrwData.DataBind();
            ViewState["ODetalleRequerimientoCompraBEList"] = ODetalleRequerimientoCompraBEList;
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