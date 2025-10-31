using Blog.Aplication.posts.interfaces;
using Blog.Comunication.request;
using Blog.Exception;
using Blog.Exception.excecao;
using FluentValidation;


namespace Blog.Aplication.posts
{
    public class ValidacaoPost : AbstractValidator<ResquestPostJSON>, IValidacaoPost
    {
        public ValidacaoPost()
        {
            RuleFor(post => post.PostJson).validarIsNullOrEmpt(MensagemExcecao.Post_Vazio);
            RuleFor(post => post.Titulo).validarIsNullOrEmpt(MensagemExcecao.Titulo_Vazio);

        }
        public void ValidarELancarExcecao(ResquestPostJSON obj)
        {
            var resultado = Validate(obj);

            if (!resultado.IsValid)
            {
                var erros = resultado.Errors.Select(e => e.ErrorMessage).ToList();
                throw new BlogExcecaoValidacao(erros);
            }
        }
        public List<string> ValidarERetornarErros(ResquestPostJSON objeto)
        {
            var resultado = Validate(objeto);
            return resultado.Errors.Select(e => e.ErrorMessage).ToList();
        }

        // Método para verificar se é válido
        public bool EhValido(ResquestPostJSON objeto)
        {
            return Validate(objeto).IsValid;
        }
    }
}
