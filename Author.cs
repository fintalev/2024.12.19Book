using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace afaffasfa
{
    internal class Author
    {
        private string firstname;
        private string lastname;

        public Guid Id { get; set; }
        public string Firstname
        {
            get => firstname;
            set
            {
                if (value == null) throw new Exception("Nem adott meg értéket");
                if (value.Length < 3 || value.Length > 32) throw new Exception("A keresztnév nem lehet rövidebb 3 karakternél és hosszabb sem 32 karakternél");
                firstname = value;
            }
        }
        public string Lastname
        {
            get => lastname;
            set
            {
                if (value == null) throw new Exception("Nem adott meg értéket");
                if (value.Length < 3 || value.Length > 32) throw new Exception("A vezetéknév nem lehet rövidebb 3 karakternél és hosszabb sem 32 karakternél");
                lastname = value;
            }
        }

        public Author(string name)
        {
            var temp = name.Split(' ');
            Firstname = temp[0];
            Lastname = temp[1];
            Id = Guid.NewGuid();
        }
        public override string ToString() => $"{Firstname} {Lastname}: {Id}";
    }
}

