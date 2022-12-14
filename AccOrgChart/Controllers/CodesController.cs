using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Controllers
{
    public class CodesController : Controller
    {
        private readonly ILogger<CodesController> _ilogger;
        private ICodesRepository _codesRepository;    

        public CodesController(ILogger<CodesController> ilogger, ICodesRepository codesRepository)
        {
            _ilogger = ilogger;
            _codesRepository = codesRepository;
        }

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

        public List<TblVerb> GetVerbsList()
        {
            try
            {
                return this._codesRepository.GetVerbsList();
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }
    }
}
