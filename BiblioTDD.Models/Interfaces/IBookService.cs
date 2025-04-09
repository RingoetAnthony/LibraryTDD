using BiblioTDD.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTDD.Models.Interfaces
{
    public interface IBookService
    {
        Book GetById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        bool HasActiveLoans(int bookId);
    }
}
