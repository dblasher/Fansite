using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSite.Models
{
    public static class BookRepository
    {
        private static List<Book> books = new List<Book>();

        public static List<Book> Books { get { return books; } }

        static BookRepository(){
            addTestData();
        }
        public static void AddBook(Book book)
        {
            books.Add(book);
        }

        static void addTestData()
        {
            Book book1;
            Book book2;
            Book book3;

            book1 = new Book()
            {
                Title = "Gandhi: The Years That Changed the World, 1914-1948",
                Author = "Ramachandra Guha",
                PubDate = "n/a"
            };

            book2 = new Book()
            {
                Title = "Gandhi, Great Soul",
                Author = "John B. Severance",
                PubDate = "n/a"
            };

            book3 = new Book()
            {
                Title = "Gandhi, Women, and the National Movement, 1920-47",
                Author = "Anup Taneja",
                PubDate = "n/a"
            };
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
        }
    }
}
