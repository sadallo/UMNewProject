using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewElasticWebsite.Models;


namespace UMNewElasticWebsite.Service.Interface
{
	public interface IRecommendedJobSvc : IService
	{
        List<RecommendedJob> selectAllRecommendedJob();
        RecommendedJob selectRecommendedJobByIdAndRecruiteeId(RecommendedJob obj);
        Boolean insertRecommendedJob(RecommendedJob obj);
        Boolean updateRecommendedJob(RecommendedJob obj);
        Boolean deleteRecommendedJob(RecommendedJob obj);
	}
}