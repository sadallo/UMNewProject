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
        //rec.Email = "goliveiradacruz@unomaha.edu";
        //RecruiteeDto blabla = svc.selectRecruiteeByEmail(rec);
        //blabla.FirstName = "blablabla";
        //bool update = svc.updateRecruitee(blabla);
        //bool up = svc.updateRecruitee(blabla.RecruiteeId, "RAN01", 10, "goliveiradacruz@unomaha.edu", "ftyfty", "Cruz", "M", "AGE01", "EDU01", "INC01");
        
        //rec.FirstName = "Tumbalacatumba";
        //bool up = svc.updateRecruitee(rec);

        //rec.RecruiteeId = Guid.NewGuid();
        //rec.RankingId = "RAN01";
        //rec.RankingValue = 10;
        //rec.Email = "goliveiradacruz@unomaha.edu";
        //rec.FirstName = "Gustavo";
        //rec.LastName = "Cruz";
        //rec.Gender = "M";
        //rec.AgeId = "AGE01",;
        //rec.EducationId = "EDU01";
        //rec.IncomeId = "INC01";
        //bool blabla = svc.insertRecruitee(Guid.NewGuid(), "RAN01", 10, "goliveiradacruz@unomaha.edu", "Gustavo", "Cruz", "M", "AGE01", "EDU01", "INC01");
        

       

        //List<EducationDto> edu = svc.selectAllEducation();
        //int i = 0;

        Service svc = new Service();

        RecruiteeDto rec = new RecruiteeDto();
        rec.Email = "email@email.com";
        RecruiteeDto rec_select = svc.selectRecruiteeByEmail(rec);

        rec_select.FirstName = "JOAQUIM";
        rec_select.EducationId = "";


        bool res = svc.updateRecruitee(rec_select);

    }
}