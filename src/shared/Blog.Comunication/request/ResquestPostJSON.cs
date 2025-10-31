
namespace Blog.Comunication.request
{
    public  class ResquestPostJSON
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string PostJson { get; set; }
        public List<RequestCommentsJSON> Comments { get; set; }


    }
}
