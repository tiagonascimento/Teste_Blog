

namespace Blog.Infra.Repositorio.Interfaces
{
    public  interface IComentarioRepositorioRead
    {
        public Task <List<Bog.Domain.entities.Comentario>> GetComentario(int idPost);        

    }
}
