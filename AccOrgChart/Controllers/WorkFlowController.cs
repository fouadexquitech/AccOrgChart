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

        public bool UpdateWorkFlowParentId(int wfId, int parentId)
        {
            try
            {
                return this._workFlowRepository.UpdateWorkFlowParentId(wfId,parentId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, int parentId)
        {
            try
            {
                return this._workFlowRepository.UpdateWorkFlow(wfId,taskId,roleId,parentId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return false;
            }
        }

        public IActionResult GetChartOrg(int subActId)
        {
            try
            {
                return Ok(this._workFlowRepository.GetChartOrg(subActId));
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

    }
}
