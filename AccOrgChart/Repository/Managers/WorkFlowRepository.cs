using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;
using System;


namespace AccOrgChart.Repository.Managers
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private readonly HR_StatisticsDbContext _dbContext;

        public WorkFlowRepository(HR_StatisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Node? GetChartOrg(int subActId)
        {
            return GetChartOrg(0, subActId);
        }

        public Node? GetChartOrgActivity(int actId)
        {
            return GetChartOrg( actId, 0);
        }
        public Node? GetChartOrg(int actId, int subActId)
        {
            var roles = _dbContext.TblRoles.ToList();

            var tasks = new List<TblActivityTask>();
            var workFlows= new List<VwJobWorkFlow>();

            if (actId > 0)
            {
                tasks = (from b in _dbContext.TblActivities
                         join c in _dbContext.TblActivitySubs on b.ActSeq equals c.ActId
                         join t in _dbContext.TblActivityTasks on c.SacSeq equals t.SubActId
                         where b.ActSeq == actId
                         select t).ToList();

                workFlows = (from b in _dbContext.VwJobWorkFlows
                             where b.ActivityId == actId
                             select b).ToList();
            }
            else
            {
                tasks = _dbContext.TblActivityTasks.Where(x => x.SubActId == subActId).ToList();
                workFlows = (from b in _dbContext.VwJobWorkFlows
                             where b.SubActivityId == subActId
                             select b).ToList();
            }

            var root = workFlows.Where(x => x.JwParentId == null).FirstOrDefault();

            Node? mainNode = null;
            if (root != null)
            {
                mainNode = new Node();
                mainNode.Id = root.JwId;
                mainNode.RoleId = root.RoleId;
                mainNode.TaskId = root.TaskId;
                var role = roles.Where(x => x.RoleId == root.RoleId).FirstOrDefault();
                var task = tasks.Where(x => x.TskSeq == root.TaskId).FirstOrDefault();
                if (role != null)
                {
                    mainNode.RoleName = role?.RoleDesc;
                    
                }
                if (task != null)
                {
                    mainNode.TaskName = task?.TskDesc;
                }
                GetChildrenNodes(mainNode, roles, tasks, workFlows);
            }
            return mainNode;
        }

        private void GetChildrenNodes(Node node, List<TblRole> roles, List<TblActivityTask> tasks, List<VwJobWorkFlow> workFlows)
        {
            var childWorkflows = workFlows.Where(x => x.JwParentId == node.Id).ToList();
            var childNodes = new List<Node>();
            if (childWorkflows != null)
            {
                foreach (var workflow in childWorkflows)
                {
                    var childNode = new Node();

                    childNode.Id = workflow.JwId;
                    childNode.RoleId = workflow.RoleId;
                    childNode.TaskId = workflow.TaskId;
                    var role = roles.Where(x => x.RoleId == workflow.RoleId).FirstOrDefault();
                    var task = tasks.Where(x => x.TskSeq == workflow.TaskId).FirstOrDefault();
                    if (role != null)
                    {
                        childNode.RoleName = role?.RoleDesc;
                    }
                    if (task != null)
                    {
                        childNode.TaskName = task?.TskDesc;
                    }


                    childNodes.Add(childNode);
                    node.Children = childNodes;
                    GetChildrenNodes(childNode, roles, tasks, workFlows);
                }
            }                   
        }


        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId)
        {
            var result =( from b in _dbContext.VwJobWorkFlows
                         where b.SubActivityId==subActId

                         select new WorkFlow
                         {
                             wfId = b.JwId,
                             wfSort=b.JwSort,
                             wfParentId=b.JwParentId,
                             RoleId = b.RoleId,
                             Role = b.Role,
                             TaskId=b.TaskId,
                             Task=b.Task
                         }).ToList();

            return result;
        }

        public bool AddWorkFlow(WorkFlow wf)
        {
            var result = _dbContext.TblJobWorkFlows.Where(x => x.JwTaskId == wf.TaskId && x.JwJobId == wf.RoleId).FirstOrDefault();

            if (result == null)
            {
                var newWf = new TblJobWorkFlow { JwTaskId = wf.TaskId, JwJobId = wf.RoleId, JwParentId = wf.wfParentId };
                _dbContext.Add<TblJobWorkFlow>(newWf);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool UpdateWorkFlowParentId(int wfId, int parentId)
        {
            var result = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();
            result.JwParentId = parentId;
            _dbContext.TblJobWorkFlows.Update(result);
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateWorkFlow(int wfId,int taskId,int roleId, bool updateTask, string newTaskName)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var result = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();
                result.JwJobId = roleId;
                result.JwTaskId = taskId;
                //result.JwParentId = parentId;
                _dbContext.TblJobWorkFlows.Update(result);
                _dbContext.SaveChanges();

                if (updateTask)
                {
                    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == taskId).FirstOrDefault();
                    task.TskDesc = newTaskName;
                    _dbContext.TblActivityTasks.Update(task);
                    _dbContext.SaveChanges();
                }

                t.Commit();
                return true;
            }
            catch (Exception ex)
            {
                t.Rollback();
                return false;
            }
        }

    }
}
