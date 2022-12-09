using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;


namespace AccOrgChart.Repository.Managers
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly HR_StatisticsDbContext _StatisticsDbContext;

        public ActivitiesRepository(HR_StatisticsDbContext statisticsDbContext)
        {
            _StatisticsDbContext = statisticsDbContext;
        }


        #region "ActivityGroup"
        public List<TblActivityGroup> GetActivityGroup(int ActGrpId)
        {
            var result = new List<TblActivityGroup>();

            if (ActGrpId > 0)
                result = _StatisticsDbContext.TblActivityGroups.Where(x => x.ActGrpSeq == ActGrpId).ToList();
            else
                result = _StatisticsDbContext.TblActivityGroups.ToList();

            //if (ActGrpId > 0)
            //    result = (from b in _StatisticsDbContext.TblActivityGroups
            //              where b.ActGrpSeq ==ActGrpId

            //              select new ActivityGroup
            //              {actGrpSeq=b.ActGrpSeq,
            //              actGrpCode=b.ActGrpCode,
            //              actGrpDesc=b.ActGrpDesc
            //              }).ToList();
            //else
            //    result = (from b in _StatisticsDbContext.TblActivityGroups

            //              select new ActivityGroup
            //              {
            //                  actGrpSeq = b.ActGrpSeq,
            //                  actGrpCode = b.ActGrpCode,
            //                  actGrpDesc = b.ActGrpDesc
            //              }).ToList();

            return result.OrderBy(x => x.ActGrpDesc).ToList();
        }

        public bool UpdateActivityGroup(ActivityGroup activity)
        {
            var result = _StatisticsDbContext.TblActivityGroups.Where(x => x.ActGrpSeq == activity.actGrpSeq).FirstOrDefault();
            result.ActGrpDesc = activity.actGrpDesc;
            result.ActGrpCode = activity.actGrpCode;

            if (result != null)
            {
                _StatisticsDbContext.TblActivityGroups.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DelActivityGroup(int id)
        {
            var result = _StatisticsDbContext.TblActivityGroups.Where(x => x.ActGrpSeq == id).FirstOrDefault();

            if (result != null)
            {
                _StatisticsDbContext.TblActivityGroups.Remove(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool AddActivityGroup(ActivityGroup act)
        {
            var activity = _StatisticsDbContext.TblActivityGroups.Where(x => x.ActGrpDesc == act.actGrpDesc).FirstOrDefault();

            if (activity == null)
            {
                var result = new TblActivityGroup { ActGrpDesc = act.actGrpDesc, ActGrpCode = act.actGrpCode };
                _StatisticsDbContext.Add<TblActivityGroup>(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion


        #region "Activities"
        public List<TblActivity> GetActivities(string user, bool isAdmin)
        {
            var result = new List<TblActivity>();

            if (! isAdmin)
            {
                result = (from b in _StatisticsDbContext.TblActivities
                          join c in _StatisticsDbContext.TblPermGrpUsrs on b.ActDesc equals c.PrmFuncId
                          where c.PrmUser == user && c.MinOfprmRead==1
                          select b).ToList();
            }
            else
                result= _StatisticsDbContext.TblActivities.OrderBy(x => x.ActDesc).ToList();

            return result;
        }

        public List<TblActivity> GetActivity(int id)
        {
            var result = new List<TblActivity>();

            if (id > 0)
                result = _StatisticsDbContext.TblActivities.OrderBy(x => x.ActDesc).Where(x => x.ActSeq == id).ToList();
            else
                result = _StatisticsDbContext.TblActivities.OrderBy(x => x.ActDesc).ToList();

            return result;
        }

        public bool UpdateActivity(Activities act)
        {
            var result = _StatisticsDbContext.TblActivities.Where(x => x.ActSeq == act.actSeq).FirstOrDefault();
            result.ActDesc = act.actDesc;
            result.ActSort = act.actSort;
            result.ActGrpId = act.actGrpId;

            if (result != null)
            {
                _StatisticsDbContext.TblActivities.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DelActivity(int id)
        {
            var result = _StatisticsDbContext.TblActivities.Where(x => x.ActSeq == id).FirstOrDefault();

            if (result != null)
            {
                _StatisticsDbContext.TblActivities.Remove(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool AddActivity(Activities act)
        {
            var activity = _StatisticsDbContext.TblActivities.Where(x => x.ActDesc == act.actDesc && x.ActGrpId == act.actGrpId).FirstOrDefault();

            if (activity == null)
            {
                var result = new TblActivity { ActDesc = act.actDesc, ActGrpId = act.actGrpId, ActCode = act.actCode, ActSort = act.actSort };
                _StatisticsDbContext.Add<TblActivity>(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion


        #region "SubActivity"
        public List<TblActivitySub> GetSubActivities()
        {
            var result = new List<TblActivitySub>();

            result = _StatisticsDbContext.TblActivitySubs.OrderBy(x => x.SacDesc).ToList();

            return result;
        }

        public bool UpdateActivitySub(ActivitySub act)
        {
            var result = _StatisticsDbContext.TblActivitySubs.Where(x => x.SacSeq == act.sacSeq).FirstOrDefault();
            result.SacDesc = act.sacDesc;
            result.SacSort = act.sacSort;
            result.SacCode = act.sacCode;
            result.ActId = act.actId;

            if (result != null)
            {
                _StatisticsDbContext.TblActivitySubs.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public result DeleteSubActivity(int subActId)
        {
            result result = new result();

            var subAct = _StatisticsDbContext.TblActivitySubs.Where(x => x.SacSeq == subActId).FirstOrDefault();

            if (subAct != null)
            {
                var task = _StatisticsDbContext.TblJobWorkFlows.Where(x => x.JwParentSubActivity == subActId).FirstOrDefault();

                if (task != null)
                {
                    result.done = false;
                    result.message = "This Sub-Activity has children, please assign it's childrens to another Sub-Activity before delete it.";
                }
                else
                {
                    _StatisticsDbContext.TblActivitySubs.Remove(subAct);
                    _StatisticsDbContext.SaveChanges();

                    result.done = true;
                    result.message = "Sub-Activity removed sucessfully";
                }
            }
            else
            { 
                result.done = false;
                result.message = "Sub-Activity not found";
            }

            return result;
        }

        public bool AddActivitySub(ActivitySub act)
        {
            var activity = _StatisticsDbContext.TblActivitySubs.Where(x => x.SacDesc == act.sacDesc && x.ActId == act.actId).FirstOrDefault();

            if (activity == null)
            {
                var result = new TblActivitySub { SacDesc = act.sacDesc, ActId = act.actId, SacCode = act.sacCode, SacSort = act.sacSort };
                _StatisticsDbContext.Add<TblActivitySub>(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public bool AddSubActivity(int ActivityId, string SubActivityDesc)
        {
            var activity = _StatisticsDbContext.TblActivitySubs.Where(x => x.SacDesc == SubActivityDesc && x.ActId == ActivityId).FirstOrDefault();

            if (activity == null)
            {
                var result = new TblActivitySub { SacDesc = SubActivityDesc, ActId = ActivityId };
                _StatisticsDbContext.Add<TblActivitySub>(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool UpdateSubActivity(int subActivityId, string subActivityDesc)
        {
            var result = _StatisticsDbContext.TblActivitySubs.Where(x => x.SacSeq == subActivityId).FirstOrDefault();
            result.SacDesc = subActivityDesc;

            if (result != null)
            {
                _StatisticsDbContext.TblActivitySubs.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion


        #region "ActivityTask"
        public List<TblActivityTask> GetTasks(int actId, int subActId)
        {
            var result = new List<TblActivityTask>();

            if (actId > 0)
            {
                result = (from b in _StatisticsDbContext.TblActivities
                          join c in _StatisticsDbContext.TblActivitySubs on b.ActSeq equals c.ActId
                          join t in _StatisticsDbContext.TblActivityTasks on c.SacSeq equals t.SubActId
                          where b.ActSeq == actId
                          select t).ToList();
            }
            else
            {
                if (subActId > 0)
                    result = _StatisticsDbContext.TblActivityTasks.OrderBy(x => x.TskDesc).Where(x => x.SubActId == subActId).ToList();
                else
                    result = _StatisticsDbContext.TblActivityTasks.OrderBy(x => x.TskDesc).ToList();
            }

            return result;
        }


        public bool UpdateTaskDesc(ActivityTask act)
        {
            var result = _StatisticsDbContext.TblActivityTasks.Where(x => x.TskSeq == act.tskSeq).FirstOrDefault();

            if (result != null)
            {
                result.TskDesc = act.tskDesc;
                _StatisticsDbContext.TblActivityTasks.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public bool UpdateTask(ActivityTask act)
        {
            var result = _StatisticsDbContext.TblActivityTasks.Where(x => x.TskSeq == act.tskSeq).FirstOrDefault();
            result.TskDesc = act.tskDesc;
            result.TskSort = act.tskSort;
            result.TskCode = act.tskCode;
            result.SubActId = act.subActId;

            if (result != null)
            {
                _StatisticsDbContext.TblActivityTasks.Update(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteTask(int id)
        {
            var result = _StatisticsDbContext.TblActivityTasks.Where(x => x.TskSeq == id).FirstOrDefault();

            if (result != null)
            {
                _StatisticsDbContext.TblActivityTasks.Remove(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool AddTask(ActivityTask act)
        {
            var activity = _StatisticsDbContext.TblActivityTasks.Where(x => x.TskDesc == act.tskDesc && x.SubActId == act.subActId).FirstOrDefault();

            if (activity == null)
            {
                var result = new TblActivityTask { TskDesc = act.tskDesc, SubActId = act.subActId, TskCode = act.tskCode, TskSort = act.tskSort };
                _StatisticsDbContext.Add<TblActivityTask>(result);
                _StatisticsDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion


    }
}
