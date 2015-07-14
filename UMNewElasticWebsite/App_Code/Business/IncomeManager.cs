using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.Exceptions.Service;
using NewRecruiteeService;

namespace UMNewElasticWebsite.Business
{
    public class IncomeManager : BusinessManager
    {

        public List<IncomeDto> selectAllIncome()
        {
            try
            {
                IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
                return svc.selectAllIncome();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public IncomeDto selectIncomeById(IncomeDto obj)
        {
            try
            {
                IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
                return svc.selectIncomeById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertIncome(IncomeDto obj)
        {
            try
            {
                IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
                return svc.insertIncome(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateIncome(IncomeDto obj)
        {
            try
            {
                IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
                return svc.updateIncome(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteIncome(IncomeDto obj)
        {
            try
            {
                IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
                return svc.deleteIncome(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        //public IncomeDto createIncomeDTO(Guid IncomeId, String IncomeId)
        //{
        //    try
        //    {
        //        IIncomeSvc svc = (IIncomeSvc)this.getService(typeof(IIncomeSvc).Name);
        //        return svc.createIncomeDTO(IncomeId, IncomeId);
        //    }
        //    catch (ServiceLoadException ex)
        //    {
        //        return null;
        //    }
        //}
    }
       
}
