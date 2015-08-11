using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace LivrariaEF.Model
{
    [Serializable]
    public class Livro
    {

        private int _livroId;
        private string _nome;
        private string _descricao;
        private int _generoId;
        private Genero _genero;

        
        public int LivroId
        {
            get { return _livroId; }
            set { _livroId = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public int GeneroId
        {
            get { return _generoId; }
            set { _generoId = value; }
        }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
    }
}
