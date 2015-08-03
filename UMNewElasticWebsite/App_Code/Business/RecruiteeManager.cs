using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using NewRecruiteeService;

namespace UMNewElasticWebsite.Business
{
    public class RecruiteeManager : BusinessManager
    {

        public List<RecruiteeDto> selectAllRecruitee()
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

        public RecruiteeDto selectRecruiteeById(RecruiteeDto obj)
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

        public RecruiteeDto selectRecruiteeByEmail(RecruiteeDto obj)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectRecruiteeByEmail(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertRecruitee(RecruiteeDto obj)
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

        public Boolean updateRecruitee(RecruiteeDto obj)
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

        public Boolean deleteRecruitee(RecruiteeDto obj)
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

        public RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email, FirstName, LastName,
                    Gender, AgeId, EducationId, IncomeId);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                List<RecruiteeDto> list = svc.selectRecruiteeBySkillId(SkillId);
                return list;
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean addSkillToRecruitee(RecruiteeDto obj, String SkillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.addSkillToRecruitee(obj, SkillId);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean removeSkillFromRecruitee(RecruiteeDto obj, String SkillId)
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.removeSkillFromRecruitee(obj, SkillId);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public String[] selectRecruiteeNames()
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectRecruiteeNames();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }            
        }

        public double[] selectRecruiteeSkills()
        {
            try
            {
                IRecruiteeSvc svc = (IRecruiteeSvc)this.getService(typeof(IRecruiteeSvc).Name);
                return svc.selectRecruiteeSkills();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }    
        }


    }
       
}
