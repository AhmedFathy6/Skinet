using Core.Entities;
using Core.Specafications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using API.Dots;
using AutoMapper;
using API.Errors;
using API.Helper;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepo, 
                                  IGenericRepository<ProductBrand> brandRepo, 
                                  IGenericRepository<ProductType> typeRepo,
                                  IMapper mapper)
        {
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProductsAsync([FromQuery]ProductParams productParams)
        {
            var spec = new ProductSpecifcation(productParams);
            var specCount = new ProductFilters(productParams);
            var totalItems = await productRepo.CountAsync(specCount);
            var products = await productRepo.ListAsync(spec);
            var data = mapper.Map<List<Product>, List<ProductToReturnDto>>((List<Product>)products);

            if (products == null)
            {
                return NotFound(new ApiResponce(404));
            }
            return Ok(new Pagination <ProductToReturnDto>(productParams.PageIndex, productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductAsync(int id)
        {
            var product = mapper.Map<Product, ProductToReturnDto>(await productRepo.GetEntityWithSpec(new ProductSpecifcation(id)));
            if (product == null)
            {
                return NotFound(new ApiResponce(404));
            }
            return product;
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetBrandsAsync() => Ok(await brandRepo.ListAllAsync());

        [HttpGet("Types")]
        public async Task<ActionResult<List<ProductType>>> GetTypesAsync() => Ok(await typeRepo.ListAllAsync());

    }
}
