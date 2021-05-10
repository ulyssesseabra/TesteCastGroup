using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCastGroup.Library.Domain;
using Microsoft.Extensions.Logging.Console;

namespace TesteCastGroup.Library.Business
{
    public class TesteCastGroupContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\db\TesteCastGroup.db");

            options.UseLazyLoadingProxies();


            options.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder
                .AddConsole((options) => { })
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Debug);
            }));
        
    }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasOne(s => s.Categoria);


            base.OnModelCreating(modelBuilder);
        }
    }
}
