
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvaroFacturacionApi.Domain.IServices;
using AlvaroFacturacionApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AlvaroFacturacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public string Get()
        {
            return "applicacion corriendo";
        }

        [HttpPost("{create}")]
        public async Task<IActionResult> CreateNewProduct([FromBody] Products products)
        {
            try
            {
                var validateProductExists = await _productService.ValidateProductExists(products);
                if (validateProductExists)
                {
                    return BadRequest(new { message = "Producto " + products.ProductName + " ya esta registrado" });
                }

                await _productService.CreateNewProduct(products);

                return Ok(new { message = "Producto registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error-> " + ex.Message);
            }
        }

        [HttpPut("{update}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Products products)
        {
            try
            {
               /* var validateProductExists = await _productService.ValidateProductExists(products);
                if (validateProductExists)
                {
                    return BadRequest(new { message = "Producto " + products.ProductName + " ya esta registrado" });
                }*/

                await _productService.UpdateProduct(products);

                return Ok(new { message = "Producto actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error-> " + ex.Message);
            }
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                await _productService.RemoveProduct(Id);

                return Ok(new { message = "Producto eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error-> " + ex.Message);
            }
        }

        
        [HttpGet]
        [Route("listProducts")]
        public async Task<IActionResult> GetListProducts()
        {
            try
            {
                var listProducts = await _productService.GetListProducts();
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error-> " + ex.Message);
            }
        }

    
        [HttpGet]
        [Route("productsById/{productsById}")]
        public async Task<IActionResult> GetProductDetailById(int productsById)
        {
            try
            {
                var listProducts = await _productService.GetProductDetailById(productsById);
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrio un error-> " + ex.Message);
            }
        }
   
    }
}
