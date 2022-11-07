using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccOrgChart.Controllers
{
    public class JobsController : Controller
    {
        private readonly ILogger<ActivitiesController> _ilogger;
        private IJobsRepository _jobsRepository;

        public JobsController(ILogger<ActivitiesController> logger, IJobsRepository jobsRepository)
        {
            _ilogger = logger;
            _jobsRepository = jobsRepository;
        }


        public List<TblRole> GetJobsList()
        {
            try
            {
                return this._jobsRepository.GetJobsList();
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                return null;
            }
        }


    }
}
