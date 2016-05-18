using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class Pages_RegistroIngresoMercaderia : System.Web.UI.Page
{
    EN_OrdenCompra oEN_OrdenCompra = new EN_OrdenCompra();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["usuario"] != null)
                InicializarPagina();
            else
                Response.Redirect("../Logueo.aspx");
        }
    }

    private void InicializarPagina()
    {
        this.btnConsultar.OnClientClick = "return fn_ValidarOc();";
        //this.btnNuevo.OnClientClick = "return fn_PopupNuevoIngreso('');";
        this.btnNuevo.Visible = false;
        this.txtOrdenCompra.Text = string.Empty;
        LimpiarControles();
    }

    /// <summary>
    /// Cargamos la data
    /// </summary>
    /// <param name="result"></param>
    private void setDatos(EN_OrdenCompra result)
    {
        this.txtCodOC.Text = result.CodigoOC.ToString();
        this.txtNroOC.Text = result.NroOrdenCompra;
        this.txtFecOC.Text = result.FechaOC.ToShortDateString();
        this.txtEstado.Text = result.desEstado.ToString();
        this.txtMontoTotal.Text = result.MontoTotal.ToString();
        this.txtTienda.Text = result.nomTienda;
        this.txtProveedor.Text = result.nomProveedor;
        this.txtEmail.Text = result.emailProveedor;
        this.txtNroDoc.Text = result.rucProveedor;
        this.hdEstadoActual.Value = result.codEstado.ToString();
        this.btnNuevo.Visible = result.codEstado == 2 ? false : true; //aqui
    }

    /// <summary>
    /// Carga los ingresos de mercaderia
    /// </summary>
    /// <param name="result"></param>
    private void CargarIngresosMercaderia(EN_OrdenCompra result)
    {
        if (result.listNotasxGuia.Any())
        {
            this.gvIngresos.DataSource = result.listNotasxGuia;
            this.gvIngresos.DataBind();
        }
        else
        {
            gvIngresos_Vacio();
        }
    }

    /// <summary>
    /// Carga el detalle de la Oc
    /// </summary>
    /// <param name="result"></param>
    private void CargarDetalleOrdenCompra(EN_OrdenCompra result)
    {
        if (result.listDetOc.Any())
        {
            this.gvOrdenCompra.DataSource = result.listDetOc;
            this.gvOrdenCompra.DataBind();
        }
        else
        {
            gvOrdenCompra_Vacio();
        }
    }


    private void gvIngresos_Vacio()
    {
        EN_GuiaRemision objApli = new EN_GuiaRemision();
        List<EN_GuiaRemision> lstApli = new List<EN_GuiaRemision>();
        objApli.nNomRol = "EMPTY";
        lstApli.Add(objApli);
        this.gvIngresos.DataSource = lstApli;
        this.gvIngresos.DataBind();
        this.gvIngresos.Rows[0].Visible = false;
    }


    private void gvOrdenCompra_Vacio()
    {
        EN_DetalleOrdenCompra objApli = new EN_DetalleOrdenCompra();
        List<EN_DetalleOrdenCompra> lstApli = new List<EN_DetalleOrdenCompra>();
        objApli.nNomProducto = "EMPTY";
        lstApli.Add(objApli);
        this.gvOrdenCompra.DataSource = lstApli;
        this.gvOrdenCompra.DataBind();
        this.gvOrdenCompra.Rows[0].Visible = false;
    }

    private void LimpiarControles()
    {
        gvOrdenCompra_Vacio();
        gvIngresos_Vacio();
        this.txtCodOC.Text = "";
        this.txtNroOC.Text = "";
        this.txtFecOC.Text = "";
        this.txtEstado.Text = "";
        this.txtMontoTotal.Text = "";
        this.txtTienda.Text = "";
        this.txtProveedor.Text = "";
        this.txtEmail.Text = "";
        this.txtNroDoc.Text = "";
    }

    private void LimpiarControlesPop()
    {
        this.txtNroPlaca.Text = "";
        this.txtCantidad.Text = "";
        this.txtTransportista.Text = "";
        this.txtNroGuiaRemis.Text = "";
        this.txtObservaciones.Text = "";
        gvProductos_Vacio();

    }

    /// <summary>
    /// Consulta la orden compra
    /// </summary>
    /// <returns></returns>
    private EN_OrdenCompra ConsultarOrden()
    {
        oEN_OrdenCompra = new EN_OrdenCompra();
        oEN_OrdenCompra.NroOrdenCompra = this.txtOrdenCompra.Text.Trim();
        oEN_OrdenCompra.codTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;//Tienda a la que pertenece el usuario

        EN_OrdenCompra result = new EN_OrdenCompra();
        result = new BL_OrdenCompra().Consultar(oEN_OrdenCompra);
        return result;
    }

    //protected void gvIngresos_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblCodGuiaRemision = (Label)e.Row.FindControl("lblCodGuiaRemision");
    //        Label lblCodNotaIngreso = (Label)e.Row.FindControl("lblCodNotaIngreso");


    //        ImageButton imgConsular = (ImageButton)e.Row.FindControl("imgConsular");
    //        imgConsular.OnClientClick = string.Format("return fn_PopupConsultaIngreso('{0}');", lblCodGuiaRemision.Text);

    //        ImageButton imgBorrar = (ImageButton)e.Row.FindControl("imgBorrar");
    //        imgBorrar.OnClientClick = string.Format("return fn_PopupEliminarNota('{0}');", lblCodNotaIngreso.Text);
    //    }
    //}

    protected void btnEvaluar_Click(object sender, EventArgs e)
    {
        //Evaluar estado OC y listar
        //Consultar Orden Compra
        if (!string.IsNullOrEmpty(this.txtOrdenCompra.Text.Trim()))
        {
            EN_OrdenCompra result = ConsultarOrden();
            if (result.CodigoOC > 0)
            {
                setDatos(result);
                CargarDetalleOrdenCompra(result);
                CargarIngresosMercaderia(result);
            }
            else
            {
                LimpiarControles();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('No se encontraron datos');", true);
                this.btnNuevo.Visible = false;
            }
        }
    }
    protected void imgBorrar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgBorrar = ((ImageButton)(sender));
        GridViewRow row = ((GridViewRow)(imgBorrar.NamingContainer));

        Label lblCodNotaIngreso = (Label)row.FindControl("lblCodNotaIngreso");
        EN_NotaIngreso oEN_NotaIngreso = new EN_NotaIngreso();
        oEN_NotaIngreso.NCodNotaIngreso = int.Parse(lblCodNotaIngreso.Text);
        oEN_NotaIngreso.nCodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;
        int result = new BL_NotaIngreso().Eliminar(oEN_NotaIngreso);
        if (result > 0)
        {
            EN_OrdenCompra resultx = ConsultarOrden();
            if (resultx.CodigoOC > 0)
            {
                setDatos(resultx);
                CargarDetalleOrdenCompra(resultx);
                CargarIngresosMercaderia(resultx);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('Se anuló exitosamente la Nota de ingreso {0}');", lblCodNotaIngreso.Text), true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Ocurrio un error al eliminar la Nota ingreso, revisar log');", true);
        }
    }
    protected void btnConsultar_Click1(object sender, ImageClickEventArgs e)
    {
        //Consultar Orden Compra
        if (!string.IsNullOrEmpty(this.txtOrdenCompra.Text.Trim()))
        {
            EN_OrdenCompra result = ConsultarOrden();
            if (result.CodigoOC > 0)
            {
                setDatos(result);
                CargarDetalleOrdenCompra(result);
                CargarIngresosMercaderia(result);

                if (result.codEstado == 2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Orden de Compra completada, no se permite registrar notas de ingreso');", true);
                }

            }
            else
            {
                LimpiarControles();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('No se encontraron datos');", true);
                this.btnNuevo.Visible = false;
            }
        }
        else
        {
            this.txtOrdenCompra.Focus();
            LimpiarControles();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Ingrese una orden compra');", true);
            this.btnNuevo.Visible = false;
        }
    }
    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarControles();
    }

    #region "Nuevo Ingreso"
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        this.lblTituloModo.Text = "REGISTRO Ingresos de Mercadería".ToUpper();
        LimpiarControlesPop();
        Session["listaProductos_pop"] = null;
        this.gvProductos.Visible = true;
        this.gvDetalleNota.Visible = false;
        EN_OrdenCompra oEN_OC = new EN_OrdenCompra();
        oEN_OC = ConsultarOrdenPop();

        CargarProductos(oEN_OC);
        gvProductos_Vacio();


        this.txtNroPlaca.Enabled = true;
        this.txtObservaciones.Enabled = true;
        this.txtTransportista.Enabled = true;
        this.txtNroGuiaRemis.Enabled = true;
        this.ddlProductos.Enabled = true;
        this.txtCantidad.Enabled = true;
        this.btnAgregar.Visible = true;
        this.btnGuardar.Visible = true;


        this.aCantidad.Visible = true;
        this.lblMaximoProducto.Visible = true;


        this.txtOrdenCompraPop.Text = oEN_OC.NroOrdenCompra;
        this.txtProveedorPop.Text = oEN_OC.nomProveedor;
        this.txtFecReg.Text = DateTime.Now.ToShortDateString();
        this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
        this.hdIdProveedor.Value = oEN_OC.codProveedor.ToString();
        this.hdEstadoOrden.Value = oEN_OC.codEstado.ToString();//2= completado
        this.hdIdOc.Value = oEN_OC.CodigoOC.ToString();

        this.btnAgregar.OnClientClick = "return fn_ValidarMonto();";
        this.btnGuardar.OnClientClick = "return fn_Validar();";

        modalNuevo.Show();
    }


    private EN_OrdenCompra ConsultarOrdenPop()
    {
        EN_OrdenCompra oEN_OrdenCompra = new EN_OrdenCompra();
        oEN_OrdenCompra.CodigoOC = int.Parse(this.txtCodOC.Text); //int.Parse(Request.QueryString["param"]);
        oEN_OrdenCompra.codTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

        EN_OrdenCompra result = new EN_OrdenCompra();
        result = new BL_OrdenCompra().Consultar(oEN_OrdenCompra);
        return result;
    }
    private void CargarProductos(EN_OrdenCompra oEN_OC)
    {
        Session["listaProductos_pop"] = oEN_OC.listDetOc;
        this.ddlProductos.DataSource = oEN_OC.listDetOc;
        this.ddlProductos.DataTextField = "nNomProducto";
        this.ddlProductos.DataValueField = "nCodProducto";
        this.ddlProductos.DataBind();
        SetearDiferencia(oEN_OC.listDetOc);
        SetearUnidadMedida(oEN_OC.listDetOc);
    }

    private void SetearUnidadMedida(List<EN_DetalleOrdenCompra> olstProductos)
    {
        int producto = Convert.ToInt32(this.ddlProductos.SelectedValue);

        var unidadmedida = olstProductos
                    .Where(x => x.nCodProducto == producto)
                    .Select(x => x.cUnidadMedida)
                    .ToList();

        this.hdUnidadMedida.Value = unidadmedida[0].ToString();
    }

    private void SetearDiferencia(List<EN_DetalleOrdenCompra> olstProductos)
    {
        int producto = Convert.ToInt32(this.ddlProductos.SelectedValue);

        var diferencia = olstProductos
            .Where(x => x.nCodProducto == producto)
            .Select(x => x.nCantDiferencia)
            .ToList();

        this.hdMontoPermitido.Value = diferencia[0].ToString();
        this.lblMaximoProducto.Text = diferencia[0].ToString();
    }

    protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<EN_DetalleOrdenCompra> olstProductos = new List<EN_DetalleOrdenCompra>();
        olstProductos = (List<EN_DetalleOrdenCompra>)Session["listaProductos_pop"];
        SetearDiferencia(olstProductos);
        SetearUnidadMedida(olstProductos);
        this.txtCantidad.Text = "";
        modalNuevo.Show();
    }

    protected void imgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgEliminar = ((ImageButton)(sender));
        GridViewRow row = ((GridViewRow)(imgEliminar.NamingContainer));
        Label lblIdProducto = (Label)row.FindControl("lblIdProducto");

        List<EN_Producto> olstProductos = new List<EN_Producto>();

        if (gvProductos.Rows.Count > 0)
        {
            if (gvProductos.Rows[0].Visible == true)
            {
                foreach (GridViewRow gvRow in gvProductos.Rows)
                {
                    if (gvRow.RowIndex != row.RowIndex)
                    {
                        EN_Producto oEN_Producto = new EN_Producto();
                        oEN_Producto.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
                        oEN_Producto.CDescripcion = ((Label)gvRow.FindControl("lblProducto")).Text;
                        oEN_Producto.CANTIDAD = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
                        oEN_Producto.CUnidadMedida = ((Label)gvRow.FindControl("lblUnidad")).Text;
                        olstProductos.Add(oEN_Producto);
                    }
                }
            }
        }

        if (olstProductos.Any()) { this.gvProductos.DataSource = olstProductos; this.gvProductos.DataBind(); }
        else { gvProductos_Vacio(); }
        modalNuevo.Show();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int montoPermitido = Convert.ToInt32(hdMontoPermitido.Value);
        if (montoPermitido > 0)
        {
            int cantidad = this.txtCantidad.Text.Length > 0 ? Convert.ToInt32(this.txtCantidad.Text) : 0;
            if (cantidad > 0)
            {
                if (cantidad <= montoPermitido)
                {
                    setProductos();
                    this.txtCantidad.Text = "";
                }
                else
                {
                    string msg = string.Format("alert('La cantidad máxima a ingresar es : ' {0})", montoPermitido.ToString());
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Este producto está sin pendientes');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Cantidad inconsistente con la diferencia para completar la O.C.');", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Este producto está sin pendientes');", true);
        }
        modalNuevo.Show();
    }

    private void gvProductos_Vacio()
    {
        EN_Producto objApli = new EN_Producto();
        List<EN_Producto> lstApli = new List<EN_Producto>();
        objApli.CDescripcion = "EMPTY";
        lstApli.Add(objApli);
        this.gvProductos.DataSource = lstApli;
        this.gvProductos.DataBind();
        this.gvProductos.Rows[0].Visible = false;
    }

    private void setProductos()
    {
        List<EN_Producto> olst = new List<EN_Producto>();
        olst = recuperarProductos();

        EN_Producto item = new EN_Producto();
        item.NCodProducto = int.Parse(this.ddlProductos.SelectedValue);
        item.CDescripcion = this.ddlProductos.SelectedItem.ToString();
        item.CANTIDAD = int.Parse(this.txtCantidad.Text.Trim());
        item.CUnidadMedida = this.hdUnidadMedida.Value;

        olst.Add(item);

        if (olst.Any()) { this.gvProductos.DataSource = olst; this.gvProductos.DataBind(); }
        else { gvProductos_Vacio(); }
    }

    public List<EN_Producto> recuperarProductos()
    {
        List<EN_Producto> olstProductos = new List<EN_Producto>();
        if (gvProductos.Rows.Count > 0)
        {
            if (gvProductos.Rows[0].Visible == true)
            {
                foreach (GridViewRow gvRow in gvProductos.Rows)
                {

                    EN_Producto oEN_Producto = new EN_Producto();
                    oEN_Producto.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
                    oEN_Producto.CDescripcion = ((Label)gvRow.FindControl("lblProducto")).Text;
                    oEN_Producto.CANTIDAD = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
                    oEN_Producto.CUnidadMedida = ((Label)gvRow.FindControl("lblUnidad")).Text;
                    olstProductos.Add(oEN_Producto);
                }
            }
        }
        return olstProductos;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.hdEstadoOrden.Value.Equals("2"))
            {
                modalNuevo.Show();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Está Orden de Compra esta completada.)", true);
                return;
            }

            String msg = "";
            bool esCorrecto = ValidarTotalesGrilla(ref msg);
            if (!esCorrecto)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('{0}')", msg), true);
                modalNuevo.Show();
                return;
            }


            List<EN_DetalleNotaDocumento> ListaDetalle = new List<EN_DetalleNotaDocumento>();
            ListaDetalle = recuperarDetalleNotaDocumento();

            int resultCodDocumento = RegistrarGuiaRemision(ListaDetalle);
            if (resultCodDocumento > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RetornarValores", "alert('Operación realizada con éxito');", true);

                btnConsultar_Click1(null, null);
                modalNuevo.Hide();
                //int resultNota = RegistrarNotaIngreso(ListaDetalle);
                //if (resultNota > 0)
                //{
                //    
                //}
                //else
                //{
                //    
                //}
            }
            else
            {
                modalNuevo.Show();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Ocurrio un error revisar el log')", true);
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('Ocurrio un error revisar el log :{0})", ex.Message.ToString()), true);
        }
    }


    private int RegistrarGuiaRemision(List<EN_DetalleNotaDocumento> ListaDetalle)
    {
        EN_GuiaRemision oEN_GuiaRemision = new EN_GuiaRemision();
        oEN_GuiaRemision.ncodGuiaRemision = this.txtNroGuiaRemis.Text.Trim().ToUpper();
        oEN_GuiaRemision.nCodOc = int.Parse(this.hdIdOc.Value);
        oEN_GuiaRemision.nCodProveedor = int.Parse(this.hdIdProveedor.Value);
        oEN_GuiaRemision.cTransportista = this.txtTransportista.Text.Trim().ToUpper();
        oEN_GuiaRemision.cPlaca = this.txtNroPlaca.Text.Trim().ToUpper();
        oEN_GuiaRemision.cObservacion_gr = this.txtObservaciones.Text.Trim().ToUpper();
        return new BL_GuiaRemision().Registrar(oEN_GuiaRemision, ListaDetalle, int.Parse(this.hdIdOc.Value));
    }

    public List<EN_DetalleNotaDocumento> recuperarDetalleNotaDocumento()
    {
        List<EN_DetalleNotaDocumento> olstdetalleNota = new List<EN_DetalleNotaDocumento>();
        if (gvProductos.Rows.Count > 0)
        {
            if (gvProductos.Rows[0].Visible == true)
            {
                foreach (GridViewRow gvRow in gvProductos.Rows)
                {

                    EN_DetalleNotaDocumento oEN_DetalleNotaDocumento = new EN_DetalleNotaDocumento();
                    //oEN_DetalleNotaDocumento.NCodGuiaRemision = this.txtNroGuiaRemis.Text.Trim().ToUpper();
                    oEN_DetalleNotaDocumento.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
                    oEN_DetalleNotaDocumento.NCantidad = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
                    oEN_DetalleNotaDocumento.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;
                    //oEN_DetalleNotaDocumento. = int.Parse(this.hdIdOc.Value);
                    olstdetalleNota.Add(oEN_DetalleNotaDocumento);
                }
            }
        }
        return olstdetalleNota;
    }

    public bool ValidarTotalesGrilla(ref string msg_return)
    {
        bool result = true;


        List<EN_DetalleOrdenCompra> olstProductOC = new List<EN_DetalleOrdenCompra>();
        olstProductOC = (List<EN_DetalleOrdenCompra>)Session["listaProductos_pop"];

        List<EN_Producto> olst = new List<EN_Producto>();
        foreach (GridViewRow gvRow in gvProductos.Rows)
        {
            EN_Producto oEN_Producto = new EN_Producto();
            oEN_Producto.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
            oEN_Producto.CANTIDAD = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
            olst.Add(oEN_Producto);
        }

        foreach (EN_DetalleOrdenCompra item in olstProductOC)
        {
            var Total = olst.Where(c => c.NCodProducto == item.nCodProducto).Sum(c => c.CANTIDAD);

            if (Total > item.nCantDiferencia)
            {
                msg_return = string.Format("La suma total del producto {0} excede la diferencia : {1}", item.nNomProducto, item.nCantDiferencia.ToString());
                result = false;
                break;
            }
        }
        return result;
    }

    #endregion


    #region "Consulta Ingreso"
    protected void imgConsular_Click(object sender, ImageClickEventArgs e)
    {

        LimpiarControlesPop();
        ImageButton imgConsular = ((ImageButton)(sender));
        GridViewRow row = ((GridViewRow)(imgConsular.NamingContainer));

        Label lblCodGuiaRemision = (Label)row.FindControl("lblCodGuiaRemision");

        this.lblTituloModo.Text = "Consulta Ingresos de Mercadería".ToUpper();

        EN_OrdenCompra oEN_OC = new EN_OrdenCompra();
        oEN_OC = ConsultarOrden();

        this.txtOrdenCompraPop.Text = oEN_OC.NroOrdenCompra;
        this.txtProveedorPop.Text = oEN_OC.nomProveedor;
        this.txtFecReg.Text = oEN_OC.FechaOC.ToShortDateString();
        this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
        this.hdIdProveedor.Value = oEN_OC.codProveedor.ToString();
        this.hdEstadoOrden.Value = oEN_OC.codEstado.ToString();//2= completado
        this.hdIdOc.Value = oEN_OC.CodigoOC.ToString();

        List<EN_GuiaRemision> olstEN_GR = new List<EN_GuiaRemision>();
        oEN_OC.ncodGuiaRemision = lblCodGuiaRemision.Text; // Request.QueryString["Nro_guia"];
        olstEN_GR = new BL_GuiaRemision().ListarIngresoMercaderia(oEN_OC);


        List<EN_DetalleNotaIngreso> olstDetalleNota = new List<EN_DetalleNotaIngreso>();
        olstDetalleNota = new BL_DetalleNotaIngreso().Listar(olstEN_GR[0].nCodNotaIngreso);
        this.gvProductos.Visible = false;
        this.gvDetalleNota.Visible = true;
        this.gvDetalleNota.DataSource = olstDetalleNota;
        this.gvDetalleNota.DataBind();

        this.txtNroGuiaRemis.Text = olstEN_GR[0].ncodGuiaRemision;
        this.txtNroPlaca.Text = olstEN_GR[0].cPlaca;
        this.txtTransportista.Text = olstEN_GR[0].cTransportista;
        this.txtObservaciones.Text = olstEN_GR[0].cObservacion_gr;

        this.txtNroPlaca.Enabled = false;
        this.txtObservaciones.Enabled = false;
        this.txtTransportista.Enabled = false;
        this.txtNroGuiaRemis.Enabled = false;
        this.ddlProductos.Enabled = false;
        this.txtCantidad.Enabled = false;
        this.btnAgregar.Visible = false;
        this.btnGuardar.Visible = false;


        this.aCantidad.Visible = false;
        this.lblMaximoProducto.Visible = false;

        modalNuevo.Show();
        //modalConsulta.Show();
    }

    #endregion
}