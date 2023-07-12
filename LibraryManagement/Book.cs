using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        int book_id { get; set; }
        string title { get; set; }
        string author { get; set; }
        string genre { get; set; }
        string borrowed { get; set; }
    }
}
