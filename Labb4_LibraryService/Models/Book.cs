using Labb4_LibraryService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Models
{
    public class Book : IEntityBase
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titel { get; set; }
        [Required]
        public string Author { get; set; }


        //Nav Prop n:m
        public ICollection<Customer_Books> Customer_Books { get; set; }
    }
}
