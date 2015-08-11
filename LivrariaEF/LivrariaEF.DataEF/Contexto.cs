using LivrariaEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaEF.DataEF
{
    public class Contexto : DbContext
    {
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public Contexto()
            : base("LivrariaDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CreateDatabaseIfNotExists<DbContext> context;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                        .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                        .Configure(p => p.HasMaxLength(100));


            base.OnModelCreating(modelBuilder);
        }
    }
}
