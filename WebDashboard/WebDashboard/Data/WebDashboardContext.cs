using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDashboard.Models;

namespace WebDashboard.Models
{
    public class WebDashboardContext : DbContext
    {
        public WebDashboardContext (DbContextOptions<WebDashboardContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public WebDashboardContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItensPedido>().HasKey(table => new {
                table.RefIdIPedido,
                table.RefIdProduto
            });
        }

        public DbSet<WebDashboard.Models.Categoria> Categoria { get; set; }

        public DbSet<WebDashboard.Models.FormaPagamento> FormaPagamento { get; set; }

        public DbSet<WebDashboard.Models.ItensPedido> ItensPedido { get; set; }

        public DbSet<WebDashboard.Models.Produto> Produto { get; set; }
    }
}
