using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext; // cria uma instância do contexto
        public CategoryRepository(ApplicationDbContext context) // construtor pra injetar a instância
        {
            _categoryContext = context; // me permite utilizar todos os recursos da DbContext
        }


        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category); // inclui a categoria no contexto
            await _categoryContext.SaveChangesAsync(); // persiste os dados no banco
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            var category = await _categoryContext.Categories.FindAsync(id); // busca a categoria pelo id
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category); // remove a categoria do contexto
            await _categoryContext.SaveChangesAsync(); // persiste a remoção no banco
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category); // atualiza a categoria do contexto
            await _categoryContext.SaveChangesAsync(); // persiste a atualização no banco
            return category;
        }
    }
}