using BookWorm.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Concrete.EntityFramework
{
    public class BookArchiveContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
    }
}
