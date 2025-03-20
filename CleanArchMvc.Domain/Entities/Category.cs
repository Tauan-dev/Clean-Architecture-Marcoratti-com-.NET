using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category //sealed faz com que a classe não possa ser herdada
    {
        // todos os sets são private, o que garante que os objetos do modelo de dominio não possam ter seus valores alterados ou atribuidos externamentes 
        public int Id { get; private set; }
        public string Name { get; private set; }

        // para permitir a criação de objetos se é criado um construtor parametrizado

        public Category(string name) // utilize o comando ctor para fazer o construtor (defina os parametros com os atributos da classe)
        {
            Name = name;
        }

        public Category(int id, string name) // o entity framework não necessita de um valor id para criar um objeto, porém quando for necessário popular o banco utilizando o id, o construtor com id é necessário
        {
            Id = id;
            Name = name;
        }

        //a partir de agora quem for criar um objeto do tipo Category, precisará fornecer os valores do name ou do id e name

        ICollection<Product> Products { get; private set; }
    }
}