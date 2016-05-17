<%@ Import Namespace="SPV.BE" %>
<%@ Language="C#" 
    MasterPageFile="~/Principal.master" 
    AutoEventWireup="true" 
    CodeFile="SPV_Orden_Compra_Mantenimiento.aspx.cs" 
    Inherits="SPV_Compras_SPV_Orden_Compra_Mantenimiento" %>

<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../SPV_UserControl/TextBoxFecha.ascx" TagName="TextBoxFecha" TagPrefix="uc1" %>
<%@ Register Src="~/SPV_UserControl/ComboMaestro.ascx" TagName="ComboMaestro" TagPrefix="uc2" %>
<%@ Register Src="~/SPV_UserControl/ComboDinamico.ascx" TagName="ComboDinamico" TagPrefix="uc5" %>
<%@ Register Src="~/SPV_UserControl/ComboProveedor.ascx" TagName="ComboProveedor" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        var mstrError = "";

        function fc_GrabarDetalle() {
            document.getElementById("<%=this.BtnAgregar.ClientID %>").click();
            return false;
        }

        function Fc_ValidaDetalle() {
            if (fc_Trim(document.getElementById("<%=this.CboProducto.ClientID %>_CboListado").value) == "") {
                mstrError += mstrDebeSeleccionar + "producto.\n";
            }
            if (fc_Trim(document.getElementById("<%=this.txtCantidad.ClientID %>").value) == "") {
                mstrError += mstrDebeIngresar + "cantidad.\n";
            }

            if (mstrError != "") {
                alert(mstrError)
                mstrError = "";
                return false;
            }
            return confirm(mstrSeguroGrabar);
        }

        function Fc_CancelarPoput() {
            document.getElementById("<%=this.CboProducto.ClientID %>_CboListado").value = "";
            document.getElementById("<%=this.txtCantidad.ClientID %>").value = "";
            return false;
        }        
        
        function Fc_EliminarDet(){
            if (fc_Trim(document.getElementById("<%=this.TxhId_detalle_orden_compra.ClientID %>").value) == "") {
                alert(mstrSeleccioneUno)
                return false;
            }
            return confirm(mstrSeguroEliminarUno);
        }




        function Fc_ValidaEsperaStockProveedor() {
            return confirm(mstrSeguroEsperaStockProveedor);
        }

        function Fc_ValidaEsperaSolicitante() {
            return confirm(mstrSeguroEsperaSolicitante);
        }

        function Fc_ValidaPendienteAprobacion() {
            return confirm(mstrSeguroPendienteAprobacion);
        }

        function Fc_ValidaAprobar() {
            return confirm(mstrSeguroAprobar);
        }

        function Fc_ValidaDesaprobar() {
            return confirm(mstrSeguroDesaprobar);
        }
    </script>
    <asp:hiddenfield runat="server" id="TxhIdCabecera_orden_compra" />
    <asp:hiddenfield runat="server" id="TxhIdEstado" />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width:100%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="bottom">
                            <!--Cabecera-->
                            <asp:ImageButton ID="BtnEsperaStockProveedor" runat="server" ImageUrl="~/Images/iconos/b-conformidad.gif" ToolTip="ESPERA STOCK PROVEEDOR" Visible="false"
                                OnClientClick="javaScript:return Fc_ValidaEsperaStockProveedor();" OnClick="BtnEsperaStockProveedor_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-conformidad2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-conformidad.gif'"/>

                            <asp:ImageButton ID="BtnEsperaSolicitante" runat="server" ImageUrl="~/Images/iconos/b-propietarios.png" ToolTip="ESPERA SOLICITANTE" Visible="false"
                                OnClientClick="javaScript:return Fc_ValidaEsperaSolicitante();" OnClick="BtnEsperaSolicitante_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-propietarios2.png'" onmouseout="javascript:this.src='../Images/iconos/b-propietarios.png'"/>

                           <asp:ImageButton ID="BtnPendienteAprobacion" runat="server" ImageUrl="~/Images/iconos/b-terminarorden.gif" ToolTip="PENDIENTE APROBACIÓN" Visible="false"
                                OnClientClick="javaScript:return Fc_ValidaPendienteAprobacion();" OnClick="BtnPendienteAprobacion_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-terminarorden2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-terminarorden.gif'"/>
                            
                            <asp:ImageButton ID="BtnAprobar" runat="server" ImageUrl="~/Images/iconos/b-aceptar.gif" ToolTip="APROBAR" Visible="false"
                                OnClientClick="javaScript:return Fc_ValidaAprobar();" OnClick="BtnAprobar_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-aceptar2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-aceptar.gif'"/>

                            <asp:ImageButton ID="BtnDesaprobar" runat="server" ImageUrl="~/Images/iconos/b-cerrar.gif" ToolTip="RECHAZAR" Visible="false"
                                OnClientClick="javaScript:return Fc_ValidaDesaprobar();" OnClick="BtnDesaprobar_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-cerrar2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-cerrar.gif'"/>

                            <asp:ImageButton ID="BtnRegresar" runat="server" onclick="BtnRegresar_Click" ImageUrl="~/Images/iconos/b-regresar.gif" ToolTip="Regresar" Visible="false"
                                onmouseover="javascript:this.src='../Images/iconos/b-regresar2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-regresar.gif'" />
                            <!--/Cabecera-->
                            <!--Detalle Plan-->
                            <asp:imagebutton id="BtnAparece" runat="server" imageurl="~/Images/iconos/b-nuevo.gif" style="display: none;"/>                           
                            <asp:imagebutton id="BtnAgregar" runat="server" imageurl="~/Images/iconos/b-nuevo.gif"
                                OnClick="BtnGrabar_Click" style="display: none;"
                                onclientclick="javascript:return Fc_ValidaDetalle();"/>                            

                            <asp:ImageButton ID="BtnAgregarDetalle" OnClick="BtnAgregarDetalle_Click" runat="server" 
                                ImageUrl="~/Images/iconos/b-agregaritem.gif" ToolTip="Agregar Producto"
                                onmouseover="javascript:this.src='../Images/iconos/b-agregaritem2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-agregaritem.gif'" />
                        
                            <asp:ImageButton ID="BtnEliminarDet" runat="server" OnClientClick="javaScript:return Fc_EliminarDet();" 
                                OnClick="BtnEliminarDet_Click" ImageUrl="~/Images/iconos/b-eliminaritem.gif" ToolTip="Eliminar Producto"
                                onmouseover="javascript:this.src='../Images/iconos/b-eliminaritem2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-eliminaritem.gif'" />

                            <asp:imagebutton ID="BtnBuscarDet" runat="server" imageurl="~/Images/iconos/b-buscar.gif" ToolTip="Buscar" onclick="BtnBuscarDet_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-buscar2.gif'"  style="display: none;"
                                onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" Visible="false"/>    

                            <asp:ImageButton ID="BtnModificar" runat="server" OnClick="BtnAgregarDetalle_Click" />
                            <asp:ImageButton ID="BtnRegresarDet" runat="server" ImageUrl="~/Images/iconos/b-regresar.gif" ToolTip="Regresar" Visible="false"
                                OnClick="BtnRegresarDet_Click" onmouseover="javascript:this.src='../Images/iconos/b-regresar2.gif'" onmouseout="javascript:this.src='../Images/iconos/b-regresar.gif'" />
                            <!--/Detalle Plan-->
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr style="width: 100%">
            <td style="vertical-align: top; width: 100%;">
                <cc1:tabcontainer id="TabordenCompra" runat="server" activetabindex="0" CssClass="" OnActiveTabChanged="TabOrdenCompra_ActiveTabChanged" AutoPostBack="true" >
                    <cc1:TabPanel ID="TabCabPlan" runat="server" CssClass="">
                        <HeaderTemplate>
                            <table id="tblHeader0" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img id="imgTabIzq" alt="" src="../Images/Tabs/tab-izq.gif" /></td>
                                    <td class="TabCabeceraOff" onmouseover="javascript: onTabCabeceraOver('0');" onmouseout="javascript: onTabCabeceraOut('0');"><%= this.TipoAccion %> Orden Compra</td>
                                    <td><img id="imgTabDer" alt="" src="../Images/Tabs/tab-der.gif" /></td>
                                </tr>
                            </table>            
                        </HeaderTemplate>
                        <ContentTemplate>        
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr><!-- Cabecera -->
                                    <td><img width="100%" src="../Images/Tabs/borarriba.gif"></td>
                                </tr>
                                <tr><!-- Cuerpo -->
                                    <td style="background-color:#ffffff;vertical-align: top; height:470px; width:100%;">
                                        <asp:updatepanel id="upBusqueda" runat="server">
                                            <contenttemplate>
                                                <table width="99%" cellpadding="2" cellspacing="1" border="0" class="cuerponuevo" style="margin-left:5px; margin-right:5px; margin-top:5px; height:70px;">
                                                    <tr>
                                                        <td class="lineadatos" valign="bottom" colspan="6"><asp:label ID="Label4" runat="server" SkinID="DatosDivisiones">&nbsp;DATOS PRESUPUESTO&nbsp;</asp:label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%">Nro. Orden</td>
                                                        <td style="width:15%"><asp:TextBox ID="txtNumSerie" Enabled="false" MaxLength="10" runat="server" Width="40%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%">Estado</td>
                                                        <td style="width:30%"><uc2:ComboMaestro Width="90%" ID="cboEstado" EnabledValidacion="false" runat="server" OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"/></td>
                                                        <td style="width:10%">Tipo OC</td>
                                                        <td style="width:30%"><uc2:ComboMaestro Width="90%" ID="cboTipo" EnabledValidacion="false" runat="server" OnSelectedIndexChanged="cboTipo_SelectedIndexChanged"/></td>
                                                        <td style="width:10%">Nro. Referencia</td>
                                                        <td style="width:15%"><asp:TextBox ID="txtNumReferencia" Enabled="false" MaxLength="10" runat="server" Width="40%"></asp:TextBox></td>
                                                    </tr>    
                                                    <tr>
                                                        <td style="width:10%">Proveedor</td>
                                                        <td style="width:30%"><uc6:ComboProveedor Width="90%" ID="cboProveedor" EnabledValidacion="false" runat="server" OnSelectedIndexChanged="cboProveedor_SelectedIndexChanged"/></td>
                                                        <td style="width:10%">Fecha</td>
                                                        <td style="width:30%"><uc1:TextBoxFecha ID="TxtFecCreacion" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:10%">Observación</td>
                                                        <td colspan="5"><asp:TextBox id="TxtInsertObservación" runat="server" Width="100%"  MaxLength="500" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                                    </tr>                                                    
                                                </table> 
                                            </contenttemplate>                                            
                                        </asp:updatepanel>                                       
                                    </td>
                                </tr>                    
                                <tr><!-- Pie -->
                                    <td><img width="100%" src="../Images/Tabs/borabajo.gif"></td>
                                </tr>
                            </table>
                        </ContentTemplate>                        
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabDetalleordenCompra" runat="server" CssClass="">
                        <HeaderTemplate>
                            <table id="tblHeader1" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td><img id="img3" alt="" src="../Images/Tabs/tab-izq.gif" /></td>
                                    <td class="TabCabeceraOff" onmouseover="javascript: onTabCabeceraOver('1');" onmouseout="javascript: onTabCabeceraOut('1');">Detalle Orden Compra</td>
                                    <td><img id="img4" alt="" src="../Images/Tabs/tab-der.gif" /></td>
                                </tr>
                            </table>            
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr> <!-- Cabecera -->
                                    <td><img width="100%" src="../Images/Tabs/borarriba.gif"></td>
                                </tr>
                                <tr style="height:435px"><!-- Cuerpo -->
                                     <td style="background-color:#ffffff" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-left:5px; margin-right:5px">
                                            <tr>
                                                <td valign="top" style="padding-top:15px;">
                                                    <asp:UpdatePanel ID="upMantenimiento" runat="server">
                                                        <contenttemplate>
                                                            <asp:hiddenfield runat="server" id="TxhId_detalle_orden_compra" />
                                                           <asp:GridView id="GrwData" runat="server" SkinID="Grilla" Width="100%" OnRowDataBound="GrwData_RowDataBound" 
                                                                OnPageIndexChanging="GrwData_PageIndexChanging" DataKeyNames="id_detalle_orden_compra" AutoGenerateColumns="False" 
                                                                AllowPaging="True" AllowSorting="True" OnSorting="GrwData_Sorting">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Producto" SortExpression="de_producto">
                                                                        <ItemStyle Width="60%" horizontalalign="left"/>
                                                                        <HeaderStyle Width="60%" />
                                                                        <ItemTemplate>
                                                                            <%# ((DetalleOrdenCompraBE)Container.DataItem).de_producto%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cantidad" SortExpression="va_cantidad">
                                                                            <ItemStyle Width="10%" horizontalalign="Right"/>
                                                                        <HeaderStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <%# ((DetalleOrdenCompraBE)Container.DataItem).va_cantidad%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField> 
                                                                    <asp:TemplateField HeaderText="Estado" SortExpression="de_estado">
                                                                            <ItemStyle Width="10%" horizontalalign="Center"/>
                                                                        <HeaderStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <%# ((DetalleOrdenCompraBE)Container.DataItem).de_estado%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                        </contenttemplate>
                                                        <triggers><asp:AsyncPostBackTrigger ControlID="BtnBuscarDet" EventName="click" /></triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><!-- Pie -->
                                     <td><img width="100%" src="../Images/Tabs/borabajo.gif"></td>
                                </tr>
                            </table>            
                        </ContentTemplate>        
                    </cc1:TabPanel>    
                </cc1:tabcontainer>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        if ("<%=this.IndiceTabOn %>" != "") setTabCabeceraOn("<%=this.IndiceTabOn %>");
    </script>
    <asp:panel id="PanelRegistro" runat="server" height="90px" width="550px" style="display: none;
        background-repeat: repeat; background-image: url(../Images/fondo_2.gif); padding-top: 0px;
        padding-bottom: 8px" cssclass="modalPopup">
        <table cellpadding="0" cellspacing="0" border="0" style="width:540px" >
            <tr style="width: 540px">
                <td style="padding-left:10px; padding-right:10px">
                    <table cellpadding="0" cellspacing="0" border="0" width="530px">
                        <tr valign="bottom" >
                            <td>
                                <asp:UpdatePanel id="upDetalleIncoterm2" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                        <table id="Table3" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td><img id="img1" alt="" src="../Images/Tabs/tab-izq.gif" /></td>
                                                <td class="TabCabeceraOn"><asp:Label ID="LblTipo" runat="server" Text="MODIFICAR"></asp:Label> Producto</td>
                                                <td><img id="img2" alt="" src="../Images/Tabs/tab-der.gif" /></td>
                                            </tr>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="right">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td style="width: 100%; height: 22px;" align="right">
                                            <asp:ImageButton ID="BtnGrabar" runat="server" ImageUrl="~/Images/iconos/b-guardar.gif"
                                                ToolTip="Grabar" OnClientClick="javaScript: return fc_GrabarDetalle()"
                                                onmouseover="javascript:this.src='../Images/iconos/b-guardar2.gif'" 
                                                onmouseout="javascript:this.src='../Images/iconos/b-guardar.gif'" />
                                            <asp:ImageButton ID="BtnCerrar" runat="server" ImageUrl="~/Images/iconos/b-cerrar.gif"
                                                ToolTip="Cerrar" 
                                                onmouseover="javascript:this.src='../Images/iconos/b-cerrar2.gif'" 
                                                onmouseout="javascript:this.src='../Images/iconos/b-cerrar.gif'" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel id="upDetalleIncoterm" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table width="530px" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <!-- Cabecera -->
                                    <td><img alt="" src="../Images/Mantenimiento/fbarr.gif" width="530px" /></td>
                                </tr>
                                <tr>
                                    <!-- Cuerpo -->
                                    <td style="background-color: #ffffff; vertical-align: top; height: 20px; width:520px;">
                                        <table width="520px" style="margin-left:5px; margin-right:5px;" cellpadding="1" cellspacing="1" border="0" class="cuerponuevo">
                                            <tr>  
                                                <td style="width:10%">Producto</td>
                                                <td style="width:90%"><uc5:ComboDinamico ID="CboProducto" runat="server" Width="100%" AutoPostBack="true"/></td>
                                            </tr>
                                            <tr>
                                                <td style="width:10%">Cantidad</td>
                                                <td style="width:90%"><asp:TextBox ID="txtCantidad" MaxLength="10" runat="server" Width="10%"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td> 
                                <tr>
                                    <!-- Pie -->
                                    <td><img alt="" src="../Images/Mantenimiento/fba.gif" width="530px" /></td>
                                </tr>
                            </table>
                        </contenttemplate>
                        <triggers><asp:AsyncPostBacktrigger ControlID="BtnModificar" EventName="Click"></asp:AsyncPostBacktrigger></triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:panel>
    <cc1:ModalPopupExtender ID="ModalKpi" runat="server" TargetControlID="BtnAparece"
        PopupControlID="PanelRegistro" CancelControlID="BtnCerrar" BackgroundCssClass="modalBackground"
        Enabled="true" RepositionMode="None" X="300" OnCancelScript="Fc_CancelarPoput()" Y="300">
    </cc1:ModalPopupExtender>
</asp:Content>