using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IRepository<AnyType>
    {
        void Add(AnyType obj);
        void Update(AnyType obj);
        void Delete(AnyType obj);
        List<AnyType> Search();
        void Save();
    }
}
