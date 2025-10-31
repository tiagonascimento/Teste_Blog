namespace Blog.Exception.excecao
{
    public class BlogExcecaoValidacao: BlogExcecaoBase
    {
        public IList<string> MensagemErro { get; set; }
        public BlogExcecaoValidacao(IList<string> mensagemsErros)
        {
            MensagemErro = mensagemsErros;
        }
    }
}
