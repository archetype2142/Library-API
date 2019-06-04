using System;
using System.Collections.Generic;
using egui.Controllers;

namespace egui.Models
{
    public class Books
    {
        private static List<Book> bookList = new List<Book>() {
            new Book() { Id=1, Title="Jeremy", Author="Clarkson", Year=1992},
            new Book() { Id=2, Title="James",   Author="May", Year=3213},
            new Book() { Id=3, Title="Richard", Author="Hamming", Year=1539},
            new Book() { Id=4, Title="Rowan", Author="Atkinson", Year=2019}
        };

        public static List<Book> GetBooks()
        {
            return bookList;
        }

        public static void PUTBook(Book book)
        {
            Console.WriteLine("Book added: " + book.Title);
            dbHandler db = new dbHandler();
            db.insertBook(book);
            bookList.Add(book);
            return;
        }
    }
}
