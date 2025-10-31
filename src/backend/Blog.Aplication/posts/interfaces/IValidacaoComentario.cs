using Blog.Comunication.request;


namespace Blog.Aplication.posts.interfaces
{
    public interface  IValidacaoComentario
    {
        public void ValidarELancarExcecao(RequestCommentsJSON obj);
    }
}
