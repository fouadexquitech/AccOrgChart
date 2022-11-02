using System.Collections.Generic;
using System.Linq;
using WebApi.Repository.Interfaces;
using WebApi.Repository.Models.HR_StatisticsModels;
using WebApi.Repository.View_Models;

namespace WebApi.Repository.Managers
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
    }
}
