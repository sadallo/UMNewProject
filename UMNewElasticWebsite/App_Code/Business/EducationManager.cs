using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using NewRecruiteeService;

namespace UMNewElasticWebsite.Business
{
    public class EducationManager : BusinessManager
    {

        public List<EducationDto> selectAllEducation()
        {
            try
            {
                IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
                return svc.selectAllEducation();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public EducationDto selectEducationById(EducationDto obj)
        {
            try
            {
                IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
                return svc.selectEducationById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertEducation(EducationDto obj)
        {
            try
            {
                IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
                return svc.insertEducation(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateEducation(EducationDto obj)
        {
            try
            {
                IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
                return svc.updateEducation(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteEducation(EducationDto obj)
        {
            try
            {
                IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
                return svc.deleteEducation(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        //public EducationDto createEducationDTO(Guid EducationId, String EducationId)
        //{
        //    try
        //    {
        //        IEducationSvc svc = (IEducationSvc)this.getService(typeof(IEducationSvc).Name);
        //        return svc.createEducationDTO(EducationId, EducationId);
        //    }
        //    catch (ServiceLoadException ex)
        //    {
        //        return null;
        //    }
        //}
    }
       
}
