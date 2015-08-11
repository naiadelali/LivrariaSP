<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="LivrariaEF.Site.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <div>
        <div class="form-group">
            <label>Nome</label>
            <asp:TextBox ID="txtNome" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Descrição</label>
            <asp:TextBox ID="txtDescricao" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
           <asp:Label runat="server" ID="lblMsg" Text=""></asp:Label>
        </div>
        <asp:Button Text="Gravar" CssClass="btn btn-success" ID="gravar" OnClick="gravar_Click" runat="server" />
    </div>
    <asp:HiddenField ID="lblId" runat="server" />

  
</asp:Content>
