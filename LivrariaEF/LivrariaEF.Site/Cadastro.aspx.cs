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
                VerificaLivro();
            }
        }

        private void VerificaLivro()
        {
            if (!(Request.QueryString["livro"] == null))
            {
                int id = Convert.ToInt32(Request.QueryString["livro"] );
                Livro livro = _servicoLivros.BuscarPorId(id);

                lblId.Value = livro.LivroId.ToString();
                txtNome.Text = livro.Nome;
                txtDescricao.Text = livro.Descricao;
            }
        }

        protected void gravar_Click(object sender, EventArgs e)
        {
            Livro livro = new Livro()
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                GeneroId = 1
            };

            _servicoLivros.Gravar(livro);
        }

        
    }
}