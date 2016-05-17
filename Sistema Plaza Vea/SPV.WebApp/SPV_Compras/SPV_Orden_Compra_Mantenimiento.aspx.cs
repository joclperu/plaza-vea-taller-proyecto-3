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

public partial class SPV_Compras_SPV_Orden_Compra_Mantenimiento : PaginaBase
{
    #region Atributos y Propiedades
    private CabeceraOrdenCompraBE OCabeceraOrdenCompraBE;
    private DetalleOrdenCompraBE ODetalleOrdenCompraBE;
    private DetalleOrdenCompraBEList ODetalleOrdenCompraBEList;

    public String TipoAccion = String.Empty;
    public Int32 IdCabecera_Orden_compra;
    public Int32 idDetalle_Orden_compra;
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
        if (ViewState["ODetalleOrdenCompraBEList"] != null &&
            this.GrwData != null &&
            this.GrwData.Rows.Count > 0 &&
            this.GrwData.PageCount > 1)
        {
            GridViewRow oRow = this.GrwData.BottomPagerRow;
            if (oRow != null)
            {
                Label oTotalReg = new Label();
                oTotalReg.Text = String.Format("Total Reg. {0}", ((DetalleOrdenCompraBEList)ViewState["ODetalleOrdenCompraBEList"]).Count);
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
            Int32.TryParse(Request.QueryString["IdCabeceraOrdenCompra"], out IdCabecera_Orden_compra);
            TxhIdCabecera_orden_compra.Value = IdCabecera_Orden_compra.ToString();
            InicializaPagina();
            VerificaAcceso();
            if (IdCabecera_Orden_compra > 0) { InicializaData(); }
        }

        if (ViewState["IndiceTabOn"] != null)
        {
            this.TabordenCompra.ActiveTabIndex = (Int32)ViewState["IndiceTabOn"];
            this.IndiceTabOn = (Int32)ViewState["IndiceTabOn"];
            IdTab = (Int32)ViewState["IndiceTabOn"];
        }
        Int32.TryParse(TxhIdCabecera_orden_compra.Value.ToString(), out IdCabecera_Orden_compra);
        if (IdCabecera_Orden_compra > 0) { TipoAccion = ConstanteBE.TIPO_MODIFICAR; }
        else { TipoAccion = ConstanteBE.TIPO_AGREGAR; }
    }

    #region "Carga de página"
    private void InicializaPagina()
    {
        try
        {
            cboEstado.CargarCombo(ConstanteBE.OBJECTO_TIPO_SELECCIONE, 19);
            cboEstado.EnabledValidacion = false;

            cboTipo.CargarCombo(ConstanteBE.OBJECTO_TIPO_SELECCIONE, 31);
            cboTipo.EnabledValidacion = false;

            cboProveedor.CargarCombo(ConstanteBE.OBJECTO_TIPO_SELECCIONE);
            cboProveedor.EnabledValidacion = false;

            BtnModificar.Style.Add("display", "none");
            TabDetalleordenCompra.Enabled = false;
            TabOrdenCompra_ActiveTabChanged(null, null);
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
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            oCabeceraOrdenCompraBL.ErrorEvent += new CabeceraOrdenCompraBL.ErrorDelegate(General_ErrorEvent);

            OCabeceraOrdenCompraBE = oCabeceraOrdenCompraBL.GetById(IdCabecera_Orden_compra);

            cboEstado.SelectedValue = OCabeceraOrdenCompraBE.id_estado.ToString();
            cboTipo.SelectedValue = OCabeceraOrdenCompraBE.id_tipo.ToString();
            cboProveedor.SelectedValue = OCabeceraOrdenCompraBE.id_proveedor.ToString();
            TxtFecCreacion.Text = OCabeceraOrdenCompraBE.fe_creacion.ToString();

            TxtInsertObservación.Text = OCabeceraOrdenCompraBE.de_observaciones.ToString();
            TxhIdEstado.Value = OCabeceraOrdenCompraBE.id_estado.ToString();
            txtNumSerie.Text = OCabeceraOrdenCompraBE.id_cabecera_orden_compra.ToString();
            txtNumReferencia.Text = OCabeceraOrdenCompraBE.id_referencia.ToString();
            TabDetalleordenCompra.Enabled = true;

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
            IndiceTabOn = this.TabordenCompra.ActiveTabIndex;
            Int32 id_rol, id_estado;
            Int32.TryParse(Profile.Usuario.id_rol.ToString(), out id_rol);
            Int32.TryParse(TxhIdEstado.Value.ToString(), out id_estado);

            BtnEsperaStockProveedor.Visible = false;
            BtnEsperaSolicitante.Visible = false;
            BtnPendienteAprobacion.Visible = false;
            BtnAprobar.Visible = false;
            BtnDesaprobar.Visible = false;

            BtnAgregarDetalle.Visible = false;
            BtnEliminarDet.Visible = false;
            BtnGrabar.Visible = false;

            #region "VERIFICACION DE ACCESO POR ROL"
            if (id_rol == 15)//GERENTE DE COMPRAS
            {
                BtnEsperaStockProveedor.Visible = VerificaAccesoEstado(BtnEsperaStockProveedor, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);

                //BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);
            }
            else if (id_rol == 16)//JEFE DE COMPRAS
            {
                BtnEsperaStockProveedor.Visible = VerificaAccesoEstado(BtnEsperaStockProveedor, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);

                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);
            }
            else if (id_rol == 17)//ASISTENTE DE COMPRAS
            {
                BtnAprobar.Visible = VerificaAccesoEstado(BtnAprobar, id_estado, IndiceTabOn);
                BtnAgregarDetalle.Visible = VerificaAccesoEstado(BtnAgregarDetalle, id_estado, IndiceTabOn);
                BtnEliminarDet.Visible = VerificaAccesoEstado(BtnEliminarDet, id_estado, IndiceTabOn);

                BtnEsperaStockProveedor.Visible = VerificaAccesoEstado(BtnEsperaStockProveedor, id_estado, IndiceTabOn);
                BtnEsperaSolicitante.Visible = VerificaAccesoEstado(BtnEsperaSolicitante, id_estado, IndiceTabOn);
                //BtnPendienteAprobacion.Visible = VerificaAccesoEstado(BtnPendienteAprobacion, id_estado, IndiceTabOn);
                BtnDesaprobar.Visible = VerificaAccesoEstado(BtnDesaprobar, id_estado, IndiceTabOn);
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
        if (id_estado == 20) //EN PROCESO
        {
            if (this.IndiceTabOn == 0)
            {
                if (btn.ID.Equals("BtnEsperaStockProveedor")) return true;
                else if (btn.ID.Equals("BtnEsperaSolicitante")) return true;
                else if (btn.ID.Equals("BtnDesaprobar")) return true;
                else if (btn.ID.Equals("BtnGrabarCab")) return true;
                else return false;
            }
            else if (this.IndiceTabOn == 1)
            {
                //if (btn.ID.Equals("BtnAgregarDetalle")) return true;
                if (btn.ID.Equals("BtnEliminarDet")) return true;
                else if (btn.ID.Equals("BtnGrabar")) return true;
                else return false;
            }
        }
        else if (id_estado == 21) //ESPERA STOCK PROVEEDOR
        {
            if (btn.ID.Equals("BtnEsperaSolicitante")) return true;
            else if (btn.ID.Equals("BtnPendienteAprobacion")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 22) //ESPERA SOLICITANTE
        {
            if (btn.ID.Equals("BtnPendienteAprobacion")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 25) //PENDIENTE APROBACION
        {
            if (btn.ID.Equals("BtnAprobar")) return true;
            else if (btn.ID.Equals("BtnDesaprobar")) return true;
            else return false;
        }
        else if (id_estado == 26) //ANULADO
        {
            return false;
        }
        else if (id_estado == 27) //APROBADO
        {
            return false;
        }
        else if (id_estado == 28) //RECHAZADO
        {
            return false;
        }
        else if (id_estado == 29) //PROCESADO
        {
            return false;
        }
        else if (id_estado == 30) //CERRADO
        {
            return false;
        }        
        #endregion
        return false;
    }

    private void BuscarDetalle()
    {
        try
        {
            DetalleOrdenCompraBL ODetalleOrdenCompraBL = new DetalleOrdenCompraBL();
            ODetalleOrdenCompraBL.ErrorEvent += new DetalleOrdenCompraBL.ErrorDelegate(General_ErrorEvent);
            TxhId_detalle_orden_compra.Value = String.Empty;

            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            ODetalleOrdenCompraBEList = ODetalleOrdenCompraBL.GetAll(IdCabecera_Orden_compra);

            if (ODetalleOrdenCompraBEList == null || ODetalleOrdenCompraBEList.Count == 0)
            {
                ODetalleOrdenCompraBEList.Add(new DetalleOrdenCompraBE());
            }
            this.GrwData.DataSource = ODetalleOrdenCompraBEList;
            this.GrwData.DataBind();
            ViewState["ODetalleOrdenCompraBEList"] = ODetalleOrdenCompraBEList;
        }
        catch (Exception ex)
        {
            this.Web_ErrorEvent(this, ex);
        }
    }
    #endregion

    #region "Evento Tab"
    protected void TabOrdenCompra_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            IndiceTabOn = this.TabordenCompra.ActiveTabIndex;
            //OrdenCompra OrdenCompra
            BtnRegresar.Visible = false;

            //Detalle OrdenCompra
            BtnAgregarDetalle.Visible = false;
            BtnEliminarDet.Visible = false;
            BtnAgregar.Visible = false;
            BtnRegresarDet.Visible = false;

            if (this.IndiceTabOn == 0)
            {
                BtnRegresar.Visible = true;
                Int32.TryParse(TxhIdCabecera_orden_compra.Value.ToString(), out IdCabecera_Orden_compra);
                if (IdCabecera_Orden_compra > 0)
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

    #region Métodos y Botones --OrdenCompra OrdenCompra
    protected void BtnRegresar_Click(object sender, ImageClickEventArgs e)
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

    protected void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
    {

    }   

    #region "botones de estados"
    protected void BtnEsperaStockProveedor_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            Int32 id_respuesta = oCabeceraOrdenCompraBL.CambiarEstado(IdCabecera_Orden_compra, Profile.Usuario.id_usuario, 1);
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
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            Int32 id_respuesta = oCabeceraOrdenCompraBL.CambiarEstado(IdCabecera_Orden_compra, Profile.Usuario.id_usuario, 2);
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

    protected void BtnPendienteAprobacion_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            Int32 id_respuesta = oCabeceraOrdenCompraBL.CambiarEstado(IdCabecera_Orden_compra, Profile.Usuario.id_usuario, 3);
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

    protected void BtnAprobar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            Int32 id_respuesta = oCabeceraOrdenCompraBL.CambiarEstado(IdCabecera_Orden_compra, Profile.Usuario.id_usuario, 5);
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

    protected void BtnDesaprobar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            CabeceraOrdenCompraBL oCabeceraOrdenCompraBL = new CabeceraOrdenCompraBL();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);

            Int32 id_respuesta = oCabeceraOrdenCompraBL.CambiarEstado(IdCabecera_Orden_compra, Profile.Usuario.id_usuario, 6);
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

    #region Métodos y Botones -- Detalle OrdenCompra
    protected void BtnAgregarDetalle_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Int32.TryParse(TxhId_detalle_orden_compra.Value, out idDetalle_Orden_compra);
            if (idDetalle_Orden_compra == 0)
            {
                //Limpiar Formulario
                txtCantidad.Text = String.Empty;
                CboProducto.SelectedValue = String.Empty;
                LblTipo.Text = ConstanteBE.TIPO_AGREGAR;
            }
            else
            {
                //Cargo Formulario 
                DetalleOrdenCompraBL ODetalleOrdenCompraBLL = new DetalleOrdenCompraBL();
                ODetalleOrdenCompraBLL.ErrorEvent += new DetalleOrdenCompraBL.ErrorDelegate(General_ErrorEvent);
                ODetalleOrdenCompraBE = ODetalleOrdenCompraBLL.GetById(idDetalle_Orden_compra);

                txtCantidad.Text = ODetalleOrdenCompraBE.va_cantidad.ToString();
                CboProducto.SelectedValue = ODetalleOrdenCompraBE.id_producto.ToString();
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
            DetalleOrdenCompraBL ODetalleOrdenCompraBL = new DetalleOrdenCompraBL();
            Int32 Indicador = 0;
            String resultado = String.Empty;
            Int32.TryParse(TxhId_detalle_orden_compra.Value, out idDetalle_Orden_compra);

            CargarEntidadDesdeForm();
            if (LblTipo.Text == ConstanteBE.TIPO_MODIFICAR) { Indicador = ODetalleOrdenCompraBL.Modificar(ODetalleOrdenCompraBE); }

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
            Response.Redirect("SPV_Orden_Compra_Bandeja.aspx", false);
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
            DetalleOrdenCompraBL ODetalleOrdenCompraBL = new DetalleOrdenCompraBL();
            ODetalleOrdenCompraBL.ErrorEvent += new DetalleOrdenCompraBL.ErrorDelegate(General_ErrorEvent);
            Int32 Indicador = 0;
            String Resultado = String.Empty;
            if (!(TxhId_detalle_orden_compra.Value.Equals("")))
            {
                ODetalleOrdenCompraBE = new DetalleOrdenCompraBE();
                ODetalleOrdenCompraBE.id_detalle_orden_compra = Int32.Parse(TxhId_detalle_orden_compra.Value.ToString());
                ODetalleOrdenCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;

                Indicador = ODetalleOrdenCompraBL.Eliminar(ODetalleOrdenCompraBE);
                if (Indicador == -1) { JavaScriptHelper.Alert(this, Message.keyNoEliminoRelacionado, ""); }
                if (Indicador > 0) { JavaScriptHelper.Alert(this, Message.keyElimino, ""); }
                else { JavaScriptHelper.Alert(this, Message.keyNoElimino, ""); }
                BtnBuscarDet_Click(null, null);
            }
            else
            {
                JavaScriptHelper.Alert(this, Message.keySeleccioneUno, "");
            }
            TxhId_detalle_orden_compra.Value = String.Empty;
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
            ODetalleOrdenCompraBE = new DetalleOrdenCompraBE();
            Int32.TryParse(TxhIdCabecera_orden_compra.Value, out IdCabecera_Orden_compra);
            Int32.TryParse(TxhId_detalle_orden_compra.Value, out idDetalle_Orden_compra);
            Int32 id_producto;
            Decimal va_cantidad = 0;
            Int32.TryParse(CboProducto.SelectedValue.ToString(), out id_producto);
            ODetalleOrdenCompraBE.id_detalle_orden_compra = idDetalle_Orden_compra;
            ODetalleOrdenCompraBE.id_cabecera_orden_compra = IdCabecera_Orden_compra;
            ODetalleOrdenCompraBE.id_producto = id_producto;
            Decimal.TryParse(txtCantidad.Text.ToString(), out va_cantidad);
            ODetalleOrdenCompraBE.va_cantidad = va_cantidad;
            ODetalleOrdenCompraBE.id_usuario_creacion = Profile.Usuario.id_usuario;
            ODetalleOrdenCompraBE.id_usuario_cambio = Profile.Usuario.id_usuario;
            TxhId_detalle_orden_compra.Value = String.Empty;
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
                Int32.TryParse(dataKey.Values["id_detalle_orden_compra"].ToString(), out aux);
                if (aux == 0)
                {
                    e.Row.Visible = false;
                    return;
                }

                e.Row.Style["cursor"] = "pointer";
                e.Row.Attributes["onclick"] = String.Format("javascript: fc_SeleccionaFilaSimple(this); document.getElementById('{0}').value = '{1}'"
                                                , TxhId_detalle_orden_compra.ClientID, dataKey.Values["id_detalle_orden_compra"].ToString());
                e.Row.Attributes["ondblclick"] = String.Format("javascript: document.getElementById('{0}').value = '{1}'; document.getElementById('{2}').click();"
                                                , TxhId_detalle_orden_compra.ClientID, dataKey.Values["id_detalle_orden_compra"].ToString(), this.BtnModificar.ClientID);
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
            ODetalleOrdenCompraBEList = (DetalleOrdenCompraBEList)ViewState["ODetalleOrdenCompraBEList"];
            this.GrwData.DataSource = ODetalleOrdenCompraBEList;
            this.GrwData.PageIndex = e.NewPageIndex;
            this.GrwData.DataBind();
            TxhId_detalle_orden_compra.Value = String.Empty;
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
            ODetalleOrdenCompraBEList = (DetalleOrdenCompraBEList)ViewState["ODetalleOrdenCompraBEList"];
            SortDirection IndOrden = (SortDirection)ViewState["OrdenLista"];
            TxhId_detalle_orden_compra.Value = String.Empty;
            if (ODetalleOrdenCompraBEList != null)
            {
                if (IndOrden == SortDirection.Ascending)
                {
                    ODetalleOrdenCompraBEList.Ordenar(e.SortExpression, direccionOrden.Descending);
                    ViewState["OrdenLista"] = SortDirection.Descending;
                }
                else
                {
                    ODetalleOrdenCompraBEList.Ordenar(e.SortExpression, direccionOrden.Ascending);
                    ViewState["OrdenLista"] = SortDirection.Ascending;
                }
            }
            this.GrwData.DataSource = ODetalleOrdenCompraBEList;
            this.GrwData.DataBind();
            ViewState["ODetalleOrdenCompraBEList"] = ODetalleOrdenCompraBEList;
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