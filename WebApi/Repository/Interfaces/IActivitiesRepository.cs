using System.Collections.Generic;
using WebApi.Repository.Models.HR_StatisticsModels;
using WebApi.Repository.View_Models;

namespace WebApi.Repository.Interfaces
{
    public interface IActivitiesRepository
    {
        public List<TblActivityGroup> GetActivityGroup(int ActGrpId);
        public bool UpdateActivityGroup(ActivityGroup activity);
        public bool DelActivityGroup(int id);
        public bool AddActivityGroup(ActivityGroup act);


        public List<TblActivity> GetActivity(int id);
        public bool UpdateActivity(Activities act);
        public bool DelActivity(int id);
        public bool AddActivity(Activities act);


        public List<TblActivitySub> GetSubActivities();
        public bool UpdateActivitySub(ActivitySub act);
        public bool DelActivitySub(int id);
        public bool AddActivitySub(ActivitySub act);


        public List<TblActivityTask> GetTasks(int subActId);
        public bool UpdateTaskDesc(ActivityTask act);
        public bool UpdateTask(ActivityTask act);
        public bool DeleteTask(int id);
        public bool AddTask(ActivityTask act);

    }
}
