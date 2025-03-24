using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext // a classe herda de DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //informa o provedor de banco de dados e a string de conexão
        }

        //DbSet mapeia as entidades para tranforma em tabelas do banco
        public DbSet<Category> Categories { get; set; } // cria um DbSet para a entidade Category mapeando para tabela Categories no bd
        public DbSet<Product> Products { get; set; } // cria um DbSet para a entidade Product mapeando para tabela Products no bd

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}