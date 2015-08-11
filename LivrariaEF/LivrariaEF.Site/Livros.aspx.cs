using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LivrariaEF.Core;
using LivrariaEF.Model;

namespace LivrariaEF.Site
{
    public partial class Livros : System.Web.UI.Page
    {
        private readonly GerenciadorDeLivros _servicoLivro = new GerenciadorDeLivros();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Text = "";
                ViewState["Ds_Registros"] = "";
                ListarLivros();
            }
        }

        private void ListarLivros()
        {
            try
            {
                ViewState["Ds_Registros"] = _servicoLivro.Listar(); ;
                gridLivros.DataSource = ViewState["Ds_Registros"];
                if (gridLivros.PageCount != 0)
                {
                    gridLivros.PageIndex = 0;
                }
                gridLivros.DataBind();


            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.Message;
            }
        }

        protected void gdv_Relatorio_Sorting(object sender, GridViewSortEventArgs e)
        {
            String vDirecaoSORT = "";
            IEnumerable<Livro> livros = (IList<Livro>)ViewState["Ds_Registros"];
            if (lbl_SortDirection.Value == "Descending")
            {
                lbl_SortDirection.Value = "Ascending";
                livros = livros.OrderByDescending(x => x.GetType().GetProperty(e.SortExpression).GetValue(x, null));  
            }
            else
            {
                lbl_SortDirection.Value = "Descending";
                livros = livros.OrderBy(x => x.GetType().GetProperty(e.SortExpression).GetValue(x, null));           
            }

            ViewState["Ds_Registros"] = livros.ToList();
            gridLivros.DataSource = ViewState["Ds_Registros"];
            gridLivros.PageIndex = 0;
            gridLivros.DataBind();

        }

        protected void gdv_Relatorio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLivros.DataSource = ViewState["Ds_Registros"];
            gridLivros.PageIndex = e.NewPageIndex;
            gridLivros.DataBind();

        }

        protected void gridLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
    }
}