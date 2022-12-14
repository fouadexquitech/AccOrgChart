using System.Collections.Generic;
using WebApi.Repository.View_Models;

namespace WebApi.Repository.Interfaces
{
    public interface IWorkFlowRepository
    {
        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId);
        public bool AddWorkFlow(WorkFlow wf);
        public bool UpdateWorkFlowParentId(int wfId, int parentId);

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, int parentId);
    }
}
