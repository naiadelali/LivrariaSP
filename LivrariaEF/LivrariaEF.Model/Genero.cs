using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivrariaEF.Model
{
    public class Genero
    {
        private int _generoId;
        private string _nome;
        private IList<Livro> _livros;

        public int GeneroId
        {
            get { return _generoId; }
            set { _generoId = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public virtual IList<Livro> Livros
        {
            get { return _livros; }
            set { _livros = value; }
        }
    }
}
