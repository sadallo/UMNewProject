using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewJobWebsite.Service.Interface;
using UMNewJobWebsite.Service;

namespace UMNewJobWebsite.Business
{
    public abstract class BusinessManager
    {
        protected IService getService(String name)
        {
            return (Factory.getInstance()).getService(name);
        }
    }
}
