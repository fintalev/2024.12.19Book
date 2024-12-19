using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afaffasfa
{
    internal class Book
    {
        private int year;
        private string language;
        private string title;
        private string isbn;
        private int stock;
        private int price;
        private List<Author> authors;

        public string ISBN
        {
            get => isbn;
            set
            {
                if (value.Length != 10)
                    throw new Exception("invalid isbn");
                isbn = value;
            }
        }
        public List<Author> Authors
        {
            get => authors; 
            set
            {
                if (value.Count < 1 || value.Count > 3)
                    throw new Exception("invalid author(s)");
                authors = value;
            }
        }
        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3 || value.Length > 64)
                    throw new Exception("invalid title");
                title = value;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (value < 2007 || value > DateTime.Today.Year)
                    throw new Exception("invalid date");
                year = value;
            }
        }
        public string Language 
        { 
            get => language;
            set 
            {
                if (value != "magyar" && value != "német" && value != "angol")
                    throw new Exception("invalid language");
                language = value; 
            } 
        }
        public int Stock
        {
            get => stock;
            set
            {
                if (value < 0) 
                    throw new Exception("invalid stock");
                stock = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value < 1000 || value > 10000) throw new Exception("invalid price");
                if (value % 100 != 0) throw new Exception("invalid price");
                price = value;
            }
        }

        public Book(string isbn, string title, int year, string language, int stock, int price, List<string> szerzok)
        {
            ISBN = isbn;
            Title = title;
            Year = year;
            Language = language;
            Stock = stock;
            Price = price;
            List<Author> tmp = [];
            foreach (string s in szerzok) tmp.Add(new Author(s));
            Authors = tmp;
        }

        public Book(string title, List<string> author)
        {
            ISBN = new Random().Next(1000000000, 2000000000).ToString();
            Authors=new List<Author>();
            Title=title;
            Year=year;
            Language = language;
            Stock = stock;
            Price=price;
        }

        public override string ToString()
        {
            string x = $"ISBN: {ISBN}\nCim: {Title}\n" +
            $"Nyelv: {Language}\n" +
            $"Készlet: {(Stock != 0 ? Stock : "Beszerzés alatt")}\n" +
            $"Ár: {Price}\n" +
            $"{(Authors.Count() > 1 ? "Szerzők:\n" : "Szerző: ")}";
            foreach (var a in Authors) x += $"{a.Firstname} {a.Lastname}\n";
            return x;
        }

    }
}
