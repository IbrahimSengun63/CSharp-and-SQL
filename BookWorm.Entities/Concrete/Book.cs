using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Entities.Abstract;

namespace BookWorm.Entities.Concrete
{
    public class Book:IEntity
    {
        [Key]
        
        public int KitapNumarası { get; set; }
        public int KategoriNumarası { get; set; }
        public string KitapAdı { get; set; }
        public string Yazar { get; set; }
        public string Çevirmen { get; set; }
        public string YayınEvi { get; set; }
        public Int16 BaskıYılı { get; set; }
        public bool ÖdünçDurumu { get; set; } 
        public string ÖdünçAlanKişi { get; set; }

    }
}
