using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using WebApi.Repository.Interfaces;
using WebApi.Repository.View_Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly ILogger<WorkFlowController> _ilogger;
        private IWorkFlowRepository _workFlowRepository;

        public WorkFlowController(ILogger<WorkFlowController> logger, IWorkFlowRepository workFlowRepository)
        {
            _ilogger = logger;
            _workFlowRepository = workFlowRepository;
        }

        [HttpGet("GetWorkFlowBySubActivity")]
        public List<WorkFlow> GetWorkFlowBySubActivity (int subActId)
        {
            try
            {
                return this._workFlowRepository.GetWorkFlowBySubActivity(subActId);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }

        [HttpPost("AddWorkFlow")]
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

        [HttpPost("UpdateWorkFlowParentId")]
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

        [HttpPost("UpdateWorkFlow")]
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

    }
}
