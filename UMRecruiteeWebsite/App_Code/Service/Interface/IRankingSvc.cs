using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMRecruiteeWebsite.Models;

namespace UMRecruiteeWebsite.Service.Interface
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
