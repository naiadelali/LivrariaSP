<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="LivrariaEF.Site.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
       <asp:HiddenField ID="lblId" runat="server" />
            <asp:TextBox ID="txtNome" runat="server">
            </asp:TextBox>
            <asp:TextBox id="txtDescricao" runat="server">
            </asp:TextBox>
            <asp:Button Text="Gravar" ID="gravar" OnClick="gravar_Click" runat="server" />
</asp:Content>
