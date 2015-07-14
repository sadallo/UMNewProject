using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class EducationSvcWSImpl : IEducationSvc
    {
        public List<EducationDto> selectAllEducation()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllEducation().ToList<EducationDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public EducationDto selectEducationById(EducationDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectEducationById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertEducation(EducationDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    return svc.insertEducation(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateEducation(EducationDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    EducationDto rec = svc.selectEducationById(obj);

                    if (rec != null)
                    {
                        return svc.updateEducation(obj);
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

        public Boolean deleteEducation(EducationDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    EducationDto rec = svc.selectEducationById(obj);

                    if (rec != null)
                    {
                        return svc.deleteEducation(obj);
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

        //public EducationDto createEducationDTO(...)
        //{
        //    using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
        //    {
        //        return svc.createEducationDTO(...);
        //    }
        //}

    }
}