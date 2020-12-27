using Core.Entities;

namespace Core.Specafications
{
    public  class ProductSpecifcation : Specifcation<Product>
    {
        public ProductSpecifcation(ProductParams productParams) : 
            base(criteria: x =>
                 (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                 (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                 (!productParams.TypeId.HasValue  || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }

                

        }

        public ProductSpecifcation(int id) : base(criteria: x => x.Id == id)
        {
             AddInclude(p => p.ProductBrand);
             AddInclude(p => p.ProductType);            
        }

    }
}
