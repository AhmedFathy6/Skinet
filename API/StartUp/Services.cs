using API.Helper;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.StartUp
{
    public static class Services
    {
       public static void  GetServices(IServiceCollection services, IConfiguration _config) 
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DevelopmentConnection")));
            services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });  });
            services.AddCors(options=>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(_config.GetSection("AllowOrgins").Get<string[]>());
                });
            }
            );
        }
    }
}
