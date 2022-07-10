using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksPersistence.Entities.Product
{
    public class ProductDto
    {
        [Key]
        /// <summary>
        /// Primary key for Product records.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the product.
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// Unique product identification number.
        /// </summary>
        public string ProductNumber { get; set; } = null!;
        ///   /// <summary>
        /// Product color.
        /// </summary>
        public string? Color { get; set; }
        /// <summary>
        /// Selling price.
        /// </summary>
        public decimal ListPrice { get; set; }
    }

    public class ProductDtoMapper : Profile
    {
        public ProductDtoMapper()
        {
            CreateMap<ProductDto, Models.Product>()
                .ForMember(s => s.ProductID, d => d.MapFrom(x => x.ID))
                .ForMember(s => s.Name, d => d.MapFrom(x => x.ProductName))
                .ReverseMap();
        }
    }
}
