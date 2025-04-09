using BiblioTDD.Models.Domain;
using BiblioTDD.Models.Exceptions;
using BiblioTDD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTDD.app
{
    public class BookController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            this._service = service;
        }

        public bool RegisterBook(Book book) 
        {
            if (_service.GetById(book.BookId) != null) { 
                throw new ISBNDuplicateException(); }
            if(string.IsNullOrEmpty(book.ISBN) || string.IsNullOrEmpty(book.Title) ) {
                throw new MandatoryFieldMissingException(); }
            if (book.Copies < 0)
            {
                throw new NegativeCopiesException();
            }
            try
            {
                _service.AddBook(book);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool UpdateBook(Book book)
        {
            if (book == null || book.BookId <= 0)
                throw new ArgumentException("ID invalide");

            var existingBook = _service.GetById(book.BookId);
            if (existingBook == null)
                throw new Exception("Livre inexistant");

            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.ISBN))
                throw new MandatoryFieldMissingException();

            if (book.Copies < 0)
                throw new ArgumentException("Le nombre de copies ne peut pas être négatif");

            // Ajout du nombre de copies
            existingBook.Copies += book.Copies;

            try
            {
                // Assurez-vous que cette ligne est bien appelée
                _service.UpdateBook(existingBook);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBook(int bookId)
        {
            var existingBook = _service.GetById(bookId);
            if (existingBook == null) throw new Exception("Livre inexistant");
            if (_service.HasActiveLoans(bookId)) throw new Exception("Livre emprunté actuellement");

            try
            {
                _service.DeleteBook(bookId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
