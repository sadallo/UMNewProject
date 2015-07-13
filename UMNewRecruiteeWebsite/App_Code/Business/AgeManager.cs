using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Exceptions.Service;

namespace UMNewRecruiteeWebsite.Business
{
    public class AgeManager : BusinessManager
    {

        public List<Age> selectAllAge()
        {
            try
            {
                IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
                return svc.selectAllAge();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Age selectAgeById(Age obj)
        {
            try
            {
                IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
                return svc.selectAgeById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertAge(Age obj)
        {
            try
            {
                IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
                return svc.insertAge(obj);
                  
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateAge(Age obj)
        {
            try
            {
                IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
                return svc.updateAge(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteAge(Age obj)
        {
            try
            {
                IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
                return svc.deleteAge(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
