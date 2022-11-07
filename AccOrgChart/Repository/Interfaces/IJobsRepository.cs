using AccOrgChart.Repository.Models.HR_StatisticsModels;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IJobsRepository
    {
        public List<TblRole> GetJobsList();
    }
}
