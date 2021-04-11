using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceDAL;
using System.Data.Entity;

namespace Inventory.DAL
{
    public class Repository<AnyType> : DbContext, IRepository<AnyType> where AnyType : class
    {
        public Repository() :base("name=InventoryDAL")
        {

        }
        public void Add(AnyType obj)
        {
            Set<AnyType>().Add(obj);
        }

        public void Delete(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            SaveChanges();
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
