using System;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using egui.Controllers;

namespace egui.Models
{
    public class Book
    {
        public Book() { }
        public Book(string author, string title, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format("{{ \"id\":{0}, \"title\":\"{1}\", \"author\":\"{2}\", \"year\":{3} }}", Id, Title, Author, Year);
        }

        public static explicit operator Book(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<egui.Models.Book> Book { get; set; }
    }
}
