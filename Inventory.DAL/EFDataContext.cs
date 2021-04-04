using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;
using System.Data.Entity;

namespace Inventory.DAL
{
    public class EFDataContext<AnyType> : DbContext, IRepository<AnyType> where AnyType : class
    {
        public void Add(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }
}
