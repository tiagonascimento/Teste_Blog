
using Blog.Infra.Repositorio;
using Blog.Infra.Repositorio.Interfaces;
using Blog.Infra.Repositorio.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infra
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfra(this IServiceCollection service, IConfiguration config)
        {
            addRepositorio(service);
            AddContex_MySQL(service, config);
        }
        private static void addRepositorio(IServiceCollection service)
        {
            service.AddScoped<IPostRepositorioWrite, PostRepositorio>();
            service.AddScoped<IPostRepositorioRead, PostRepositorio>();
            service.AddScoped<IComentarioRepositorioWrite, ComentarioRepositorio>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        private static void AddContex_MySQL(IServiceCollection services, IConfiguration config)
        {

            var strConnection = config["ConnectionStrings:MySqlConnection"];
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));


            services.AddDbContext<BlogDbContext>(opt =>
            {
                opt.UseMySql(strConnection, serverVersion);
            });
        }
    }
}
