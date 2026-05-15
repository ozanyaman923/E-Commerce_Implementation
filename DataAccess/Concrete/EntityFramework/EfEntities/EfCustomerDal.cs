using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DataBase;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.EfEntities
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>,ICustomerDal
    {




    }
}
