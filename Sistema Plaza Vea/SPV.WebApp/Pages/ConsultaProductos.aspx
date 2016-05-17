<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ConsultaProductos.aspx.cs" Inherits="Pages_ConsultaProductos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/SPV_UserControl/TextBoxFecha.ascx" TagName="TextBoxFecha" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../ShadowBox/report.css" rel="stylesheet" />
    <link href="../ShadowBox/shadowbox.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../ShadowBox/shadowbox.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            Shadowbox.init({ title: 'PLAZA VEA', modal: true, enableKeys: false, handleOversize: "drag" });
        });

        function fr_ClosePopup() {
            Shadowbox.close();
        };

        function fn_PopuDetalle(param) {
            var titulo = 'PLAZA VEA';
            var url = 'Popup/PopupDetalleProducto.aspx?param=' + param;
            Shadowbox.open({ player: "iframe", title: titulo, content: url, height: 400, width: 600 });
            return false;


        };
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <cc1:ModalPopupExtender ID="modalNuevo" BackgroundCssClass="modalBackground" TargetControlID="btnLaunchModal" CancelControlID="btnCerrar" PopupControlID="modal" runat="server"></cc1:ModalPopupExtender>
            <asp:Button ID="btnLaunchModal" runat="server" Style="display: none;" Text="Button" />
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr valign="bottom">
                    <td style="width: 30%">
                        <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td class="TabCabeceraOn">Consulta Stock Productos</td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 70%" align="right">
                        <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="right">
                                    <asp:ImageButton ID="BtnNuevo" Visible="false" runat="server" ImageUrl="../images/iconos/b-nuevo.gif"
                                        ToolTip="Agregar"
                                        onmouseover="javascript:this.src='../Images/iconos/b-nuevo2.gif'"
                                        onmouseout="javascript:this.src='../Images/iconos/b-nuevo.gif'" />

                                    <asp:ImageButton ID="BtnEliminar" Visible="false" runat="server" ImageUrl="~/Images/iconos/b-eliminar.gif"
                                        ToolTip="Eliminar"
                                        onmouseover="javascript:this.src='../Images/iconos/b-eliminar2.gif'"
                                        onmouseout="javascript:this.src='../Images/iconos/b-eliminar.gif'" />

                                    <asp:ImageButton ID="BtnBuscar" runat="server" ImageUrl="~/Images/iconos/b-buscar.gif"
                                        ToolTip="Buscar"
                                        onmouseover="javascript:this.src='../Images/iconos/b-buscar2.gif'"
                                        onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" OnClick="BtnBuscar_Click" />

                                    <asp:ImageButton ID="BtnLimpiar" runat="server" CausesValidation="False"
                                        ImageUrl="~/Images/iconos/b-limpiar.gif"
                                        ToolTip="Limpiar"
                                        onmouseover="javascript:this.src='../Images/iconos/b-limpiar2.gif'"
                                        onmouseout="javascript:this.src='../Images/iconos/b-limpiar.gif'" OnClick="BtnLimpiar_Click" />
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
                    <td style="background-color: #ffffff; vertical-align: top;width: 100%;">
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
                                                        <td style="width: 100px;">Tienda</td>
                                                        <td style="width: 300px;">
                                                            <asp:DropDownList AppendDataBoundItems="true" ID="ddlTienda" Width="200px" runat="server">
                                                                <asp:ListItem Selected="True" Value="-1">[SELECCIONE UNA TIENDA]</asp:ListItem>
                                                                <asp:ListItem Value="0">[TODOS]</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 100px;">Producto</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtProducto" Width="200px" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 100px;">Fecha</td>
                                                        <td style="width: 300px;">
                                                            <uc1:TextBoxFecha ID="TxtFecIni" runat="server" />
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
                                <td valign="top" style="padding-top: 15px;">
                                    <asp:Label CssClass="cbusqueda" ID="lblRegistros" Style="background-color: white!important" runat="server" Text="Registros encontrados : 0"></asp:Label>
                                    <asp:GridView Width="100%" ID="gvProductos" SkinID="Grilla" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="..." ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgConsultarDetalle" ImageUrl="~/Images/iconos/ico_Buscar.gif" runat="server" OnClick="imgConsultarDetalle_Click" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tienda" ItemStyle-Width="40%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnomTienda" Visible="true" runat="server" Text='<%# Eval("nom_tienda") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="40%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Producto" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProducto" Visible="true" runat="server" Text='<%# Eval("CDescripcion") %>'></asp:Label>
                                                    <asp:Label ID="lblidProducto" Visible="false" runat="server" Text='<%# Eval("NCodProducto") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStock" Visible="true" runat="server" Text='<%# Eval("NStock") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <!-- Pie -->
                    <td>
                        <img alt="" src="../Images/Mantenimiento/fba.gif" width="100%" /></td>
                </tr>
            </table>




            <%--Modal Nuevo--%>
            <div id="modal" style="height: 400px; width: 600px; background-color: white; display: none;">
                <div style="background-color: white!important; padding: 20px; height: 100%;">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr style="width: 100%">
                            <td style="background-color: #ffffff; vertical-align: top;width: 100%;">
                                <table cellpadding="1" cellspacing="1" style="margin-left: 5px; margin-right: 5px; width: 99%;" border="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" SkinID="lblcb">DETALLE DEL PRODUCTO</asp:Label>
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
                                                                    <asp:TextBox ID="txtProductoPop" Width="200px" runat="server"></asp:TextBox>
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
                                                                <td style="width: 200px;">Fecha creación registro</td>
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
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/iconos/fbusqueda.gif" Width="100%" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="height: 200px; overflow-y: auto;">
                                                <asp:Label CssClass="cbusqueda" ID="Label2" Style="background-color: white!important" runat="server" Text="Datos del stock del producto: 0"></asp:Label>
                                                <asp:GridView Width="100%" ID="gvProductosPop" SkinID="Grilla" runat="server" AutoGenerateColumns="False">
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
                                                        <asp:TemplateField HeaderText="Stock" Visible="false" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStock" Visible="true" runat="server" Text='<%# Eval("NStock") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">

                                            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" />
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <script type="text/javascript">
                setTabCabeceraOn("0");
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

