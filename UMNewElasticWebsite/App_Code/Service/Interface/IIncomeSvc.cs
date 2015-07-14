using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IIncomeSvc : IService
    {
        List<IncomeDto> selectAllIncome();
        IncomeDto selectIncomeById(IncomeDto obj);
        Boolean insertIncome(IncomeDto obj);
        Boolean updateIncome(IncomeDto obj);
        Boolean deleteIncome(IncomeDto obj);
        //IncomeDto createIncomeDTO(...)
    }
}