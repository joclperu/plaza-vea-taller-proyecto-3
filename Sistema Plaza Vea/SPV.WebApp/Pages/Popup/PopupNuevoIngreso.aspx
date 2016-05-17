<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupNuevoIngreso.aspx.cs" Inherits="Pages_Popup_PopupNuevoIngreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="../../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../../ShadowBox/shadowbox.js"></script>
    <script src="../../Scripts/jsIngresoMercaderia.js"></script>

    <script type="text/javascript">
        function fr_Cerrar() {
            parent.fr_ClosePopup();
            return false;
        };

        function fr_ReturnValues(v) {
            parent.fr_ReturnValuesIngreso(v);
            return false;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdIdOc" Value="0" runat="server" />
        <asp:HiddenField ID="hdIdProveedor" Value="0" runat="server" />
        <asp:HiddenField ID="hdEstadoOrden" Value="" runat="server" />
        <div style="background-color: white!important; padding: 20px; height: 100%;">
            <table>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:Label ID="lblTituloModo" runat="server" Text="INGRESO MERCADERÍA"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFecReg" Text="Ejemplo" Width="200px" runat="server" Enabled="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblusr" runat="server" Text="Jefe Almácen"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtusrLog" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-weight: bold">
                        <asp:Label ID="Label1" runat="server" Text="GUÍA REMISIÓN"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label2" runat="server" Text="Orden compra"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroOc" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Proveedor"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtProveedor" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label4" runat="server" Text="N° Guía Remisión"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroGuiaRemis" placeholder="Ingrese N° Guía Remisión" Text="" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Placa"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroPlaca" Text="" placeholder="Ingrese N° Placa" Width="200px" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label6" runat="server" Text="Transportista"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTransportista" TextMode="MultiLine" Height="60px" Width="100%" placeholder="Ingrese el Transportista" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label7" runat="server" Text="Observaciones"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Height="60px" Width="100%" placeholder="Ingrese una observación" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>

                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label8" runat="server" Text="Producto"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProductos" Width="200px" runat="server" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:HiddenField ID="hdUnidadMedida" Value="" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Cantidad"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:HiddenField ID="hdMontoPermitido" Value="-1" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidad" placeholder="Ingrese una cantidad" Text="" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Label ID="aCantidad" Style="font-size: 12px;" runat="server" Text="Necesario para completar la O.C. : "></asp:Label>
                        <asp:Label ID="lblMaximoProducto" Style="font-size: 12px;" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="height: 20px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div style="overflow-y: auto; height: 200px;">
                            <asp:GridView ID="gvDetalleNota" Width="100%" Visible="false" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProducto" Visible="true" runat="server" Text='<%# Eval("Product_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unidad">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("und_medida") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantidad" Visible="true" runat="server" Text='<%# Eval("NCantidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <asp:GridView ID="gvProductos" Width="100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Acción">
                                        <ItemTemplate>
                                            <asp:ImageButton ToolTip="Eliminar..." Height="20" Width="20" ID="imgEliminar" ImageUrl="~/Images/iconos/quitar_imagen_2.gif" runat="server" OnClick="imgEliminar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProducto" Visible="true" runat="server" Text='<%# Eval("CDescripcion") %>'></asp:Label>
                                            <asp:Label ID="lblIdProducto" Visible="false" Text='<%# Eval("NCodProducto") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unidad">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("CUnidadMedida") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCantidad" Visible="true" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label>
                                        </ItemTemplate>
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
