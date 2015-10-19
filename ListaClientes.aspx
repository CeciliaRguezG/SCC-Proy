<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ListaClientes.aspx.cs" Inherits="Cliente_ListaClientes" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true"
    CodeFile="ListaClientes.aspx.cs" Inherits="Cliente_ListaClientes" %>

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
                            <li><a href='#'>Solicitudes</a>
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
            <div>
                <asp:Label ID="lblIdCliente" runat="server" CssClass="hide"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblListado" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
