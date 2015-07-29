using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewElasticWebsite.Models;


namespace UMNewElasticWebsite.Service.Interface
{
	public interface ITaskSvc : IService
	{
        List<Task> selectAllTask();
        Task selectTaskById(Task obj);
        Boolean insertTask(Task obj);
        Boolean updateTask(Task obj);
        Boolean deleteTask(Task obj);
        TaskRatingDTO[] selectRatings();
	}
}