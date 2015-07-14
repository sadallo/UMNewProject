using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class AgeSvcWSImpl : IAgeSvc
    {
        public List<AgeDto> selectAllAge()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllAge().ToList<AgeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AgeDto selectAgeById(AgeDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAgeById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertAge(AgeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    return svc.insertAge(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateAge(AgeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    AgeDto rec = svc.selectAgeById(obj);

                    if (rec != null)
                    {
                        return svc.updateAge(obj);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public Boolean deleteAge(AgeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    AgeDto rec = svc.selectAgeById(obj);

                    if (rec != null)
                    {
                        return svc.deleteAge(obj);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //public AgeDto createAgeDTO(...)
        //{
        //    using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
        //    {
        //        return svc.createAgeDTO(...);
        //    }
        //}

    }
}