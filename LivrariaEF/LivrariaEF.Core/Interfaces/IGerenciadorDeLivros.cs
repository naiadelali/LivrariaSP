using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaEF.Core.Interfaces
{
    public interface IGerenciadorDeLivros
    {

        List<Livro> Listar();

        void Gravar(Livro livro);
        void Inserir(Livro livro);
        void Alterar(Livro livro);
        Livro BuscarPorId(int id);
        void Deletar(int id);
    }
}
