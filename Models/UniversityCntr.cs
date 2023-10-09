using System.ComponentModel.DataAnnotations;

namespace Task_Unis.Models
{
    internal class UniversityCntr
    {
        public string UniversityCountry { get; set; } 
        public string UniversityName { get; set; }
        public List<string> UniversityUrl { get; set; }

        public UniversityCntr(string universityCountry, string universityName, List<string> universityUrl)
        {
            UniversityCountry = universityCountry;
            UniversityName = universityName;
            UniversityUrl = (List<string>)universityUrl;
        }
    }
}