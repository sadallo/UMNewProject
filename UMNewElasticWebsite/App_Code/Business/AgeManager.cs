using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using NewRecruiteeService;

namespace UMNewElasticWebsite.Business
{
    public class AgeManager : BusinessManager
    {

        public List<AgeDto> selectAllAge()
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

        public AgeDto selectAgeById(AgeDto obj)
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

        public Boolean insertAge(AgeDto obj)
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

        public Boolean updateAge(AgeDto obj)
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

        public Boolean deleteAge(AgeDto obj)
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

        //public AgeDto createAgeDTO(Guid AgeId, String AgeId)
        //{
        //    try
        //    {
        //        IAgeSvc svc = (IAgeSvc)this.getService(typeof(IAgeSvc).Name);
        //        return svc.createAgeDTO(AgeId, AgeId);
        //    }
        //    catch (ServiceLoadException ex)
        //    {
        //        return null;
        //    }
        //}
    }
       
}
