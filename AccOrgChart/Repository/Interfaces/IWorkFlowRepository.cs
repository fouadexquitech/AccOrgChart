using System.Collections.Generic;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IWorkFlowRepository
    {
        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId);

        public bool AddWorkFlow(int parentID, int TaskId, int RoleId, bool updateTask, string newTaskName,int verbId, string proposedUser);
        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId, bool updateTask, string newTaskName, int verbId, string proposedUser);

        public bool UpdateWorkFlowParentId(int wfId, int parentId,int type);

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName, int verbId,int proposedRoleId, int proposedVerbId, string proposedTaskName, string proposedUser);

        public Node GetChartOrgSubActivity(int subActId);
        public Node GetChartOrgActivity(int actId);

        public bool DeleteWorkFlow(int wfId);


    }
}
