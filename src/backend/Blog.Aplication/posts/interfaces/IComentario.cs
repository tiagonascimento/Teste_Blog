
using Blog.Comunication.request;

namespace Blog.Aplication.posts.interfaces
{
    public interface IComentario
    {
        public Task<bool> CriarComentario(RequestCommentsJSON comet);
    }
}
