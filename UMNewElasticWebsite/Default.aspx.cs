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

    }






    public void updateRankingValues()
    {
        IFileSystemSvc fileSvc = new FileSystemSvcImpl();
        List<RecruiteeDto> recList = fileSvc.readRecruitees(Server.MapPath("~/") + "/files/IDandAVG.txt");

        Service svc = new Service();

        foreach (RecruiteeDto rec in recList)
        {
            RecruiteeDto recSelect = svc.selectRecruiteeById(rec);
            recSelect.RankingValue = rec.RankingValue;
            bool result = svc.updateRecruitee(recSelect);
        }    
    }
}