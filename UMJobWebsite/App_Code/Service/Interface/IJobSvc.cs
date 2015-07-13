using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;

namespace UMJobWebsite.Service.Interface
{
    public interface IJobSvc : IService
    {
        List<Job> selectAllJob();
        Job selectJobById(Job obj);
        Boolean insertJob(Job obj);
        Boolean updateJob(Job obj);
        Boolean deleteJob(Job obj);
        Boolean addSkillToJob(Job obj, String skillId);
        Boolean removeSkillFromJob(Job obj, String skillId);
        List<Job> selectJobBySkillId(String skillId);

    }
}