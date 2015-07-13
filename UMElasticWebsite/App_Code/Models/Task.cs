using System;
using System.Collections.Generic;

namespace UMElasticWebsite.Models
{
    public class Task
    {
        public System.Guid TaskId { get; set; }
        public System.Guid JobId { get; set; }
        public System.Guid RecruiteeId { get; set; }
        public string TaskDescription { get; set; }

        public static Task createTask(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription)
        {
            Task obj = new Task();
            obj.TaskId = TaskId;
            obj.JobId = JobId;
            obj.RecruiteeId = RecruiteeId;
            obj.TaskDescription = TaskDescription;
            return obj;
        }
    }
}
