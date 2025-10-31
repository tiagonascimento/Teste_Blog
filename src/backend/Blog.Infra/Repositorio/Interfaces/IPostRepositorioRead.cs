using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Repositorio.Interfaces
{
    public interface IPostRepositorioRead
    {
        public Task<Bog.Domain.entities.Post> GetPost(int id);

        public Task<List<Bog.Domain.entities.Post>> GetAllPost();
      
    }
}
