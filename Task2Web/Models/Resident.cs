using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2Web.Models
{
    public class Resident
    {
        [Key]
        public int ResidentId { get; set; }
        [Required]
        public string ResidentName { get; set; }
        [Required]
        public string ResidentSurname { get; set; }
        [Required]
        public string ResidentPersonalID { get; set; }
        [Required]
        public string ResidentBirthday { get; set; }
        [Required]
        public string ResidentPhoneNumber { get; set; }
        [Required]
        public string ResidentEmail { get; set; }
      

        public int FlatId { get; set; }
        public Flat Flat { get; set; }

    }
}
