using AdventureWorksPersistence.Entities.Product;
using AdventureWorksPersistence.Models;

namespace AdventureWorksPersistence.DataAccess
{
    public interface IAdventureWorksDataAccess
    {
        Task<List<ProductDto>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<ProductDto?> GetCustomProductById(int id);
        Task<int> AddProduct(AddProductDto addProductDto);
        Task<bool> EditProduct(EditProductDto editProductDto,int id );
    }
}