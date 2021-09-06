
using AlvaroFacturacionApi.Domain.IRepositories;
using AlvaroFacturacionApi.Domain.IServices;
using AlvaroFacturacionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlvaroFacturacionApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateNewProduct(Products product)
        {
           await _productRepository.CreateNewProduct(product);
        }

        public async Task<bool> ValidateProductExists(Products product)
        {
            return await _productRepository.ValidateProductExists(product);
        }

        public async Task<List<Products>> GetListProducts()
        {
            return await _productRepository.GetListProducts();
        }

        public async Task<Products> GetProductDetailById(int productID)
        {
           return await _productRepository.GetProductDetailById(productID);
        }

        public async Task RemoveProduct(int product)
        {
            await _productRepository.RemoveProduct(product);
        }

        public async Task UpdateProduct(Products product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}