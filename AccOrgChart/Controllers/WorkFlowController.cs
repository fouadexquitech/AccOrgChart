using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.View_Models;
using System.Threading.Tasks;

namespace AccOrgChart.Controllers
{
    public class WorkFlowController : Controller
    {
        private readonly ILogger<WorkFlowController> _ilogger;
        private IWorkFlowRepository _workFlowRepository;

        public WorkFlowController(ILogger<WorkFlowController> logger, IWorkFlowRepository workFlowRepository)
        {
            _ilogger = logger;
            _workFlowRepository = workFlowRepository;
        }

        public IActionResult GetWorkFlowBySubActivity (int subActId)
        {
            try
            {
                return Ok(this._workFlowRepository.GetWorkFlowBySubActivity(subActId));
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public bool AddWorkFlow(int parentId, int RoleId, int verbId, int TaskId, string newTaskName , string proposedUser, int wfAddMode)
        {
            try
            {
                return this._workFlowRepository.AddWorkFlow(parentId,  RoleId,  verbId,  TaskId,  newTaskName,  proposedUser,  wfAddMode);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId, bool updateTask, string newTaskName, int verbId, string proposedUser)
        {
            try
            {
                return this._workFlowRepository.AddWorkflowToSubActivity(SubActivityId,  TaskId,  RoleId, updateTask, newTaskName,verbId, proposedUser);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool UpdateWorkFlowParentId(int wfId, int parentId,int type)
        {
            try
            {
                return this._workFlowRepository.UpdateWorkFlowParentId(wfId,parentId, type);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName,int verbId, int proposedRoleId, int proposedVerbId, string proposedTaskName, string proposedUser)
        {
            try
            {
                return this._workFlowRepository.UpdateWorkFlow(wfId,taskId,roleId, updateTask, newTaskName, verbId,  proposedRoleId,  proposedVerbId,  proposedTaskName,  proposedUser);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public IActionResult GetChartOrgSubActivity(int subActId)
        {
            try
            {
                return Ok(this._workFlowRepository.GetChartOrgSubActivity(  subActId));
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }


        public IActionResult GetChartOrgActivity(int actId)
        {
            try
            {
                return Ok(this._workFlowRepository.GetChartOrgActivity(actId));
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        public bool DeleteWorkFlow(int wfId)
        {
            try
            {
                return this._workFlowRepository.DeleteWorkFlow(wfId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

    }
}
