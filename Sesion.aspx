<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sesion.aspx.cs" Inherits="Sesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="accountInfo">
                <fieldset class="login">
                    <legend>Ingresa tu información</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="usuario">Usuario:</asp:Label>
                        <asp:TextBox ID="usuario" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="usuario" 
                             CssClass="failureNotification"  ValidationGroup="LoginUserValidationGroup">*Usuario obligatorio</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="contrasenia">Contraseña:</asp:Label>
                        <asp:TextBox ID="contrasenia" runat="server" CssClass="textEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="contrasenia" 
                             CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup">*Contraseña obligatoria</asp:RequiredFieldValidator>
                             
                    </p>
                    <asp:Label ID="lbl_Mensaje" runat="server" CssClass="failureNotification"></asp:Label>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" 
                         ValidationGroup="LoginUserValidationGroup" OnClick="boton_click" CssClass="a_demo_one"/>
                </p>
            </div>
</asp:Content>

