
using AlvaroFacturacionApi.Domain.IRepositories;
using AlvaroFacturacionApi.Domain.Models;
using AlvaroFacturacionApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlvaroFacturacionApi.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AplicationDbContext _context;

        public ProductRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewProduct(Products product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            //actualizamos el codigo del producto
            product.ProductCode = "PRO-" + product.Id;

            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateProductExists(Products product)
        {//ProductCode cambiar luego por el nombre del producto
            bool validateExists = await _context.Products.AnyAsync(
                x => x.ProductName == product.ProductName);

            return validateExists;
        }

        public async Task<List<Products>> GetListProducts()
        {
            var productList = await _context.Products.Select(o => new Products
            {
                Id = o.Id,
                ProductCode = o.ProductCode,
                ProductName = o.ProductName,
                ProductDescription = o.ProductDescription,
                PriceOfTheProduct = o.PriceOfTheProduct
            }).ToListAsync();


            return productList;
        }

        public async Task<Products> GetProductDetailById(int productID)
        {
            var product = await _context.Products.Where(x => x.Id == productID)
                                .Select(o => new Products
                                {
                                    Id = o.Id,
                                    ProductCode = o.ProductCode,
                                    ProductName = o.ProductName,
                                    ProductDescription = o.ProductDescription,
                                    PriceOfTheProduct = o.PriceOfTheProduct

                                }).FirstOrDefaultAsync();

            return product;
        }

        public async Task RemoveProduct(int productId)
        {
            //_context.Entry(productId).State = EntityState.Modified;
            var product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Products product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}