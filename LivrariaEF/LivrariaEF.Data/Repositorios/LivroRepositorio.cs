using LivrariaEF.Data.Interfaces;
using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaEF.Data.Repositorios
{

    public class LivroRepositorio : ILivroRepositorio
    {

        public List<Livro> Listar()
        {
            List<Livro> livros = new List<Livro>();
            using (DataTable dt = DbComandos.ConsultarProcedure("sp_livro_listar"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    Livro livro = new Livro()
                    {
                        Descricao = r["descricao"].ToString(),
                        GeneroId = (int)r["generoid"],
                        Nome = r["nome"].ToString(),
                        LivroId = (int)r["livroid"]
                    };

                    livros.Add(livro);
                }
            }

            return livros;
        }

        public void Gravar(Livro livro)
        {
            string sql = "sp_livro_gravar";

            List<SqlParameter> parameters = new List<SqlParameter>()
           {  
               new SqlParameter("@livroid",livro.LivroId),
               new SqlParameter("@generoid", livro.GeneroId),
               new SqlParameter("@nome", livro.Nome),
               new SqlParameter("@descricao", livro.Descricao)
             
               
           };

            DbComandos.ExecutarProcedure(sql, parameters);
        }

        public void Inserir(Livro livro)
        {

        }

        public void Alterar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public Livro BuscarPorId(int id)
        {
            Livro livro = new Livro() { LivroId = id, };
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@livroid",livro.LivroId),
                new SqlParameter("@generoid",DBNull.Value),
                new SqlParameter("@nome", DBNull.Value),
                new SqlParameter("@descricao", DBNull.Value)
              
            };

            using (DataTable dt = DbComandos.ConsultarProcedure("sp_livro_listarcomtratamento", parameters))
            {

                foreach (DataRow r in dt.Rows)
                {
                    livro.LivroId = (int)r["livroid"];
                    livro.Nome = r["nome"].ToString();
                    livro.GeneroId = (int)r["generoid"];
                    livro.Descricao = r["descricao"].ToString();
                }

            }
            return livro;
        }

        public void Deletar(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("@livroid", id)
            };

            DbComandos.ExecutarProcedure("sp_livro_deletar", parametros);
        }


        public Livro BuscarPorNome(string nome)
        {

            Livro livro = new Livro() { Nome = nome};
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@livroid",DBNull.Value),
                new SqlParameter("@generoid",DBNull.Value),
                new SqlParameter("@nome", livro.Nome),
                new SqlParameter("@descricao", DBNull.Value)
              
            };

            using (DataTable dt = DbComandos.ConsultarProcedure("sp_livro_listarcomtratamento", parameters))
            {

                foreach (DataRow r in dt.Rows)
                {
                    livro.LivroId = (int)r["livroid"];
                    livro.Nome = r["nome"].ToString();
                    livro.GeneroId = (int)r["generoid"];
                    livro.Descricao = r["descricao"].ToString();
                }

            }
            return livro;
        }
    }
}
