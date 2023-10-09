using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.Encodings.Web;
using System.Text.Json;
using Task_Unis.Models;

namespace Task_Unis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUniNameController : ControllerBase
    {

        private readonly UniversityContext _context;

        public GetUniNameController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync(string input)
        {
            //var upperFirst = FirstCharToUpper(input);

            var unis = _context.Universities;

            string? UniversityName;
            string? UniversityCountry;
            List<string>? UniversityUrl;
            var name = from uni in unis
                where uni.UniversityName.Contains(input)
                select new
                {
                    UniversityName = uni.UniversityName,
                    UniversityCountry = uni.UniversityCountry,
                    UniversityUrl = uni.UniversityUrl
                };

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            foreach (var item in name)
            {

                var charSeparator = ",";
                List<string> urlList = item.UniversityUrl.Split(charSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
                var tmp = new UniversityCntr(UniversityCountry = item.UniversityCountry, UniversityName = item.UniversityName, UniversityUrl = new List<string>() { item.UniversityUrl });
                string jsonString = JsonSerializer.Serialize(tmp, options);

                Console.WriteLine(jsonString);

            }
            return Ok();
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("You have provided an empty quest!");
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }

    }
}
