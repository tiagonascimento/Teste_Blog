
using System.Text.Json.Serialization;

namespace Blog.Comunication.request
{
    public  class RequestCommentsJSON
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int IdPost { get; set; }
        public string Comment { get; set; }       
    }
}
