namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            while (true) {
                Console.WriteLine("Press 1 : Add New Book");
                Console.WriteLine("Press 2 : Display All Books");
                Console.WriteLine("Press 3 : Display Avaliable Books");
                Console.WriteLine("Press 4 : Display Borrowed Books");
                Console.WriteLine("Press 5 : Display Books By Author Name");
                Console.WriteLine("Press 6 : Display Books By Genre Name");
                Console.WriteLine("Press 7 : Display Books By Id");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Id of Book:- ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("title");
                            string Book_title = Console.ReadLine();
                            Console.WriteLine("Author");
                            string Book_author = Console.ReadLine();
                            Console.WriteLine("Gener");
                            string Book_gener = Console.ReadLine();
                            Book book = new() {
                                Book_id = id,
                                Title = Book_title,
                                Author = Book_author,
                                Genre = Book_gener,
                                Borrowed = false
                            };
                            library.add_book(book);
                            break;
                        }
                    case 2:
                        {
                            library.get_total_books();
                            break;
                        }

                    case 3:
                        {
                            library.get_available_books();
                            break;
                        }

                    case 4:
                        {
                            library.get_borrowed_books();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter name of Author");
                            string author = Console.ReadLine();
                            library.get_books_by_author(author);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter Name of Genre");
                            string genre = Console.ReadLine();
                            library.get_books_by_genre(genre);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter ID");
                            int id = int.Parse(Console.ReadLine());
                            library.get_book_details(id);
                            break;
                        }

                    case 8:
                        {


                        }
                }
            }
        }
    }
}