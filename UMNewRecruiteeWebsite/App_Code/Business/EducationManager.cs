using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Exceptions.Service;

namespace UMNewRecruiteeWebsite.Business
{
    public class EducationManager : BusinessManager
    {

        public List<Education> selectAllEducation()
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

        public Education selectEducationById(Education obj)
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

        public Boolean insertEducation(Education obj)
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

        public Boolean updateEducation(Education obj)
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

        public Boolean deleteEducation(Education obj)
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
    }
}
