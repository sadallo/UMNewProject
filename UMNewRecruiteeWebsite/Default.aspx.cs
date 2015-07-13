using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLApp;
using UMNewRecruiteeWebsite.Business;
using UMNewRecruiteeWebsite.Service.Interface;
using UMNewRecruiteeWebsite.Service.Plugin;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.DomainDTO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Service svc = new Service();
        //List<EducationDto> list = svc.selectAllEducation();
        List<RecruiteeDto> list_rec = svc.selectAllRecruitee();
    }
}