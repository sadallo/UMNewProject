using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.Service.Interface

{
    public interface IIncomeSvc : IService
    {
        List<Income> selectAllIncome();
        Income selectIncomeById(Income obj);
        Boolean insertIncome(Income obj);
        Boolean updateIncome(Income obj);
        Boolean deleteIncome(Income obj);
    }
}
