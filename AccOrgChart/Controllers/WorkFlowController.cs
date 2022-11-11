using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.View_Models;

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

        public bool AddWorkFlow(WorkFlow wf)
        {
            try
            {
                return this._workFlowRepository.AddWorkFlow(wf);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }


        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId, bool updateTask, string newTaskName)
        {
            try
            {
                return this._workFlowRepository.AddWorkflowToSubActivity(SubActivityId,  TaskId,  RoleId, updateTask, newTaskName);
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

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName)
        {
            try
            {
                return this._workFlowRepository.UpdateWorkFlow(wfId,taskId,roleId, updateTask, newTaskName);
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

    }
}
