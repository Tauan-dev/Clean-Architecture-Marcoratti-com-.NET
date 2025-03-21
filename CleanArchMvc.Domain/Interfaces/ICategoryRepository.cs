using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(); // A classe task  define uma operação assincrona e o IEnumerable me retorna uma lista de categorias 
        Task<Category> GetByIdAsync(int? id); // Retorna uma categoria pelo id
        Task<Category> CreateAsync(Category category); // Cria uma categoria
        Task<Category> UpdateAsync(Category category); // Atualiza uma categoria
        Task<Category> RemoveAsync(Category category); // Remove uma categoria
    }
}