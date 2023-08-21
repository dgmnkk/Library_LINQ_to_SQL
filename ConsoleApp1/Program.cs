using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DataClasses1DataContext db = new DataClasses1DataContext();

            var query = Method2(db, "B");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} {item.Author.Name}");
            }
        }

        static IQueryable<Book> Method1(DataClasses1DataContext db, int number)
        {
            return db.Books.Where(x => x.Pages > number);
        }

        static IQueryable<Book> Method2(DataClasses1DataContext db, string letter)
        {
            return db.Books.Where(x => x.Name.ToLower().StartsWith(letter.ToLower()));
        }

        static IQueryable<Book> Method3(DataClasses1DataContext db, string name, string surname)
        {
            return db.Books.Where(x => x.Author.Name == name && x.Author.Surname == surname);
        }

        static IQueryable<Book> Method4(DataClasses1DataContext db, string country)
        {
            return db.Books.Where(x => x.Author.Country.Name == country).OrderBy(x => x.Author.Country.Name);
        }

        static IQueryable<Book> Method5(DataClasses1DataContext db, int number)
        {
            return db.Books.Where(x => x.Name.Length < number);
        }

        static Book Method6(DataClasses1DataContext db, string country)
        {
            return db.Books.Where(x=> x.Author.Country.Name == country).OrderByDescending(x=> x.Pages).First();
        }

        static Author Method7(DataClasses1DataContext db)
        {
            return db.Authors.OrderBy(x=> x.Books.Count).FirstOrDefault();
        }

        static Country Method8(DataClasses1DataContext db)
        {
            return db.Countries.OrderByDescending(x=> x.Authors.Count).FirstOrDefault();
        }
    }
}