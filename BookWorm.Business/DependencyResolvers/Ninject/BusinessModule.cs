using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.Business.Abstract;
using BookWorm.Business.Concrete;
using BookWorm.DataAccess.Abstract;
using BookWorm.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace BookWorm.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookManager>().InSingletonScope();
            Bind<IBookDal>().To<EfBookDal>().InSingletonScope();

            Bind<IBookTypeService>().To<BookTypeManager>().InSingletonScope();
            Bind<IBookTypeDal>().To<EfBookTypeDal>().InSingletonScope();
        }
    }
}
