using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetById(int? id);
        Task Add(CategoryDTO categoryDto);
        Task Update(CategoryDTO categoryDto);
        Task Remove(int? id);
    }
}