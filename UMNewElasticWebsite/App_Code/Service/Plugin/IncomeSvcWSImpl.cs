using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;
using UMNewElasticWebsite.Service.Interface;

namespace UMNewElasticWebsite.Service.Plugin
{
    public class IncomeSvcWSImpl : IIncomeSvc
    {
        public List<IncomeDto> selectAllIncome()
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectAllIncome().ToList<IncomeDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IncomeDto selectIncomeById(IncomeDto obj)
        {
            NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();

            try
            {
                return svc.selectIncomeById(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertIncome(IncomeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    return svc.insertIncome(obj);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Boolean updateIncome(IncomeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    IncomeDto rec = svc.selectIncomeById(obj);

                    if (rec != null)
                    {
                        return svc.updateIncome(obj);
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

        public Boolean deleteIncome(IncomeDto obj)
        {
            using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
            {
                try
                {
                    IncomeDto rec = svc.selectIncomeById(obj);

                    if (rec != null)
                    {
                        return svc.deleteIncome(obj);
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

        //public IncomeDto createIncomeDTO(...)
        //{
        //    using (NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient())
        //    {
        //        return svc.createIncomeDTO(...);
        //    }
        //}

    }
}