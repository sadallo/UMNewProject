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

        //NewRecruiteeService.ServiceWCFClient svc = new NewRecruiteeService.ServiceWCFClient();
        //RecruiteeDto rec = new RecruiteeDto();
        //rec.Email = "sadallo@hotmail.com";
        //RecruiteeDto recemail = svc.selectRecruiteeByEmail(rec);
        //bool blabla = svc.insertRecruitee(Guid.NewGuid(), "RAN01", 10, "goliveiradacruz@unomaha.edu", "Gustavo", "Cruz", "M", "AGE01", "EDU01", "INC01");
        //ServiceMobile svc = new ServiceMobile();
        //RecruiteeDto rec = new RecruiteeDto();
        //rec.Email = "goliveiradacruz@unomaha.edu";
        //RecruiteeDto chu = svc.selectRecruiteeByEmail("sadallo@hotmail.com");

        ServiceMobile svc = new ServiceMobile();
        bool res = svc.insertRecruitee(Guid.NewGuid(), "", 0, "emailbgfbgfb@email.com", "", "", "M", "", "", "");

    }

 //public void updateRankingValues()
    //{
    //    IFileSystemSvc fileSvc = new FileSystemSvcImpl();
    //    List<RecruiteeDto> recList = fileSvc.readRecruitees(Server.MapPath("~/") + "/files/IDandAVG.txt");

    //    Service svc = new Service();

    //    foreach (RecruiteeDto rec in recList)
    //    {
    //        RecruiteeDto recSelect = svc.selectRecruiteeById(rec);
    //        recSelect.RankingValue = rec.RankingValue;
    //        bool result = svc.updateRecruitee(recSelect);
    //    }    
    //}
}