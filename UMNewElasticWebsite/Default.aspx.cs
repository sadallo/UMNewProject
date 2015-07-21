using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMNewElasticWebsite.Business;
using UMNewElasticWebsite.Models;
using UMNewElasticWebsite.Service.Plugin;
using UMNewElasticWebsite.Service.Interface;
using UMNewElasticWebsite.DomainDTO;
using NewRecruiteeService;
using NewJobService;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ServiceMobile svc = new ServiceMobile();
        //List<RecommendedJobDto> list = svc.selectAllRecommendedJob();
        //List<TaskDto> list_task = svc.selectAllTask();
        //RecommendedJobDto rec_job = svc.selectRecommendedJobByJobIdAndRecruiteeId(new Guid("18789F2D-B66F-48D4-A082-20003868C33A"), new Guid("666B43D8-3FF8-4438-BEC8-C2BE7B340D50"));
        //ServiceMobile svc = new ServiceMobile();
        //List<IncomeDto> inc = svc.selectAllIncome();
        //int i = 0;

        //ServiceMobile svc = new ServiceMobile();
        //bool result = svc.insertRecruitee(Guid.NewGuid(), "RAN01", 10, "goliveiradacruz@unomaha.edu", "Gustavo", "Cruz", "M", "AGE01", "EDU01", "INC01");
        Service svc = new Service();
        RecruiteeDto bla = new RecruiteeDto();
        bla.RecruiteeId = (new Guid("EE00390F-3422-4E7D-84BD-5C55EFE3A215"));

        RecruiteeDto rec = svc.selectRecruiteeById(bla);
        
 
    }
}






//    public void updateRankingValues()
//    {
//        IFileSystemSvc fileSvc = new FileSystemSvcImpl();
//        List<RecruiteeDto> recList = fileSvc.readRecruitees(Server.MapPath("~/") + "/files/IDandAVG.txt");

//        Service svc = new Service();

//        foreach (RecruiteeDto rec in recList)
//        {
//            RecruiteeDto recSelect = svc.selectRecruiteeById(rec);
//            recSelect.RankingValue = rec.RankingValue;
//            bool result = svc.updateRecruitee(recSelect);
//        }    
//    }
//}