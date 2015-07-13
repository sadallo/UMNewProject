using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.Service.Interface
{
    public interface IRankingSvc : IService
    {
        List<Ranking> selectAllRanking();
        Ranking selectRankingById(Ranking obj);
        Boolean insertRanking(Ranking obj);
        Boolean updateRanking(Ranking obj);
        Boolean deleteRanking(Ranking obj);
    }
}
