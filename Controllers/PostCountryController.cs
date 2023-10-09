using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Task_Unis.Models;

namespace Task_Unis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostCountryController : ControllerBase
    {

        private readonly UniversityContext _context;

        public PostCountryController(UniversityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task PostAsync([Required] string country)
        {

            country = FirstCharToUpper(country);

            var unis = _context.Universities;

            string? UniversityName;
            string? UniversityCountry;
            List<string>? UniversityUrl;
            var nn = from uni in unis
                    where uni.UniversityCountry.Equals(country)
                    select new{ UniversityName = uni.UniversityName,
                UniversityCountry = uni.UniversityCountry,
                UniversityUrl = uni.UniversityUrl
            };

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            foreach (var item in nn)
            {

                var charSeparator = ",";
                List<string> urlList = item.UniversityUrl.Split(charSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();
                var tmp = new UniversityCntr(UniversityCountry=item.UniversityCountry, UniversityName = item.UniversityName, UniversityUrl = new List<string>(){item.UniversityUrl});
                string jsonString = JsonSerializer.Serialize(tmp, options);

                Console.WriteLine(jsonString);

            }

        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("You have provided an empty quest!");
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }

    }
}