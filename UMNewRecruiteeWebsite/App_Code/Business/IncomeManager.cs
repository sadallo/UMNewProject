using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Exceptions.Service;

namespace UMNewRecruiteeWebsite.Business
{
    public class IncomeManager : BusinessManager
    {

        public List<Income> selectAllIncome()
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

        public Income selectIncomeById(Income obj)
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

        public Boolean insertIncome(Income obj)
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

        public Boolean updateIncome(Income obj)
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

        public Boolean deleteIncome(Income obj)
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
    }
}
