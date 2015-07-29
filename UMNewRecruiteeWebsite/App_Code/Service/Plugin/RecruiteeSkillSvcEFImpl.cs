using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.DomainDTO;
using UMNewRecruiteeWebsite.Models;
using UMNewRecruiteeWebsite.Service.Interface;

namespace UMNewRecruiteeWebsite.Service.Plugin
{
    public class RecruiteeSkillSvcEFImpl : IRecruiteeSkillSvc
    {
        public List<RecruiteeSkillDto> selectAllRecruiteeSkill()
        {
            NewRecruiteeBankContext db = new NewRecruiteeBankContext();

            try
            {
                return db.Database.SqlQuery(typeof(RecruiteeSkillDto), "dbo.SelectAllRecruiteeSkill").Cast<RecruiteeSkillDto>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
