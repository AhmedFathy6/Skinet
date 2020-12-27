using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dots;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration config;

        public ProductUrlResolver(IConfiguration Config)
        {
            config = Config;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (! string.IsNullOrEmpty(source.PictureUrl))
            {
                return config["ApiUrl"]+source.PictureUrl;
            }
            return null;
        }
    }
}
