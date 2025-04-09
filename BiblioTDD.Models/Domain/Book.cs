using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTDD.Models.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Auteur { get;set; }
        public string ISBN { get; set; }
        public int Year { get;set; }
        public string Genre { get; set; }
        public int Copies { get; set; }
    }
}
