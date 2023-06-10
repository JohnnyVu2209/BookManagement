using AutoMapper;
using BookManagement.Server.BL.Mapping;
using BookManagement.Server.BL.Services;
using BookManagement.Server.BL.Services.Interfaces;
using BookManagement.Server.DL;
using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.Repositories;
using BookManagement.Server.DL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace BookManagement.Server.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<BookShopDbContext>(
                options =>
                {
                    options.UseSqlServer(connectionString, b =>

                    {
                        b.MigrationsAssembly("BookManagement.Server.API");
                        b.EnableRetryOnFailure();

                    }
                        );

                }
                    );
            services.AddScoped<IRepository<Book>,BookRepository>();
            services.AddScoped<IRepository<User>,UserRepository>();

            services.AddScoped<IBookService,BookService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
