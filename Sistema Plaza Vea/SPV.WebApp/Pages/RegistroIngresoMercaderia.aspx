<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="RegistroIngresoMercaderia.aspx.cs" Inherits="Pages_RegistroIngresoMercaderia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jsRegistroMercaderia.js"></script>
    <script type="text/javascript" src="../Scripts/jsIngresoMercaderia.js"></script>
    <link href="../ShadowBox/shadowbox.css" rel="stylesheet" />
    <script type="text/javascript" src="../ShadowBox/shadowbox.js"></script>

    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ModalPopupExtender ID="modalNuevo" BackgroundCssClass="modalBackground" TargetControlID="btnLaunchModal" CancelControlID="btnCerrar" PopupControlID="modal" runat="server"></cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="modalConsulta" BackgroundCssClass="modalBackground" TargetControlID="btnLaunchModal2" CancelControlID="btnCerrarNuevo" PopupControlID="modal2" runat="server"></cc1:ModalPopupExtender>

    <asp:HiddenField ID="hdIdOc" Value="0" runat="server" />
    <asp:HiddenField ID="hdIdProveedor" Value="0" runat="server" />
    <asp:HiddenField ID="hdEstadoOrden" Value="" runat="server" />
    <asp:HiddenField ID="hdEstadoActual" Value="-1" runat="server" />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="bottom">
            <td style="width: 30%">
                <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="TabCabeceraOn">REGISTRO INGRESO MERCADERÍA</td>
                    </tr>
                </table>
            </td>
            <td style="width: 70%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnLaunchModal" runat="server" Style="display: none;" Text="Button" />
                            <asp:Button ID="btnLaunchModal2" runat="server" Style="display: none;" Text="Button" />
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
                                onmouseout="javascript:this.src='../Images/iconos/b-buscar.gif'" OnClick="btnConsultar_Click1" />

                            <asp:ImageButton ID="btnLimpiar" runat="server" CausesValidation="False"
                                ImageUrl="~/Images/iconos/b-limpiar.gif"
                                ToolTip="Limpiar"
                                onmouseover="javascript:this.src='../Images/iconos/b-limpiar2.gif'"
                                onmouseout="javascript:this.src='../Images/iconos/b-limpiar.gif'" OnClick="btnLimpiar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <%--cabecera--%>

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
                                                <td style="width: 100px;">N ° Orden compra</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtOrdenCompra" Width="200px" runat="server" Text=""></asp:TextBox>
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
                            <asp:Label ID="Label7" runat="server" SkinID="lblcb">DETALLE ORDEN COMPRA</asp:Label></td>
                    </tr>

                    <tr>
                        <td>
                            <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 100px;">Código OC</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtCodOC" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px;">N° OC</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtNroOC" Width="200px" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 100px;">Fecha OC</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtFecOC" Width="200px" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px;">Estado</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtEstado" Width="200px" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>

                                                <td style="width: 100px;">Monto total</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtMontoTotal" Width="200px" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>

                                                <td style="width: 100px;">Tienda</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtTienda" Width="200px" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100px;">Proveedor</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtProveedor" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>

                                                <td style="width: 100px;">email Proveedor</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtEmail" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
                                                </td>

                                                <td style="width: 100px;">N° Documento</td>
                                                <td style="width: 300px;">
                                                    <asp:TextBox ID="txtNroDoc" Text="Ejemplo" runat="server" Enabled="false"></asp:TextBox>
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
                        <td valign="top" style="padding-top: 15px;">

                            <asp:GridView ID="gvOrdenCompra" Width="100%" SkinID="Grilla" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNomProducto" Visible="true" runat="server" Text='<%# Eval("nNomProducto") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" Visible="true" runat="server" Text='<%# Eval("cUnidadMedida") %>'></asp:Label>
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
                            <asp:Label ID="Label1" runat="server" SkinID="lblcb">INGRESO DE MERCADERÍA</asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top: 15px;">

                            <asp:GridView ID="gvIngresos" SkinID="Grilla" Width="100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Acción" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ToolTip="Consultar..." Height="20" Width="20" ID="imgConsular" ImageUrl="~/Images/iconos/lupa.gif" runat="server" OnClick="imgConsular_Click" />
                                            &nbsp;
                            <asp:ImageButton ToolTip="Eliminar..." Visible="false" Height="20" Width="20" ID="imgBorrar" ImageUrl="~/Images/iconos/quitar_imagen_2.gif" runat="server" OnClick="imgBorrar_Click" />
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N° Ingreso M." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodNotaIngreso" Visible="true" runat="server" Text='<%# Eval("nCodNotaIngreso") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N° Orden Compra" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNroOrdenCompra" Visible="true" runat="server" Text='<%# Eval("NroOrdenCompra") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaNota" Visible="true" runat="server" Text='<% # Eval("dFecha_nota", "{0:dd/MM/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N° Guia R." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodGuiaRemision" Visible="true" runat="server" Text='<%# Eval("ncodGuiaRemision") %>'></asp:Label>
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
        <tr>
            <!-- Pie -->
            <td>
                <img alt="" src="../Images/Mantenimiento/fba.gif" width="100%" /></td>
        </tr>
    </table>


    <%--Modal Nuevo--%>
    <div id="modal" style="height: 670px; width: 800px; background-color: white; display: none;">
        <div style="background-color: white!important; padding: 20px; height: 100%;">



            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr style="width: 100%">
                    <td style="background-color: #ffffff; vertical-align: top; height: 470px; width: 100%;">
                        <table cellpadding="1" cellspacing="1" style="margin-left: 5px; margin-right: 5px; width: 99%;" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTituloModo" runat="server" SkinID="lblcb">INGRESO MERCADERÍA</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 200px;">Fecha</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtFecReg" Text="Ejemplo" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 200px;">Jefe Almácen</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtusrLog" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
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
                                    <asp:Label ID="Label12" runat="server" SkinID="lblcb">GUÍA REMISIÓN</asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 200px;">Orden compra</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtOrdenCompraPop" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 200px;">Proveedor</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtProveedorPop" Text="" Width="200px" runat="server" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">N° Guía Remisión</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtNroGuiaRemis" placeholder="Ingrese N° Guía Remisión" Text="" runat="server"></asp:TextBox>
                                                        </td>

                                                        <td style="width: 200px;">Placa</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtNroPlaca" Text="" placeholder="Ingrese N° Placa" Width="200px" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">Transportista</td>
                                                        <td colspan="3" style="width: 300px;">
                                                            <asp:TextBox ID="txtTransportista" TextMode="MultiLine" Height="60px" Width="100%" placeholder="Ingrese el Transportista" Text="" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;">Observaciones</td>
                                                        <td colspan="3" style="width: 300px;">
                                                            <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Height="60px" Width="100%" placeholder="Ingrese una observación" Text="" runat="server"></asp:TextBox>
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
                                                            <asp:DropDownList ID="ddlProductos" Width="200px" runat="server" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:HiddenField ID="hdUnidadMedida" Value="" runat="server" />
                                                        </td>

                                                        <td style="width: 200px;">Cantidad</td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="txtCantidad" placeholder="Ingrese una cantidad" Text="" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="hdMontoPermitido" Value="-1" runat="server" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;">
                                                            <asp:Label ID="aCantidad" Style="font-size: 12px;" runat="server" Text="Necesario para completar la O.C. : "></asp:Label>
                                                            <asp:Label ID="lblMaximoProducto" Style="font-size: 12px;" runat="server" Text="0"></asp:Label>
                                                        </td>

                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px;"></td>
                                                        <td style="width: 300px;">
                                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                                                        </td>

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

                                        <asp:GridView ID="gvDetalleNota" Width="100%" SkinID="Grilla" Visible="false" runat="server" AutoGenerateColumns="False">
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

                                        <asp:GridView ID="gvProductos" Width="100%" SkinID="Grilla" runat="server" AutoGenerateColumns="False">
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


    <%--Modal consulta--%>
    <div id="modal2" style="height: 670px; width: 800px; background-color: white; display: none;">
        <div style="background-color: white!important; padding: 20px; height: 100%;">
            <asp:Button ID="btnCerrarNuevo" runat="server" Text="Cerrar" />
        </div>
    </div>

</asp:Content>

