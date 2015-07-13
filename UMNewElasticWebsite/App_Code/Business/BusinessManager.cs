using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Service;

namespace UMNewElasticWebsite.Business
{
    public abstract class BusinessManager
    {
        protected IService getService(String name)
        {
            return (Factory.getInstance()).getService(name);
        }
    }
}
