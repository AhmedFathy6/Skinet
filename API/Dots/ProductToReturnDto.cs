using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dots
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }

        //public ProductToReturnDto() { }

        //public static List<ProductToReturnDto> GetProducts(List<Product> products) => products.Select(p => new ProductToReturnDto(p)).ToList();
        //public ProductToReturnDto(Product product)
        //{
        //    Id = product.Id;
        //    Name = product.Name;
        //    Description = product.Description;
        //    Price = product.Price;
        //    PictureUrl = product.PictureUrl;
        //    ProductType = product.ProductType.Name;
        //    ProductBrand = product.ProductBrand.Name;
        //}
    }
}
