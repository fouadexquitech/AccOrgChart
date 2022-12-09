using System.Collections.Generic;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IActivitiesRepository
    {
        public List<TblActivityGroup> GetActivityGroup(int ActGrpId);
        public bool UpdateActivityGroup(ActivityGroup activity);
        public bool DelActivityGroup(int id);
        public bool AddActivityGroup(ActivityGroup act);


        public List<TblActivity> GetActivities(string user, bool isAdmin);
        public List<TblActivity> GetActivity(int id);
        public bool UpdateActivity(Activities act);
        public bool DelActivity(int id);
        public bool AddActivity(Activities act);


        public List<TblActivitySub> GetSubActivities();
        public bool UpdateActivitySub(ActivitySub act);
        public result DeleteSubActivity(int subActId);
        public bool AddActivitySub(ActivitySub act);
        public bool AddSubActivity(int ActivityId, string SubActivityDesc);
        public bool UpdateSubActivity(int subActivityId, string subActivityDesc);


        public List<TblActivityTask> GetTasks(int actId, int subActId);
        public bool UpdateTaskDesc(ActivityTask act);
        public bool UpdateTask(ActivityTask act);
        public bool DeleteTask(int id);
        public bool AddTask(ActivityTask act);

    }
}
