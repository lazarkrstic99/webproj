using System.ComponentModel.DataAnnotations;
namespace webproj.Models
{
    public class Sahista
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Ime { get; set; }
        [MaxLength(255)]
        public string Prezime { get; set; }
        [MaxLength(255)]
        public string Titula {get;set; }
        public int Rejting {get;set; }
    }
}