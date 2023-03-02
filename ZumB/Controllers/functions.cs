using ZumB.Model;

namespace ZumB.Controllers
{
    public class Functions
    {

        /**
         * Filters, sorts post from list of post object.
         *
         * @param   List<Posts>  tags        list of all post that needs to be filtered.
         * @param   string       sortBy      contains sorting creteria for collected posts, could be id, likes, reads, popularity
         * @param   string       direction   contains sorting pattern of list
         * 
         * @return  List<Posts> Filtered list of post object.
         */
        public List<Posts> filter(List<Posts> list, string sortBy, string direction)
        {
            List<Posts> localList = new List<Posts>();
            
            switch (sortBy)
            {
                case "Reads":
                    localList = list.OrderBy(i => i.reads).ToList();
                    break;
                case "Likes":
                    localList = list.OrderBy(i => i.likes).ToList();
                    break;
                case "Popularity":
                    localList = list.OrderBy(i => i.popularity).ToList();
                    break;

                default:
                    localList = list.OrderBy(i => i.id).ToList();
                    break;
            }

            switch (direction)
            {
                case "desc":
                    localList.Reverse();
                    break;
                default:
                    break;
            }

            return (localList);
        }
    }
}
