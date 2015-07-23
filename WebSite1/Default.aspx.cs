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
        NewElasticServiceMobile.ServiceMobileClient svc = new NewElasticServiceMobile.ServiceMobileClient();
        RecruiteeDto rec = new RecruiteeDto();
        
        RecruiteeDto recdto = svc.selectRecruiteeByEmail("sadallo@hotmail.com");
       
        
        
        
        //bool result = svc.insertRecommendedJob(Guid.NewGuid(), Guid.NewGuid(), 3.999865);
        //RecommendedJobDto rec_job = svc.selectRecommendedJobByIdAndRecruiteeId(new Guid("37947971-D83A-4231-B572-7924EB09DA7A"), new Guid("779F9777-DB09-437A-B30D-532385DC2FCE"));

    }
}