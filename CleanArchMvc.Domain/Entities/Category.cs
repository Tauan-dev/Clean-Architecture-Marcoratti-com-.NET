using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation; // importar o validation

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
            ValidateDomain(name);
        }

        public Category(int id, string name) // o entity framework não necessita de um valor id para criar um objeto, porém quando for necessário popular o banco utilizando o id, o construtor com id é necessário
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            ValidateDomain(name);
        }

        //a partir de agora quem for criar um objeto do tipo Category, precisará fornecer os valores do name ou do id e name

        ICollection<Product> Products { get; private set; }

        // incluir comportamentos de validação no modelo de domínio

        public void Update (string name) 
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required"); // regras de validação

            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Too short, minimum 3 characters");
            Name = name; // regras de validação
        }

    }
}