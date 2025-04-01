using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebAPI.Controllers
{
    [ApiController] // permite para habilitar recursos
    [Route("api/[controller]")] // define a rota para acessar a api, pegando como referencia de nome o nome da classe, ou seja, a rota vai ser api/categories
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; // instância o service de category
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound("Categories not found"); // retorna o código de status 404 caso não encontre nada
            }

            return Ok(categories); // retorna o código 200 e a lista 
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        { // FromBody indica que os dados estão vindo via corpo da requisição
            if (categoryDto == null)
            {
                return BadRequest("Invalid Data");
            }
            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id }, categoryDto); // os parametros utilizam a requisição do metodo de getby id pra retornar a categoria criada no banco
            // retorna o status 201 indicando que a categoria foi criada 
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Invalid Id");
            }

            if (categoryDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return BadRequest("Invalid data");
            }

            await _categoryService.Remove(id);
            return Ok(category);
        }

    }
}