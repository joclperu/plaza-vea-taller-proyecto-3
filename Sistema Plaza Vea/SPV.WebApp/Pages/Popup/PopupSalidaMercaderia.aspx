<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupSalidaMercaderia.aspx.cs" Inherits="Pages_Popup_PopupSalidaMercaderia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../../ShadowBox/shadowbox.js"></script>

    <script type="text/javascript">
        function fr_Cerrar() {
            parent.fr_ClosePopup();
            return false;
        };

        function fr_ReturnValues(v) {
            parent.fr_ReturnValues(v);
            return false;
        };

        function fn_ValidarMonto() {

            var montoPermitido = $('#hdMontoPermitido').val();
            if (montoPermitido != '-1') {
                if (montoPermitido > 0) {

                    var cantidad = $('#txtCantidad').val().length > 0 ? $('#txtCantidad').val() : "0";
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

            /*
            var estadoOrden = $('#hdEstadoOrden').val();
            if (estadoOrden.length > 0 && estadoOrden == '2') {
                alert('La Orden de compra está completada.');
                return false;
            }*/

            var observaciones = $('#txtObservacion').val();
            var grilla = $("#gvProductos tr").length;

            if (observaciones.length > 0) {
            } else {
                alert('Debe ingresar alguna observación');
                $('#txtObservaciones').focus();
                return false;
            }

            if (grilla == 1) {
                alert('Debe agregar algún Producto');
                $('#txtCantidad').focus();
                return false;
            }
            return true;

        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdEstadoOD" runat="server" />
        <div style="background-color: white!important; padding: 20px; height: 100%;">
            <table>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:Label ID="lblTituloModo" runat="server" Text="LISTA NOTA DE SALIDA DE MERCADERÍA"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFecReg" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblusr" runat="server" Text="Analista Almacen"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtusrLog" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:Label ID="Label1" runat="server" Text="DETALLE ORDEN DESPACHO"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblOrden" runat="server" Text="Orden Despacho"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrdenDespacho" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtEstado" Width="200px" Text="" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 10px;"></div>
                    </td>
                </tr>
                <tr>
                    <td>Observación</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtObservacion" Width="100%" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblproducto" runat="server" Text="Producto"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProductos" Width="200px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidad" Width="200px" Text="" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hdMontoPermitido" Value="-1" runat="server" />
                        <asp:HiddenField ID="hdUnidadMedida" Value="" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMaximoProducto" Style="font-size: 12px;" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="overflow-y: auto; height: 200px;">

                            <asp:GridView ID="gvProductosconsulta" Visible="false" Width="100%" runat="server" AutoGenerateColumns="False">
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


                            <asp:GridView ID="gvProductos" Width="100%" runat="server" AutoGenerateColumns="False">
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
                    <td></td>
                    <td colspan="3" style="text-align: right">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
