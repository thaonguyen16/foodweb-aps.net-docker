using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace FoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IDistributedCache _cache;
        private List<Models.Food> foodList = new List<Models.Food>();

        public void addFood()
        {
            this.foodList.Add(
                new Models.Food(1, "Pizza", "https://i.pinimg.com/564x/34/f4/8f/34f48f5c56c938642b80b0555e5adf82.jpg", "200,000"));
            this.foodList.Add(
                new Models.Food(2, "Spaghetti", "https://i.pinimg.com/474x/a1/9a/12/a19a120db960178b1ef689cccf0263e2.jpg", "49,000"));
            this.foodList.Add(
                new Models.Food(3, "Fried chicken thighs", "https://i.pinimg.com/474x/5c/7a/bf/5c7abf4bf3ac7440af505641a682d7cc.jpg", "39,000"));
            this.foodList.Add(
                new Models.Food(4, "Fried shrimp", "https://i.pinimg.com/564x/b0/7f/d5/b07fd5e0ce5f83664f6e53b358c00561.jpg", "149,000"));
            this.foodList.Add(
                new Models.Food(5, "Seafood Boil", "https://i.pinimg.com/564x/e8/a3/dd/e8a3ddbc38cbc86a7f3f8793bd0971d5.jpg", "590,000"));
            this.foodList.Add(
                new Models.Food(6, "Banh Xeo", "https://i.pinimg.com/474x/9e/59/5d/9e595df6543706a9b433e326873944d9.jpg", "49,000"));
            this.foodList.Add(
               new Models.Food(7, "Goi cuon", "https://i.pinimg.com/474x/91/2b/23/912b2395a8a6b9de7835c982800bbd28.jpg", "49,000"));

            this.foodList.Add(
               new Models.Food(8, "Grilled scallops", "https://i.pinimg.com/564x/d0/7b/23/d07b23fbb9c1bfd5cee40571661f0d7a.jpg", "59,000"));


        }

        public FoodController(ILogger<FoodController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet(Name = "GetFood")]
        public List<Models.Food> Get()
        {
            addFood();
            return this.foodList;
        }

    }
}
