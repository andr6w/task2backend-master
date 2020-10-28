using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2Web.Models
{
    public class Flat
    {
        [Key]
        public int FlatId { get; set; }
        [Required]
        public int FlatNumber { get; set; }
        [Required]
        public int FlatFloor { get; set; }
        [Required]
        public int FlatRoomsAmmount { get; set; }
        [Required]
        public int FlatResidentsAmmount { get; set; }
        [Required]
        public double FlatFullArea { get; set; }
        [Required]
        public double FlatLivingSpaceArea { get; set; }
        public int HouseId { get; set; }  // внешний ключ

        [JsonIgnore]
        public House House { get; set; } // навигационное свойство

        [JsonIgnore]
        public List<Resident> Residents { get; set; }


    }
}
