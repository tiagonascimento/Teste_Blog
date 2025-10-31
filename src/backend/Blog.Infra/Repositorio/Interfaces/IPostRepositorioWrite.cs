
namespace Blog.Infra.Repositorio.Interfaces
{
    public interface IPostRepositorioWrite
    {
        public Task AddPost(Bog.Domain.entities.Post post);
    }
}
