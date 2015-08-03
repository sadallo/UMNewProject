using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TaskRatingDTO
/// </summary>

namespace UMNewElasticWebsite.DomainDTO
{
    public class TaskRatingDTO
    {
        public TaskRatingDTO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Guid JobId { get; set; }

        public Guid RecruiteeId { get; set; }

        public double? Rating { get; set; }
    }
}