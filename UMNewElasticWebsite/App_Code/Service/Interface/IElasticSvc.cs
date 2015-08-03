using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewElasticWebsite.Domain;

namespace UMNewElasticWebsite.Service.Interface
{
    public interface IElasticSvc : IService
    {
        bool insertRecommenderJob(DataResult avgs);
        double[,] SelectRatings(String[] expressions, UserProfile[] users);
        bool InsertRatings(String[] expressions, UserProfile[] users, double[,] Y);
        int[,] GetYIndex(String jobID, String recruiteeID, String[] expressions, UserProfile[] users);
    }
}
