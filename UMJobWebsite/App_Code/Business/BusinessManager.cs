using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMJobWebsite.Service.Interface;
using UMJobWebsite.Service;

namespace UMJobWebsite.Business
{
    public abstract class BusinessManager
    {
        protected IService getService(String name)
        {
            return (Factory.getInstance()).getService(name);
        }
    }
}
