using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task_Unis.Models;

namespace Task_Unis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUnisController : ControllerBase
    {
        private readonly UniversityContext _context;

        public GetUnisController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAsync()
        {
            var client = new HttpClient();
            var request = await client.GetAsync("http://universities.hipolabs.com/search");
            request.EnsureSuccessStatusCode();
            var result = await request.Content.ReadAsStringAsync();
            var line_uni = JsonConvert.DeserializeObject<List<Unis_Json>>(result);


            foreach (var data in line_uni)
            { 

                var data_name = data.name;
                var data_url = data.web_pages;
                var data_country = data.country;

                var new_entry = new University();
                new_entry.UniversityName = data_name;
                new_entry.UniversityCountry = data_country;
                string v = string.Join(",", data_url);
                new_entry.UniversityUrl = v;

                var ex = _context.Universities.Any(u => u.UniversityName == data_name && u.UniversityCountry == data_country && u.UniversityUrl == v);
                if (!ex) {
                    _context.Add(new_entry);
                    await _context.SaveChangesAsync();
                }
            }

            while (true)
            {
                foreach (var data in line_uni)
                {

                    var data_name = data.name;
                    var data_url = data.web_pages;
                    var data_country = data.country;

                    var new_entry = new University();
                    new_entry.UniversityName = data_name;
                    new_entry.UniversityCountry = data_country;
                    string v = string.Join(",", data_url);
                    new_entry.UniversityUrl = v;

                    var ex = _context.Universities.Any(u =>
                        u.UniversityName == data_name && u.UniversityCountry == data_country && u.UniversityUrl == v);
                    if (!ex)
                    {
                        _context.Add(new_entry);
                        await _context.SaveChangesAsync();
                    }
                }

            }
            return Ok();
        }
    }
}