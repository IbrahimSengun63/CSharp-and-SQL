using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Business.Abstract;
using BookWorm.DataAccess.Abstract;
using BookWorm.Entities.Concrete;

namespace BookWorm.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public List<Book> GetBooksByBooksName(string kitapAdı)
        {
            return _bookDal.GetAll(p => p.KitapAdı.ToLower().Contains(kitapAdı.ToLower()));
        }

        public List<Book> GetBooksByCategory(int kategoriNumarası)
        {
            return _bookDal.GetAll(p => p.KategoriNumarası == kategoriNumarası);
        }

        public List<Book> GetBooksByAuthorName(string yazar)
        {
            return _bookDal.GetAll(p => p.Yazar.ToLower().Contains(yazar.ToLower()));
        }

        public void Add(Book book)
        {
            
            _bookDal.Add(book);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }

        public void Delete(Book book)
        {
            try
            {
                _bookDal.Delete(book);
            }
            catch 
            {
                throw new Exception("Silme Gerçekleşemedi!");
            }
        }
    }
}
