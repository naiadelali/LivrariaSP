<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Livros.aspx.cs" Inherits="LivrariaEF.Site.Livros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <div class="col-md-12">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading"></div>
                <div class="panel-body">
                    <div class="col-md-10"></div>
                    <div class="col-md-2">
                        <a href="Cadastro.aspx" class="btn btn-info"><i class="glyphicon glyphicon-plus"></i> Novo</a>
                    </div>
                </div>
                <div class="panel-footer"></div>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblMsg" Text="" runat="server"></asp:Label>
        </div>
        <div class="row">
            <asp:GridView runat="server" AutoGenerateColumns="false" AllowSorting="True" AllowPaging="true" PageSize="3" OnSorting="gdv_Relatorio_Sorting" OnPageIndexChanging="gdv_Relatorio_PageIndexChanging" OnRowCommand="gridLivros_RowCommand" ID="gridLivros" CssClass="table table-bordered">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <a href="">
                                <asp:Label runat="server" ID="lblId" Text='<%# DataBinder.Eval(Container.DataItem,"LivroId") %>' /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nome" SortExpression="Nome" DataField="Nome" />
                    <asp:BoundField HeaderText="Descricao" SortExpression="Descricao" DataField="Descricao" />
                </Columns>
            </asp:GridView>
            
        </div>

    </div>
    <asp:HiddenField runat="server" ID="lbl_SortDirection"/>
     
</asp:Content>
