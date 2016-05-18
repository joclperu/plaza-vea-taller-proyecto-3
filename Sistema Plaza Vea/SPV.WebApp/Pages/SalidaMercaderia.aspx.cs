using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class Pages_SalidaMercaderia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.btnConsultar.OnClientClick = "return fn_ValidarOd();";
            //this.btnNuevo.OnClientClick = "return fn_PopupNuevaSalida('');";
            this.btnNuevo.Visible = false;
            gvDetalleOrdenDespacho_Vacio();
            gvNotasDocumento_Vacio();

        }
    }

    private void ListarNotasDocumento(int ncodDocumento)
    {
        EN_NotaDocumento oEN_NotaDocumento = new EN_NotaDocumento();
        oEN_NotaDocumento.cTipoMov = "2";
        oEN_NotaDocumento.ncodDespacho = ncodDocumento;

        List<EN_NotaDocumento> list = new List<EN_NotaDocumento>();
        list = new BL_NotaDocumento().Listar(oEN_NotaDocumento);
        if (list.Any())
        {
            this.gvNotasDocumento.DataSource = list;
            this.gvNotasDocumento.DataBind();
        }
        else
        {
            gvNotasDocumento_Vacio();
        }
    }


    private void gvNotasDocumento_Vacio()
    {
        EN_NotaDocumento objApli = new EN_NotaDocumento();
        List<EN_NotaDocumento> lstApli = new List<EN_NotaDocumento>();
        objApli.cObservacion = "EMPTY";
        lstApli.Add(objApli);
        this.gvNotasDocumento.DataSource = lstApli;
        this.gvNotasDocumento.DataBind();
        this.gvNotasDocumento.Rows[0].Visible = false;
    }


    private void gvDetalleOrdenDespacho_Vacio()
    {
        EN_DetalleOrdenDespacho objApli = new EN_DetalleOrdenDespacho();
        List<EN_DetalleOrdenDespacho> lstApli = new List<EN_DetalleOrdenDespacho>();
        objApli.nom_producto = "EMPTY";
        lstApli.Add(objApli);
        this.gvDetalleOrdenDespacho.DataSource = lstApli;
        this.gvDetalleOrdenDespacho.DataBind();
        this.gvDetalleOrdenDespacho.Rows[0].Visible = false;
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {

        if (this.txtOrdenDespacho.Text.Trim().Length > 0)
        {
            EN_OrdenDespacho oEN_OrdenDespacho = new EN_OrdenDespacho();
            oEN_OrdenDespacho.ncodDespacho = int.Parse(this.txtOrdenDespacho.Text.Trim());
            oEN_OrdenDespacho.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

            EN_OrdenDespacho oresult = new EN_OrdenDespacho();
            oresult = new BL_OrdenDespacho().Consultar(oEN_OrdenDespacho);

            if (oresult.ncodDespacho > 0)
            {

                ListarNotasDocumento(oresult.ncodDespacho);
                hdEstadoOD.Value = oresult.ncodEstado.ToString();

                if (oresult.ncodEstado == 2)  // COMPLETADO
                {
                    this.btnNuevo.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Orden de Despacho completada, no se permite registrar notas de salida');", true);
                }
                else
                {
                    this.btnNuevo.Visible = true;
                }




                this.txtEstado.Text = oresult.nom_estado.ToUpper();
                if (oresult.listDet.Any())
                {
                    this.gvDetalleOrdenDespacho.DataSource = oresult.listDet;
                    this.gvDetalleOrdenDespacho.DataBind();
                }
                else
                {
                    gvNotasDocumento_Vacio();
                    gvDetalleOrdenDespacho_Vacio();
                }
            }
            else
            {
                this.btnNuevo.Visible = false;
                this.txtEstado.Text = "";
                gvDetalleOrdenDespacho_Vacio();
                gvNotasDocumento_Vacio();
            }
        }
        else
        {
            this.btnNuevo.Visible = false;
        }




    }
    protected void btnEvaluar_Click(object sender, EventArgs e)
    {
        if (this.txtOrdenDespacho.Text.Trim().Length > 0)
        {
            EN_OrdenDespacho oEN_OrdenDespacho = new EN_OrdenDespacho();
            oEN_OrdenDespacho.ncodDespacho = int.Parse(this.txtOrdenDespacho.Text.Trim());
            oEN_OrdenDespacho.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

            EN_OrdenDespacho oresult = new EN_OrdenDespacho();
            oresult = new BL_OrdenDespacho().Consultar(oEN_OrdenDespacho);

            if (oresult.ncodDespacho > 0)
            {

                ListarNotasDocumento(oresult.ncodDespacho);

                this.hdEstadoOD.Value = oresult.ncodEstado.ToString();
                if (oresult.ncodEstado == 2)  // COMPLETADO
                {
                    this.btnNuevo.Visible = false;
                }

                this.txtEstado.Text = oresult.nom_estado.ToUpper();
                if (oresult.listDet.Any())
                {
                    this.gvDetalleOrdenDespacho.DataSource = oresult.listDet;
                    this.gvDetalleOrdenDespacho.DataBind();

                    this.btnNuevo.Visible = true;
                }
                else
                {
                    gvNotasDocumento_Vacio();
                    gvDetalleOrdenDespacho_Vacio();
                }
            }
            else
            {
                this.btnNuevo.Visible = false;
                this.txtEstado.Text = "";
                gvDetalleOrdenDespacho_Vacio();
                gvNotasDocumento_Vacio();
            }
        }
        else
        {
            this.btnNuevo.Visible = false;
        }
    }

    //protected void gvNotasDocumento_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label lblcodDespacho = (Label)e.Row.FindControl("lblcodDespacho");
    //        Label lblCodDocumento = (Label)e.Row.FindControl("lblCodDocumento");


    //        ImageButton imgConsultar = (ImageButton)e.Row.FindControl("imgConsultar");
    //        imgConsultar.OnClientClick = string.Format("return fnPopupConsulta('{0}');", lblCodDocumento.Text);

    //    }
    //}





    #region "Nueva Salida Modal"


    public void LimpiarControlesPop()
    {
        this.txtOrdenDespachopop.Text = "";
        this.txtObservacion.Text = "";
        this.txtCantidad.Text = "";
        gvProductos_Vacio();

    }





    protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<EN_DetalleOrdenDespacho> olstProductos = new List<EN_DetalleOrdenDespacho>();
        olstProductos = (List<EN_DetalleOrdenDespacho>)Session["listaProductos_pop"];
        SetearDiferencia(olstProductos);
        SetearUnidadMedida(olstProductos);
        this.txtCantidad.Text = "";

        modalNuevo.Show();
    }

    private void SetearDiferencia(List<EN_DetalleOrdenDespacho> olstProductos)
    {
        int producto = Convert.ToInt32(this.ddlProductos.SelectedValue);

        var diferencia = olstProductos
            .Where(x => x.ncodProducto == producto)
            .Select(x => x.nCantDiferencia)
            .ToList();

        this.hdMontoPermitido.Value = diferencia[0].ToString();
        this.lblMaximoProducto.Text = "Necesario para completar la O.D. : " + diferencia[0].ToString();
    }

    private void SetearUnidadMedida(List<EN_DetalleOrdenDespacho> olstProductos)
    {
        int producto = Convert.ToInt32(this.ddlProductos.SelectedValue);

        var unidadmedida = olstProductos
                    .Where(x => x.ncodProducto == producto)
                    .Select(x => x.nom_unidad)
                    .ToList();

        this.hdUnidadMedida.Value = unidadmedida[0].ToString();
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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.hdEstadoOD.Value.Equals("2"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Está Orden de despacho esta completada.')", true);
                modalNuevo.Show();
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

            //Carga detalle nota documento
            List<EN_DetalleNotaDocumento> ListaDetalle = new List<EN_DetalleNotaDocumento>();
            ListaDetalle = recuperarDetalleNotaDocumento();

            int resultDocumento = RegistrarNotaDocumento(ListaDetalle);
            if (resultDocumento > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RetornarValores", "alert('Operación realizada con éxito');", true);
                btnConsultar_Click(null, null);
                modalNuevo.Hide();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", "alert('Ocurrio un error revisar el log')", true);
                modalNuevo.Hide();
            }



        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", string.Format("alert('Ocurrio un error revisar el log :{0})", ex.Message.ToString()), true);
            modalNuevo.Show();
        }
    }

    public bool ValidarTotalesGrilla(ref string msg_return)
    {
        bool result = true;


        List<EN_DetalleOrdenDespacho> olstProductOC = new List<EN_DetalleOrdenDespacho>();
        olstProductOC = (List<EN_DetalleOrdenDespacho>)Session["listaProductos_pop"];

        List<EN_Producto> olst = new List<EN_Producto>();
        foreach (GridViewRow gvRow in gvProductos.Rows)
        {
            EN_Producto oEN_Producto = new EN_Producto();
            oEN_Producto.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
            oEN_Producto.CANTIDAD = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
            olst.Add(oEN_Producto);
        }

        foreach (EN_DetalleOrdenDespacho item in olstProductOC)
        {
            var Total = olst.Where(c => c.NCodProducto == item.ncodProducto).Sum(c => c.CANTIDAD);

            if (Total > item.nCantDiferencia)
            {
                msg_return = string.Format("La suma total del producto {0} excede la diferencia : {1}", item.nom_producto, item.nCantDiferencia.ToString());
                result = false;
                break;
            }

        }
        return result;
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
                    oEN_DetalleNotaDocumento.NCodProducto = int.Parse(((Label)gvRow.FindControl("lblIdProducto")).Text);
                    oEN_DetalleNotaDocumento.NCantidad = int.Parse(((Label)gvRow.FindControl("lblCantidad")).Text);
                    oEN_DetalleNotaDocumento.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;
                    olstdetalleNota.Add(oEN_DetalleNotaDocumento);
                }
            }
        }
        return olstdetalleNota;
    }

    private int RegistrarNotaDocumento(List<EN_DetalleNotaDocumento> ListaDetalle)
    {
        EN_NotaDocumento oEN_NotaDocumento = new EN_NotaDocumento();
        oEN_NotaDocumento.cTipoMov = "2"; //salida mercaderia
        oEN_NotaDocumento.cObservacion = this.txtObservacion.Text.Trim().ToUpper();
        oEN_NotaDocumento.ncodDespacho = int.Parse(this.txtOrdenDespacho.Text);// int.Parse(Request.QueryString["param"]);
        return new BL_NotaDocumento().Registrar(oEN_NotaDocumento, ListaDetalle);

    }

    #endregion


    private EN_OrdenDespacho ConsultarOrden()
    {
        EN_OrdenDespacho oEN_OrdenDespacho = new EN_OrdenDespacho();
        oEN_OrdenDespacho.ncodDespacho = int.Parse(this.txtOrdenDespacho.Text);
        oEN_OrdenDespacho.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

        EN_OrdenDespacho oresult = new EN_OrdenDespacho();
        oresult = new BL_OrdenDespacho().Consultar(oEN_OrdenDespacho);
        return oresult;
    }

    private EN_NotaDocumento ConsultarNota(String cododcumento)
    {
        EN_NotaDocumento oEN_NotaDocumento = new EN_NotaDocumento();
        oEN_NotaDocumento.nCodDocumento = int.Parse(cododcumento);
        EN_NotaDocumento oresultNota = new EN_NotaDocumento();
        oresultNota = new BL_NotaDocumento().Consultar(oEN_NotaDocumento);
        return oresultNota;
    }

    protected void imgConsultar_Click(object sender, ImageClickEventArgs e)
    {
        //Listar
        LimpiarControlesPop();

        ImageButton imgConsultar = ((ImageButton)(sender));
        GridViewRow row = ((GridViewRow)(imgConsultar.NamingContainer));

        Label lblCodDocumento = (Label)row.FindControl("lblCodDocumento");


        this.gvProductos.Visible = false;
        this.gvProductosconsulta.Visible = true;
        this.btnAgregar.Visible = false;
        this.ddlProductos.Enabled = false;
        this.txtCantidad.Enabled = false;
        this.btnGuardar.Visible = false;
        this.txtOrdenDespachopop.Text = this.txtOrdenDespacho.Text;// Request.QueryString["param"];
        this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
        this.txtObservacion.Enabled = false;

        EN_OrdenDespacho oresult = ConsultarOrden();

        this.txtEstadoPop.Text = oresult.nom_estado.ToUpper();


        EN_NotaDocumento oresultNota = ConsultarNota(lblCodDocumento.Text);

        this.txtFecReg.Text = oresultNota.dFecha.ToShortDateString();
        this.txtObservacion.Text = oresultNota.cObservacion;



        List<EN_DetalleNotaDocumento> olst = new List<EN_DetalleNotaDocumento>();
        olst = new BL_DetalleNotaDocumento().Listar(int.Parse(lblCodDocumento.Text));

        if (olst.Any())
        {
            this.gvProductosconsulta.DataSource = olst;
            this.gvProductosconsulta.DataBind();
        }

        modalNuevo.Show();
    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Session["listaProductos_pop"] = null;

        this.btnAgregar.Visible = true;
        this.ddlProductos.Enabled = true;
        this.txtCantidad.Enabled = true;
        this.btnGuardar.Visible = true;
        this.txtObservacion.Enabled = true;

        this.gvProductos.Visible = true;
        this.gvProductosconsulta.Visible = false;

        LimpiarControlesPop();
        this.txtusrLog.Text = ((EN_Usuario)Session["usuario"]).cID;
        this.txtFecReg.Text = DateTime.Now.ToShortDateString();
        this.txtOrdenDespachopop.Text = this.txtOrdenDespacho.Text;


        EN_OrdenDespacho oEN_OrdenDespacho = new EN_OrdenDespacho();
        oEN_OrdenDespacho.ncodDespacho = int.Parse(this.txtOrdenDespacho.Text); //int.Parse(Request.QueryString["param"]);
        oEN_OrdenDespacho.ncodTienda = ((EN_Usuario)Session["usuario"]).nCodTienda;

        EN_OrdenDespacho oresult = new EN_OrdenDespacho();
        oresult = new BL_OrdenDespacho().Consultar(oEN_OrdenDespacho);

        this.txtEstadoPop.Text = oresult.nom_estado.ToUpper();
        this.hdEstadoOD.Value = oresult.ncodEstado.ToString();

        Session["listaProductos_pop"] = oresult.listDet;
        this.ddlProductos.DataSource = oresult.listDet;
        this.ddlProductos.DataTextField = "nom_producto";
        this.ddlProductos.DataValueField = "ncodProducto";
        this.ddlProductos.DataBind();

        SetearDiferencia(oresult.listDet);
        SetearUnidadMedida(oresult.listDet);

        this.btnAgregar.OnClientClick = "return fn_ValidarMonto();";
        this.btnGuardar.OnClientClick = "return fn_Validar();";
        gvProductos_Vacio();


        modalNuevo.Show();
    }

}