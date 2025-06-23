using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class BookIndexViewModel
    {
        public List<Book> Books { get; set; }
        public int? FilterYear { get; set; }
    }
}
