
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Models.Banner> banners { get; set; }
        public List<Models.Food> foods { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            banners = new List<Models.Banner>();
            foods = new List<Models.Food>();
        }

        public async Task OnGet()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://bannerapi/Counter");
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                List<Models.Banner> bannerList = JsonConvert.DeserializeObject<List<Models.Banner>>(result) ?? throw new InvalidOperationException();
                ViewData["Message"] = $"Counter value from cache :{bannerList[0].Image}";

                this.banners = bannerList;
            }

            using (var client = new System.Net.Http.HttpClient())
            {

                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://foodapi/Food");
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                List<Models.Food> foodList = JsonConvert.DeserializeObject<List<Models.Food>>(result) ?? throw new InvalidOperationException();
                ViewData["Message"] = $"Counter value from cache :{foodList[0].Image}";

                this.foods = foodList;
            }


        }
    }
}