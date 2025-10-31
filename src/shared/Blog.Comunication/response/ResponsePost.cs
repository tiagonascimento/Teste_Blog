
namespace Blog.Comunication.response
{
    public class ResponsePost
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Titulo { get; set; }

        public List<ResponseComments>  Comments{ get; set; }
    }
}
