using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LivrariaEF.Core;
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

                ListarLivros();
            }
        }

        private void ListarLivros()
        {
            try
            {
                gridLivros.DataSource = _servicoLivro.Listar();
                gridLivros.DataBind();
            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.Message;
            }
        }


        protected void gridLivros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
    }
}