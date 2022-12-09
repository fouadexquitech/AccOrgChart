using System.Collections.Generic;
using System.Linq;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Managers
{
    public class CodesRepository:ICodesRepository
    {
        private readonly HR_StatisticsDbContext _StatisticsDbContext;

        public CodesRepository(HR_StatisticsDbContext context)
        {
            _StatisticsDbContext = context;
        }

        public List<TblCode> GetCodesByType(int type)
        {
            var result = new List<TblCode>();
            //var result=(from b in _StatisticsDbContext.TblCodes
            //            where b.CodType == type
            //            select b).ToList();
            result = _StatisticsDbContext.TblCodes.OrderBy(x => x.CodDesc).Where(x => x.CodType == type).ToList();

            return result;

        }

        public List<TblVerb> GetVerbsList()
        {
            return _StatisticsDbContext.TblVerbs.OrderBy(x => x.VerbDesc).ToList(); 
        }
    }
}
