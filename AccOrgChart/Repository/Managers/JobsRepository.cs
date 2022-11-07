using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;

namespace AccOrgChart.Repository.Managers
{
    public class JobsRepository:IJobsRepository
    {
        private readonly HR_StatisticsDbContext _dbContext;

        public JobsRepository(HR_StatisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TblRole> GetJobsList()
        {
            return  _dbContext.TblRoles.OrderBy(x => x.RoleDesc).ToList();
        }
    }
}
