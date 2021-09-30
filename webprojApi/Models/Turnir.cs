using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace webproj.Models
{
     public class Turnir
    {
        [Key]
        public virtual int Id { get; protected set; }
        [MaxLength(255)]
        public virtual string Naziv { get; set; }
        [MaxLength(255)]
        public virtual string Zemlja { get; set; }
        [MaxLength(255)]
        public virtual string Grad { get; set; }
        [JsonIgnore]
        public virtual List<Partija> OdigranePartije { get; set; }
    }
}