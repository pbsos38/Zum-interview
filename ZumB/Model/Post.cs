using System.Text.Json.Serialization;

namespace ZumB.Model
{
    public class Post
    {
        [JsonPropertyName("posts")]
        public List<Posts> Posts { get; set; }
    }
}
