using LivrariaEF.Core;
using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrariaEF.Site
{
    public partial class Cadastro : System.Web.UI.Page
    {
        private readonly GerenciadorDeLivros _servicoLivros = new GerenciadorDeLivros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Text = "";
                VerificaLivro();
            }
        }

        private void VerificaLivro()
        {
            if (!(Request.QueryString["livro"] == null))
            {
                int id = Convert.ToInt32(Request.QueryString["livro"]);
                Livro livro = _servicoLivros.BuscarPorId(id);

                lblId.Value = livro.LivroId.ToString();
                txtNome.Text = livro.Nome;
                txtDescricao.Text = livro.Descricao;
            }
        }

        protected void gravar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = string.IsNullOrEmpty(lblId.Value) ? 0 :Convert.ToInt32(lblId.Value);

                Livro livro = new Livro()
                {
                    LivroId =id,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    GeneroId = 1
                };

                _servicoLivros.Gravar(livro);
                lblMsg.Text = "<div class='alert alert-success'>Registro salvo com sucesso!</div>";
                VerificaLivro();

            }
            catch (Exception ex)
            {

                lblMsg.Text = String.Format("<div class='alert alert-danger'>{0}</div>", ex.Message);
            }
        }


    }
}