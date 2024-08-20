using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDInWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsApiController : ControllerBase
    {


        /* Declaring the List to add the Fruits list in the string format */
        private readonly List<string> list = new List<string>()
        {
            "Mango",
            "Apple",
            "Banana",
            "Watermalon",
            "Grapes"
        };

        /*Declaring the method to fetch the List of the Fruits */
        [HttpGet("fruits")]
        public List<string> getFruits() 
        { 
            return list;
        }

        //[Route("sorted")]
        /* Creating the API to sort the List*/
        [HttpGet("sorted")]
        public List<string> getSortedList()
        {
            //List<string> newlist = new List<string>();
            //newlist.Sort();
            list.Sort();
            return list;
        }


        [HttpGet("{id}")]
        public string getFruitsByIndex(int id)
        {
            return list.ElementAt(id);
        }
    }
}
