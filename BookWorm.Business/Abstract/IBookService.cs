using BookWorm.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<Book> GetBooksByBooksName(string kitapAdı);
        List<Book> GetBooksByCategory(int kategoriNumarası);
        List<Book> GetBooksByAuthorName(string yazar);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
