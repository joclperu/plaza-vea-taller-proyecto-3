using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.IO;
//using Entidades = DEVCON.Alife.Pacientes.Entidades;

/// <summary>
/// Summary description for UtilitarioWeb
/// </summary>
public class UtilitarioWeb
{
    public UtilitarioWeb(){}

    public void validarSesionActiva(
        System.Web.UI.Page page)
    {
        if (page.Session["objUsuario"] == null)
            //page.Response.Redirect(page.Request.ApplicationPath + @"/Mensaje.aspx", true);
            page.Response.Redirect(page.Request.ApplicationPath + @"/Mensaje.aspx?mensaje=Su sesión ha expirado. Por favor ingrese nuevamente a la aplicación");
    }

    //public void validarAccesoPagina(System.Web.UI.Page page,string strAutorizacion)
    //{
    //    if (!validarAcceso(page, strAutorizacion))
    //        page.Response.Redirect(page.Request.ApplicationPath + @"/Mensaje.aspx?mensaje=Usted no tiene acceso a esta opción del sistema");
    //}

    //public bool validarAcceso(
    //    System.Web.UI.Page page,
    //    string strAutorizacion)
    //{
    //    Entidades.Usuario objUsuario = (Entidades.Usuario)page.Session["objUsuario"];
    //    bool respuesta = false;
    //    foreach (Entidades.PermisoXperfil objPermisoxPerfil in objUsuario.PermisoxPerfil)
    //    {
    //        if (objPermisoxPerfil.Permiso == strAutorizacion)
    //        {
    //            respuesta = true;
    //            break;
    //        }
    //    }
    //    return respuesta;
    //}

    //public int getUsuarioSesion(
    //    System.Web.UI.Page page)
    //{
    //    Entidades.Usuario objUsuario = (Entidades.Usuario)page.Session["objUsuario"];
    //    if (objUsuario == null)
    //        throw new Exception("ALIFE: No se pudo determinar el usuario de la sesión actual.");
    //    return objUsuario.Id;
    //}

    public void limpiarSesion(
        System.Web.UI.Page page)
    {
        for (int i = page.Session.Keys.Count - 1; i >= 0; i--)
        {
            if (page.Session.Keys[i].ToString() != "objUsuario")
                page.Session.RemoveAt(i);
        }
    }

    public void cerrarSesion(
        System.Web.UI.Page page)
    {
        page.Session.RemoveAll();
        page.Session.Abandon();
    }

    public void controlarError(System.Web.UI.Page page, Exception ex)
    {
        escribirLog(page, ex);
        page.Response.Redirect(page.Request.ApplicationPath + @"/Mensaje.aspx");
        //page.Response.Redirect(page.Request.ApplicationPath + @"/Mensaje.aspx?mensaje=Lo sentimos en este momento el servidor se encuentra saturado, intentelo mas tarde");
    }

    private void escribirLog(System.Web.UI.Page page, Exception ex)
    {
        FileStream fs = new FileStream(ConfigurationManager.AppSettings["rutaArchivoLog"], FileMode.Append, FileAccess.Write, FileShare.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(DateTime.Now.ToString());
        sw.WriteLine(ex.ToString());
        sw.WriteLine();
        sw.Close();
    }

    public void cargarCombo(DropDownList pobjDDL, DataTable pdtbFuente, string pstrColumnaTexto, string pstrColumnaValor)
    {
        pobjDDL.DataSource = pdtbFuente;
        pobjDDL.DataValueField = pstrColumnaValor;
        pobjDDL.DataTextField = pstrColumnaTexto;
       
        pobjDDL.DataBind();
        if (pobjDDL.Items.Count > 0)
            pobjDDL.SelectedIndex = 0;
    }

    public void cargarComboYSeleccione(DropDownList pobjDDL, DataTable pdtbFuente, string pstrColumnaTexto, string pstrColumnaValor, string pstrItem)
    {
        cargarCombo(pobjDDL, pdtbFuente, pstrColumnaTexto, pstrColumnaValor);
        pobjDDL.Items.Insert(0, new ListItem(pstrItem, "0"));
        pobjDDL.SelectedIndex = 0;
    }

    public void cargarComboSoloSeleccione(DropDownList pobjDDL, string pstrItem)
    {
        pobjDDL.Items.Clear();
        pobjDDL.Items.Insert(0, new ListItem(pstrItem, "0"));
        pobjDDL.SelectedIndex = 0;
        pobjDDL.Enabled = false;
    }

    public string formatearMonto(double pdblMonto)
    {
        return pdblMonto.ToString("#,##0.00");
    }

    public string formatearMontoMoneda(double pdblMonto, string pstrSimboloMoneda)
    {
        return pstrSimboloMoneda + " " + formatearMonto(pdblMonto);
    }

    public double formatearMontoIn(string pstrMonto)
    {
        if (pstrMonto.Trim().Length == 0)
            return 0.00;
        string[] partes = pstrMonto.Trim().Split(char.Parse(ConfigurationManager.AppSettings["separadorDecimal"]));
        if (partes.Length > 2)
            throw new FormatException("Monto con mas de un separador decimal");
        double resultado = 0;
        resultado += int.Parse(partes[0]);
        if (partes.Length > 1)
        {
            if (int.Parse(partes[1]) > 0)
            {
                resultado += (int.Parse(partes[1]) / (Math.Pow(10.00, partes[1].Length)));
            }
        }
        return resultado;
    }

    public string formatearCodigo(int pintCodigo)
    {
        return pintCodigo.ToString("00000000");
    }

    public string formatearCodigo(object pobjCodigo)
    {
        return Convert.ToInt32(pobjCodigo).ToString("00000000");
    }

    public string formatearFechaOUT(DateTime pdtmFecha)
    {
        if (pdtmFecha.Ticks > 0)
            return pdtmFecha.ToString(ConfigurationManager.AppSettings["formatoFecha"]);
        else
            return "";
    }

    public DateTime formatearFechaIN(string pstrFecha)
    {
        string strFormatoFecha = ConfigurationManager.AppSettings["formatoFecha"];
        return new DateTime(
            Convert.ToInt32(pstrFecha.Substring(strFormatoFecha.IndexOf("yyyy"), 4)), 
            Convert.ToInt32(pstrFecha.Substring(strFormatoFecha.IndexOf("MM"), 2)), 
            Convert.ToInt32(pstrFecha.Substring(strFormatoFecha.IndexOf("dd"), 2)));
    }

    public string formatearHoraOUT(DateTime pdtmHora)
    {
        if (pdtmHora.Ticks > 0)
            return pdtmHora.ToString("HH:mm");
        else
            return "";
    }

    public DateTime formatearHoraIN(DateTime pdtmFecha, string pstrHora)
    {
        return new DateTime(
            pdtmFecha.Year, 
            pdtmFecha.Month, 
            pdtmFecha.Day,
            Convert.ToInt32(pstrHora.Substring(11,2)),
            Convert.ToInt32(pstrHora.Substring(14, 2)),
            0);
    }

    public double formatearPorcentaje(double pdblValor)
    {
        return pdblValor * 100;
    }

    public DataTable listarTablaHorario(bool pblnMasMediaHora)
    {
        DataRow drwHorario = null;
        DataTable dtbHorario = new DataTable();
        dtbHorario.Columns.Add("id");
        dtbHorario.Columns.Add("descripcion");

        if (!pblnMasMediaHora)
        {
            drwHorario = dtbHorario.NewRow();
            drwHorario["id"] = "01/01/1900 07:00:00";
            drwHorario["descripcion"] = "7:00";
            dtbHorario.Rows.Add(drwHorario);
        }


        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 07:30:00";
        drwHorario["descripcion"] = "7:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 08:00:00";
        drwHorario["descripcion"] = "8:00";
        dtbHorario.Rows.Add(drwHorario);


        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 08:30:00";
        drwHorario["descripcion"] = "8:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 09:00:00";
        drwHorario["descripcion"] = "9:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 09:30:00";
        drwHorario["descripcion"] = "9:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 10:00:00";
        drwHorario["descripcion"] = "10:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 10:30:00";
        drwHorario["descripcion"] = "10:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 11:00:00";
        drwHorario["descripcion"] = "11:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 11:30:00";
        drwHorario["descripcion"] = "11:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 12:00:00";
        drwHorario["descripcion"] = "12:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 12:30:00";
        drwHorario["descripcion"] = "12:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 13:00:00";
        drwHorario["descripcion"] = "13:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 13:30:00";
        drwHorario["descripcion"] = "13:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 14:00:00";
        drwHorario["descripcion"] = "14:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 14:30:00";
        drwHorario["descripcion"] = "14:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 15:00:00";
        drwHorario["descripcion"] = "15:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 15:30:00";
        drwHorario["descripcion"] = "15:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 16:00:00";
        drwHorario["descripcion"] = "16:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 16:30:00";
        drwHorario["descripcion"] = "16:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 17:00:00";
        drwHorario["descripcion"] = "17:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 17:30:00";
        drwHorario["descripcion"] = "17:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 18:00:00";
        drwHorario["descripcion"] = "18:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 18:30:00";
        drwHorario["descripcion"] = "18:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 19:00:00";
        drwHorario["descripcion"] = "19:00";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 19:30:00";
        drwHorario["descripcion"] = "19:30";
        dtbHorario.Rows.Add(drwHorario);

        drwHorario = dtbHorario.NewRow();
        drwHorario["id"] = "01/01/1900 20:00:00";
        drwHorario["descripcion"] = "20:00";
        dtbHorario.Rows.Add(drwHorario);


        if (pblnMasMediaHora)
        {
            drwHorario = dtbHorario.NewRow();
            drwHorario["id"] = "01/01/1900 20:30:00";
            drwHorario["descripcion"] = "20:30";
            dtbHorario.Rows.Add(drwHorario);
        }

        return dtbHorario;
    }

    void limpiarControles(Control pctrlContenedor) 
    {
        foreach (Control ctrl in pctrlContenedor.Controls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            if (ctrl is DropDownList)
                ((DropDownList)ctrl).SelectedIndex = 0;
            if (ctrl is CheckBox)
                ((CheckBox)ctrl).Checked = false;
            else if (ctrl.HasControls())
                limpiarControles(ctrl);
        }
    }
}
