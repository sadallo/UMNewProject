using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Service.Interface;
using UMRecruiteeWebsite.Service;

namespace UMRecruiteeWebsite.Business
{
    public abstract class BusinessManager
    {
        protected IService getService(String name)
        {
            return (Factory.getInstance()).getService(name);
        }
    }
}
