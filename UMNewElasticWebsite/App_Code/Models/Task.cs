using System;
using System.Collections.Generic;

namespace UMNewElasticWebsite.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public Guid JobId { get; set; }
        public Guid RecruiteeId { get; set; }
        public string TaskDescription { get; set; }

        public static Task createTask(Guid TaskId, Guid JobId, Guid RecruiteeId, String TaskDescription)
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
