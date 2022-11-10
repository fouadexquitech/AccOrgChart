﻿using System.Collections.Generic;
using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IWorkFlowRepository
    {
        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId);
        public bool AddWorkFlow(WorkFlow wf);
        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId);
        public bool UpdateWorkFlowParentId(int wfId, int parentId);

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName);

        public Node GetChartOrgSubActivity(int subActId);
        public Node GetChartOrgActivity(int actId);
    }
}
