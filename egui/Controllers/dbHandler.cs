using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using egui.Models;

namespace egui.Controllers
{
    class dbHandler
    {
        private SQLiteConnection m_dbConnection;

        public void createNewDatabase()
        {
            SQLiteConnection.CreateFile("dbm.db");
        }

        public void createTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS BOOK( AUTHOR TEXT NOT NULL, TITLE TEXT NOT NULL, YEAR INTEGER NOT NULL)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=dbm.db;Version=3;");
            m_dbConnection.Open();
        }

        void fillTable()
        {
            string sql = "insert into Book (Author, Title, Year) values ('dfdf', 'dfdf', 1997)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Book (Author, Title, Year) values ('dfdf', 'dfdf', 1997)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Book (Author, Title, Year) values ('dfdf', 'dfdf', 1997)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void insertBook(Book book)
        {
            string sql = $"insert into Book (Title, Author, Year) values ('{(book.Title)}', '{(book.Author)}', {(book.Year)})";
            connectToDatabase();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public SQLiteDataReader LoadData()
        {
            //createNewDatabase();
            connectToDatabase();
            //createTable();
            //fillTable();
            string sql = "select rowid,* from Book";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void EditAuthor(string author, int index)
        {
            connectToDatabase();
            string sql = $"UPDATE BOOK SET AUTHOR = '{author}' WHERE id={index};";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return;
        }

        public void EditTitle(string title, int index)
        {
            connectToDatabase();
            string sql = $"UPDATE BOOK SET TITLE = '{title}' WHERE id={index};";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return;
        }
        public void EditYear(int year, int index)
        {
            connectToDatabase();
            string sql = $"UPDATE BOOK SET YEAR = '{year}' WHERE id={index};";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return;
        }

        public void EditBook(int index, string author, string title, int year)
        {
            connectToDatabase();
            string sql = $"UPDATE BOOK SET AUTHOR = '{author}',TITLE = '{title}',YEAR = '{year}' WHERE id={index};";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return;
        }
       
        public Book FindBook(int index)
        {
            connectToDatabase();
            string sql = $"SELECT * FROM BOOK WHERE id={index};";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            Book bk = new Book();
            while (reader.Read())
            {
                bk.Id = Convert.ToInt32(reader["id"]);
                bk.Author = reader["Author"].ToString();
                bk.Title = reader["Title"].ToString();
                bk.Year = Convert.ToInt32(reader["year"]);
            }
            return bk;
        }

        public void DeleteRecord(int id)
        {
            connectToDatabase();
            string sql = $"DELETE FROM BOOK where id={id}";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            return;
        }

        public List<int> LoadYears()
        {
            connectToDatabase();
            string sql = $"SELECT YEAR FROM BOOK";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<int> years = new List<int>();

            while (reader.Read())
            {

                years.Add(Convert.ToInt32(reader["Year"]));
            }

            return years;
        }

        public List<Book> loadFilters(string sql)
        {
            connectToDatabase();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<Book> bk = new List<Book>();
            while (reader.Read())
            {
                bk.Add(new Book { Id = Convert.ToInt32(reader["Id"]), Title = (reader["Title"].ToString()), Author = (reader["Author"].ToString()), Year = Convert.ToInt32(reader["Year"]) });
            }
            return bk;
        }

    }
}

