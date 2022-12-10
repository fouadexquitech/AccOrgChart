using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AccOrgChart.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ILogger<ActivitiesController> _ilogger;
        private IActivitiesRepository _activitiesRepository;

        public ActivitiesController(ILogger<ActivitiesController> logger, IActivitiesRepository activitiesRepository)
        {
            _ilogger = logger;
            _activitiesRepository = activitiesRepository;
        }


        #region "ActivityGrp"
        public List<TblActivityGroup> GetActivityGroup(int ActGrpId)
        {
            try
            {
                return this._activitiesRepository.GetActivityGroup(ActGrpId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public bool UpdateActivityGroup(ActivityGroup activity)
        {
            try
            {
                return this._activitiesRepository.UpdateActivityGroup(activity);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool DelActivityGroup(int id)
        {
            try
            {
                return this._activitiesRepository.DelActivityGroup(id);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool AddActivityGroup(ActivityGroup a)
        {
            try
            {
                return this._activitiesRepository.AddActivityGroup(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }
        #endregion


        #region "Activity"
        public List<TblActivity> GetActivities(string user, bool isAdmin)
        {
            isAdmin = true;
            try
            {
                return this._activitiesRepository.GetActivities(  user, isAdmin);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public List<TblActivity> GetActivity(int id)
        {
            try
            {
                return this._activitiesRepository.GetActivity(id);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public bool UpdateActivity(Activities a)
        {
            try
            {
                return this._activitiesRepository.UpdateActivity(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool DelActivity(int id)
        {
            try
            {
                return this._activitiesRepository.DelActivity(id);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool AddActivity(Activities a)
        {
            try
            {
                return this._activitiesRepository.AddActivity(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }
        #endregion


        #region "SubActivity"
        public List<TblActivitySub> GetSubActivities()
        {
            try
            {
                return this._activitiesRepository.GetSubActivities();
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        //public bool UpdateActivitySub(ActivitySub a)
        //{
        //    try
        //    {
        //        return this._activitiesRepository.UpdateActivitySub(a);
        //    }
        //    catch (Exception ex)
        //    {
        //        _ilogger.LogError(ex.Message);
        //        return false;
        //    }
        //}

        public result DeleteSubActivity(int subActId)
        {
            try
            {
                return this._activitiesRepository.DeleteSubActivity(subActId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                result res = new result();
                res.done = false;
                res.message = ex.Message;
                return res;
            }
        }

        public bool AddSubActivity(int ActivityId,string SubActivityDesc, string proposedUser)
        {
            try
            {
                return this._activitiesRepository.AddSubActivity(ActivityId, SubActivityDesc,  proposedUser);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool UpdateSubActivity(int subActivityId, string newSubActDesc, string proposedUser)
        {
            try
            {
                return this._activitiesRepository.UpdateSubActivity(subActivityId, newSubActDesc,proposedUser);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }
        #endregion


        #region "Task"
        public List<TblActivityTask> GetTasks(int actId, int subActId)
        {
            try
            {
                return this._activitiesRepository.GetTasks( actId, subActId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public bool UpdateTaskDesc(ActivityTask a)
        {
            try
            {
                return this._activitiesRepository.UpdateTaskDesc(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool UpdateActivityTask(ActivityTask a)
        {
            try
            {
                return this._activitiesRepository.UpdateTask(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool DeleteTask(int id)
        {
            try
            {
                return this._activitiesRepository.DeleteTask(id);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool AddTask(ActivityTask a)
        {
            try
            {
                return this._activitiesRepository.AddTask(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
