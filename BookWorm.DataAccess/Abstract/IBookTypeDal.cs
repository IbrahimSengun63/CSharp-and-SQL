using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Entities.Concrete;

namespace BookWorm.DataAccess.Abstract
{
    public interface IBookTypeDal:IEntityRepository<BookType>
    {
    }
}
