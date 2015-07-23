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
        
        //RecruiteeDto bla = new RecruiteeDto();
        //bla.RecruiteeId = new Guid("EE00390F-3422-4E7D-84BD-5C55EFE3A215");
        //Service svc = new Service();
        //RecruiteeDto rec = new RecruiteeDto();

        //rec.RecruiteeId = Guid.NewGuid();
        //rec.RankingId = "RAN01";
        //rec.RankingValue = 10;
        //rec.Email = "sadallo@hotmail.com";
        //rec.FirstName = "Gustavo";
        //rec.LastName = "Cruz";
        //rec.Gender = "M";
        //rec.AgeId = "AGE01";
        //rec.EducationId = "EDU01";
        //rec.IncomeId = "INC01";
        //bool result = svc.insertRecruitee(rec);
       // bool blabla = svc.insertRecruitee(Guid.NewGuid(), "RAN01", 10, "goliveiradacruz@unomaha.edu", "Gustavo", "Cruz", "M", "AGE01", "EDU01", "INC01");


        //Service svc = new Service();
        //RecruiteeDto rec = new RecruiteeDto();
        //rec.Email = "sadallo@hotmail.com";
        //RecruiteeDto rec_select = svc.selectRecruiteeByEmail(rec);
        //rec_select.FirstName = "JOAQUIM";
        //rec_select.IncomeId = "INC01";
        //rec_select.AgeId = "";
        //rec_select.RankingId = "";
        //bool res = svc.updateRecruitee(rec_select);

    }
}