
namespace Blog.Comunication.response
{
    public class ResponseException
    {
        public IList<string> MensagemErro { get; set; }
        public ResponseException(IList<string> erros)
        {
            MensagemErro = erros;
        }
        public ResponseException(string erro)
        {
            MensagemErro = [erro];
        }
    }
}
