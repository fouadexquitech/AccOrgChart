using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccOrgChart.Repository.View_Models;
using AccOrgChart.Repository.Interfaces;

namespace AccOrgChart.Controllers
{
    public class LogonController : ControllerBase
    {
        private readonly ILogger<LogonController> _logger;
        private IlogonRepository _logonRepository;

        public LogonController(ILogger<LogonController> logger, IlogonRepository logonRepository)
        {
            _logger = logger;
            _logonRepository = logonRepository;
        }


        public User GetLogin(string user, string pass)
        {
            try
            {
                return this._logonRepository.GetLogin(user, pass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public User GetUser(string user)
        {
            try
            {
                return this._logonRepository.GetUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


    }
}
