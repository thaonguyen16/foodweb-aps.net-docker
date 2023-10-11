using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Collections;

namespace BannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly ILogger<CounterController> _logger;
        private readonly IDistributedCache _cache;
        private List<Models.Banner> bannerList = new List<Models.Banner>();

        public void addDate()
        {
            this.bannerList.Add(new Models.Banner(1, "Blog 1", "https://cdn.pixabay.com/photo/2017/05/07/08/56/pancakes-2291908_1280.jpg"));
            this.bannerList.Add(new Models.Banner(2, "Blog 2", "https://cdn.pixabay.com/photo/2017/01/26/02/06/platter-2009590_1280.jpg"));
            this.bannerList.Add(new Models.Banner(3, "Blog 3", "https://cdn.pixabay.com/photo/2019/06/25/13/59/city-4298285_1280.jpg"));
            this.bannerList.Add(new Models.Banner(4, "Blog 4", "https://cdn.pixabay.com/photo/2016/03/27/17/17/friends-1283173_1280.jpg"));
        }

        public CounterController(ILogger<CounterController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet(Name = "GetCounter")]
        public List<Models.Banner> Get()
        {
            addDate();
           /* string key = "Counter";

            string? result = null;
            try
            {
                var counterStr = _cache.GetString(key);
                if (int.TryParse(counterStr, out int counter))
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
                result = counter.ToString();
                _cache.SetString(key, result);
               
            }
            catch (RedisConnectionException)
            {
                result = "Redis cache is not found.";
            }*/
            return this.bannerList;
        }
    }
}
