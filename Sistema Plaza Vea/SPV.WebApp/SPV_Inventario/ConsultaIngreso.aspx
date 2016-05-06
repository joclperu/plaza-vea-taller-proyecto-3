<%@ Page Title="" Language="C#" MasterPageFile="~/SPV_Inventario/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaIngreso.aspx.cs" Inherits="ConsultaIngreso" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


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
            <td colspan="3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                </td>
        </tr>
        <tr>
            <td colspan="3">
                <h2 align="center" style="height: 29px; background-color: #FF0C2A;">
                <asp:Label ID="Label2" runat="server" Text="Consulta Ingreso de Mercadería" ForeColor="#FFFEFE"></asp:Label></h2>
                </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                <table>
                    <tr>
                        <td>Fecha :</td>
                        <td>
                            <asp:TextBox ID="txtFecha" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Jefe Almacen :</td>
                        <td>
                            <asp:TextBox ID="txtJefAlmacen" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Orden Compra :</td>
                        <td>
                            <asp:TextBox ID="txtOrdenCompra" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Proveedor:</td>
                        <td>
                            <asp:TextBox ID="txtProveedor" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Guia Remisión :</td>
                        <td>
                            <asp:TextBox ID="txtGuiaRemision" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Placa :</td>
                        <td>
                            <asp:TextBox ID="txtPlaca" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Transportista :</td>
                        <td>
                            <asp:TextBox ID="txtTransportista" runat="server" autocomplete="off" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>Observación :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtObservacion" runat="server" Width="100%" autocomplete="off" ReadOnly="True"></asp:TextBox>
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
                        <td colspan="8">
                             <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:GridView ID="grdProductos" runat="server" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="CodProducto" HeaderText="Código" > <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Producto" > <ItemStyle HorizontalAlign="Left" /> </asp:BoundField>
                                    <asp:BoundField DataField="UnidadMedida" HeaderText="Unidad" > <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="Ingreso" > <ItemStyle HorizontalAlign="Right" /> </asp:BoundField>

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
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                             &nbsp;</td>
                        <td>
                             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#009E0F" Font-Bold="True" ForeColor="#FFFFCC" Width="80px" OnClick="btnCancelar_Click" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                             &nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                             &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                             &nbsp;</td>
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

