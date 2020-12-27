using Core.Entities;


namespace Core.Specafications
{
    public class ProductFilters : Specifcation<Product>
    {
        public ProductFilters(ProductParams productParams) :
           base(criteria: x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
