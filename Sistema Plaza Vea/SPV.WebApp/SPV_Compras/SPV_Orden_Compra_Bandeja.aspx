<%@ Import Namespace="SPV.BE" %>
<%@ Language="C#" 
    MasterPageFile="~/Principal.master" 
    AutoEventWireup="true" 
    CodeFile="SPV_Orden_Compra_Bandeja.aspx.cs" 
    Inherits="SPV_Compras_SPV_Orden_Compra_Bandeja" 
    Theme="Default"%>

<%@ MasterType VirtualPath="~/Principal.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../SPV_UserControl/TextBoxFecha.ascx" TagName="TextBoxFecha" TagPrefix="uc1" %>
<%@ Register Src="~/SPV_UserControl/ComboMaestro.ascx" TagName="ComboMaestro" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        var mstrError = "";
        function Fc_Elimina() {
            if (fc_Trim(document.getElementById('<%=this.Txhid_cabecera_orden_compra.ClientID%>').value) == "") {
                alert(mstrSeleccioneUno);
                return false;
            }
            return confirm(mstrSeguroEliminarUno);
        }

        function Fc_Limpiar() {
            
            return false;
        }

        function Fc_Buscar() {
            
            if (mstrError != "") {
                alert(mstrError);
                mstrError = "";
                return false;
            }
            return true;
        }
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="bottom" >
            <td style="width:30%">
                <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="TabCabeceraOn">Orden de Compra</td>                        
                    </tr>
                </table>
            </td>
            <td style="width:70%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right">
                            <asp:imagebutton id="BtnNuevoRequerimiento" runat="server" imageurl="../images/iconos/b-confrimarreserva.gif"
                                ToolTip="AGREGAR DESDE REQUERIMIENTO DE COMPRA" onclick="BtnNuevoRequerimiento_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-confrimarreserva2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-confrimarreserva.gif'" />

                            <asp:imagebutton id="BtnNuevoSolicitud" runat="server" imageurl="../images/iconos/b-confirmarsol.gif"
                                ToolTip="AGREGAR DESDE SOLICITUD DE COMPRA" onclick="BtnNuevoSolicitud_Click"
                                onmouseover="javascript:this.src='../Images/iconos/b-confirmarsol2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-confirmarsol.gif'" />
                
                            <asp:imagebutton id="BtnEliminar" runat="server" imageurl="~/Images/iconos/b-eliminar.gif" 
                                ToolTip="Anular" onclick="BtnEliminar_Click" OnClientClick="javascript:return Fc_Elimina();"
                                onmouseover="javascript:this.src='../Images/iconos/b-eliminar2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-eliminar.gif'" />
                
                            <asp:imagebutton id="BtnBuscar" runat="server" imageurl="~/Images/iconos/b-buscar.gif" 
                                ToolTip="Buscar" onclick="BtnBuscar_Click" onclientclick="javascript:return Fc_Buscar();"
                                onmouseover="javascript:this.src='../Images/iconos/b-buscar2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" />
                
                            <asp:imagebutton id="BtnLimpiar" runat="server" causesvalidation="False" imageurl="~/Images/iconos/b-limpiar.gif"
                                ToolTip="Limpiar" OnClientClick="javascript:return Fc_Limpiar();" 
                                onmouseover="javascript:this.src='../Images/iconos/b-limpiar2.gif'" 
                                onmouseout="javascript:this.src='../Images/iconos/b-limpiar.gif'"/>
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr style="width: 100%">
            <!-- Cabecera -->
            <td><img alt="" width="100%" src="../Images/Mantenimiento/fbarr.gif" /></td>
        </tr>
        <tr style="width: 100%">
            <td style="background-color: #ffffff; vertical-align: top; height: 470px;width: 100%;">
                <table cellpadding="1" cellspacing="1" style="margin-left:5px; margin-right:5px;width: 99%;" border="0">  
                    <tr>
                        <td><asp:Label ID="lbl" runat="server" SkinID="lblcb" >CRITERIOS DE BUSQUEDA</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:updatepanel id="upBusqueda" runat="server">
                                <contenttemplate>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td style="width:10%">Estado</td>
                                            <td style="width:10%"><uc2:ComboMaestro Width="50%" ID="cboEstado" runat="server" OnSelectedIndexChanged="cboEstado_SelectedIndexChanged"/></td>
                                            <td style="width:10%">Fecha Inicio</td>
                                            <td style="width:10%"><uc1:TextBoxFecha ID="TxtFecIni" runat="server" /></td>
                                            <td style="width:10%">Fecha Fin</td>
                                            <td style="width:10%"><uc1:TextBoxFecha ID="TxtFecFin" runat="server" /></td>
                                            <td style="width:10%">Nro Orden</td>
                                            <td style="width:10%"><asp:TextBox ID="txtNumSerie" MaxLength="10" runat="server" Width="90%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </contenttemplate>
                                </asp:updatepanel>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/iconos/fbusqueda.gif" Width="100%" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top:15px;">
                            <asp:UpdatePanel ID="upMantenimiento" runat="server">
                                <contenttemplate>
                                    <asp:ImageButton ID="BtnModificar" runat="server" OnClick="BtnNuevo_Click" />
                                    <asp:hiddenfield runat="server" id="Txhid_cabecera_orden_compra" />
                                    <asp:GridView id="GrwData" runat="server" SkinID="Grilla" Width="100%" OnRowDataBound="GrwData_RowDataBound" 
                                        OnPageIndexChanging="GrwData_PageIndexChanging" DataKeyNames="id_cabecera_orden_compra" AutoGenerateColumns="False" 
                                        AllowPaging="True" AllowSorting="True" OnSorting="GrwData_Sorting">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Núm. OC" SortExpression="id_cabecera_orden_compra">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).id_cabecera_orden_compra%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo Ref." SortExpression="de_tipo">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).de_tipo%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Referencia" SortExpression="id_referencia">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).id_referencia%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estado" SortExpression="de_estado">
                                                <ItemStyle Width="10%" horizontalalign="left"/>
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).de_estado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Crea" SortExpression="fe_creacion">
                                                <ItemStyle Width="5%" horizontalalign="center"/>
                                                <HeaderStyle Width="5%" />
                                                <HeaderStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_creacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Cambio" SortExpression="fe_cambio">
                                                <ItemStyle Width="8%" horizontalalign="left" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_cambio%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec En Proc" SortExpression="fe_en_proceso">
                                                <ItemStyle Width="12%" horizontalalign="left" />
                                                <HeaderStyle Width="12%" />
                                                <HeaderStyle Width="12%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_en_proceso%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Justificación" SortExpression="fe_espera_justificacion">
                                                <ItemStyle Width="8%" horizontalalign="center" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_espera_justificacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Anulado" SortExpression="fe_anulado">
                                                <ItemStyle Width="12%" horizontalalign="left" />
                                                <HeaderStyle Width="12%" />
                                                <HeaderStyle Width="12%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_anulado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Stock Prov." SortExpression="fe_espera_stock_proveedor">
                                                <ItemStyle Width="8%" horizontalalign="center" />
                                                <HeaderStyle Width="8%" />
                                                <HeaderStyle Width="8%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_espera_stock_proveedor%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Espera Solicitante" SortExpression="fe_espera_solicitante">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_espera_solicitante%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Pendiente Aprobación" SortExpression="fe_pendiente_aprobacion">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_pendiente_aprobacion%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Rechazado" SortExpression="fe_rechazo">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_rechazo%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fec Aprobado" SortExpression="fe_aprobado">
                                                <ItemStyle Width="10%" horizontalalign="right" />
                                                <HeaderStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <%# ((CabeceraOrdenCompraBE)Container.DataItem).fe_aprobado%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>  
            </td>
        </tr>
         <tr>
            <!-- Pie -->
            <td><img alt="" src="../Images/Mantenimiento/fba.gif" Width="100%" /></td>
        </tr>
    </table>
    <script type="text/javascript">
        setTabCabeceraOn("0");
    </script>
</asp:Content>