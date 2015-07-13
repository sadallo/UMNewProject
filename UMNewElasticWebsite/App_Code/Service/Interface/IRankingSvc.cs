using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewRecruiteeService;


namespace UMNewElasticWebsite.Service.Interface
{
    public interface IRankingSvc : IService
    {
        List<RankingDto> selectAllRanking();
        RankingDto selectRankingById(RankingDto obj);
        Boolean insertRanking(RankingDto obj);
        Boolean updateRanking(RankingDto obj);
        Boolean deleteRanking(RankingDto obj);
        RankingDto createRankingDTO(String RankingId, String RankingName);
    }
}