using System.Collections.Generic;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IWorkFlowRepository
    {
        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId);
        public bool AddWorkFlow(WorkFlow wf);
        public bool UpdateWorkFlowParentId(int wfId, int parentId);

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, int parentId);

        public Node GetChartOrg(int subActId);
    }
}
