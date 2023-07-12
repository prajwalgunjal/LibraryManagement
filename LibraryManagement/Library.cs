﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement
{
    public class Library
    {
        private string connection = $"Data source= PRAJWAL; Database = library; Integrated Security = true; TrustServerCertificate = true";
        private SqlConnection sqlConnection;
        public Library() { 
            sqlConnection = new SqlConnection(connection);
        }
        public bool add_book(Book book) 
        {
            try
            {
                sqlConnection.Open();
                string query = "AddBook";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@book_id", book.Book_id);
                sqlCommand.Parameters.AddWithValue("@title", book.Title);
                sqlCommand.Parameters.AddWithValue("@author", book.Author);
                sqlCommand.Parameters.AddWithValue("@genre", book.Genre);
                sqlCommand.Parameters.AddWithValue("@borrowed", 0);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected in Contact Table");
                    Console.WriteLine("Data added .....");
                    sqlConnection.Close();

                    return true;
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                    sqlConnection.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool get_total_books()
        {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "DisplayBooks";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                    /*Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                    Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}  ");
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public bool get_available_books() {

            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "DisplayAvaliableBooks";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                   /* Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                    Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre} ");
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool get_borrowed_books(){
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "DisplayBorrowedeBooks";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {

                    /* Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                         $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                    Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public bool get_books_by_author(string input) {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "get_books_by_author";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@author", input);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {
                    
                        /* Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                             $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                        Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                            $"\t Genre:- {book.Genre}");
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

       public bool get_books_by_genre(string genre) {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "get_books_by_genre";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@genre", genre);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {

                    /* Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                         $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                    Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}");

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public bool get_book_details(int book_id) {
            try
            {
                List<Book> list = new List<Book>();
                sqlConnection.Open();
                string Query = "get_books_by_book_id";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@book_id", book_id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Book_id = (int)reader["book_id"],
                        Title = (string)reader["title"],
                        Author = (string)reader["author"],
                        Genre = (string)reader["genre"],
                        Borrowed = (bool)reader["borrowed"],
                    };
                    list.Add(book);
                }
                foreach (Book book in list)
                {

                    /* Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                         $"\t Genre:- {book.Genre}  \t Borrowed: - {book.Borrowed}");*/
                    Console.WriteLine($"Book_id: {book.Book_id}\t Title:- {book.Title}\t Author:- {book.Author}" +
                        $"\t Genre:- {book.Genre}");

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Something went wrong");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        /*public void borrow_book(book_id, borrower) { }
       public void return_book(book_id) { }
        */

    }
}
