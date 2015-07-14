using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UMNewRecruiteeWebsite.Models;

namespace UMNewRecruiteeWebsite.DomainDTO
{
    [DataContract]
    public class RecruiteeDto
    {
        [DataMember]
        public Guid RecruiteeId { get; set; }

        [DataMember]
        public string RankingId { get; set; }

        [DataMember]
        public double RankingValue { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string AgeId { get; set; }

        [DataMember]
        public string EducationId { get; set; }

        [DataMember]
        public string IncomeId { get; set; }

        public static RecruiteeDto createRecruiteeDTO(Recruitee obj)
        {
            RecruiteeDto rec = new RecruiteeDto();
            rec.RecruiteeId = obj.RecruiteeId;
            rec.RankingId = obj.RankingId;
            rec.RankingValue = (double)obj.RankingValue;
            rec.Email = obj.Email;
            rec.FirstName = obj.FirstName;
            rec.LastName = obj.LastName;
            rec.Gender = obj.Gender;
            rec.AgeId = obj.AgeId;
            rec.EducationId = obj.EducationId;
            rec.IncomeId = obj.IncomeId;
            return rec;
        }

        public static RecruiteeDto createRecruiteeDTO(Guid RecruiteeId, String RankingId, double RankingValue, String Email,
                   String FirstName, String LastName, String Gender, String AgeId, String EducationId, String IncomeId)
        {
            RecruiteeDto rec = new RecruiteeDto();
            rec.RecruiteeId = RecruiteeId;
            rec.RankingId = RankingId;
            rec.RankingValue = (double)RankingValue;
            rec.Email = Email;
            rec.FirstName = FirstName;
            rec.LastName = LastName;
            rec.Gender = Gender;
            rec.AgeId = AgeId;
            rec.EducationId = EducationId;
            rec.IncomeId = IncomeId;
            return rec;
        }
    }
}
