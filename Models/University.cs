using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Task_Unis.Models
{
    public class University
    {
        
        [Key]
        public int UniversityId { get; set; }
        //[JsonProperty("name")]
        public string? UniversityName { get; set; }
        //[JsonProperty("web_pages")]
        public string? UniversityUrl { get; set; }
        //[JsonProperty("country")]
        public string? UniversityCountry { get; set; }

    }
}