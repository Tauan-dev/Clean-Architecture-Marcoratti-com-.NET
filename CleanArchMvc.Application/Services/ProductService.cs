using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository; // instanciar o repository
        private readonly IMapper _mapper; // instanciar o mapper

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            return _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productCategories = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productCategories);
        }

        public Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            return _productRepository.RemoveAsync(productEntity);
        }

        public Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            return _productRepository.UpdateAsync(productEntity);
        }
    }
}