using CardShop.DAL.Interfaces;
using CardShop.DAL.Repositories;
using CardShop.Domain.Models;
using CardShop.Service.Implementations;
using CardShop.Service.Interfaces;

namespace CardShop
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<GraphicsCard>, GraphicsCardRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphicsCardService, GraphicsCardService>();
        }
    }
}
