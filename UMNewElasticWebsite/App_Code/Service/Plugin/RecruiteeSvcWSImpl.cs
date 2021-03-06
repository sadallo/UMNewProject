﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class RecruiteeSvcWSImpl : IRecruiteeSvc
    {
        public List<RecruiteeDto> selectAllRecruitee()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllRecruitee().ToList<RecruiteeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public RecruiteeDto selectRecruiteeById(RecruiteeDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRecruiteeById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RecruiteeDto selectRecruiteeByEmail(RecruiteeDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRecruiteeByEmail(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {                        
                    return svc.insertRecruitee(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RecruiteeDto rec = svc.selectRecruiteeById(obj);

                    if (rec != null)
                    {
                        return svc.updateRecruitee(obj);
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

        public Boolean deleteRecruitee(RecruiteeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    RecruiteeDto rec = svc.selectRecruiteeById(obj);

                    if (rec != null)
                    {
                        return svc.deleteRecruitee(obj);
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

        public RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                return svc.createRecruiteeDTO(RecruiteeId, RankingId, RankingValue, Email, FirstName, LastName, 
                    Gender, AgeId, EducationId, IncomeId);
            }
            
        }

        public List<RecruiteeDto> selectRecruiteeBySkillId(String SkillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectRecruiteeBySkillId(SkillId).ToList<RecruiteeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean addSkillToRecruitee(RecruiteeDto obj, String skillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.addSkillToRecruitee(obj.RecruiteeId, skillId);
            }
            catch
            {
                return false;
            }

        }

        public Boolean removeSkillFromRecruitee(RecruiteeDto obj, String skillId)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.removeSkillFromRecruitee(obj.RecruiteeId, skillId);
            }
            catch
            {
                return false;
            }

        }

        //user profile (just the first information of the user profile)
        public String[] selectRecruiteeNames()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();
            Guid[] recNames = svc.selectRecruiteeNames();
            return Array.ConvertAll(recNames, x => x.ToString());
        }

        //user self ratings
        public double[] selectRecruiteeSkills()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();
            NewRecruiteeService.RecruiteeSkillDto[] recSkills = svc.selectAllRecruiteeSkill();
            double[] result = new double[recSkills.Length];
            for (int n = 0; n < recSkills.Length; n++)
            {
                switch (recSkills[n].SkillId)
                {
                    case "SKI01":
                        result[n] = 1;
                        break;
                    case "SKI02":
                        result[n] = 2;
                        break;
                    case "SKI03":
                        result[n] = 3;
                        break;
                    case "SKI04":
                        result[n] = 4;
                        break;
                    case "SKI05":
                        result[n] = 5;
                        break;
                }
            }
            return result;
        }
    }
}