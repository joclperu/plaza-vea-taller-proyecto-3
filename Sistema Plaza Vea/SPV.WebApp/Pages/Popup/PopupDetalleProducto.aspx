<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupDetalleProducto.aspx.cs" Inherits="Pages_Popup_PopupDetalleProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr style="width: 100%">
                <td style="background-color: #ffffff; vertical-align: top; height: 470px; width: 100%;">
                    <table cellpadding="1" cellspacing="1" style="margin-left: 5px; margin-right: 5px; width: 99%;" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="lbl" runat="server" SkinID="lblcb">DETALLE DEL PRODUCTO</asp:Label>
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
                                                        <asp:TextBox ID="txtProducto" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td rowspan="5" style="background-color: #ffffff;">
                                                        <asp:Image ID="imgProducto" Width="150px" Height="150px" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px;">Código</td>
                                                    <td style="width: 300px;">
                                                        <asp:TextBox ID="txtCodigo" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px;">Proveedor</td>
                                                    <td style="width: 300px;">
                                                        <asp:TextBox ID="txtProveedor" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px;">Stock actual</td>
                                                    <td style="width: 300px;">
                                                        <asp:TextBox ID="txtStockActual" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px;">Fecha actualización stock dirección</td>
                                                    <td style="width: 300px;">
                                                        <asp:TextBox ID="txtfecActStock" Width="200px" runat="server"></asp:TextBox>
                                                    </td>
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
                                <asp:Label CssClass="cbusqueda" ID="lblRegistros" Style="background-color: white!important" runat="server" Text="Registros encontrados : 0"></asp:Label>
                                <asp:GridView Width="100%" ID="gvProductos" SkinID="Grilla" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Guia remisión" ItemStyle-Width="40%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNroGuia" Visible="true" runat="server" Text='<%# Eval("NcodGuiaRemision") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFecha" Visible="true" runat="server" Text='<%# Eval("DFecha") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cantidad recibida" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecibida" Visible="true" runat="server" Text='<%# Eval("recibida") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cantidad solicitada" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSolicitada" Visible="true" runat="server" Text='<%# Eval("solicitada") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStock" Visible="true" runat="server" Text='<%# Eval("NStock") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
