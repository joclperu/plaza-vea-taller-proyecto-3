<%@ Page Title="" Language="C#" MasterPageFile="~/SPV_Inventario/MasterPage.master" AutoEventWireup="true" CodeFile="IngresoMercaderia.aspx.cs" Inherits="IngresoMercaderia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3"><h2 align="center" style="height: 29px; background-color: #FF0C2A;">
                <asp:Label ID="Label2" runat="server" Text="Registrar Ingreso Mercadería" ForeColor="#FFFEFE"></asp:Label></h2>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <table>
                    <tr>
                        <td>Ingrese Orden de Compra :</td>
                        <td>
                            <asp:TextBox ID="txtOrdenCompra" runat="server" autocomplete="off"></asp:TextBox>
                        </td>
                        <td>
                             <asp:Button ID="btnBuscar" runat="server" Text="Aceptar" BackColor="#009E0F" Font-Bold="True" ForeColor="#FFFFCC" OnClick="btnBuscar_Click" Width="80px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                             <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Detalle Orden de Compra :</strong></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>Código OC :</td>
                        <td>
                            <asp:TextBox ID="txtCodOC" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td></td>
                        <td>N° OC :</td>
                        <td>
                            <asp:TextBox ID="txtNroOC" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Fecha OC :</td>
                        <td>
                            <asp:TextBox ID="txtFecOC" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                     </tr>
                    <tr>
                        <td>Estado :</td>
                        <td>
                            <asp:TextBox ID="txtEstado" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Monto Total :</td>
                        <td>
                            <asp:TextBox ID="txtMonto" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Tienda :</td>
                        <td>
                            <asp:TextBox ID="txtTienda" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                     </tr>
                    <tr>
                        <td>Proveedor :</td>
                        <td>
                            <asp:TextBox ID="txtProveedor" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Email Proveedor :</td>
                        <td>
                            <asp:TextBox ID="txtEmailProv" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>N° Documento :</td>
                        <td>
                            <asp:TextBox ID="txtNroDoc" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                     </tr>
                    <tr>
                        <td colspan="8">&nbsp;</td>
                     </tr>
                    <tr>
                        <td colspan="8"><strong>Detalle de Productos :</strong></td>
                     </tr>
                    <tr>
                        <td colspan="8">
                            <asp:GridView ID="grdProductos" runat="server" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="CodProducto" HeaderText="Código" > <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Producto" > <ItemStyle HorizontalAlign="Left" /> </asp:BoundField>
                                    <asp:BoundField DataField="UnidadMedida" HeaderText="Unidad" > <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="CantPedido" HeaderText="Cant P." > <ItemStyle HorizontalAlign="Right" /> </asp:BoundField>
                                    <asp:BoundField DataField="CantReposicion" HeaderText="Cant R." > <ItemStyle HorizontalAlign="Right" /> </asp:BoundField>
                                    <asp:BoundField DataField="CantDiferencia" HeaderText="Diferencia" > <ItemStyle HorizontalAlign="Right" /> </asp:BoundField>
                                    
                                </Columns>
                            </asp:GridView>
                        </td>
                     </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                     </tr>
                    <tr>
                        <td colspan="8"><strong>Ingreso de Mercadería :</strong></td>

                     </tr>
                    <tr>
                        <td colspan="8">
                             <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" BackColor="#009E0F" Font-Bold="True" ForeColor="#FFFFCC" Width="80px" OnClick="btnNuevo_Click" Visible="False" />
                        </td>

                     </tr>
                    <tr>
                        <td colspan="8">
                            <asp:GridView ID="grdMercaderia" runat="server" Width="100%" AutoGenerateColumns="False" 
                                OnSelectedIndexChanged="grdMercaderia_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
                                    <asp:BoundField DataField="CodNotaIngreso" HeaderText="NotaIngreso" />
                                    <asp:BoundField DataField="NroOrdenCompra" HeaderText="NroOrdenCompra" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="CodGuiaRemision" HeaderText="GuiaRemision" />
                                </Columns>
                            </asp:GridView>
                        </td>

                     </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                     </tr>
                    <tr>
                        <td align="center" colspan="8">
                             <asp:Button ID="btnSalir" runat="server" Text="Salir" BackColor="#009E0F" Font-Bold="True" ForeColor="#FFFFCC" Width="80px" OnClick="btnSalir_Click" />
                        </td>
                     </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                     </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

