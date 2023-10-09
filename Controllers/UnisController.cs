using Microsoft.AspNetCore.Mvc;
using Task_Unis.Models;

namespace Task_Unis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnisController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UnisController(UniversityContext context) 
        { 
            _context = context;
        }

        /*
        [HttpGet()]
        public async Task<ActionResult> GetAsync()
        {
            var client = new HttpClient();
            var request = await client.GetAsync("http://universities.hipolabs.com/search");
            //var response = await client.GetAsync(request);
            request.EnsureSuccessStatusCode();
            var result = await request.Content.ReadAsStringAsync();
            //Console.WriteLine(result);
            var line_uni = JsonConvert.DeserializeObject<List<Unis_Json>>(result);
            return Ok();
        }
        */

        [HttpPost]
        public async Task<ActionResult> PostAsync(string name, string country, string url)
        {

            var test = new University();
            test.UniversityName = name;
            test.UniversityCountry = country;
            test.UniversityUrl = url;
            _context.Add(test);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}