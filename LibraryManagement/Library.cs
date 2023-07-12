using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement
{
    public class Library
    {
       List<Book> ListOfBooks = new List<Book>();
         public void add_book(book) {
            
        
        }
         public void get_total_books() { }
         public void get_available_books() { }
        public void get_borrowed_books(){ }
        public void get_books_by_author(author) { }

        public void get_books_by_genre(genre) { }
        public void borrow_book(book_id, borrower) { }
        public void return_book(book_id) { }
        public void get_book_details(book_id) { }

    }
}
