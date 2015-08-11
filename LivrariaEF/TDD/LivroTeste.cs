using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LivrariaEF.Model;
using LivrariaEF.Data.Repositorios;

namespace TDD
{
    [TestClass]
    public class LivroTeste
    {
        [TestMethod]
        public void BuscarPorId()
        {
            LivroRepositorio repositorio = new LivroRepositorio();
            var livro = repositorio.BuscarPorId(2);
        }

        [TestMethod]
        public void ListarTodosOsLivros()
        {
            LivroRepositorio repositorio = new LivroRepositorio();
            var livro = repositorio.Listar();

            Assert.AreEqual(1, livro.Count);
        }

        [TestMethod]
        public void Inserir()
        {
           LivroRepositorio repositorio = new LivroRepositorio();
           repositorio.Gravar(new Livro() { LivroId = 2, GeneroId = 1, Nome = "percy jackson", Descricao = "livro sobre mitologia grega e fantasia" });
        }

        [TestMethod]
        public void Alterar()
        {
            LivroRepositorio repositorio = new LivroRepositorio();
            repositorio.Gravar(new Livro() {LivroId = 1,GeneroId = 2, Descricao = "Harry Potter e a pedra filosofal", Nome = "O menino bruxo em busca da pedra" });
        }

        [TestMethod]
        public void Deletar()
        {
            LivroRepositorio repositorio = new LivroRepositorio();

            repositorio.Deletar(1);
        }

        [TestMethod]
        public void BuscarPorNome()
        {
            LivroRepositorio repositorio = new LivroRepositorio();

            var livro = repositorio.BuscarPorNome("livro");
        }

     
    }
}
