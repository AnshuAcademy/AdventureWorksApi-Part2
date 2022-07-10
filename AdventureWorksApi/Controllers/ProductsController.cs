using AdventureWorksPersistence.DataAccess;
using AdventureWorksPersistence.Entities.Product;
using AdventureWorksPersistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAdventureWorksDataAccess data;

        public ProductsController(IAdventureWorksDataAccess data)
        {
            this.data = data;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await data.GetProducts());

        }

        [HttpGet("GetProductByID")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            return Ok(await data.GetProductById(id));

        }

        [HttpGet("GetCustomProductByID")]
        public async Task<IActionResult> GetCustomProductByID(int id)
        {
            return Ok(await data.GetCustomProductById(id));

        }

        [HttpPost("AddProduct")]
        public async Task<int> AddProduct(AddProductDto addProductDto)
        {
            return await data.AddProduct(addProductDto);
        }

        [HttpPut("EditProduct")]
        public async Task<bool> EditProduct(EditProductDto editProductDto,int id)
        {
            return await data.EditProduct(editProductDto, id);
        }

    }
}
