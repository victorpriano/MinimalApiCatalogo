using Microsoft.EntityFrameworkCore;
using MinimalApiCatalogo.Models;

namespace MinimalApiCatalogo.Context;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //FluentAPI
        {
            modelBuilder.Entity<Categoria>().HasKey(x => x.CategoriaId);
            modelBuilder.Entity<Categoria>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.Descricao).HasMaxLength(150).IsRequired();
            
            modelBuilder.Entity<Produto>().HasKey(x => x.ProdutoId);
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Produto>().Property(x => x.Imagem).HasMaxLength(100);
            modelBuilder.Entity<Produto>().Property(x => x.Preco).HasPrecision(14,2);

            // Relacionamento 
            modelBuilder.Entity<Produto>().HasOne<Categoria>(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(c => c.CategoriaId);
        }
    }
