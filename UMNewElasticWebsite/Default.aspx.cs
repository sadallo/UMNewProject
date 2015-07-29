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
        //bool result = svc.insertTask(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "test", 99.5);

        //TaskDto task = svc.selectTaskById(new Guid("E610E19E-397F-4A20-AAB0-FB9BC067E364"));
        //bool result = svc.updateTask(task.TaskId, task.JobId, task.RecruiteeId, "bla bla", 44.5325);

        //List<JobDto> list = svc.selectJobNotDoneByRecruiteeIdRecommendation("40709433-B16C-4952-B662-08D28040C723");

        TaskSvcEFImpl svc = new TaskSvcEFImpl();
        TaskRatingDTO[] arr = svc.selectRatings();
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