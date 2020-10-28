using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2Web.Models
{
    public class House
    {
        [Key]
        public int HId { get; set; }
        [Required]
      
        public int HouseNumber { get; set; }
        [Required]
      
        public string HouseCity { get; set; }
        [Required]      
        public string HouseCountry { get; set;}
        [Required]   
        public string HousePostIndex { get; set; }
        public List<Flat> Flats { get; set; }
    }
}
