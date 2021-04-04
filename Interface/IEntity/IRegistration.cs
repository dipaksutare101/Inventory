using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDAL.IEntity
{
    public interface IRegistration
    {
        int id { get; set; }
      
        string name { get; set; }

        string Gender { get; set; }

         int cityid { get; set; }

        Boolean isstudent { get; set; }
    }
}
