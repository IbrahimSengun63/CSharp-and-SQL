using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Entities.Concrete;

namespace BookWorm.Business.Abstract
{
    public interface IBookTypeService
    {
        List<BookType> GetAll();
    }
}
