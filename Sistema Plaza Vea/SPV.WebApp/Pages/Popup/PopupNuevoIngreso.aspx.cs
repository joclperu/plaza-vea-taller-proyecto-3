using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class Pages_Popup_PopupNuevoIngreso : System.Web.UI.Page
{
    EN_OrdenCompra oEN_OC = new EN_OrdenCompra();
    EN_GuiaRemision oEN_GR = new EN_GuiaRemision();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InicializarPagina();
        }
    }

    private void InicializarPagina()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["param"]) &&
            !string.IsNullOrEmpty(Request.QueryString["modo"]))
        {
            this.hdIdProveedor.Value = "0";
            this.hdIdOc.Value = "0";
            Session["listaProductos_pop"] = null;
            Modo();
        }
    }

    private void Modo()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["modo"]))
        {
            if (Request.QueryString["modo"].Equals("C"))//Consulta
            {
                this.lblTituloModo.Text = "Consulta Ingresos de Mercadería".ToUpper();

                oEN_OC = new EN_OrdenCompra();
                oEN_OC = ConsultarOrden();

                this.txtNroOc.Text = oEN_OC.NroOrdenCompra;
                this.txtProveedor.Text = oEN_OC.nomProveedor;
                this.txtFecReg.Text = oEN_OC.FechaOC.ToShortDateString();
                this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
                this.hdIdProveedor.Value = oEN_OC.codProveedor.ToString();
                this.hdEstadoOrden.Value = oEN_OC.codEstado.ToString();//2= completado
                this.hdIdOc.Value = oEN_OC.CodigoOC.ToString();

                List<EN_GuiaRemision> olstEN_GR = new List<EN_GuiaRemision>();
                oEN_OC.ncodGuiaRemision = Request.QueryString["Nro_guia"];
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
            }

            if (Request.QueryString["modo"].Equals("N"))//Nuevo
            {
                oEN_OC = new EN_OrdenCompra();
                oEN_OC = ConsultarOrden();

                CargarProductos();
                gvProductos_Vacio();

                this.txtNroOc.Text = oEN_OC.NroOrdenCompra;
                this.txtProveedor.Text = oEN_OC.nomProveedor;
                this.txtFecReg.Text = DateTime.Now.ToShortDateString();
                this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
                this.hdIdProveedor.Value = oEN_OC.codProveedor.ToString();
                this.hdEstadoOrden.Value = oEN_OC.codEstado.ToString();//2= completado
                this.hdIdOc.Value = oEN_OC.CodigoOC.ToString();

                this.btnAgregar.OnClientClick = "return fn_ValidarMonto();";
                this.btnGuardar.OnClientClick = "return fn_Validar();";

            }
        }
    }

    private void CargarProductos()
    {
        Session["listaProductos_pop"] = oEN_OC.listDetOc;
        this.ddlProductos.DataSource = oEN_OC.listDetOc;
        this.ddlProductos.DataTextField = "nNomProducto";
        this.ddlProductos.DataValueField = "nCodProducto";
        this.ddlProductos.DataBind();
        SetearDiferencia(oEN_OC.listDetOc);
        SetearUnidadMedida(oEN_OC.listDetOc);
    }

    private EN_OrdenCompra ConsultarOrden()
    {
        EN_OrdenCompra oEN_OrdenCompra = new EN_OrdenCompra();
        oEN_OrdenCompra.CodigoOC = int.Parse(Request.QueryString["param"]);
        oEN_OrdenCompra.codTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

        EN_OrdenCompra result = new EN_OrdenCompra();
        result = new BL_OrdenCompra().Consultar(oEN_OrdenCompra);
        return result;
    }


    protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<EN_DetalleOrdenCompra> olstProductos = new List<EN_DetalleOrdenCompra>();
        olstProductos = (List<EN_DetalleOrdenCompra>)Session["listaProductos_pop"];
        SetearDiferencia(olstProductos);
        SetearUnidadMedida(olstProductos);
        this.txtCantidad.Text = "";
    }

    /// <summary>
    /// Calcula el maximo por producto
    /// </summary>
    /// <param name="olstProductos"></param>
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

    /// <summary>
    /// Setea la unidad medida del producto seleccionado
    /// </summary>
    /// <param name="olstProductos"></param>
    private void SetearUnidadMedida(List<EN_DetalleOrdenCompra> olstProductos)
    {
        int producto = Convert.ToInt32(this.ddlProductos.SelectedValue);

        var unidadmedida = olstProductos
                    .Where(x => x.nCodProducto == producto)
                    .Select(x => x.cUnidadMedida)
                    .ToList();

        this.hdUnidadMedida.Value = unidadmedida[0].ToString();
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
    }

    /// <summary>
    /// Agrega los productos a la grilla
    /// </summary>
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

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.hdEstadoOrden.Value.Equals("2"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Está Orden de Compra esta completada.)", true);
                return;
            }

            String msg = "";
            bool esCorrecto = ValidarTotalesGrilla(ref msg);
            if (!esCorrecto)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('{0}')", msg), true);
                return;
            }


            List<EN_DetalleNotaDocumento> ListaDetalle = new List<EN_DetalleNotaDocumento>();
            ListaDetalle = recuperarDetalleNotaDocumento();

            int resultCodDocumento = RegistrarGuiaRemision(ListaDetalle);
            if (resultCodDocumento > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RetornarValores", "alert('Operación realizada con éxito');fr_ReturnValues('1');", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Ocurrio un error revisar el log')", true);
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('Ocurrio un error revisar el log :{0})", ex.Message.ToString()), true);
        }



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

    private int RegistrarNotaIngreso(List<EN_DetalleNotaIngreso> olstLista)
    {
        EN_NotaIngreso oEN_NotaIngreso = new EN_NotaIngreso();
        oEN_NotaIngreso.NCodGuiaRemision = this.txtNroGuiaRemis.Text.Trim().ToUpper();
        return new BL_NotaIngreso().Registrar(oEN_NotaIngreso, olstLista);
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
}