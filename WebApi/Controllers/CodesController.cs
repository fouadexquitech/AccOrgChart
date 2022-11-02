using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApi.Repository.Interfaces;
using WebApi.Repository.Models.HR_StatisticsModels;
using WebApi.Repository.View_Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodesController : ControllerBase
    {
        private readonly ILogger<CodesController> _ilogger;
        private ICodesRepository _codesRepository;    

        public CodesController(ILogger<CodesController> ilogger, ICodesRepository codesRepository)
        {
            _ilogger = ilogger;
            _codesRepository = codesRepository;
        }


        [HttpGet("GetCodesByType")]
        public List<TblCode> GetCodesByType(int type)
        {
            try
            {
                return this._codesRepository.GetCodesByType(type);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
            
        }
    }
}
