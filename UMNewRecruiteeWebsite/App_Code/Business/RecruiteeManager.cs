using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Exceptions.Service;

namespace UMNewRecruiteeWebsite.Business
{
    public class RecruiteeManager : BusinessManager
    {

        public List<Recruitee> selectAllRecruitee()
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectAllRecruitee();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Recruitee selectRecruiteeById(Recruitee obj)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectRecruiteeById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<Recruitee> selectRecruiteeBySkillId(String skillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectRecruiteeBySkillId(skillId);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertRecruitee(Recruitee obj)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.insertRecruitee(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateRecruitee(Recruitee obj)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.updateRecruitee(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteRecruitee(Recruitee obj)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.deleteRecruitee(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean addSkillToRecruitee(Recruitee obj, String skillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.addSkillToRecruitee(obj, skillId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean removeSkillFromRecruitee(Recruitee obj, String skillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.removeSkillFromRecruitee(obj, skillId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
