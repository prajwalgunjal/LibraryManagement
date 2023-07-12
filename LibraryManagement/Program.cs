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
                }
            }
        }
    }
}