using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_LibraryService.Models
{
    public class Customer_Books
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        [Required]
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }



        //Nav prop
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
