using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllData();
        T SelectDataById(object id);
        void InsertRecord(T objRecord);
        void Update(T objRecord);
        void DeleteRecord(object id);
        void SaveRecord();
    }
}
