using LivrariaEF.Core.Interfaces;
using LivrariaEF.Data.Repositorios;
using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaEF.Core
{
    public class GerenciadorDeLivros : IGerenciadorDeLivros
    {
        private readonly LivroRepositorio _livroRepositorio = new LivroRepositorio();
        public List<Livro> Listar()
        {
            return _livroRepositorio.Listar();
        }

        public void Gravar(Livro livro)
        {
            _livroRepositorio.Gravar(livro);
        }

        public void Inserir(Livro livro)
        {
            _livroRepositorio.Inserir(livro);
        }

        public void Alterar(Livro livro)
        {
            _livroRepositorio.Alterar(livro);
        }

        public Livro BuscarPorId(int id)
        {
            return _livroRepositorio.BuscarPorId(id);
        }

        public void Deletar(Livro livro)
        {
            _livroRepositorio.Deletar(livro);
        }
    }
}
