using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using UMNewElasticWebsite.Models;

namespace UMNewElasticWebsite.DomainDTO
{
    [DataContract]
    public class TaskDto
    {
        [DataMember]
        public System.Guid TaskId { get; set; }

        [DataMember]
        public System.Guid JobId { get; set; }

        [DataMember]
        public System.Guid RecruiteeId { get; set; }

        [DataMember]
        public string TaskDescription { get; set; }


        public static TaskDto createTaskDTO(Task obj)
        {
            TaskDto task = new TaskDto();
            task.TaskId = obj.TaskId;
            task.JobId = obj.JobId;
            task.RecruiteeId = obj.RecruiteeId;
            task.TaskDescription = obj.TaskDescription;
            return task;
        }

        public static TaskDto createTaskDTO(System.Guid TaskId, System.Guid JobId, System.Guid RecruiteeId, String TaskDescription)
        {
            TaskDto task = new TaskDto();
            task.TaskId = TaskId;
            task.JobId = JobId;
            task.RecruiteeId = RecruiteeId;
            task.TaskDescription = TaskDescription;
            return task;
        }
    }
}