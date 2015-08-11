<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="LivrariaEF.Site.Livros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
     <asp:Label ID="lblMsg" Text="" runat="server"></asp:Label>
    <asp:GridView runat="server" AutoGenerateColumns="false" OnRowCommand="gridLivros_RowCommand" ID="gridLivros"> 
        <Columns>
            <asp:TemplateField HeaderText="Id">
                <ItemTemplate>
                    <a href="" ><asp:Label runat="server" ID="lblId" Text='<%# DataBinder.Eval(Container.DataItem,"LivroId") %>' /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nome" DataField="Nome" />
            <asp:BoundField HeaderText="Descricao" DataField="Descricao" />
        </Columns>
    </asp:GridView>
</asp:Content>
