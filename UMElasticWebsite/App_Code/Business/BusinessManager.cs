using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMElasticWebsite.Service.Interface;
using UMElasticWebsite.Service;

namespace UMElasticWebsite.Business
{
    public abstract class BusinessManager
    {
        protected IService getService(String name)
        {
            return (Factory.getInstance()).getService(name);
        }
    }
}
