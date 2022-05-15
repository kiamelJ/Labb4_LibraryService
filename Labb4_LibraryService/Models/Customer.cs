using Labb4_LibraryService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Models
{
    public class Customer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Max character is 40 and min character is 2")]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }


        //Nav Prop n:m
        public ICollection<Customer_Books> Customer_Books { get; set; }
    }
}
