using UMElasticWebsite.Service.Interface;
using RecruiteeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMElasticWebsite.Service.Plugin
{
    public class FileSystemSvcImpl : IFileSystemSvc
    {
        //Reads the binary rating for the Features for each one of the Jobs
        public List<RecruiteeDto> readRecruitees(String path)
        {
            //reading X
            List<RecruiteeDto> list = new List<RecruiteeDto>();
            using (TextReader readerX = File.OpenText(path))
            {
                string line = readerX.ReadLine();
                while (line != null)
                {
                    string[] temp = line.Split('\t');
                    RecruiteeDto rec = new RecruiteeDto();
                    rec.RecruiteeId = new Guid(temp[0]);
                    rec.RankingValue = Convert.ToDouble(temp[1]);
                    list.Add(rec);
                    
                    line = readerX.ReadLine();
                }
                readerX.Close();
            }
            return list;
        }
    }
}
