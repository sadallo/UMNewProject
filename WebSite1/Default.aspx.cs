using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewElasticServiceMobile;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServiceMobileClient svc = new ServiceMobileClient();
        JobDto[] list = svc.selectJobNotDoneByRecruiteeIdRecommendation("3DD57FF0-ECCD-4E15-9FC8-74FB6AC412DA");

        //ServiceWCFClient svcJob = new ServiceWCFClient();
        //NewJobService.JobDto[] list = svcJob.selectJobNotDoneByRecruiteeId("3DD57FF0-ECCD-4E15-9FC8-74FB6AC412DA");
    }
}