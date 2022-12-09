using System.Collections.Generic;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface ICodesRepository
    {
        public List<TblCode> GetCodesByType(int type);

        public List<TblVerb> GetVerbsList();
    }
}
