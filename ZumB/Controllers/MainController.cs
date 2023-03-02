using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text.Json;
using ZumB.Model;

namespace ZumB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        static HttpClient client = new HttpClient();
        Functions fun = new Functions();

        public MainController()
        {

        }

        /**
         * Collect, filters, sorts post from external api based on several factors.
         *
         * @param   string  tags                contains string of tags, can be more than one separted by comma.
         * @param   string  direction optional  contains sorting pattern of list, default value ascending
         * @param   string  sortBy    optional  contains sorting creteria for collected posts, could be id, likes, reads, popularity
         * 
         * @return  Task<IActionResult>         Json List of post object.
         */
        [HttpGet("/Posts")]
        public async Task<IActionResult> getList(string tags, string? direction= "asc", string? sortBy = "Id")
        {
            if (tags.Equals(""))
            {
                return Json("Missing required request parameters: [tag]");
            }

            if(!direction.Equals("desc",StringComparison.InvariantCultureIgnoreCase) &&
                !direction.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
            {
               return Json("direction parameter is invalid");
            }

            if (!sortBy.Equals("id", StringComparison.InvariantCultureIgnoreCase) &&
                !sortBy.Equals("reads", StringComparison.InvariantCultureIgnoreCase) &&
                !sortBy.Equals("popularity", StringComparison.InvariantCultureIgnoreCase) &&
                !sortBy.Equals("likes", StringComparison.InvariantCultureIgnoreCase))
            {
                return Json("sortBy parameter is invalid");
            }


            List<string> tagsList = tags.Split(",").ToList<string>();
            List<Posts> allPosts = new List<Posts>();  
            
            //Fetching data for each tag
            foreach(string tag in tagsList)
            {
                HttpResponseMessage response = await client.GetAsync("https://api.assessment.skillset.technology/a74fsg46d/posts?tag="+tag);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (jsonString.Length>0)
                    {
                        Post post1 = JsonSerializer.Deserialize<Post>(jsonString);

                        allPosts.AddRange(post1.Posts); // Adding list of each tag to main list that has all posts

                    }
                }
            }

            allPosts = allPosts.DistinctBy(x => x.id).ToList(); // Removing all the duplicates based on the post id or id 

            allPosts = fun.filter(allPosts, sortBy, direction); // Sorting and filtering data


            return Json(allPosts);
      
        }

        

    }
}
