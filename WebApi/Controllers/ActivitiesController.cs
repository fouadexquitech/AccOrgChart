using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebApi.Repository.Interfaces;
using WebApi.Repository.Models.HR_StatisticsModels;
using WebApi.Repository.View_Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ILogger<ActivitiesController> _ilogger;
        private IActivitiesRepository _activitiesRepository;

        public ActivitiesController(ILogger<ActivitiesController> logger, IActivitiesRepository activitiesRepository)
        {
            _ilogger = logger;
            _activitiesRepository = activitiesRepository;
        }


        #region "ActivityGrp"
        [HttpGet("GetActivityGroup")]
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

        [HttpPost("UpdateActivityGroup")]
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

        [HttpPost("DelActivityGroup")]
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

        [HttpPost("AddActivityGroup")]
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
        [HttpGet("GetActivity")]
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

        [HttpPost("UpdateActivity")]
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

        [HttpPost("DelActivity")]
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

        [HttpPost("AddActivity")]
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


        #region "ActivitySub"
        [HttpGet("GetSubActivities")]
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

        [HttpPost("UpdateActivitySub")]
        public bool UpdateActivitySub(ActivitySub a)
        {
            try
            {
                return this._activitiesRepository.UpdateActivitySub(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        [HttpPost("DelActivitySub")]
        public bool DelActivitySub(int id)
        {
            try
            {
                return this._activitiesRepository.DelActivitySub(id);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        [HttpPost("AddActivitySub")]
        public bool AddActivitySub(ActivitySub a)
        {
            try
            {
                return this._activitiesRepository.AddActivitySub(a);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }
        #endregion


        #region "Task"
        [HttpGet("GetTasks")]
        public List<TblActivityTask> GetTasks(int subActId)
        {
            try
            {
                return this._activitiesRepository.GetTasks(subActId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        [HttpPost("UpdateTaskDesc")]
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

        [HttpPost("UpdateActivityTask")]
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

        [HttpPost("DeleteTask")]
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

        [HttpPost("AddTask")]
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
