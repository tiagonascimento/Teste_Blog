using Blog.Aplication.posts;
using Blog.Aplication.posts.interfaces;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
namespace Blog.Aplication
{
    public static class DependecyInjectionExtension
    {
        public static void AddAplicacao(this IServiceCollection service)
        {
            addRepositorio(service);
        }
        private static void addRepositorio(IServiceCollection service)
        {

            service.AddScoped<IMapper, Mapper>();
            service.AddScoped<IValidacaoPost, ValidacaoPost>();
            service.AddScoped<IValidacaoComentario, ValidacaoComentaio>();
            service.AddScoped<IPost, Post>();
            service.AddScoped<IComentario, Comentario>();

        }
    }
}
