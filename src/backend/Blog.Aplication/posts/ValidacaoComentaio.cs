using Blog.Aplication.posts.interfaces;
using Blog.Comunication.request;
using Blog.Exception;
using Blog.Exception.excecao;
using FluentValidation;


namespace Blog.Aplication.posts
{
    public class ValidacaoComentaio :  AbstractValidator<RequestCommentsJSON>, IValidacaoComentario
    {
        public ValidacaoComentaio()
        {
            RuleFor(post => post.Comment).validarIsNullOrEmpt(MensagemExcecao.Comentario_Vazio);           

        }
        void IValidacaoComentario.ValidarELancarExcecao(RequestCommentsJSON obj)
        {
            var resultado = Validate(obj);

            if (!resultado.IsValid)
            {
                var erros = resultado.Errors.Select(e => e.ErrorMessage).ToList();
                throw new BlogExcecaoValidacao(erros);
            }
        }
        public List<string> ValidarERetornarErros(RequestCommentsJSON objeto)
        {
            var resultado = Validate(objeto);
            return resultado.Errors.Select(e => e.ErrorMessage).ToList();
        }

        // Método para verificar se é válido
        public bool EhValido(RequestCommentsJSON objeto)
        {
            return Validate(objeto).IsValid;
        }
    }
    
}
