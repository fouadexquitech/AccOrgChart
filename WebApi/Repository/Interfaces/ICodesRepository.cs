using System.Collections.Generic;
using WebApi.Repository.Models.HR_StatisticsModels;
using WebApi.Repository.View_Models;

namespace WebApi.Repository.Interfaces
{
    public interface ICodesRepository
    {
        public List<TblCode> GetCodesByType(int type);
    }
}
