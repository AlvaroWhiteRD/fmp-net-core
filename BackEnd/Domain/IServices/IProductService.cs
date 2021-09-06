using AlvaroFacturacionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlvaroFacturacionApi.Domain.IServices
{
    public interface IProductService
    {
        Task CreateNewProduct(Products product);

        Task UpdateProduct(Products product);

        Task RemoveProduct(int productId);

        Task<List<Products>> GetListProducts();

        Task<Products> GetProductDetailById(int productID);

        Task<bool> ValidateProductExists(Products product);
    }
}
