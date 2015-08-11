using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace LivrariaEF.DataEF
{
    public class LivroRepositorio
    {

        public Livro BuscarPorId(int id)
        {
            using (Contexto contexto = new Contexto())
            {
                List<SqlParameter> p = new List<SqlParameter>{
                    new SqlParameter("@livroId",id)
                };
                var livro = contexto.Database.SqlQuery<Livro>("SP_LIVRO_BUSCAID @livroid", new SqlParameter("@LivroId", id)).FirstOrDefault();

                return livro;
            }
        }

        public void Inserir(Livro livro)
        {
            using (Contexto contexto = new Contexto())
            {
                List<SqlParameter> p = new List<SqlParameter>{
                    new SqlParameter("@nome",livro.Nome),
                    new SqlParameter("@descricao",livro.Descricao),
                    new SqlParameter("@generoid", livro.GeneroId)
                };

                contexto.Database.ExecuteSqlCommand("SP_LIVRO_INSERIR @nome, @descricao, @generoid", p.ToArray());
                contexto.SaveChanges();
            }
        }
    }
}
