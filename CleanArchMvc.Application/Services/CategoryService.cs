using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Add(CategoryDTO categoryDto)
        {
            // em metodos que persistem dados no banco, a lógica é feita de forma diferente dos gets, pois já recebemos o  categoryDto, e para inserir no banco temos que converte para o tipo Category

            var categoryEntity = _mapper.Map<Category>(categoryDto); // mapeia o metodo
            await _categoryRepository.CreateAsync(categoryEntity); // cria a categoria no banco
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync(); //o metodo get categories vai retornar uma lista de categories através da instância do Repository de categories (lembrando que é uma lista de entidades, por isso a variavel está no plural )
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity); // o metodo mapper na instância mapper retorna o Ienumerable DTO de categories, mapeando 
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result; // caso não tivesse o result, o retorno seria um task de category, e não a categoria em si
            await _categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }


    }
}