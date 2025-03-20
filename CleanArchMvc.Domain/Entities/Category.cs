using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category //sealed faz com que a classe não possa ser herdada
    {   
        // todos os sets são private, o que garante que os objetos do modelo de dominio não possam ter seus valores alterados ou atribuidos externamentes 
        public int Id { get; private set; }   // para iniciar um atributo, utilize o comando prop e de tab 2x e coloque o nome do atributo e seu tipo 
        public string Name { get; private set; }





        
        ICollection<Product> Products { get; private set; } // o ICollection faz a ligação de Category com product funcionando como em uma relação 1:N 
    }
}