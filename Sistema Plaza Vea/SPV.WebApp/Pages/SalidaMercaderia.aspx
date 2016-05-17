<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SalidaMercaderia.aspx.cs" Inherits="Pages_SalidaMercaderia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jsSalidaMercaderia.js"></script>

    <link href="../ShadowBox/shadowbox.css" rel="stylesheet" />
    <script type="text/javascript" src="../ShadowBox/shadowbox.js"></script>

    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>


    <script type="text/javascript">
        function fn_ValidarMonto() {

            var montoPermitido = $('#ctl00_ContentPlaceHolder1_hdMontoPermitido').val();
            if (montoPermitido != '-1') {
                if (montoPermitido > 0) {

                    var cantidad = $('#ctl00_ContentPlaceHolder1_txtCantidad').val().length > 0 ? $('#ctl00_ContentPlaceHolder1_txtCantidad').val() : "0";
                    if (cantidad > 0 && cantidad.length > 0) {
                        if (parseInt(cantidad) <= parseInt(montoPermitido)) {
                            return true;
                        } else {
                            alert('La cantidad máxima a ingresar es : ' + montoPermitido);
                            return false;
                        }
                    } else {
                        alert('Cantidad inconsistente con la diferencia para completar la O.D.');
                        return false;
                    }
                } else {
                    alert('Este producto está sin pendientes despacho');
                    return false;
                }

            } else {

                return false;
            }

        };


        function fn_Validar() {

            var observaciones = $('#ctl00_ContentPlaceHolder1_txtObservacion').val();
            var grilla = $("#ctl00_ContentPlaceHolder1_gvProductos tr").length;

            if (observaciones.length > 0) {
            } else {
                alert('Debe ingresar alguna observación');
                $('#ctl00_ContentPlaceHolder1_txtObservaciones').focus();
                return false;
            }

            if (grilla == 1) {
                alert('Debe agregar algún Producto');
                $('#ctl00_ContentPlaceHolder1_txtCantidad').focus();
                return false;
            }
            return true;

        };
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ModalPopupExtender ID="modalNuevo" BackgroundCssClass="modalBackground" TargetControlID="btnLaunchModal" CancelControlID="btnCerrar" PopupControlID="modal" runat="server"></cc1:ModalPopupExtender>
    <asp:Button ID="btnLaunchModal" runat="server" Style="display: none;" Text="Button" />

    <asp:HiddenField ID="hdEstadoOD" Value="-1" runat="server" />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="bottom">
            <td style="width: 30%">
                <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="TabCabeceraOn">LISTA NOTA DE SALIDA DE MERCADERÍA</td>
                    </tr>
                </table>
            </td>
            <td style="width: 70%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="btnNuevo" Visible="true" runat="server" ImageUrl="../images/iconos/b-nuevo.gif"
                                ToolTip="Agregar"
                                onmouseover="javascript:this.src='../Images/iconos/b-nuevo2.gif'"
                                onmouseout="javascript:this.src='../Images/iconos/b-nuevo.gif'" OnClick="btnNuevo_Click" />

                            <asp:ImageButton ID="BtnEliminar" Visible="false" runat="server" ImageUrl="~/Images/iconos/b-eliminar.gif"
                                ToolTip="Eliminar"
                                onmouseover="javascript:this.src='../Images/iconos/b-eliminar2.gif'"
                                onmouseout="javascript:this.src='../Images/iconos/b-eliminar.gif'" />

                            <asp:ImageButton ID="btnConsultar" runat="server" ImageUrl="~/Images/iconos/b-buscar.gif"
                                ToolTip="Buscar"
                                onmouseover="javascript:this.src='../Images/iconos/b-buscar2.gif'"
                                onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" OnClick="btnConsultar_Click" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr style="width: 100%">
            <!-- Cabecera -->
            <td>
                <img alt="" width="100%" src="../Images/Mantenimiento/fbarr.gif" /></td>
        </tr>
        <tr style="width: 100%">
            <td style="background-color: #ffffff; vertical-align: top; height: 470px; width: 100%;">
                <table cellpadding="1" cellspacing="1" style="margin-left: 5px; margin-right: 5px; width: 99%;" border="0">
                    <tr>
                        <td>
                            <asp:Label ID="lbl" runat="server" SkinID="lblcb">CRITERIOS DE BUSQUEDA</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 100px;">N ° Orden despacho</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtOrdenDespacho" onkeypress='return event.charCode >= 48 && event.charCode <= 57' Width="200px" runat="server" Text=""></asp:TextBox>
                                                </td>
                                                <td style="width: 100px;"></td>
                                                <td style="width: 300px;"></td>
                                                <td style="width: 100px;"></td>
                                                <td style="width: 300px;"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/iconos/fbusqueda.gif" Width="100%" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height: 15px;"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" SkinID="lblcb">DETALLE ORDEN DESPACHO</asp:Label></td>
                    </tr>

                    <tr>
                        <td>
                            <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 100px;">Estado</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtEstado" Width="200px" runat="server" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top: 15px;">
                            <asp:GridView ID="gvDetalleOrdenDespacho" SkinID="Grilla" Width="100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNomProducto" Visible="true" runat="server" Text='<%# Eval("nom_producto") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("nom_unidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad P." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantidadP" Visible="true" runat="server" Text='<%# Eval("nCantPedido") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad R." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantidadR" Visible="true" runat="server" Text='<%# Eval("nCantReposicion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Diferencia" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantidadD" Visible="true" runat="server" Text='<%# Eval("nCantDiferencia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height: 15px;"></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" SkinID="lblcb">LISTA ORDENES DESPACHO</asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top: 15px;">

                            <asp:GridView ID="gvNotasDocumento" SkinID="Grilla" Width="100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Acciones" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:ImageButton ToolTip="Consultar..." Height="20" Width="20" ID="imgConsultar" ImageUrl="~/Images/iconos/lupa.gif" runat="server" OnClick="imgConsultar_Click" />
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro.Salida Mer." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodDocumento" Visible="true" runat="server" Text='<%# Eval("nCodDocumento") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nro.Orden despacho" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodDespacho" Visible="true" runat="server" Text='<%# Eval("ncodDespacho") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFecha" Visible="true" runat="server" Text='<% # Eval("dFecha", "{0:dd/MM/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnEvaluar" Style="display: none;" runat="server" Text="Button" OnClick="btnEvaluar_Click" />





    <%--Modal--%>
    <div id="modal" style="height: 670px; width: 800px; background-color: white; display: none;">
        <div style="background-color: white!important; padding: 20px; height: 100%;">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr style="width: 100%">
                    <td style="background-color: #ffffff; vertical-align: top; height: 470px; width: 100%;">
                        <table cellpadding="1" cellspacing="1" style="margin-left: 5px; margin-right: 5px; width: 99%;" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTituloModo" runat="server" SkinID="lblcb" Text="LISTA NOTA DE SALIDA DE MERCADERÍA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 270px;">Fecha</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtFecReg" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 200px;">Analista Almacen</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtusrLog" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 15px;"></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" SkinID="lblcb">DETALLE ORDEN DESPACHO</asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 200px;">Orden Despacho</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtOrdenDespachopop" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 200px;">Estado</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtEstadoPop" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">Observaciónn</td>
                                                        <td colspan="3" style="width: 300px;">
                                                            <asp:TextBox ID="txtObservacion" Width="95%" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 15px;"></div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 200px;">Producto</td>
                                                        <td style="width: 300px;">
                                                            <asp:DropDownList ID="ddlProductos" Width="200px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
                                                            <asp:HiddenField ID="hdUnidadMedida" Value="" runat="server" />
                                                        </td>

                                                        <td style="width: 200px;">Cantidad</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtCantidad" Width="200px" Text="" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="hdMontoPermitido" Value="-1" runat="server" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;">
                                                            <asp:Label ID="lblMaximoProducto" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                                                        </td>

                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;">
                                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" /></td>


                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="padding-top: 15px;">
                                    <div style="overflow-y: auto; height: 200px;">

                                        <asp:GridView ID="gvProductosconsulta" SkinID="Grilla" Visible="false" Width="100%" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Producto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProducto" Visible="true" runat="server" Text='<%# Eval("nom_producto") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unidad" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("nom_unidad") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCantidad" Visible="true" runat="server" Text='<%# Eval("NCantidad") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>


                                        <asp:GridView ID="gvProductos" SkinID="Grilla" Width="100%" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Acción" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ToolTip="Eliminar..." Height="20" Width="20" ID="imgEliminar" ImageUrl="~/Images/iconos/quitar_imagen_2.gif" runat="server" OnClick="imgEliminar_Click" />
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Producto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProducto" Visible="true" runat="server" Text='<%# Eval("CDescripcion") %>'></asp:Label>
                                                        <asp:Label ID="lblIdProducto" Visible="false" Text='<%# Eval("NCodProducto") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unidad" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("CUnidadMedida") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCantidad" Visible="true" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

