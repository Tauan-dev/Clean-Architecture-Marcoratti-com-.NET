using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection // os recursos usados no projeto são definidos nessa classe
    {
        // é criado o metodo AddInfrastructure que vai ser utilizado na classe Startup, seja de webui ou api para  ser utilizado nos controladores
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string 'DefaultConnection' is null or empty.");
            } // verifica se a string de conexão é nula ou vazia
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
           
            //o primeiro passo adiciona o contexto dbContext
            //Depois se é definido o provedor do banco de dados, nesse caso o MySQL e a string de conexão 
            // por fim é definido que as migrations vão ficar na pasta do projeto onde está definido o ApplicationDbContext (nesse caso o projeto Infra.Data)

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}