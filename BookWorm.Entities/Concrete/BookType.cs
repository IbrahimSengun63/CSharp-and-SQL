using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Entities.Abstract;

namespace BookWorm.Entities.Concrete
{
    public class BookType : IEntity
    {
        [Key]
        public int KategoriNumarası { get; set; }
        public string KategoriTürü { get; set; }
    }
}
