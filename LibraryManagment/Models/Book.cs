using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50)]
        public string Author { get; set; }

        [Range(1000, 2100, ErrorMessage = "Year must be between 1000 and 2100")]
        public int Year { get; set; }

        [StringLength(30, ErrorMessage = "Genre must be at most 30 characters")]
        public string Genre { get; set; }
    }
}
