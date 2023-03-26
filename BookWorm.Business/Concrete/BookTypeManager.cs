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
    public class BookTypeManager:IBookTypeService
    {
        private IBookTypeDal _bookTypeDal;

        public BookTypeManager(IBookTypeDal bookTypeDal)
        {
            _bookTypeDal = bookTypeDal;
        }

        public List<BookType> GetAll()
        {
            return _bookTypeDal.GetAll(); ////////
        }
    }
}
