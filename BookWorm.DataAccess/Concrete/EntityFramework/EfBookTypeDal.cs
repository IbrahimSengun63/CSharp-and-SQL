using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.DataAccess.Abstract;
using BookWorm.Entities.Concrete;

namespace BookWorm.DataAccess.Concrete.EntityFramework
{
    public class EfBookTypeDal:EfEntityRepositoryBase<BookType,BookArchiveContext>,IBookTypeDal
    {
    }
}
