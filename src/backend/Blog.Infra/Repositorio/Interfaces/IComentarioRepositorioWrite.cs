namespace Blog.Infra.Repositorio.Interfaces
{
    public interface IComentarioRepositorioWrite
    {
        public Task AddComentario(Bog.Domain.entities.Comentario coment);
    }
}
