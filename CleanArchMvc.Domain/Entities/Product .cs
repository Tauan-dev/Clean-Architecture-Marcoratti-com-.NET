using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public class Product : EntityBase
    {
     
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }


        public Product(int id, string name, string description, decimal price, int stock,)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }


        public void Update(string name, string, description, decimal price, int stock, string image, int CategoryId)
        {
            ValidateDomain(name, description, price, stock, image);
        }


        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id");
            DomainExceptionValidation.When(stock < 0, "Stock invalid, minimum value needed is 0");
            DomainExceptionValidation.When(price < 0, "Price invalid, minimum value needed is 0");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, to short");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }  // chave estrangeira relacionada a Category
        public Category Category { get; set; }


    }
}