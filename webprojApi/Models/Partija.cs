using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace webproj.Models
{
    public class Partija
    {
        [Key]
        public int Id { get; set; }
        public Sahista BeliSahista { get; set; }
        public Sahista CrniSahista { get; set; }
        [MaxLength(255)]
        public string Ishod {get;set;}
        public int Trajanje {get;set;}
        public Turnir Turnir{get;set;}
    }
}