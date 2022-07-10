﻿using AdventureWorksPersistence.Entities.Product;
using AdventureWorksPersistence.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksPersistence.DataAccess
{
    public class AdventureWorksDataAccess : IAdventureWorksDataAccess
    {
        private readonly AdventureWorksDBContext context;
        private readonly IMapper mapper;

        public AdventureWorksDataAccess(AdventureWorksDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddProduct(AddProductDto addProductDto)
        {
            var product = mapper.Map<Product>(addProductDto);

            context.Add(product);

            await context.SaveChangesAsync();

            return product.ProductID;
        }

        public async Task<bool> EditProduct(EditProductDto editProductDto, int id)
        {
            var existingProduct = await context.Product.FindAsync(id);
           
            if (existingProduct != null)
            {
                mapper.Map(editProductDto, existingProduct);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductDto?> GetCustomProductById(int id)
        {
            var productDto = await context.Product
                .Where(x => x.ProductID == id)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return productDto;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await context.Product.FindAsync(id);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var productdtos = await context.Product
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .Take(20).ToListAsync();

            return productdtos;
        }
    }
}