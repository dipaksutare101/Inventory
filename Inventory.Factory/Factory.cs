using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using InterfaceDAL;
using Inventory.Entity;
using Inventory.DAL;
namespace Inventory.Factory
{
    public static class Factory<AnyType>
    {
        private static IUnityContainer ObjectList = null;

        public static AnyType Create(string type)
        {



            if (ObjectList == null)
            {
                ObjectList = new UnityContainer();

                ObjectList.RegisterType<IRepository<Registration>, EFModelCreate>();
                

            }
            return ObjectList.Resolve<AnyType>(type);

        }
        }
    }
