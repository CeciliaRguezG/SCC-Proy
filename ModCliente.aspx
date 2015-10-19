<%@ Page Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ModCliente.aspx.cs" Inherits="Cliente_ModCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../Styles/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="../Bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/styles.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <script src="../js/Cliente.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
    <script src="../js/DataTable.js" type="text/javascript"></script>
    <script src="../js/dataTable-es.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" CssClass="panel">
            <div id='cssmenu'>
                <ul>
                    <li class='active'><a href='#'>Clientes</a>
                        <ul>
                            <li><a href="Cliente.aspx">Registro</a></li>
                            <li><a href="ListaClientes.aspx">Ver clientes</a></li>
                            <li><a href='#'>Estados de cuenta</a></li>
                        </ul>
                    </li>
                    <li><a href='#'>Créditos</a>
                        <ul>
                            <li><a href="../Credito/Solicitud.aspx">Solicitudes</a>
                                <ul>
                                    <li><a href='#'>Aceptadas</a></li>
                                    <li><a href='#'>Rechazadas</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href='#'>Balance</a>
                        <ul>
                            <li><a href='#'>General</a></li>
                            <li><a href='#'>Mensual</a></li>
                        </ul>
                    </li>
                    <li><a href='#'>Contactos</a></li>
                    <li><a href="#" id="dialog-link" class="ui-state-default ui-corner-all"><span class="ui-icon-calculator">
                    </span>Calculadora</a></span></a></li>
                </ul>
            </div>
            <table style="width: 100%;">
                <br />
                <tr>
                    <td align="right">
                     <asp:Label ID="lblIdCliente" runat="server" CssClass="hide"></asp:Label>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" MaxLength="50" CssClass="form-control"
                            Width="149px" Height="20px"></asp:TextBox>
                        <asp:Label ID="lblNom" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Apellido Paterno:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_app" runat="server" MaxLength="50" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblApp" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Apellido Materno:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_apm" runat="server" MaxLength="50" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblApm" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Sexo:
                    </td>
                    <td>
                        <asp:DropDownList ID="txt_sexo" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion"
                            DataValueField="idSexo" CssClass="form-control" Width="175px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sccConnectionString1 %>"
                            SelectCommand="SELECT [descripcion], [idSexo] FROM [sexo]"></asp:SqlDataSource>
                        <asp:Label ID="lblSexo" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Fecha de Nacimiento:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_fn" runat="server" MaxLength="50" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblFn" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Número de IFE:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_IFE" runat="server" MaxLength="13" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblIFE" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Domicilio:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Dom" runat="server" MaxLength="50" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblDom" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Número:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Num" runat="server" MaxLength="4" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblNum" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Señas particulares (casa):
                    </td>
                    <td>
                        <asp:TextBox ID="txt_casa" runat="server" MaxLength="50" CssClass="form-control"
                            Width="149px" Height="20px"></asp:TextBox>
                        <asp:Label ID="lblCasa" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Teléfono:
                    </td>
                    <td>
                        <asp:TextBox ID="txt_tel" runat="server" MaxLength="10" CssClass="form-control" Width="149px"
                            Height="20px"></asp:TextBox>
                        <asp:Label ID="lblTel" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Teléfono (alterno):
                    </td>
                    <td>
                        <asp:TextBox ID="txt_tela" runat="server" MaxLength="10" CssClass="form-control"
                            Width="149px" Height="20px"></asp:TextBox>
                        <asp:Label ID="lblTela" runat="server" CssClass="colorMje"></asp:Label>
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Button ID="btn_Modificar" runat="server" OnClick="btn_Modificar_Click" Text="Modificar"
                            CssClass="btn btn-primary colorMje" />
                    </td>
                    <td class="style2">
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style1">
                    </td>
                    <td class="style1">
                        <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
                    </td>
                    <td class="style3">
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
