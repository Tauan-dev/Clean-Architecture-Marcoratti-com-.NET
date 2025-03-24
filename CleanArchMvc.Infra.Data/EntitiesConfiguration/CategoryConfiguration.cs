using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // a interface gera uma instância de EntityTypeBuilder<Category> que é passada como parâmetro para o método Configure
            // o método Configure é implementado para configurar a entidade Category para quando for aplicado a migration, ela seguir o que foi configurado aqui
            //https://learn.microsoft.com/pt-br/dotnet/api/microsoft.entityframeworkcore.metadata.builders.entitytypebuilder?view=efcore-8.0   onde encontrar outras propriedades e métodos
           
            builder.HasKey(t => t.Id); // Haskey define a propriedade Id como chave primária
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(); // Property define a propriedade Name com tamanho máximo de 100 caracteres e como obrigatória

            // t e p são alias que se referem a Cetegory, onde t se refere a entidade em si e p a uma propriedade da entidade

        }
    }
}